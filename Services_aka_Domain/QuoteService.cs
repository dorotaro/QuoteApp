using Persistence.Client;
using Persistence.Models;
using Services_aka_Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services_aka_Domain
{
    public class QuoteService : IQuoteService
    {
        private readonly IQuoteClient _quoteClient;

        public QuoteService(IQuoteClient quoteClient)
        {
            _quoteClient = quoteClient;
        }

        public async Task<List<QuoteReadModel>> GetQuotes()
        {
           var listOfQuotesOfResponseModel = await _quoteClient.GetQuotes();

            var quoteModelList = new List<QuoteReadModel>();

            foreach (var quote in listOfQuotesOfResponseModel.Quotes) 
            { 
               var quoteReadModel = new QuoteReadModel
                {
                    Id = quote.Id,
                    Url = quote.Url,
                    FavoritesCount = quote.FavoritesCount,
                    UpvotesCount = quote.UpvotesCount,
                    DownvotesCount = quote.DownvotesCount,
                    Author = quote.Author,
                    Body = quote.Body,
                    Tags = quote.Tags
                };

                quoteModelList.Add(quoteReadModel);
            };

            return quoteModelList;
        }

        public async Task<QuoteReadModel> GetQuote(int id)
        {
            var quoteOfResponseModel = await _quoteClient.GetQuote(id);

            var quoteofReadModel = new QuoteReadModel
            {
                Id = quoteOfResponseModel.Id,
                Url = quoteOfResponseModel.Url,
                FavoritesCount = quoteOfResponseModel.FavoritesCount,
                UpvotesCount = quoteOfResponseModel.UpvotesCount,
                DownvotesCount = quoteOfResponseModel.DownvotesCount,
                Author = quoteOfResponseModel.Author,
                Body = quoteOfResponseModel.Body,
                Tags = quoteOfResponseModel.Tags

            };

            return quoteofReadModel;
        }

        public async Task AddQuote(QuoteWriteModel quoteWriteModel)
        {
           var postQuoteBody = new QuoteBody
               {
                    Author = quoteWriteModel.Author,
                    Body = quoteWriteModel.Body
               };

            var postQuoteModel = new QuotePostModel
            {
                Quote = postQuoteBody
            };

            await _quoteClient.AddQuote(postQuoteModel);
        }

        public async Task FavQuote(int id)
        {
           await  _quoteClient.FavQuote(id);
        }
    }
}
