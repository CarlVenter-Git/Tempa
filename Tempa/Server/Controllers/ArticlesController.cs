using Microsoft.AspNetCore.Mvc;
using Tempa.Server.Data.Repositories.Scraping;
using Tempa.Shared;

namespace Tempa.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        // GET: api/<ArticlesController>
        [HttpGet]
        public async Task<IEnumerable<ArticleModel>> Get()
        {
            return await DailyMaverickArticleScraper.ScrapeDailyMaverickAsync();
        }

        // GET api/<ArticlesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
    }
}
