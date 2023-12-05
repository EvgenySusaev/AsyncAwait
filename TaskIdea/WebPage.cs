using System.Net;

namespace AsyncAwait.TaskIdea;

public class WebPage
{
    public WebPage()
    {
        
    }
    
    public Task<WebResponse> Get(string url)
    {
            WebRequest request = WebRequest.Create(url);
            return request.GetResponseAsync();
    }
    
    public async Task<WebResponse> GetContent(string url)
    {
        WebRequest request = WebRequest.Create(url);
        return await request.GetResponseAsync();
    }

    public Task<string> GetAsync(string url)
    {
        // Create a TaskCompletionSource to represent the asynchronous operation
        var tcs = new TaskCompletionSource<string>();

        // Create a WebRequest object
        WebRequest request = WebRequest.Create(url);

        // Start the asynchronous operation
        request.BeginGetResponse(asyncResult =>
        {
            try
            {
                WebResponse response = request.EndGetResponse(asyncResult);
                using (Stream responseStream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(responseStream))
                {
                    string content = reader.ReadToEnd();
                    tcs.SetResult(content);
                }
            }
            catch (Exception ex)
            {
                tcs.SetException(ex);
            }
        }, null);
        
        return tcs.Task;
    }
    
}