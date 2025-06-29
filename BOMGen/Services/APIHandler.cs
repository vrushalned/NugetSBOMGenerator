using BOMGen.Models;
using System;
using System.Text;
using System.Text.Json;

namespace BOMGen.Services
{
    public class APIHandler
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl =  Constants.Constants.OSVBaseUrl;

        public APIHandler()
        {
            _httpClient = new HttpClient();
        }

        public async Task<QueryResponse> PostAsync(string request, string url)
        {
            try
            {
                Console.WriteLine(request);
                var content = new StringContent(request, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync($"{_baseUrl}{url}",content);
                response.EnsureSuccessStatusCode();
                var responseJson = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseJson);
                var apiResponse = JsonSerializer.Deserialize<QueryResponse>(responseJson);
                return apiResponse;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching API: {ex.Message}");
                return null;
            }
        }


    }
}
