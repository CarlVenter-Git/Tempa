using HtmlAgilityPack;
using Tempa.Shared;

namespace Tempa.Server.Data.Repositories.Scraping
{
    public static class DailyMaverickArticleScraper
    {
        const string DailyMaverickUrl = "https://www.dailymaverick.co.za/section/south-africa/";
        public static async Task<List<ArticleModel>> ScrapeDailyMaverickAsync()
        {
            List<ArticleModel> articleList = new();

            HttpClient client = new();
            var scrapedData = await client.GetStringAsync(DailyMaverickUrl);

            HtmlDocument htmlDoc = new();
            htmlDoc.LoadHtml(scrapedData);

            //Get all div elements with a class of 'media-item' and return the nodes as a list
            var articleHtml = htmlDoc.DocumentNode.Descendants("div")
                .Where(node => node.GetAttributeValue("class", "")
                .Equals("media-item")).ToList();

            foreach (var articleNode in articleHtml)
            {
                try
                {
                    articleList.Add(new ArticleModel()
                    {
                        ArticleSource = articleNode.Descendants("a").First().Attributes["href"].Value,
                        Title = articleNode.Descendants("h1").First().InnerText,
                        Author = articleNode.Descendants("h6").First().InnerText,
                        ScrapedID = articleNode.Attributes["data-object-id"].Value,
                        //ThumbnailSource = articleNode.Element("media-left").Attributes["style"].Value
                        //Author = a.SelectNodes("").First().Attributes[""].Value
                    });

                    var source = articleNode.Descendants("div").Where(node => node.GetAttributeValue("class", "").Equals("media-left"));
                }
                catch (NullReferenceException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            return articleList;
        }
    }
}
