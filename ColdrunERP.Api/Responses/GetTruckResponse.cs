namespace ColdrunERP.Api.Responses
{
    public class GetTruckResponse
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int StatusId { get; set; }
        public string StatusName { get; set; }
    }
}
