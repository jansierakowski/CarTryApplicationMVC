using System;
using System.Collections.Generic;
using System.Text;

namespace CarTryApplicationMVC.Domain.Model
{
    public class CarSpecification
    {
        public int Id { get; set; }
        public int CarModelId { get; set; }
        public int CarBrandId { get; set; }
        public string CarModelName { get; set; }
        public string CarBrandName { get; set; }
        public string Generation { get; set; }
        public string FuelType { get; set; }
        public string DriveTrain { get; set; }
        public string Equipment { get; set; }
        public int OdometerValue { get; set; }
        public int NumberOfCylinders { get; set; }
        public int ProductionYear { get; set; }
        public virtual ICollection<Ad> Ads { get; set; }
        public virtual ICollection<CarFeedback> CarFeedbacks { get; set; }
        


    }
}
