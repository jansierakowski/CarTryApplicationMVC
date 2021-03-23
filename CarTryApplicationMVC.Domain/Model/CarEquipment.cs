namespace CarTryApplicationMVC.Domain.Model
{
    public class CarEquipment
    {
        public int Id { get; set; }
        public string Equipment { get; set; }
        public int AdId { get; set; }
        public virtual Ad Ad { get; set; }

    }
}