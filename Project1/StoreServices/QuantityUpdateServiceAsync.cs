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
    internal class QuantityUpdateServiceAsync
    {
        public static async Task UpdateItemQuantityAsync(int statueQuantity, int storeID, int itemID)
        {
            HttpClient _httpClient = new ();
            Uri server = new("https://localhost:7125");
            _httpClient.BaseAddress = server;

            ///<remarks>
            ///["variableName"] -> variableName == the controller's variable
            /// </remarks>
            Dictionary<string, string> customerDictionary = new Dictionary<string, string>() { ["statueQuantity"] = statueQuantity.ToString(), ["storeID"] = storeID.ToString(), ["itemID"] = itemID.ToString() };

            string requestUri = QueryHelpers.AddQueryString("/api/customer", customerDictionary);
            HttpRequestMessage request = new(HttpMethod.Post, requestUri);
            request.Headers.Accept.Add(new(MediaTypeNames.Application.Json));
            HttpResponseMessage response;
            response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }
    }
}
