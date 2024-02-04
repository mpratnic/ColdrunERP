namespace ColdrunERP.Api.Requests.Truck
{
    public class GetTruckListRequest
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? StatusId { get; set; }

        public bool? SortByName { get; set; }
        public bool? SortByDescription { get; set; }
        public bool? SortByStatus { get; set; }

        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
