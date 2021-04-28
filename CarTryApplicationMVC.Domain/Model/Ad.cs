using System;
using System.Collections.Generic;
using System.Text;

namespace CarTryApplicationMVC.Domain.Model
{
    public class Ad
    {

        public int Id { get; set; }
        public virtual int CarSpecificationId { get; set; }
        public virtual string ApplicationUserId { get; set; }
        public bool IsActive { get; set; }
        public string AdName { get; set; }
        public string AdDescription { get; set; }
        public int AdPrice { get; set; }
        public string AdPromotion { get; set; }


        public string AdLocation { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual CarSpecification CarSpecification { get; set; }
        public virtual ICollection<AdTag> AdTags { get; set; }


    }
}
