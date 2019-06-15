using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestA8.Models
{
    public class Order
    {
        public Pizza Pizza { get; set; }
        public DateTime OrderTime { get; set; }
        public DateTime PickupTime { get; set; }
        public bool Paid { get; set; }
        public bool Pickedup { get; set; }
    }
}
