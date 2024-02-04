namespace ColdrunERP.Domain.Models.Truck
{
    public class TruckStatusRule
    {
        public int Id { get; set; }
        public int StatusIdFrom { get; set; }
        public int StatusIdTo { get; set; }
    }
}