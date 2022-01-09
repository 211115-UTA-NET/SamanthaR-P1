using StoreApi;
namespace StoreApi.Dtos
{
    public class CustomerDtos
    {
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? address { get; set; }
        public string? city { get; set; }
        public string? state { get; set; }
        public int customerID { get; set; }
        public StoreDtos store { get; set; }
        public List<KeyValuePair<StatueDtos, int>> cart { get; set; } = new List<KeyValuePair<StatueDtos, int>>();
    }
}
