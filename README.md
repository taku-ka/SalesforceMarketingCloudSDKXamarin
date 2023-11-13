# SalesforceMarketingCloudSDKXamarin
 marketingcloudsdk-8
 
 How to init 
 Droid:

 In MainActivity
  ```
  internal static MainActivity Instance { get; private set; }
  public override void OnCreate()
  {
    base.OnCreate();


//Other code
  Instance = this;
   var startMarketingSdk = new StartMCSdk();
   startMarketingSdk.StartSdk();
 }
  ```

StartMCSdk class
  ```
using System;
using Android.Runtime;
using xxxxx.Droid.MessagingServices.MCListener;
using Com.Salesforce.Marketingcloud;
using Com.Salesforce.Marketingcloud.Notifications;
using Com.Salesforce.Marketingcloud.Sfmcsdk;

namespace xxxxx.Droid.MessagingServices
{
    [Preserve(AllMembers = true)]
    public class StartMCSdk : Java.Lang.Object, ISFMCSdkReadyListener, ILogListener
    {
        public void StartSdk()
        {
            try
            {
                // Initialize logging _before_ initializing the SDK to avoid losing valuable debugging information.
#if DEBUG
                SFMCSdk.SetLogging(LogLevel.Debug, this);
                MarketingCloudSdk.LogLevel = MCLogListener.Verbose;
                MarketingCloudSdk.SetLogListener(new MCWriteLogListener());
#endif

                 var appID = "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx";
                 var accessToken = "xxxxxxxxxxxxxxxxx";
                 var appEndpoint = "https://mcxxxxxxxxxxx.device.marketingcloudapis.com/";
                 var mid = "0000000000";
                 var senderId = "0000000000";
                 var inbox = true;
                 var pushAnalytics = true;

                var marketingCloudConfig = MarketingCloudConfig
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
                       .SetPiAnalyticsEnabled(true)
                       .SetProximityEnabled(true)
                       .SetNotificationCustomizationOptions(NotificationCustomizationOptions.Create(Resource.Mipmap.app_icon))
                       .Build(MainApplication.Instance);

                // Init a SFMCSdk builder
                var config = new SFMCSdkModuleConfig.Builder();
                config.PushModuleConfig = marketingCloudConfig;
                var builder = config.Build();
                SFMCSdk.Configure(MainApplication.Instance, builder);
                SFMCSdk.RequestSdk(this);

                var sdkListner = new MCSdkListner(MainApplication.Instance);
                MarketingCloudSdk.Init(MainApplication.Instance, marketingCloudConfig, sdkListner);

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }

        public void Ready(SFMCSdk sdk)
        {
        }

        public void Out(LogLevel level, string tag, string message, Java.Lang.Throwable throwable)
        {
            LogInformation(tag, message);
        }

        void LogInformation(string methodName, object information) => Debug.WriteLine($"\nMethod: {methodName}\nInfo: {information}");
    }
}

 ```



 
 Write Logs: new MCWriteLogListener()
```
using System;
using System.Diagnostics;
using Android.Runtime;
using Com.Salesforce.Marketingcloud;
using Java.Interop;
using Java.Lang;

namespace xxxxx.Droid.MessagingServices.MCListener
{
    [Preserve(AllMembers = true)]
    class MCWriteLogListener : Java.Lang.Object, IMCLogListener, IJavaObject, IDisposable, IJavaPeerable
    {
        public void Out(int level, string tag, string message, Throwable throwable)
        {
            LogInformation(tag, message);

        }
        void LogInformation(string methodName, object information) => Debug.WriteLine($"\nMethod: {methodName}\nInfo: {information}");

    }
}

```
new MCSdkListner()
```
using System;
using System.Threading.Tasks;
using Android.App;
using Android.Gms.Common;
using Android.Runtime;
using Com.Salesforce.Marketingcloud;

namespace xxxxx.Droid.MessagingServices
{
    [Preserve(AllMembers = true)]
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
}

```
new MCReadyListener();
```
using System;
using Android.Runtime;
using Com.Salesforce.Marketingcloud;

namespace xxxxx.Droid.MessagingServices.MCListener
{
    [Preserve(AllMembers = true)]
    public class MCReadyListener : Java.Lang.Object, MarketingCloudSdk.IWhenReadyListener
    {
        private string _contactKey { get; set; } = string.Empty;
        public MCReadyListener(string contactKey)
        {
            _contactKey = contactKey;
        }

        public void Ready(MarketingCloudSdk sdk)
        {
            System.Diagnostics.Debug.WriteLine(_contactKey);

            MarketingCloudSdk.Instance.PushMessageManager.EnablePush();
            var success = MarketingCloudSdk.Instance.RegistrationManager.Edit().SetContactKey(_contactKey).Commit();
            string contactkey = MarketingCloudSdk.Instance.RegistrationManager.ContactKey;
            var sdkstate1 = sdk.SdkState.ToString();
        }
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


