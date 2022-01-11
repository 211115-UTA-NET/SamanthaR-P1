using Microsoft.AspNetCore.Mvc;
using StoreApi.Sql;
using StoreApi.Dtos;
using System.ComponentModel.DataAnnotations;
using StoreApi.Sql;

namespace StoreApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoreController : ControllerBase
    {
        private readonly IRepository _repository;
        public StoreController(IRepository repository)
        {
            _repository = repository;
        }
        [HttpGet("displayStores")]
        public async Task<List<StoreDtos>> DisplayStoreOptions()
        {
            IEnumerable<StoreDtos> storeDtosList = await _repository.ReadStoreMenu();
            return storeDtosList.ToList();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateInventoryAsync([FromQuery, Required] int quantity, [FromQuery, Required] int storeID, [FromQuery, Required] int itemID)
        {
            try
            {
                UpdateQuantity update = new UpdateQuantity();
                await update.UpdateItemQuantity(quantity, storeID, itemID);
                    
                }
            catch (Exception ex)
            {
                Console.WriteLine("Server Error");
                return StatusCode(500);
            }
            
            return StatusCode(200);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStoreHistory([FromQuery, Required] int customerID, [FromQuery, Required] int storeID, [FromQuery, Required] int itemID, [FromQuery] string style,[FromQuery] DateTime dateTime)
        {
            ///<remarks>
            ///Read in all of the information from the OrderDtos class, but you don't have to instantiate one unless the function is looking for a Dtos class object. In this case, we don't need to instantiate an object becasue the AddNewOrder() is only looking for numbers and a string and not for a Dtos object. Also, returning an object is pointless, since the task is void and returns nothing
            /// </remarks>
            UpdateStoreOrderHistory newOrderHistory = new UpdateStoreOrderHistory();
            await newOrderHistory.AddNewOrder(customerID, storeID, itemID, style, dateTime);
            return StatusCode(200);
        }
    }
}
