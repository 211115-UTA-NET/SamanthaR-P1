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
    public static class LoadService
    {
        public static async Task<CustomerDtos> CustomerLoadServiceAsync(CustomerDtos customer)
        {
            HttpClient _httpClient = new();
            Uri server = new("https://localhost:7125");
            _httpClient.BaseAddress = server;
            Dictionary<string, string> query = new() { ["firstName"] = customer.firstName, ["lastName"] = customer.lastName };
            string requestUri = QueryHelpers.AddQueryString("/api/customer", query);
            HttpRequestMessage request = new(HttpMethod.Get, requestUri);
            request.Headers.Accept.Add(new(MediaTypeNames.Application.Json));
            HttpResponseMessage response;
            response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var requestedInfo = await response.Content.ReadFromJsonAsync<CustomerDtos>();


            return requestedInfo;
        }
    }
}
