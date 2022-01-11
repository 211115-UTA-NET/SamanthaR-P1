using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Project1.Dtos;
using System.Net.Http.Json;

namespace Project1.StoreServices
{
    internal class CustomerPostServiceAsync
    {
        public static async Task<CustomerDtos> PostNewCustomerServiceAsync(CustomerDtos customer)
        {
            HttpClient _httpClient = new();
            Uri server = new("https://localhost:7125");
            _httpClient.BaseAddress = server;
            
            Dictionary<string, string> customerDictionary = new Dictionary<string, string>() { ["firstName"] = customer.firstName, ["lastName"] = customer.lastName, ["address"] = customer.address, ["city"] = customer.city, ["state"] = customer.state};
            string requestUri = QueryHelpers.AddQueryString("/api/customer", customerDictionary);
            HttpRequestMessage request = new(HttpMethod.Post, requestUri);
            request.Headers.Accept.Add(new(MediaTypeNames.Application.Json));
            HttpResponseMessage response;
            response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            //var requestedInfo = await response.Content.ReadFromJsonAsync<CustomerDtos>();


            return customer;
        }
    }
}
