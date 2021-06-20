using AngleSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Parsers
{
    public class AngleSharpHtmlParser
    {
        public async Task Run() 
        {
            var document = await BrowsingContext.New().OpenNewAsync("https://market.mosreg.ru/Trade/ViewTrade/1763198");
            //парсим страницу
        }
    }
}
