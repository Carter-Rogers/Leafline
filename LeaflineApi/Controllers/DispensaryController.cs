using LeaflineApi.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace LeaflineApi.Controllers
{
  [ApiController]
  [Route("Dispensaries")]
  [Authorize]
  public class DispensaryController : ControllerBase
  {

    private readonly ILogger<DispensaryController> _logger;
    private readonly ApiContext _context;

    public DispensaryController(ILogger<DispensaryController> logger, ApiContext context)
    {
      _logger = logger;
      _context = context;
    }

    [HttpGet]
    public async Task<List<string>> GetDispensaries()
    {
      var dispensaries = await _context.dispensaries.ToListAsync();
      var dispensaryIDS = new List<string>();
      foreach (LeaflineDispensary dispo in dispensaries)
      {
        dispensaryIDS.Add(dispo.DispensaryId.ToString());
      }

      return dispensaryIDS;
    }

    [HttpGet]
    [Route("/Dispensary/{UniqueId}")]
    public async Task<LeaflineDispensary> GetDispensary(string UniqueId)
    {
      var dispensary = await _context.dispensaries.FirstOrDefaultAsync(d => d.DispensaryId.ToString() == UniqueId);

      if (dispensary == null)
      {
        return new LeaflineDispensary
        {
          Name = "Failed to find"
        };
      }

      return dispensary;
    }

    [HttpPost]
    [Route("/Dispensaries")]
    public async Task<List<LeaflineDispensary>> GetDispensaries(LeaflineQuery query, int page, int count) 
    {
      var queryResult = await _context.dispensaries.Where(d => d.Name.Contains(query.Name) || d.DispensaryId.ToString() == query.UniqueId || d.OwnerId.ToString() == query.OwnerId).ToListAsync();
      queryResult = queryResult.Skip(page * count).Take(count).ToList();
      return queryResult;
    }


    [HttpPost]
    [Route("/Dispensary/create")]
    public async Task<LeaflineResponse> CreateDispensary(LeaflineDispensary dispensary)
    {
      LeaflineResponse result = new LeaflineResponse();

      try
      {
        dispensary.DispensaryId = Guid.NewGuid();
        dispensary.CreatedAt = DateOnly.Parse(DateTime.UtcNow.ToString("yyyy-MM-dd"));
        dispensary.ModifiedOn = dispensary.CreatedAt;
        dispensary.JoinDate = dispensary.CreatedAt;

        await _context.dispensaries.AddAsync(dispensary);
        await _context.SaveChangesAsync();

        result.isSuccess = true;
        result.Message = "Dispensary created successfully.";
        result.Content = JsonSerializer.Serialize(dispensary);
      }
      catch (Exception e)
      {
        result.Message = "An internal error occurred while processing your request.";
        result.isSuccess = false;
        result.Content = e.Message;
      }

      return result;
    }

    [HttpDelete]
    [Route("/Dispensary/delete")]
    public async Task<LeaflineResponse> DeleteDispensary(LeaflineDeleteRequest request)
    {
      LeaflineResponse result = new LeaflineResponse();
      var dispensary = await _context.dispensaries.FirstOrDefaultAsync(d => d.DispensaryId.ToString() == request.ResourceUniqueId);
      if (dispensary != null)
      {
        if (dispensary.OwnerId.ToString() == request.RequesterId)
        {
          _context.dispensaries.Remove(dispensary);
          await _context.SaveChangesAsync();

          result.Message = "Dispensary deleted successfully.";
          result.isSuccess = true;
          result.Content = null;
        }else 
        {
          result.Message = "You do not have permissions to perform the requested action!";
          result.isSuccess = false;
          result.Content = null;
        }
      }else 
      {
        result.Message = "Requested resource was not found on the server!";
        result.isSuccess = false;
        result.Content = null;
      }
      return result;
    }

  }
}