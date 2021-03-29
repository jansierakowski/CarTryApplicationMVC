using System;
using System.Collections.Generic;
using System.Text;

namespace CarTryApplicationMVC.Domain.Model
{
    public class CarModel
    {
        public int Id { get; set; }
        public virtual int CarBrandId { get; set; }
        public string Model { get; set; }
        public virtual CarBrand CarBrand { get; set; }
    }
}
