using System;
using System.Collections.Generic;
using System.Text;

namespace CarTryApplicationMVC.Domain.Model
{
    public class AdTag
    {
        public int AdId { get; set; }
        public int TagId { get; set; }
        public virtual Ad Ad { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
