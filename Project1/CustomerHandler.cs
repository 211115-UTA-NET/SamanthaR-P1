using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.AspNetCore.Mvc;
using Project1.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    /// <summary>
    /// to use opposite of the customer controller in the api
    /// </summary>
    public class CustomerHandler
    {
        public async Task<CustomerDtos> CustomerLookupAsync(CustomerDtos customer)
        {
            HttpClient _httpClient = new();
            Uri server = new("https://localhost:7125");
            _httpClient.BaseAddress = server;
            Dictionary<string, string> query = new() { ["firstName"] = customer.firstName, ["lastName"] = customer.lastName };
            string requestUri = QueryHelpers.AddQueryString("/api/customer/lookup", query); //change the uri to be the name of the controller
            HttpRequestMessage request = new(HttpMethod.Get, requestUri);
            request.Headers.Accept.Add(new(MediaTypeNames.Application.Json));
            HttpResponseMessage response;
            response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            CustomerDtos? requestedInfo = await response.Content.ReadFromJsonAsync<CustomerDtos>(); //can be a list, a customerDtos, whatever to call in for

            return requestedInfo;
        }

        public async Task<List<OrderDtos>> CustomerOrderHistoryAsync(CustomerDtos customer)
        {
            HttpClient _httpClient = new();
            Uri server = new("https://localhost:7125");
            _httpClient.BaseAddress = server;
            Dictionary<string, string> query = new() { ["firstName"] = customer.firstName, ["lastName"] = customer.lastName };
            string requestUri = QueryHelpers.AddQueryString("/api/customer/history", query); //change the uri to be the name of the controller
            HttpRequestMessage request = new(HttpMethod.Get, requestUri);
            request.Headers.Accept.Add(new(MediaTypeNames.Application.Json));
            HttpResponseMessage response;
            response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            List<OrderDtos>? requestedInfo = await response.Content.ReadFromJsonAsync<List<OrderDtos>>(); //can be a list, a customerDtos, whatever to call in for

            return requestedInfo;
        }
        public async Task AddCustomerAsync(CustomerDtos customer)
        {
            HttpClient _httpClient = new();
            Uri server = new("https://localhost:7125");
            _httpClient.BaseAddress = server;
            Dictionary<string, string> query = new() { ["firstName"] = customer.firstName, ["lastName"] = customer.lastName, ["address"] = customer.address, ["city"] = customer.city, ["state"] = customer.state };
            string requestUri = QueryHelpers.AddQueryString("/api/customer/add", query); //change the uri to be the name of the controller
            HttpRequestMessage request = new(HttpMethod.Post, requestUri);
            request.Headers.Accept.Add(new(MediaTypeNames.Application.Json));
            HttpResponseMessage response;
            response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            await response.Content.ReadFromJsonAsync<Task>(); //can be a list, a customerDtos, whatever to call in for

            ///<remarks>no return type needed, we are not saving this information on the client side - nothing hard-coded</remarks>
        }
    }
}
