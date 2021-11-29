using Persistence.Models;
using System.Threading.Tasks;

namespace Persistence.Client
{
    public interface IQuoteClient
    {
        Task<QuotesModelList> GetQuotes();
        Task<QuoteResponseModel> GetQuote(int id);
        Task AddQuote(QuotePostModel quotePostModel); 
        Task FavQuote(int id); 
    }
}
