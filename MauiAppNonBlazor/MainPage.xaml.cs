using MauiAppNonBlazor.WebData;

namespace MauiAppNonBlazor;
public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

    public void CheckConnection(object sender, System.EventArgs e)
    {
        _ = GetWebsiteResponse();
    }
    private async Task GetWebsiteResponse()
    {
        WebResponseServices webservice = new();
        activeIndicator.IsRunning = true;
        ButtonMain.Text = "Checking...";
        ButtonMain.TextColor = Colors.Green;
        await webservice.GetWebsiteResponse(url.Text);
        ButtonMain.Text = "Check Website Now";
        ButtonMain.TextColor = Color.FromRgba("#512BD4"); //set back to default
        ResponseText.Text = webservice.Response;
        ResponseText.TextColor = webservice.ResponseColor;
        activeIndicator.IsRunning = false;
    }
}

