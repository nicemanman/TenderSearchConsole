using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Parsers
{
    public class AngleSharpHtmlParser
    {
        public Task<IElement> SelectFromDocument(IHtmlDocument document, string selectors) 
        {
            //var document = await BrowsingContext.New().OpenNewAsync("https://market.mosreg.ru/Trade/ViewTrade/1763198");
            try
            {
                var tagContent = document.QuerySelector(selectors);
                return Task.FromResult(tagContent);
            }
            catch (HttpRequestException e)
            {
                throw new Exception("Ошибка http запроса", e);
            }
            catch (NullReferenceException e)
            {
                throw new Exception("Ошибка", e);
            }
        }
        public async Task<IHtmlDocument> GetDocumentAsync(string url) 
        {
            var httpClient = new HttpClient();
            try
            {
                var responseHtml = await httpClient.GetStringAsync(url);
                var parser = new HtmlParser();
                var document = await parser.ParseDocumentAsync(responseHtml);
                return document;
            }
            catch (HttpRequestException e) 
            {
                throw new Exception("Ошибка http запроса", e);
            }
        }
        
    }
}
