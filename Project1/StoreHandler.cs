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
    public class StoreHandler
    {
        public async Task<List<StoreDtos>> DisplayStoreOptionsAsync(StoreDtos store)
        {
            HttpClient _httpClient = new();
            Uri server = new("https://localhost:7125");
            _httpClient.BaseAddress = server;
            ///<remarks> HttpReQuestMessage takes in http method, and the parameters(a dictionary in this project). Since there are no parameters for this method, simply putting the path is sufficient</remarks>
            HttpRequestMessage request = new(HttpMethod.Get, "api/store/displaystores");
            request.Headers.Accept.Add(new(MediaTypeNames.Application.Json));
            HttpResponseMessage response;
            response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            List<StoreDtos> requestedInfo = await response.Content.ReadFromJsonAsync<List<StoreDtos>>(); //can be a list, a customerDtos, whatever to call in for

            return requestedInfo;
        }
        public async Task UpdateInventoryAsync(int quantity, int storeID, int itemID)
        {
            HttpClient _httpClient = new();
            Uri server = new("https://localhost:7125");
            _httpClient.BaseAddress = server;
            Dictionary<string, string> query = new() { ["quantity"] = quantity.ToString(), ["storeID"] = storeID.ToString(), ["itemID"] = itemID.ToString() };
            string requestUri = QueryHelpers.AddQueryString("api/store/inventory", query); //change the uri to be the name of the controller
            HttpRequestMessage request = new(HttpMethod.Post, requestUri);
            request.Headers.Accept.Add(new(MediaTypeNames.Application.Json));
            HttpResponseMessage response;
            response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            await response.Content.ReadFromJsonAsync<Task>(); //can be a list, a customerDtos, whatever to call in for

            ///<remarks>no return type needed, we are not saving this information on the client side - nothing hard-coded</remarks>
        }
        public async Task UpdateStoreHistory(int customerID, int storeID, int itemID, string style, DateTime dateTime)
        {
            HttpClient _httpClient = new();
            Uri server = new("https://localhost:7125");
            _httpClient.BaseAddress = server;
            Dictionary<string, string> query = new() { ["customerID"] = customerID.ToString(), ["storeID"] = storeID.ToString(), ["itemID"] = itemID.ToString(), ["style"] = style, ["dateTime"] = dateTime.ToString() };
            string requestUri = QueryHelpers.AddQueryString("api/store.history", query); //change the uri to be the name of the controller
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
