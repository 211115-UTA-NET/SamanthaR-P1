namespace StoreApi.Dtos
{
    public class OrderDtos
    {
        public List<KeyValuePair<StatueDtos, int>> item;
        public int quantity { get; set; }
        public StoreDtos? storeLocation { get; set; }
        public DateTime orderedOn { get; set; }
        public CustomerDtos? customerName { get; set; }
    }
}
