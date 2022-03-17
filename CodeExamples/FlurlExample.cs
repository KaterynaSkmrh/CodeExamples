using AngleSharp.Dom;
using AngleSharp.Html.Parser;
using AngleSharp.XPath;
using Flurl;
using Flurl.Http;
using Flurl.Http.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeExamples
{
    public class AppStoreApi
    {
        const string Url = "https://apps.apple.com/";
        readonly IFlurlClient client = new FlurlClient()
                .Configure(x => x.HttpClientFactory = new DefaultHttpClientFactory());

        public async Task<List<Genre>> GetGenres()
        {
            var response = await Url
                .AppendPathSegment("genre/id36")
                .WithClient(client)
                .GetAsync();
            var document = await new HtmlParser().ParseDocumentAsync(await response.GetStreamAsync());
            var genres = document.DocumentElement
                .SelectNodes(@"//*[@id='genre-nav']//ul/li/a")
                .Select(x => new Genre() { name = x.TextContent, id = Convert.ToInt32(Substring(((IElement)x).GetAttribute("href"), "/id")) })
                .ToList();
            return genres;
        }

        static string Substring(string value, string delimiter)
        {
            var index = value.LastIndexOf(delimiter, StringComparison.OrdinalIgnoreCase);
            return index != -1 ? value.Substring((index + delimiter.Length), value.Length - (index + delimiter.Length) - 1) : value;
        }

        public class Genre
        {
            public int id;
            public string name;
        }
    }
}
