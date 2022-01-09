using Microsoft.AspNetCore.Mvc;
using StoreApi.Sql;
using StoreApi.Dtos;
using System.ComponentModel.DataAnnotations;

namespace StoreApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        [HttpGet]
        public ActionResult<CustomerDtos> CustomerLookUp([FromQuery, Required]string firstName, [FromQuery, Required] string lastName)
        {
            CustomerDtos customerDtos;
            customerDtos = CustomerLookup.ReadCustomers(firstName, lastName);
            return customerDtos;
        }
    }
}