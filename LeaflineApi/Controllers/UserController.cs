using LeaflineApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using BCrypt.Net;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;

namespace LeaflineApi.Controllers
{
  [ApiController]
  [Route("User")]
  public class UserController : ControllerBase
  {

    private readonly ILogger<UserController> _logger;
    private readonly ApiContext _context;
    private readonly IConfiguration _configuration;

    public UserController(ILogger<UserController> logger, ApiContext context, IConfiguration configuration)
    {
      _logger = logger;
      _context = context;
      _configuration = configuration;
    }

    [HttpGet]
    [Route("ListAll/{page}/{count}")]
    [Authorize]
    public async Task<LeaflineResponse> GetUsers(string query, int page, int count)
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
    [Authorize]
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
    public async Task<LeaflineResponse> LoginUser(string email, string password)
    {
      LeaflineResponse result = new LeaflineResponse();
      try
      {
        var existing = await _context.users.FirstOrDefaultAsync(x => x.Email == email);
        if (existing != null)
        {
          if (BCrypt.Net.BCrypt.Verify(password, existing.PasswordHash))
          {
            result.Message = "Login successful.";

            var jwtSettings = _configuration.GetSection("Jwt");
            var key = Encoding.ASCII.GetBytes(jwtSettings["Key"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
              Subject = new ClaimsIdentity(new[]
              {
                new Claim(ClaimTypes.Name, existing.UserId.ToString())
              }),
              Expires = DateTime.UtcNow.AddHours(1),
              Issuer = jwtSettings["Issuer"],
              Audience = jwtSettings["Audience"],
              SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);


            result.Content = JsonSerializer.Serialize(tokenHandler.WriteToken(token));
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
