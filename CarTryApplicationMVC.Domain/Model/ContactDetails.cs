namespace CarTryApplicationMVC.Domain.Model
{
    public class ContactDetail
    {
        public int Id { get; set; }
        public string ContactDetailInformation { get; set; }

        public virtual ContactDetailType ContactDetailType { get; set; }
        public virtual Contact Contact { get; set; }
    }
}