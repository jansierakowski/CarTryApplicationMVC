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
        public virtual int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Car Car { get; set; }
        public virtual ICollection<AdTag> AdTags { get; set; }


    }
}
