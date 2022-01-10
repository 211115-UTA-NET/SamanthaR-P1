using Microsoft.AspNetCore.Mvc;
using StoreApi.Sql;
using StoreApi.Dtos;
using System.ComponentModel.DataAnnotations;
using StoreApi.Logic;


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

        //[HttpPost]
        //public async Task<IActionResult> AddCustomers([FromQuery, Required] string firstName, [FromQuery, Required] string lastName, [FromQuery, Required] string address, [FromQuery, Required] string city, [FromQuery, Required] string state)
        //{
        //    CustomerDtos customerDtos;
        //    customerDtos.firstName = await AddCustomer.AddNewCustomer(firstName);
        //}
    }
}