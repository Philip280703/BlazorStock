
using Azure;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BlazorStock.Client.Services
{
    public class StockGetApi
    {
        private readonly string _apiKey;
        private readonly string _baseUrl = "https://www.alphavantage.co/query";
        private readonly HttpClient _httpClient;

        public StockGetApi()
        {
            _apiKey = "DPO6Z7MRGBD2QN5S";
            _httpClient = new HttpClient();
        }

        public async Task<JObject> GetDailyStockPriceAsync(string symbol)
        {
            if (string.IsNullOrWhiteSpace(symbol)) throw new ArgumentNullException(nameof(symbol));

            string requestUrl = $"{_baseUrl}?function=TIME_SERIES_DAILY&symbol={symbol}&apikey={_apiKey}";

            try
            {
                HttpResponseMessage httpResponse = await _httpClient.GetAsync(requestUrl);

                if (httpResponse.IsSuccessStatusCode)
                {
                    string jsonResponse = await httpResponse.Content.ReadAsStringAsync();
                    JObject stockData = JObject.Parse(jsonResponse);
                    return stockData;
                }
                else
                {
                    throw new HttpRequestException($"Error fetching stock data: {httpResponse.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in API call: {ex.Message}");
                throw;
            }
        }


    }
}
