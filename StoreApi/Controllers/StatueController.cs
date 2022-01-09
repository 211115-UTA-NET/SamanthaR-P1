using Microsoft.AspNetCore.Mvc;
using StoreApi.Sql;
using StoreApi.Dtos;
using System.ComponentModel.DataAnnotations;
using StoreApi.StoreApi.Sql;

namespace StoreApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatueController : ControllerBase
    {
        [HttpGet]
        public ActionResult<StatueDtos> DisplayStatues([FromQuery, Required] int itemID, [FromQuery, Required] string style, [FromQuery, Required] decimal price)
        {
            StatueDtos statueDtos;
            statueDtos = DisplayStatueMenu.ReadStatueMenu(itemID, style, price);
            return statueDtos;
        }
        
    }
}
