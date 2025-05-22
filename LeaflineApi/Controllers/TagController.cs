using LeaflineApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LeaflineApi.Controllers
{

  [ApiController]
  [Route("Tags")]
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
    public async Task<List<LeaflineTag>> ListTags() {
      var tags = await _context.tags.ToListAsync();
      return tags;
    }


  }
}
