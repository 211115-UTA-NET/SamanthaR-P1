using StoreApi.Logic;

namespace StoreApi.Dtos
{
    public class StoreDtos
    {

        internal int storeID { get; set; }

        internal string? storeLocation { get; set; }

        internal Dictionary<Statue, int> itemQuantity { get; set; } = new Dictionary<Statue, int>();
    }
}
