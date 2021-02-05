using System;
using System.Collections.Generic;
using System.Text;

namespace CarTryApplicationMVC.Domain.Model
{
    public class AdType
    {
        public int Id { get; set; }
        public string AdvertisementType{ get; set; }
        public virtual ICollection<Ad> CarAds { get; set; }
    }
}
