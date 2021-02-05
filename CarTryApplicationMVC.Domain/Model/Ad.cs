using System;
using System.Collections.Generic;
using System.Text;

namespace CarTryApplicationMVC.Domain.Model
{
    public class Ad
    {
        public int Id { get; set; }
        public virtual Car Car { get; set; }
        public virtual ICollection<AdTag> AdTags { get; set; }
        public virtual AdType AdType { get; set; }

    }
}
