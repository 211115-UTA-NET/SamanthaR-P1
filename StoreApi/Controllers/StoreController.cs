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
        [HttpGet]
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
    }
}
