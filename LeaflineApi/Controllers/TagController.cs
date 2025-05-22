using LeaflineApi.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace LeaflineApi.Controllers
{

  [ApiController]
  [Route("Tags")]
  [Authorize]
  public class TagController : ControllerBase
  {

    private readonly ILogger<TagController> _logger;
    private readonly ApiContext _context;

    public TagController(ILogger<TagController> logger, ApiContext context)
    {
      _logger = logger;
      _context = context;
    }

    [HttpGet]
    public async Task<List<LeaflineTag>> ListTags()
    {
      var tags = await _context.tags.ToListAsync();
      return tags;
    }

    [HttpPost]
    [Route("/Tags/CreateTag")]
    public async Task<LeaflineResponse> CreateTag(string tag)
    {
      LeaflineResponse response = new LeaflineResponse();
      var existingTag = await _context.tags.FirstOrDefaultAsync(t => t.Tag.ToLower().Equals(tag));
      if(existingTag == null) {
        var newTag = new LeaflineTag
        {
          TagId = Guid.NewGuid(),
          Tag = tag
        };

        var result = await _context.tags.AddAsync(newTag);
        await _context.SaveChangesAsync();

        response.isSuccess = true;
        response.Message = "Tag created successfully!";
        response.Content = JsonSerializer.Serialize(result);
      }else {
        response.isSuccess = false;
        response.Message = "Tag already exists!";
        response.Content = null;
      }


      return response;
    }

  }
}
