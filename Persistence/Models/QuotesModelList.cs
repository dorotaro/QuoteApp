using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Persistence.Models
{
    public class QuotesModelList
    {
        [JsonPropertyName("quotes")]
        public List<QuoteResponseModel> Quotes { get; set; }

    }
}
