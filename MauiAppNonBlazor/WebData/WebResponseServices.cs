using System.Net;

namespace MauiAppNonBlazor.WebData
{
    internal class WebResponseServices
    {
        public String Response { get; set; }
        public Color ResponseColor { get; set; }

        public async Task GetWebsiteResponse(string url)
        {
            HttpClient client = new();
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    ResponseColor = Color.FromRgb(0, 255, 0);//green
                    Response = "Status Code="
                    + response.StatusCode.ToString()
                    + " "  + DateTime.Now.ToString("MMMM dd, yyyy hh:mm:ss");
                }
                if (!response.IsSuccessStatusCode)
                {
                    ResponseColor = Color.FromRgb(255, 0, 0);//red
                    Response = "Status Code="
                    + response.StatusCode.ToString()
                    + " " + DateTime.Now.ToString("MMMM dd, yyyy hh:mm:ss");
                }
                if (response.StatusCode == HttpStatusCode.Forbidden
                    || response.StatusCode == HttpStatusCode.Unauthorized
                    || response.StatusCode == HttpStatusCode.ServiceUnavailable)
                {
                    
                    ResponseColor = Color.FromRgb(255, 0, 0);//red
                    Response = "Status Code="
                    + response.StatusCode.ToString()
                    + " " + DateTime.Now.ToString("MMMM dd, yyyy hh:mm:ss");
                }
            }
            catch
            {
                ResponseColor = Color.FromRgb(255, 0, 0);//red
                Response = "Status Code="
                + "Error no response."
                + " " + DateTime.Now.ToString("MMMM dd, yyyy hh:mm:ss");
            }
        }
    }
}
