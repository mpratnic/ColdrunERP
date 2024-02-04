namespace ColdrunERP.Api.Requests.Truck
{
    public class CreateTruckRequest
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int StatusId { get; set; }
    }
}
