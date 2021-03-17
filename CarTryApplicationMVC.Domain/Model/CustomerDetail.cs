using System.Collections.Generic;

namespace CarTryApplicationMVC.Domain.Model
{
    public class CustomerDetail
    {
        public int Id { get; set; }
        public string CustomerDetailInformation { get; set; }
        public ICollection<CustomerDetailType> CustomerDetailTypes { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}