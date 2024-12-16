using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorStock.Shared.Models
{
    public class Portfolio
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TotalValue { get; set; }

        public int UserID { get; set; }
        public User user { get; set; }

        public List<Holding> ?Holdings { get; set; }

        public Portfolio() { }
    }
}
