using Microsoft.AspNetCore.Mvc;
using StoreApi.Sql;
using StoreApi.Dtos;
using System.ComponentModel.DataAnnotations;
using StoreApi.Logic;


namespace StoreApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        [HttpGet]
        public ActionResult<CustomerDtos> CustomerLookUp([FromQuery, Required]string firstName, [FromQuery, Required] string lastName)
        {
            CustomerDtos customerDtos;
            customerDtos = CustomerLookup.ReadCustomers(firstName, lastName);
            return customerDtos;
        }

        [HttpGet]
        public ActionResult<List<OrderDtos>> CustomerOrderHistory([FromQuery, Required] string firstName, [FromQuery, Required] string lastName)
        {
            List<OrderDtos> orderDtos;
            orderDtos = DisplayCustomerOrderHistory.ReadOrderHistory(firstName, lastName);
            return orderDtos;
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomers([FromQuery, Required] string firstName, [FromQuery, Required] string lastName, [FromQuery, Required] string address, [FromQuery, Required] string city, [FromQuery, Required] string state)
        {
            CustomerDtos customerDtos = new CustomerDtos();
            customerDtos.firstName = firstName;
            customerDtos.lastName = lastName;
            customerDtos.address = address;
            customerDtos.city = city;
            customerDtos.state = state;
            AddCustomer newCustomer = new AddCustomer();
            customerDtos = await newCustomer.AddNewCustomer(customerDtos);
            return StatusCode(200);
        }
    }
}