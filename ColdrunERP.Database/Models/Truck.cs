namespace ColdrunERP.Database.Models
{
    public class Truck
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int StatusId { get; set; }
        public string Description { get; set; }
    }
}
