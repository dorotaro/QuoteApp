using Services_aka_Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services_aka_Domain
{
    public interface IQuoteService
    {
        Task<List<QuoteReadModel>> GetQuotes();
        Task<QuoteReadModel> GetQuote(int id);
        Task AddQuote(QuoteWriteModel quoteWriteModel);
        Task FavQuote(int id);
    }
}
