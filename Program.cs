using System;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Microsoft.VisualBasic;

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

  static async Task<string[]> GetHeadlinesAsync(string url)
  {
    using var httpClient = new HttpClient();
    var html = await httpClient.GetStringAsync(url);
    
    var doc = new HtmlDocument();
    doc.LoadHtml(html);
    
    var headlineNodes = doc.DocumentNode.SelectNodes("//h2"); 
    
    var headlines = new List<string>();

    if (headlineNodes != null)
    {
      Console.WriteLine("Headlines Found! extracting text.");
      foreach (var node in headlineNodes)
      {
        headlines.Add(node.InnerText.Trim());
      }
    }
    else
    {
      Console.WriteLine("No headlines found. check XPath");
    }
    
    
    
    return headlines.ToArray();
  }

}