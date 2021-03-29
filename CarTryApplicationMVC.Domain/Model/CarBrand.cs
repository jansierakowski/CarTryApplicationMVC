using System;
using System.Collections.Generic;
using System.Text;

namespace CarTryApplicationMVC.Domain.Model
{
    public class CarBrand
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public ICollection<CarModel> CarModels { get; set; }
    }
}
