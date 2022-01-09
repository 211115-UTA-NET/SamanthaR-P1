using Microsoft.AspNetCore.Mvc;
using StoreApi.Sql;
using StoreApi.Dtos;
using System.ComponentModel.DataAnnotations;

namespace StoreApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StoreController : ControllerBase
    {
        [HttpGet]
        public ActionResult<StoreDtos> DisplayStore([FromQuery, Required] int storeID, [FromQuery, Required] string storeLocation)
        {
            StatueDtos statueDtos;
            statueDtos = 
            return
        }
     }
}
