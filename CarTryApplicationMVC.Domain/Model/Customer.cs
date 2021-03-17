using System;
using System.Collections.Generic;
using System.Text;

namespace CarTryApplicationMVC.Domain.Model
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Ad> Ads { get; set; }
        public virtual ICollection<CustomerDetail> CustomerDetails { get; set; }
        public virtual ICollection<CustomerFeedback> CustomerFeedbacks { get; set; }

    }
}
