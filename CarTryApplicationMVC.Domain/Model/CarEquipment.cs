namespace CarTryApplicationMVC.Domain.Model
{
    public class CarEquipment
    {
        public int Id { get; set; }
        public string Equipment { get; set; }
        public int CarId { get; set; }
        public virtual Car Car { get; set; }

    }
}