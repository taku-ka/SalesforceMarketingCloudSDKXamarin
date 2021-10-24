# SalesforceMarketingCloudSDKXamarin
 marketingcloudsdk-7.4.2
 
 How to init 
 Droid:
 
 
  ```
  // Initialize logging _before_ initializing the SDK to avoid losing valuable debugging information.
  MarketingCloudSdk.LogLevel = MCLogListener.Verbose;
  MarketingCloudSdk.SetLogListener(new MCWriteLogListener());

  var appID = "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx";
  var accessToken = "xxxxxxxxxxxxxxxxx";
  var appEndpoint = "https://mcxxxxxxxxxxx.device.marketingcloudapis.com/";
  var mid = "0000000000";
  var senderId = "0000000000";
  var inbox = true;
  var pushAnalytics = true;

  var config = MarketingCloudConfig
         .InvokeBuilder()
         .SetApplicationId(appID)
         .SetAccessToken(accessToken)
         .SetSenderId(senderId)
         .SetMid(mid)
         .SetGeofencingEnabled(true)
         .SetDelayRegistrationUntilContactKeyIsSet(true)
         .SetAnalyticsEnabled(pushAnalytics)
         .SetInboxEnabled(inbox)
         .SetMarketingCloudServerUrl(appEndpoint)
         .SetNotificationCustomizationOptions(NotificationCustomizationOptions.Create(Resource.Mipmap.app_icon))
         .Build(MainApplication.Instance);

  var sdkListner = new MCSdkListner(MainApplication.Instance);
  MarketingCloudSdk.Init(MainApplication.Instance, config, sdkListner);

  var persionID = "Taku Device";
  var sdkReadyLister = new MCReadyListener(persionID);
  MarketingCloudSdk.RequestSdk(sdkReadyLister);

  var token = await FirebaseMessaging.Instance.GetToken();
  if (token != null)
  {
      System.Diagnostics.Debug.WriteLine(token);
      MarketingCloudSdk.Instance.PushMessageManager.PushToken = token.ToString();
  }
 ```
 
 Write Logs: new MCWriteLogListener()
```
class MCWriteLogListener : Java.Lang.Object, IMCLogListener, IJavaObject, IDisposable, IJavaPeerable
{
    public void Out(int level, string tag, string message, Throwable throwable)
    {
        System.Diagnostics.Debug.WriteLine("Level: " + level + " Tag: " + tag);
        System.Diagnostics.Debug.WriteLine("Message: " + message);
        System.Diagnostics.Debug.WriteLine("Throwable: " + throwable);
        System.Diagnostics.Debug.WriteLine(",,,,,,,,,,,,,,,,,,,,,,,,,,,,,");
    }
}
```
new MCSdkListner()
```
public class MCSdkListner : Java.Lang.Object, MarketingCloudSdk.IInitializationListener
{
    private readonly Application _application;
    private readonly TaskCompletionSource<string> _taskCompletionSource;

    public MCSdkListner(Application application)
    {
        _application = application;
        _taskCompletionSource = new TaskCompletionSource<string>();
    }

    public void Complete(InitializationStatus status)
    {
        if (status.IsUsable)
        {
            var invokedStatus = status.InvokeStatus();

            if (invokedStatus == InitializationStatus.Status.CompletedWithDegradedFunctionality)
            {

                if (status.LocationsError())
                {
                    GoogleApiAvailability.Instance.ShowErrorNotification(_application, status.PlayServicesStatus());
                }
                else if (status.MessagingPermissionError())
                {

                    System.Diagnostics.Debug.WriteLine("Location permission was denied.");
                }
            }

            _taskCompletionSource.TrySetResult(default(string));
        }
        else
        {

            var error = status.UnrecoverableException();
            System.Diagnostics.Debug.WriteLine(error);
            _taskCompletionSource.TrySetException(new Exception(error.ToString()));
        }
    }

}
```
new MCReadyListener();
```
public class MCReadyListener : Java.Lang.Object, MarketingCloudSdk.IWhenReadyListener
{
    private string _persionID { get; set; } = string.Empty;
    public MCReadyListener(string persionID)
    {
        _persionID = persionID;
    }

    public void Ready(MarketingCloudSdk sdk)
    {
        System.Diagnostics.Debug.WriteLine(_persionID);

        MarketingCloudSdk.Instance.PushMessageManager.EnablePush();

        var success = MarketingCloudSdk.Instance.RegistrationManager.Edit().SetContactKey("Taku Device").Commit();

        string contactkey = MarketingCloudSdk.Instance.RegistrationManager.ContactKey;
        var sdkstate1 = sdk.SdkState.ToString();
    }
}
```

iOS
```
public void MarketingSdk()
{
    try
    {
        var appID = "xxxxxx-xxxx-xxx-xx-xxxxxx";
        var accessToken = "xxxxxxx";
        var appEndpoint = "https://mcxxxxxxxx.device.marketingcloudapis.com/";
        var mid = "xxxxxx";

        // Define features of MobilePush your app will use.
        var inbox = true;
        var location = false;
        var pushAnalytics = true;

        var configbuilder = new MarketingCloudSDKConfigBuilder()
                    .SetApplicationId(appID)
                    .SetAccessToken(accessToken)
                    .SetMarketingCloudServerUrl(appEndpoint)
                    .SetMid(mid)
                    .SetDelayRegistrationUntilContactKeyIsSet(true)
                    .SetInboxEnabled(inbox)
                    .SetLocationEnabled(location)
                    .SetAnalyticsEnabled(pushAnalytics)
                    .Build();

        var isSuccessful = MarketingCloudSDK.SharedInstance().ConfigureWithDictionary(configbuilder, out NSError configError);

        if (isSuccessful)
        {
            MarketingCloudSDK.SharedInstance().SetDebugLoggingEnabled(true);
            MarketingCloudSDK.SharedInstance().SetURLHandlingDelegate(new UrlHandler());
            MarketingCloudSDK.SharedInstance().StartWatchingLocation();

            string sdkstate = MarketingCloudSDK.SharedInstance().GetSDKState;

            UserSettings.MCSdkInitialized = false;
        }
        else
        {
            Debug.WriteLine("Initialisation Unsuccessful  " + configError);
        }

        if (UIApplication.SharedApplication.BackgroundRefreshStatus == UIBackgroundRefreshStatus.Available)
        {
            Debug.WriteLine("Enabling background refresh");
            UIApplication.SharedApplication.SetMinimumBackgroundFetchInterval(UIApplication.BackgroundFetchIntervalMinimum);
        }
    }
    catch (Exception ex)
    {
        Debug.WriteLine(ex);
    }
}
```
new UrlHandler();

```
public class UrlHandler : MarketingCloudSDKURLHandlingDelegate
{
    public override void Type(NSUrl url, string type)
    {
        Debug.WriteLine(string.Format("HandleURL: {0} {1}", type, url));

        if (UIApplication.SharedApplication.CanOpenUrl(url))
        {
            Debug.WriteLine(string.Format("Can open: " + url));
            var options = new NSDictionary();
            UIApplication.SharedApplication.OpenUrl(url, options, (success) => Debug.WriteLine("OpenURL: " + success));
        }
        else
        {
            Debug.WriteLine("Cannot open URL: " + url);
        }
    }
}
```


