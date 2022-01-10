using StoreApi.Logic;

namespace StoreApi.Dtos
{
    public class StoreDtos
    {

        public int StoreID { get; set; }

        public string? StoreLocation { get; set; }

        public StoreDtos()
        {

        }
        public StoreDtos(int storeID, string storeLocation)
        {
            StoreID = storeID;
            StoreLocation = storeLocation;
        }

       

        //internal Dictionary<Statue, int> itemQuantity { get; set; } = new Dictionary<Statue, int>();
    }
}
