using LeaflineApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using BCrypt.Net;

namespace LeaflineApi.Controllers
{
  [ApiController]
  [Route("User")]
  public class UserController : ControllerBase
  {

    private readonly ILogger<UserController> _logger;
    private readonly ApiContext _context;

    public UserController(ILogger<UserController> logger, ApiContext context)
    {
      _logger = logger;
      _context = context;
    }

    [HttpGet]
    [Route("ListAll")]
    public async Task<LeaflineResponse> GetUsers()
    {
      LeaflineResponse result = new LeaflineResponse();

      try
      {
        var response = await _context.users.ToListAsync();
        result.Message = "Users retrieved successfully.";
        result.Content = JsonSerializer.Serialize(response);
        result.isSuccess = true;
      }
      catch (Exception)
      {
        result.Message = "An internal error occurred while processing your request.";
        result.isSuccess = false;
      }
      return result;
    }

    [HttpPost]
    [Route("Create")]
    public async Task<LeaflineResponse> CreateUser(LeaflineUser user)
    {

      LeaflineResponse result = new LeaflineResponse();

      if (user.Email != "")
      {
        if (user.PasswordHash != "")
        {
          string realHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);
          user.PasswordHash = realHash;
          user.UserId = Guid.NewGuid();

          try {
            var existing = await _context.users.FirstOrDefaultAsync(x => x.Email == user.Email);
            if(existing == null) {
              await _context.users.AddAsync(user);
              await _context.SaveChangesAsync();

              result.Message = "User created successfully.";
              result.isSuccess = true;
              result.Content = JsonSerializer.Serialize(user);
            }
          }catch(Exception) {
            result.Message = "An internal error occurred while processing your request.";
            result.isSuccess = false;
          }

        }
        else
        {
          result.isSuccess = false;
          result.Message = "A password is required to use Leafline!";
        }
      }else {
        result.isSuccess = false;
        result.Message = "Email address is not valid!";
      }


        return result;
    }

    [HttpPost]
    [Route("Login")]
    public async Task<LeaflineResponse> LoginUser(LeaflineUser user)
    {
      LeaflineResponse result = new LeaflineResponse();
      try
      {
        var existing = await _context.users.FirstOrDefaultAsync(x => x.Email == user.Email);
        if (existing != null)
        {
          if (BCrypt.Net.BCrypt.Verify(user.PasswordHash, existing.PasswordHash))
          {
            result.Message = "Login successful.";
            result.Content = JsonSerializer.Serialize(existing);
            result.isSuccess = true;
          }
          else
          {
            result.Message = "Invalid password.";
            result.isSuccess = false;
          }
        }
        else
        {
          result.Message = "User not found.";
          result.isSuccess = false;
        }
      }
      catch (Exception)
      {
        result.Message = "An internal error occurred while processing your request.";
        result.isSuccess = false;
      }
      return result;
    }

  }
}
