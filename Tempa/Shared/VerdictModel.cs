using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tempa.Shared
{
    public class VerdictModel
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int UserID { get; set; }

        [Required]
        public DateTime Created { get; set; }

        [Required]
        public string Content { get; set; }

        public int Votes { get; set; }
    }
}
