using Microsoft.AspNetCore.Mvc;
using StoreApi.Sql;
using StoreApi.Dtos;
using System.ComponentModel.DataAnnotations;
using StoreApi.Sql;

namespace StoreApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
        public IActionResult UpdateInventoryAsync([FromQuery, Required] List<StatueDtos> statueDtos, [FromQuery, Required] int storeID)
        {
            for(int i = 0; i < statueDtos.Count; i++)
            {

                try
                {
                   UpdateQuantity.UpdateItemQuantity(statueDtos[i].quantity, storeID, statueDtos[i].itemID);
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Server Error");
                    return StatusCode(500);
                }
            }
            return StatusCode(200);
        }
    }
}
