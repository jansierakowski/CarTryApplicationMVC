using System;
using System.Collections.Generic;
using System.Text;

namespace CarTryApplicationMVC.Domain.Model
{
    public class CarTypeBody
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Car> Cars { get; set; }

    }
}
