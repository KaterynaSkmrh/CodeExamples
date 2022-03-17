using Flurl;
using Flurl.Http;
using Flurl.Http.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeExamples
{
    public class PrivatBankApi
    {
        const string Url = "https://api.privatbank.ua/";
        readonly IFlurlClient client = new FlurlClient()
                .Configure(x => x.HttpClientFactory = new DefaultHttpClientFactory());

        public Task<List<ExchangeRate>> GetExchangeRate(int type = ExchangeType.Card) => Url
            .AppendPathSegment("p24api/pubinfo")
            .SetQueryParam("exchange")
            .SetQueryParam("json")
            .SetQueryParam("coursid", 11)
            .WithClient(client)
            .GetJsonAsync<List<ExchangeRate>>();

        public class ExchangeRate
        {
            public string ccy { get; set; }
            public string base_ccy { get; set; }
            public decimal buy { get; set; }
            public decimal sale { get; set; }
        }
        public class ExchangeType
        {
            public const int Cash = 4;
            public const int Card = 11;
        }
    }
}
