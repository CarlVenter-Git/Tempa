using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tempa.Shared
{
    public class ArticleModel
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string ScrapedID { get; set; } //Use this to distinguish articles on a scraped website

        [Required]
        public string ArticleSource { get; set; }

        [Required]
        public string ThumbnailSource { get; set; }

        [Required]
        public string BannerSource { get; set; }

        [Required]
        public DateTime DatePublished { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string ArticleContent { get; set; }

        public List<VerdictModel> Verdicts { get; set; }
    }
}
