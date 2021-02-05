using System;
using System.Collections.Generic;
using System.Text;

namespace CarTryApplicationMVC.Domain.Model
{
    public class Car
    {
        public int Id { get; set; }
        public string CarGeneration { get; set; }
        public int CarProductionYear { get; set; }
        public string CarBrand { get; set; }
        public string CarModel { get; set; }
        public string CarLocation { get; set; }
        public string FuelType { get; set; }
        public string DriveTrain { get; set; }
        public int NumberOfCylinders { get; set; }

        public virtual ICollection<Ad> Ads { get; set; }
        public virtual ICollection<CarFeedback> CarFeedbacks { get; set; }
        public virtual ICollection<CarEquipment> CarEquipments { get; set; }
        public virtual Contact Contact { get; set; }
        public virtual CarTypeBody CarTypeBody { get; set; }

    }
}
