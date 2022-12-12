using System.Text.Json;
using Tempa.Shared;

namespace Tempa.Client.Repositories
{
    public class ArticleRepo
    {
        string url = "/api/articles";
        
        public async Task<List<ArticleModel>> GetArticleList(){
            
            var client = new HttpClient();
            var response = await client.GetAsync(url);
            var json = await response.Content.ReadAsStringAsync();
            var articles = JsonSerializer.Deserialize<List<ArticleModel>>(json);
            return articles ?? new List<ArticleModel>();
        }
    }
}
