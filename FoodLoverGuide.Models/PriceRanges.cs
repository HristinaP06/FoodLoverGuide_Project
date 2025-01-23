using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodLoverGuide.Models
{
    public class PriceRanges
    {
        public Guid Id { get; set; }
        public double FromPrice { get; set; }
        public double ToPrice { get; set; }
    }
}
