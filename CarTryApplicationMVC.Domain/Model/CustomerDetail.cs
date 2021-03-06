namespace CarTryApplicationMVC.Domain.Model
{
    public class CustomerDetail
    {
        public int Id { get; set; }
        public string CustomerDetailInformation { get; set; }
        public int CustomerDetailTypeId { get; set; }
        public int CustomerId { get; set; }
        public virtual CustomerDetailType CustomerDetailType { get; set; }
        public virtual Customer Customer { get; set; }
    }
}