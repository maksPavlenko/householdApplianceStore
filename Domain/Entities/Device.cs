using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    //public т.к. модель предметной области находится в другом проекте 
    public class Device
    {
        public int DeviceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
    }
}
