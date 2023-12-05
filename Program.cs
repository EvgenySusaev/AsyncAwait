using System.Net;
using AsyncAwait.TaskIdea;

string url = "https://ya.ru";

try
{
    WebPage webPage = new WebPage();
    
    WebResponse content = await webPage.GetContent(url);
    Console.WriteLine(content);
    
    
    WebResponse page = await webPage.Get(url);
    Console.WriteLine(page);
    
    
    WebResponse page2 = await webPage.Get(url);
    Console.WriteLine(page2.ContentType);

    string page3 = await webPage.GetAsync(url);

    Console.WriteLine(page3);

}
catch (WebException webEx)
{
    // Handle web exception
    Console.WriteLine($"WebException: {webEx.Message}");
}
catch (Exception ex)
{
    // Handle other exceptions
    Console.WriteLine($"Exception: {ex.Message}");
}


