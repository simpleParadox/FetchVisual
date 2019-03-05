using Microsoft.WindowsAzure.MobileServices;

public class AzureMobileServiceClient
{
    private const string backendUrl = "https://fetchvisual.azurewebsites.net";
    private static MobileServiceClient client;


    // Any other class can use this property.
    public static MobileServiceClient Client
    {
        get
        {
            if(client == null)
            {
                client = new MobileServiceClient(backendUrl);
            }
            return client;
        }
    }
}
