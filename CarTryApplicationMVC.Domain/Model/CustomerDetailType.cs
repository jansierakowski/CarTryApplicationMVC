namespace CarTryApplicationMVC.Domain.Model
{
    public class CustomerDetailType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual int CustomerDetailId { get; set; }
        public virtual CustomerDetail CustomerDetail { get; set; }
    }
}