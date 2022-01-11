using Microsoft.AspNetCore.WebUtilities;
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
        public async Task<CustomerDtos> CustomerLookup(string firstName, string lastName)
        {
            HttpClient _httpClient = new();
            Uri server = new("https://localhost:7125");
            _httpClient.BaseAddress = server;
            Dictionary<string, string> query = new() { ["firstName"] = firstName, ["lastName"] = lastName };
            string requestUri = QueryHelpers.AddQueryString("api/customer", query); //change the uri to be the name of the controller
            HttpRequestMessage request = new(HttpMethod.Get, requestUri);
            request.Headers.Accept.Add(new(MediaTypeNames.Application.Json));
            HttpResponseMessage response;
            response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            CustomerDtos? requestedInfo = await response.Content.ReadFromJsonAsync<CustomerDtos>(); //can be a list, a customerDtos, whatever to call in for


            return requestedInfo;
        }
    }
}
