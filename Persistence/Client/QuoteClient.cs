using Persistence.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Persistence.Client
{
	public class QuoteClient : IQuoteClient
	{
        private readonly HttpClient _httpClient;

        public QuoteClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        private readonly string _sessionToken = "Y00zjtMAQCbL0oj29Y1HhsstFq+YsFkf8qyjO5bSCk69f/gejWnoq6zBJGt7Rmt93eFp3mevgmPQ0Oq0BGZTkQ==";

        public async Task<QuotesModelList> GetQuotes()
        {
            const string url = "/api/quotes";

            var response = await _httpClient.GetFromJsonAsync<QuotesModelList>(url);

            return response;
        }
        public async Task<QuoteResponseModel> GetQuote(int id)
        {
            string url = $"/api/quotes/{id}";

            return await _httpClient.GetFromJsonAsync<QuoteResponseModel>(url);
        }

        public  Task/*<QuoteResponseModel>*/ AddQuote(QuotePostModel quotePostModel)
        {
            string url = $"/api/quotes";

            _httpClient.DefaultRequestHeaders.Add("User-Token", _sessionToken);

            return  _httpClient.PostAsJsonAsync(url, quotePostModel);
        }

        public async Task FavQuote(int id)
        {
            string url = $"/api/quotes/{id}/fav";

            _httpClient.DefaultRequestHeaders.Add("User-Token", _sessionToken);

            await _httpClient.PutAsJsonAsync<QuoteResponseModel>(url, null);
        }

       
    }
}
