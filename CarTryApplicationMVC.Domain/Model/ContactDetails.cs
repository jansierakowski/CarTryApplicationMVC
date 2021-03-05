namespace CarTryApplicationMVC.Domain.Model
{
    public class ContactDetail
    {
        public int Id { get; set; }
        public string ContactDetailInformation { get; set; }
        public int ContactDetailTypeId { get; set; }
        public virtual ContactDetailType ContactDetailType { get; set; }
        public int ContactId { get; set; }
        public virtual Contact Contact { get; set; }
    }
}