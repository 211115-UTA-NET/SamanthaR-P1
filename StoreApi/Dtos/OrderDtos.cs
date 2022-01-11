namespace StoreApi.Dtos
{
    public class OrderDtos
    {
        public List<KeyValuePair<StatueDtos, int>> item;
        public int quantity { get; set; }
        public int orderID { get; set; }
        public int itemID { get; set; }
        public int storeID { get; set; }
        public string style { get; set; }
        public string storeLocation { get; set; }

        public DateTime orderedOn { get; set; }
        public int customerID { get; set; }
        ///<remarks> will have to make a JOIN of tables Statue_Orders and Garden_Customers on Customer_ID where Customer_First_Name = {firstName} AND Customer_Last_Name = {lastName}</remarks>
    }
}
