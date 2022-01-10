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
        [HttpGet]
        public ActionResult<List<StoreDtos>> DisplayStoreOptions([FromQuery, Required] int storeID, [FromQuery, Required] string storeLocation)
        {
            List<StoreDtos> storeDtos = StoreOptionDisplay.ReadStoreMenu();
            return storeDtos;
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
