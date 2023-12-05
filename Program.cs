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
    Console.WriteLine(page3.Take(10));
    
    
    Task<WebResponse> task = webPage.Get(url);
    task.ContinueWith(task =>
    {
        if (task.IsFaulted)
        {
            Console.WriteLine($"Exception: {task.Exception?.Flatten().InnerException?.Message}");
        }
        else
        {
            Console.WriteLine(task.Result.ContentType);
        }
    });

    
    Task<WebResponse> webRequestTask = webPage.Get(url);
    webRequestTask.Wait();
    
    if (webRequestTask.IsCompletedSuccessfully)
    {
        Console.WriteLine(webRequestTask.Result);
    }
    else if (webRequestTask.IsFaulted)
    {
        Console.WriteLine($"Exception: {webRequestTask.Exception?.Flatten().InnerException?.Message}");
    }

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


