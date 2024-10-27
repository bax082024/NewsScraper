using System;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;

class Program
{
  static async Task Main(string[] args)
  {
    string url = "https://www.ba.no";

    Console.WriteLine("Fetching headlines...");

    var headlines = await GetHeadlinesAsync(url);

    Console.WriteLine("Top headlines");
    foreach (var headline in headlines)
    {
      Console.WriteLine("- " + headline);
    }


  }

}