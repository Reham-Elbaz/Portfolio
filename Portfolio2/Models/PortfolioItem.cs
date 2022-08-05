using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Models
{
    public class PortfolioItem
    {
        public int Id { get; set; }
        public string project_name { get; set; }
        public string description { get; set; }
        public string image { get; set; }

        [ForeignKey("Owner")]
        public int OwnerId { get; set; }

        public Owner Owner { get; set; }
    }
}
