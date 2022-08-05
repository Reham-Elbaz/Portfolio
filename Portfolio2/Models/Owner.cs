using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Models
{
    public class Owner
    {
        public int Id { get; set; }
        public string full_name { get; set; }
        public string profile { get; set; }
        public string avatar { get; set; }
        public string address { get; set; }

        public List<PortfolioItem> PortfolioItems { get; set; }
    }
}
