using System;
using System.Collections.Generic;
using System.Text;

namespace CarTryApplicationMVC.Domain.Model
{
    public class Ad
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public bool IsActive { get; set; }
        public string AdName { get; set; }
        public string AdDescription { get; set; }
        public int AdPrice { get; set; }
        public string AdPromotion { get; set; }

        public string CarFuelType { get; set; }
        public string CarDriveTrain { get; set; }
        public int CarOdometerValue { get; set; }
        public int CarNumberOfCylinders { get; set; }
        public int CarProductionYear { get; set; }
        public string CarLocation { get; set; }
        public virtual int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Car Car { get; set; }
        public virtual ICollection<AdTag> AdTags { get; set; }
        public virtual ICollection<CarEquipment> CarEquipments { get; set; }


    }
}
