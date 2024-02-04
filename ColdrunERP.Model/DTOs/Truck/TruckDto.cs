namespace ColdrunERP.Domain.DTOs.Truck
{
    public class TruckDto
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public TruckStatusDto Status { get; set; }
        public string Description { get; set; }
    }
}