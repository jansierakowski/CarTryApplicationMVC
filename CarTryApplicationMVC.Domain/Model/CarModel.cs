using System;
using System.Collections.Generic;
using System.Text;

namespace CarTryApplicationMVC.Domain.Model
{
    public class CarModel
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int CarId { get; set; }
        public virtual Car Car { get; set; }

        
    }
}
