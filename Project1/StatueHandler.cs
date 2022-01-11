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
    public class StatueHandler
    {
        public async Task<List<StatueDtos>> DisplayStatues(int storeID)
        {
            HttpClient _httpClient = new();
            Uri server = new("https://localhost:7125");
            _httpClient.BaseAddress = server;
            Dictionary<string, string> query = new() { ["storeID"] = storeID.ToString()};
            string requestUri = QueryHelpers.AddQueryString("api/statue/itemMenu", query); //change the uri to be the name of the controller
            HttpRequestMessage request = new(HttpMethod.Get, requestUri);
            request.Headers.Accept.Add(new(MediaTypeNames.Application.Json));
            HttpResponseMessage response;
            response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            List<StatueDtos> requestedInfo = await response.Content.ReadFromJsonAsync<List<StatueDtos>>(); //can be a list, a customerDtos, whatever to call in for


            return requestedInfo;
        }
        public async Task UpdateStoreQuantity(int storeID)
        {
            HttpClient _httpClient = new();
            Uri server = new("https://localhost:7125");
            _httpClient.BaseAddress = server;
            Dictionary<string, string> query = new() { ["storeID"] = storeID.ToString() };
            string requestUri = QueryHelpers.AddQueryString("api/statue/updateQuantity", query); //change the uri to be the name of the controller
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
