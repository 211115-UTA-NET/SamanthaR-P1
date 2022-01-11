using Microsoft.AspNetCore.Mvc;
using StoreApi.Sql;
using StoreApi.Dtos;
using System.ComponentModel.DataAnnotations;
using StoreApi.StoreApi.Sql;
using StoreApi.Logic;

namespace StoreApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatueController : ControllerBase
    {
        [HttpGet("itemMenu")]
        public ActionResult<List<StatueDtos>> DisplayStatues([FromQuery, Required] int storeID)
        {
            List<StatueDtos> statueDtos;
            statueDtos = DisplayStatueMenu.ReadStatueMenu(storeID);
            return statueDtos;
        }

        [HttpPost("updateQuantity")]
        public async Task<IActionResult> UpdateStoreQuantity([FromQuery, Required] int statueQuantity, [FromQuery, Required] int storeID, [FromQuery, Required] int itemID)
        {
            StatueDtos statueDtos = new StatueDtos();
            statueDtos.quantity = statueQuantity;
            statueDtos.itemID = itemID;
            StoreDtos storeDtos = new StoreDtos();
            storeDtos.StoreID = storeID;
            
            UpdateQuantity updateQuantity = new UpdateQuantity();
            await updateQuantity.UpdateItemQuantity(statueQuantity, storeID, itemID);
            return StatusCode(200);
        }

    }
}

//Read in a storeID and find all products based on a store id, controller HttpGET, change the parameters to be just the storeID (all I need), then enter the SQL command in the DisplayStatueMenu class, then instatueContrtollerm, make a list of StatueDtos's and then change the readStatueMenu parameters to just be one storeID, everythgng else will be in displastatuemenu, and in the return type, intake params, and SQL command, read it in and add it to the list