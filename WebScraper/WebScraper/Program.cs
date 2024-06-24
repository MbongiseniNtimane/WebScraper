using HtmlAgilityPack;
using System;
using System.Net.Http;


namespace WebScrapper
{
    class Program
    {
        static void Main(String[] args)
        {
            String url = "https://weather.com/en-ZA/weather/today/l/SFXX0044:1:SF?Goto=Redirected";
            var httpClient = new HttpClient();
            var html = httpClient.GetStringAsync(url).Result;

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);


            //Scraping the temperature,condition and location
            var locationElement = htmlDocument.DocumentNode.SelectSingleNode("//h1[@class = 'CurrentConditions--location--1YWj_']");
            var location = locationElement.InnerText.Trim();
            Console.WriteLine("Location : " + location);

            var temperatureElement = htmlDocument.DocumentNode.SelectSingleNode("//span[@class = 'CurrentConditions--tempValue--MHmYY']");
            var temperature = temperatureElement.InnerText.Trim();
            Console.WriteLine("Temperature : " + temperature );

            var conditionElement = htmlDocument.DocumentNode.SelectSingleNode("//div[@class = 'CurrentConditions--phraseValue--mZC_p']");
            var condition = conditionElement.InnerText.Trim();
            Console.WriteLine("Condition : " + condition);

            var daynightElement = htmlDocument.DocumentNode.SelectSingleNode("//div[@class = 'CurrentConditions--tempHiLoValue--3T1DG']");
            var daynight = daynightElement.InnerText.Trim();
            Console.WriteLine("Day & Night : " + daynight );



        }
    }
    
}
