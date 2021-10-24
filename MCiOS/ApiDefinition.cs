using System;

using ObjCRuntime;
using Foundation;
using UIKit;
using UserNotifications;
using CoreLocation;

namespace MarketingIOS
{
    partial interface Constants
    {
        // extern NSString *const _Nonnull MarketingCloudSDKErrorDomain;
        [Field("MarketingCloudSDKErrorDomain", "__Internal")]
        NSString MarketingCloudSDKErrorDomain { get; }

        // extern NSNotificationName  _Nonnull const SFMCFrameworkDidSetupNotification;
        [Field("SFMCFrameworkDidSetupNotification", "__Internal")]
        NSString SFMCFrameworkDidSetupNotification { get; }

        // extern NSNotificationName  _Nonnull const SFMCFrameworkDidTeardownNotification;
        [Field("SFMCFrameworkDidTeardownNotification", "__Internal")]
        NSString SFMCFrameworkDidTeardownNotification { get; }

        // extern NSNotificationName  _Nonnull const SFMCFoundationRegistrationResponseSucceededNotification;
        [Field("SFMCFoundationRegistrationResponseSucceededNotification", "__Internal")]
        NSString SFMCFoundationRegistrationResponseSucceededNotification { get; }

        // extern NSNotificationName  _Nonnull const SFMCFoundationUNNotificationReceivedNotification;
        [Field("SFMCFoundationUNNotificationReceivedNotification", "__Internal")]
        NSString SFMCFoundationUNNotificationReceivedNotification { get; }

        // extern NSNotificationName  _Nonnull const SFMCInboxMessagesRefreshCompleteNotification;
        [Field("SFMCInboxMessagesRefreshCompleteNotification", "__Internal")]
        NSString SFMCInboxMessagesRefreshCompleteNotification { get; }

        // extern NSNotificationName  _Nonnull const SFMCInboxMessagesNewInboxMessagesNotification;
        [Field("SFMCInboxMessagesNewInboxMessagesNotification", "__Internal")]
        NSString SFMCInboxMessagesNewInboxMessagesNotification { get; }

        // extern NSNotificationName  _Nonnull const SFMCInboxMessagesUpdateStatusCompleteNotification;
        [Field("SFMCInboxMessagesUpdateStatusCompleteNotification", "__Internal")]
        NSString SFMCInboxMessagesUpdateStatusCompleteNotification { get; }

        // extern NSNotificationName  _Nonnull const SFMCInboxMessagesNotificationHandledNotification;
        [Field("SFMCInboxMessagesNotificationHandledNotification", "__Internal")]
        NSString SFMCInboxMessagesNotificationHandledNotification { get; }

        // extern NSNotificationName  _Nonnull const SFMCOpenDirectMessageNotificationHandledNotification;
        [Field("SFMCOpenDirectMessageNotificationHandledNotification", "__Internal")]
        NSString SFMCOpenDirectMessageNotificationHandledNotification { get; }

        // extern NSNotificationName  _Nonnull const SFMCLocationDidFixLocationNotification;
        [Field("SFMCLocationDidFixLocationNotification", "__Internal")]
        NSString SFMCLocationDidFixLocationNotification { get; }

        // extern NSNotificationName  _Nonnull const SFMCLocationDidReceiveLocationUpdateNotification;
        [Field("SFMCLocationDidReceiveLocationUpdateNotification", "__Internal")]
        NSString SFMCLocationDidReceiveLocationUpdateNotification { get; }

        // extern NSNotificationName  _Nonnull const SFMCLocationGeofenceRefreshCompleteNotification;
        [Field("SFMCLocationGeofenceRefreshCompleteNotification", "__Internal")]
        NSString SFMCLocationGeofenceRefreshCompleteNotification { get; }

        // extern NSNotificationName  _Nonnull const SFMCDidEnterLocationRegionMessageNotification;
        [Field("SFMCDidEnterLocationRegionMessageNotification", "__Internal")]
        NSString SFMCDidEnterLocationRegionMessageNotification { get; }

        // extern NSNotificationName  _Nonnull const SFMCDidExitLocationRegionMessageNotification;
        [Field("SFMCDidExitLocationRegionMessageNotification", "__Internal")]
        NSString SFMCDidExitLocationRegionMessageNotification { get; }

        // extern NSNotificationName  _Nonnull const SFMCDidDisplayLocationMessageNotification;
        [Field("SFMCDidDisplayLocationMessageNotification", "__Internal")]
        NSString SFMCDidDisplayLocationMessageNotification { get; }

        // extern NSNotificationName  _Nonnull const SFMCBeaconRefreshCompleteNotification;
        [Field("SFMCBeaconRefreshCompleteNotification", "__Internal")]
        NSString SFMCBeaconRefreshCompleteNotification { get; }

        // extern NSNotificationName  _Nonnull const SFMCDidRangeBeaconLocationMessageNotification;
        [Field("SFMCDidRangeBeaconLocationMessageNotification", "__Internal")]
        NSString SFMCDidRangeBeaconLocationMessageNotification { get; }

        // extern NSNotificationName  _Nonnull const SFMCLocationDidStartMonitoringForRegionNotification;
        [Field("SFMCLocationDidStartMonitoringForRegionNotification", "__Internal")]
        NSString SFMCLocationDidStartMonitoringForRegionNotification { get; }

        // extern NSNotificationName  _Nonnull const SFMCFrameworkDidBlockNotification;
        [Field("SFMCFrameworkDidBlockNotification", "__Internal")]
        NSString SFMCFrameworkDidBlockNotification { get; }
    }

    partial interface Constants
    {
        // extern NSString *const _Nonnull SFMCURLTypeCloudPage;
        [Field("SFMCURLTypeCloudPage", "__Internal")]
        NSString SFMCURLTypeCloudPage { get; }

        // extern NSString *const _Nonnull SFMCURLTypeOpenDirect;
        [Field("SFMCURLTypeOpenDirect", "__Internal")]
        NSString SFMCURLTypeOpenDirect { get; }

        // extern NSString *const _Nonnull SFMCURLTypeAction;
        [Field("SFMCURLTypeAction", "__Internal")]
        NSString SFMCURLTypeAction { get; }
    }

    partial interface Constants
    {
        // extern NSString *const _Nonnull MarketingCloudSDKInboxMessageKey;
        [Field("MarketingCloudSDKInboxMessageKey", "__Internal")]
        NSString MarketingCloudSDKInboxMessageKey { get; }
    }

    [Protocol]
    [BaseType(typeof(NSObject))]
    interface SFMCEvent
    {
        // @required -(NSString * _Nonnull)key;
        [Abstract]
        [Export("key")]
        string Key { get; }

        // @required -(NSDictionary<NSString *,id> * _Nullable)parameters;
        [Abstract]
        [NullAllowed, Export("parameters")]
        NSDictionary<NSString, NSObject> Parameters { get; }

        // +(id<SFMCEvent> _Nullable)customEventWithName:(NSString * _Nonnull)key;
        [Static]
        [Export("customEventWithName:")]
        [return: NullAllowed]
        SFMCEvent CustomEventWithName(string key);

        // +(id<SFMCEvent> _Nullable)customEventWithName:(NSString * _Nonnull)key withAttributes:(NSDictionary<NSString *,id> * _Nonnull)parameters;
        [Static]
        [Export("customEventWithName:withAttributes:")]
        [return: NullAllowed]
        SFMCEvent CustomEventWithName(string key, NSDictionary<NSString, NSObject> parameters);

        // +(NSDictionary<NSString *,id> * _Nullable)parseAndTrim:(NSDictionary<NSString *,id> * _Nonnull)parameters;
        [Static]
        [Export("parseAndTrim:")]
        [return: NullAllowed]
        NSDictionary<NSString, NSObject> ParseAndTrim(NSDictionary<NSString, NSObject> parameters);

        // +(NSString * _Nullable)validateAndPrepareKey:(id _Nonnull)key;
        [Static]
        [Export("validateAndPrepareKey:")]
        [return: NullAllowed]
        string ValidateAndPrepareKey(NSObject key);
    }

    // @interface Intelligence (MarketingCloudSDK)
    [Category]
    [BaseType(typeof(MarketingCloudSDK))]
    interface MarketingCloudSDK_Intelligence
    {
        // -(BOOL)sfmc_setPiIdentifier:(NSString * _Nullable)identifier;
        [Export("sfmc_setPiIdentifier:")]
        bool SetPiIdentifier([NullAllowed] string identifier);

        // -(NSString * _Nullable)sfmc_piIdentifier;
        //[NullAllowed, Export("sfmc_piIdentifier")]
        //string PiIdentifier();

        // -(void)sfmc_trackMessageOpened:(NSDictionary * _Nonnull)inboxMessage;
        [Export("sfmc_trackMessageOpened:")]
        void TrackMessageOpened(NSDictionary inboxMessage);

        // -(void)sfmc_trackPageViewWithURL:(NSString * _Nonnull)url title:(NSString * _Nullable)title item:(NSString * _Nullable)item search:(NSString * _Nullable)search;
        [Export("sfmc_trackPageViewWithURL:title:item:search:")]
        void TrackPageViewWithURL(string url, [NullAllowed] string title, [NullAllowed] string item, [NullAllowed] string search);

        // -(void)sfmc_trackCartContents:(NSDictionary * _Nonnull)cartDictionary;
        [Export("sfmc_trackCartContents:")]
        void TrackCartContents(NSDictionary cartDictionary);

        // -(void)sfmc_trackCartConversion:(NSDictionary * _Nonnull)orderDictionary;
        [Export("sfmc_trackCartConversion:")]
        void TrackCartConversion(NSDictionary orderDictionary);

        // -(NSDictionary * _Nullable)sfmc_cartItemDictionaryWithPrice:(NSNumber * _Nonnull)price quantity:(NSNumber * _Nonnull)quantity item:(NSString * _Nonnull)item uniqueId:(NSString * _Nullable)uniqueId;
        [Export("sfmc_cartItemDictionaryWithPrice:quantity:item:uniqueId:")]
        [return: NullAllowed]
        NSDictionary CartItemDictionaryWithPrice(NSNumber price, NSNumber quantity, string item, [NullAllowed] string uniqueId);

        // -(NSDictionary * _Nullable)sfmc_cartDictionaryWithCartItemDictionaryArray:(NSArray * _Nonnull)cartItemDictionaryArray;
        [Export("sfmc_cartDictionaryWithCartItemDictionaryArray:")]
        [return: NullAllowed]
        NSDictionary CartDictionaryWithCartItemDictionaryArray(NSObject[] cartItemDictionaryArray);

        // -(NSDictionary * _Nullable)sfmc_orderDictionaryWithOrderNumber:(NSString * _Nonnull)orderNumber shipping:(NSNumber * _Nonnull)shipping discount:(NSNumber * _Nonnull)discount cart:(NSDictionary * _Nonnull)cartDictionary;
        [Export("sfmc_orderDictionaryWithOrderNumber:shipping:discount:cart:")]
        [return: NullAllowed]
        NSDictionary OrderDictionaryWithOrderNumber(string orderNumber, NSNumber shipping, NSNumber discount, NSDictionary cartDictionary);
    }

    // @interface MarketingCloudSDK : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MarketingCloudSDK
    {
        // +(instancetype _Nonnull)sharedInstance;
        [Static]
        [Export("sharedInstance")]
        MarketingCloudSDK SharedInstance();

        // -(BOOL)sfmc_configureWithDictionary:(NSDictionary * _Nonnull)configuration error:(NSError * _Nullable * _Nullable)error;
        [Export("sfmc_configureWithDictionary:error:")]
        bool ConfigureWithDictionary(NSDictionary configuration, [NullAllowed] out NSError error);

        // -(BOOL)sfmc_configureWithDictionary:(NSDictionary * _Nonnull)configuration error:(NSError * _Nullable * _Nullable)error completionHandler:(void (^ _Nullable)(BOOL, NSString * _Nonnull, NSError * _Nonnull))completionHandler;
        [Export("sfmc_configureWithDictionary:error:completionHandler:")]
        bool ConfigureWithDictionary(NSDictionary configuration, [NullAllowed] out NSError error, [NullAllowed] Action<bool, NSString, NSError> completionHandler);

        // -(void)sfmc_tearDown;
        [Export("sfmc_tearDown")]
        void TearDown();

        // -(BOOL)sfmc_setContactKey:(NSString * _Nonnull)contactKey;
        [Export("sfmc_setContactKey:")]
        bool SetContactKey(string contactKey);

        // -(NSString * _Nullable)sfmc_contactKey;
        [NullAllowed, Export("sfmc_contactKey")]
        string ContactKey { get; }

        // -(BOOL)sfmc_addTag:(NSString * _Nonnull)tag;
        [Export("sfmc_addTag:")]
        bool AddTag(string tag);

        // -(BOOL)sfmc_removeTag:(NSString * _Nonnull)tag;
        [Export("sfmc_removeTag:")]
        bool RemoveTag(string tag);

        // -(NSSet * _Nullable)sfmc_addTags:(NSArray * _Nonnull)tags;
        [Export("sfmc_addTags:")]
        [return: NullAllowed]
        NSSet AddTags(NSObject[] tags);

        // -(NSSet * _Nullable)sfmc_removeTags:(NSArray * _Nonnull)tags;
        [Export("sfmc_removeTags:")]
        [return: NullAllowed]
        NSSet RemoveTags(NSObject[] tags);

        // -(NSSet * _Nullable)sfmc_tags;
        [NullAllowed, Export("sfmc_tags")]
        NSSet Tags { get; }

        // -(BOOL)sfmc_setAttributeNamed:(NSString * _Nonnull)name value:(NSString * _Nonnull)value;
        [Export("sfmc_setAttributeNamed:value:")]
        bool SetAttributeNamed(string name, string value);

        // -(BOOL)sfmc_clearAttributeNamed:(NSString * _Nonnull)name;
        [Export("sfmc_clearAttributeNamed:")]
        bool ClearAttributeNamed(string name);

        // -(NSDictionary * _Nullable)sfmc_attributes;
        [NullAllowed, Export("sfmc_attributes")]
        NSDictionary Attributes { get; }

        // -(NSDictionary * _Nullable)sfmc_setAttributes:(NSArray * _Nonnull)attributes;
        [Export("sfmc_setAttributes:")]
        [return: NullAllowed]
        NSDictionary SetAttributes(NSObject[] attributes);

        // -(NSDictionary * _Nullable)sfmc_clearAttributesNamed:(NSArray * _Nonnull)attributeNames;
        [Export("sfmc_clearAttributesNamed:")]
        [return: NullAllowed]
        NSDictionary ClearAttributesNamed(NSObject[] attributeNames);

        // -(void)sfmc_setDeviceToken:(NSData * _Nonnull)deviceToken;
        [Export("sfmc_setDeviceToken:")]
        void SetDeviceToken(NSData deviceToken);

        // -(NSString * _Nullable)sfmc_deviceToken;
        [NullAllowed, Export("sfmc_deviceToken")]
        string DeviceToken { get; }

        // -(NSString * _Nullable)sfmc_appID;
        [NullAllowed, Export("sfmc_appID")]
        string AppID { get; }

        // -(NSString * _Nullable)sfmc_accessToken;
        [NullAllowed, Export("sfmc_accessToken")]
        string AccessToken { get; }

        // -(NSString * _Nullable)sfmc_deviceIdentifier;
        [NullAllowed, Export("sfmc_deviceIdentifier")]
        string DeviceIdentifier { get; }

        // -(void)sfmc_setNotificationRequest:(UNNotificationRequest * _Nonnull)request __attribute__((availability(ios, introduced=10)));
        [Export("sfmc_setNotificationRequest:")]
        void SetNotificationRequest(UNNotificationRequest request);

        // -(UNNotificationRequest * _Nonnull)sfmc_notificationRequest __attribute__((availability(ios, introduced=10)));
        [Export("sfmc_notificationRequest")]
        UNNotificationRequest NotificationRequest { get; }

        // -(void)sfmc_setNotificationUserInfo:(NSDictionary * _Nonnull)userInfo;
        [Export("sfmc_setNotificationUserInfo:")]
        void SetNotificationUserInfo(NSDictionary userInfo);

        // -(NSDictionary * _Nonnull)sfmc_notificationUserInfo;
        [Export("sfmc_notificationUserInfo")]
        NSDictionary NotificationUserInfo { get; }

        // -(void)sfmc_setPushEnabled:(BOOL)pushEnabled;
        [Export("sfmc_setPushEnabled:")]
        void SetPushEnabled(bool pushEnabled);

        // -(BOOL)sfmc_pushEnabled;
        [Export("sfmc_pushEnabled")]
        bool PushEnabled { get; }

        // -(NSString * _Nullable)sfmc_getSDKState __attribute__((swift_name("sfmc_getSDKState()")));
        [NullAllowed, Export("sfmc_getSDKState")]
        string GetSDKState { get; }

        // -(void)sfmc_setDebugLoggingEnabled:(BOOL)enabled;
        [Export("sfmc_setDebugLoggingEnabled:")]
        void SetDebugLoggingEnabled(bool enabled);

        // -(BOOL)sfmc_getDebugLoggingEnabled;
        [Export("sfmc_getDebugLoggingEnabled")]
        bool GetDebugLoggingEnabled { get; }

        // -(BOOL)sfmc_refreshWithFetchCompletionHandler:(void (^ _Nullable)(UIBackgroundFetchResult))completionHandler;
        [Export("sfmc_refreshWithFetchCompletionHandler:")]
        bool RefreshWithFetchCompletionHandler([NullAllowed] Action<UIBackgroundFetchResult> completionHandler);

        // -(BOOL)sfmc_setSignedString:(NSString * _Nullable)signedString;
        [Export("sfmc_setSignedString:")]
        bool SetSignedString([NullAllowed] string signedString);

        // -(NSString * _Nullable)sfmc_signedString;
        [NullAllowed, Export("sfmc_signedString")]
        string SignedString { get; }

        // -(BOOL)sfmc_isReady;
        [Export("sfmc_isReady")]
        bool IsReady { get; }

        // -(BOOL)sfmc_isInitializing;
        [Export("sfmc_isInitializing")]
        bool IsInitializing { get; }
    }

    // @protocol MarketingCloudSDKEventDelegate <NSObject>
    [Protocol, Model(AutoGeneratedName = true)]
    [BaseType(typeof(NSObject))]
    interface MarketingCloudSDKEventDelegate
    {
        // @optional -(BOOL)sfmc_shouldShowInAppMessage:(NSDictionary * _Nonnull)message;
        [Export("sfmc_shouldShowInAppMessage:")]
        bool ShouldShowInAppMessage(NSDictionary message);

        // @optional -(void)sfmc_didShowInAppMessage:(NSDictionary * _Nonnull)message;
        [Export("sfmc_didShowInAppMessage:")]
        void DidShowInAppMessage(NSDictionary message);

        // @optional -(void)sfmc_didCloseInAppMessage:(NSDictionary * _Nonnull)message;
        [Export("sfmc_didCloseInAppMessage:")]
        void DidCloseInAppMessage(NSDictionary message);
    }

    // @interface Events (MarketingCloudSDK)
    [Category]
    [BaseType(typeof(MarketingCloudSDK))]
    interface MarketingCloudSDK_Events
    {
        // -(void)sfmc_setEventDelegate:(id<MarketingCloudSDKEventDelegate> _Nullable)delegate;
        [Export("sfmc_setEventDelegate:")]
        void SetEventDelegate([NullAllowed] MarketingCloudSDKEventDelegate @delegate);

        // -(NSString * _Nullable)sfmc_messageIdForMessage:(NSDictionary * _Nonnull)message;
        [Export("sfmc_messageIdForMessage:")]
        [return: NullAllowed]
        string MessageIdForMessage(NSDictionary message);

        // -(void)sfmc_showInAppMessage:(NSString * _Nonnull)messageId;
        [Export("sfmc_showInAppMessage:")]
        void ShowInAppMessage(string messageId);

        // -(BOOL)sfmc_setInAppMessageFontName:(NSString * _Nullable)fontName;
        [Export("sfmc_setInAppMessageFontName:")]
        bool SetInAppMessageFontName([NullAllowed] string fontName);

        // -(void)sfmc_track:(id _Nullable)events;
        [Export("sfmc_track:")]
        void Track([NullAllowed] NSObject events);
    }

    // @interface MarketingCloudSDKInboxMessagesDataSource : NSObject <UITableViewDataSource>
    [BaseType(typeof(NSObject))]
    interface MarketingCloudSDKInboxMessagesDataSource : IUITableViewDataSource
    {
        // -(id _Nullable)initWithMarketingCloudSDK:(MarketingCloudSDK * _Nonnull)sdk tableView:(UITableView * _Nonnull)tableView;
        [Export("initWithMarketingCloudSDK:tableView:")]
        IntPtr Constructor(MarketingCloudSDK sdk, UITableView tableView);
    }

    // @interface MarketingCloudSDKInboxMessagesDelegate : NSObject <UITableViewDelegate>
    [BaseType(typeof(NSObject))]
    interface MarketingCloudSDKInboxMessagesDelegate : IUITableViewDelegate
    {
        // -(id _Nullable)initWithMarketingCloudSDK:(MarketingCloudSDK * _Nonnull)sdk tableView:(UITableView * _Nonnull)tableView dataSource:(MarketingCloudSDKInboxMessagesDataSource * _Nonnull)dataSource;
        [Export("initWithMarketingCloudSDK:tableView:dataSource:")]
        IntPtr Constructor(MarketingCloudSDK sdk, UITableView tableView, MarketingCloudSDKInboxMessagesDataSource dataSource);
    }

    // @interface InboxMessages (MarketingCloudSDK)
    [Category]
    [BaseType(typeof(MarketingCloudSDK))]
    interface MarketingCloudSDK_InboxMessages
    {
        // -(NSArray * _Nullable)sfmc_getAllMessages;
        [Export("sfmc_getAllMessages")]
        NSObject[] GetAllMessages();

        // -(NSArray * _Nullable)sfmc_getUnreadMessages;
        [Export("sfmc_getUnreadMessages")]
        NSObject[] GetUnreadMessages();

        //-(NSArray * _Nullable) sfmc_getReadMessages;
        [Export("sfmc_getReadMessages")]
        NSObject[] GetReadMessages();

        // -(NSArray * _Nullable)sfmc_getDeletedMessages;
        [Export("sfmc_getDeletedMessages")]
        NSObject[] GetDeletedMessages();

        // -(NSUInteger)sfmc_getAllMessagesCount;
        [Export("sfmc_getAllMessagesCount")]
        nuint GetAllMessagesCount();

        // -(NSUInteger)sfmc_getUnreadMessagesCount;
        [Export("sfmc_getUnreadMessagesCount")]
        nuint GetUnreadMessagesCount();

        // -(NSUInteger)sfmc_getReadMessagesCount;
        [Export("sfmc_getReadMessagesCount")]
        nuint GetReadMessagesCount();

        // -(NSUInteger)sfmc_getDeletedMessagesCount;
        [Export("sfmc_getDeletedMessagesCount")]
        nuint GetDeletedMessagesCount();

        // -(BOOL)sfmc_markMessageRead:(NSDictionary * _Nonnull)messageDictionary;
        [Export("sfmc_markMessageRead:")]
        bool MarkMessageRead(NSDictionary messageDictionary);

        // -(BOOL)sfmc_markMessageDeleted:(NSDictionary * _Nonnull)messageDictionary;
        [Export("sfmc_markMessageDeleted:")]
        bool MarkMessageDeleted(NSDictionary messageDictionary);

        // -(BOOL)sfmc_markMessageWithIdRead:(NSString * _Nonnull)messageId;
        [Export("sfmc_markMessageWithIdRead:")]
        bool MarkMessageWithIdRead(string messageId);

        // -(BOOL)sfmc_markMessageWithIdDeleted:(NSString * _Nonnull)messageId;
        [Export("sfmc_markMessageWithIdDeleted:")]
        bool MarkMessageWithIdDeleted(string messageId);

        // -(BOOL)sfmc_markAllMessagesRead;
        [Export("sfmc_markAllMessagesRead")]
        bool MarkAllMessagesRead();

        // -(BOOL)sfmc_markAllMessagesDeleted;
        [Export("sfmc_markAllMessagesDeleted")]
        bool MarkAllMessagesDeleted();

        // -(BOOL)sfmc_refreshMessages;
        [Export("sfmc_refreshMessages")]
        bool RefreshMessages();

        // -(MarketingCloudSDKInboxMessagesDataSource * _Nullable)sfmc_inboxMessagesTableViewDataSourceForTableView:(UITableView * _Nonnull)tableView;
        [Export("sfmc_inboxMessagesTableViewDataSourceForTableView:")]
        [return: NullAllowed]
        MarketingCloudSDKInboxMessagesDataSource InboxMessagesTableViewDataSourceForTableView(UITableView tableView);

        // -(MarketingCloudSDKInboxMessagesDelegate * _Nullable)sfmc_inboxMessagesTableViewDelegateForTableView:(UITableView * _Nonnull)tableView dataSource:(MarketingCloudSDKInboxMessagesDataSource * _Nonnull)dataSource;
        [Export("sfmc_inboxMessagesTableViewDelegateForTableView:dataSource:")]
        [return: NullAllowed]
        MarketingCloudSDKInboxMessagesDelegate InboxMessagesTableViewDelegateForTableView(UITableView tableView, MarketingCloudSDKInboxMessagesDataSource dataSource);
    }

    // @protocol MarketingCloudSDKLocationDelegate<NSObject>
    [Protocol, Model(AutoGeneratedName = true)]
    [BaseType(typeof(NSObject))]
    interface MarketingCloudSDKLocationDelegate
    {
        // @required -(BOOL)sfmc_shouldShowLocationMessage:(NSDictionary * _Nonnull)message forRegion:(NSDictionary * _Nonnull)region;
        [Abstract]
        [Export("sfmc_shouldShowLocationMessage:forRegion:")]
        bool ForRegion(NSDictionary message, NSDictionary region);
    }

    // @interface Location (MarketingCloudSDK)
    [Category]
    [BaseType(typeof(MarketingCloudSDK))]
    interface MarketingCloudSDK_Location
    {
        // -(void)sfmc_setLocationDelegate:(id<MarketingCloudSDKLocationDelegate> _Nullable)delegate;
        [Export("sfmc_setLocationDelegate:")]
        void SetLocationDelegate([NullAllowed] MarketingCloudSDKLocationDelegate @delegate);

        // -(CLRegion * _Nullable)sfmc_regionFromDictionary:(NSDictionary * _Nonnull)dictionary;
        [Export("sfmc_regionFromDictionary:")]
        [return: NullAllowed]
        CLRegion RegionFromDictionary(NSDictionary dictionary);

        // -(BOOL)sfmc_locationEnabled;
        [Export("sfmc_locationEnabled")]
        bool LocationEnabled();

        // -(void)sfmc_startWatchingLocation;
        [Export("sfmc_startWatchingLocation")]
        void StartWatchingLocation();

        // -(void)sfmc_stopWatchingLocation;
        [Export("sfmc_stopWatchingLocation")]
        void StopWatchingLocation();

        // -(BOOL)sfmc_watchingLocation;
        [Export("sfmc_watchingLocation")]
        bool SatchingLocation();

        // -(NSDictionary<NSString *,NSString *> * _Nullable)sfmc_lastKnownLocation;
        [Export("sfmc_lastKnownLocation")]
        NSDictionary<NSString, NSString> LastKnownLocation();
    }

    // @protocol MarketingCloudSDKURLHandlingDelegate <NSObject>
    [Protocol, Model(AutoGeneratedName = true)]
    [BaseType(typeof(NSObject))]
    interface MarketingCloudSDKURLHandlingDelegate
    {
        // @required -(void)sfmc_handleURL:(NSURL * _Nonnull)url type:(NSString * _Nonnull)type;
        [Abstract]
        [Export("sfmc_handleURL:type:")]
        void Type(NSUrl url, string type);
    }

    // @interface URLHandling (MarketingCloudSDK)
    [Category]
    [BaseType(typeof(MarketingCloudSDK))]
    interface MarketingCloudSDK_URLHandling
    {
        // -(void)sfmc_setURLHandlingDelegate:(id<MarketingCloudSDKURLHandlingDelegate> _Nullable)delegate;
        [Export("sfmc_setURLHandlingDelegate:")]
        void SetURLHandlingDelegate([NullAllowed] MarketingCloudSDKURLHandlingDelegate @delegate);
    }

    // @interface MarketingCloudSDKConfigBuilder : NSObject
    [BaseType(typeof(NSObject))]
    interface MarketingCloudSDKConfigBuilder
    {
        // -(NSDictionary * _Nullable)sfmc_build;
        [Export("sfmc_build")]
        NSDictionary Build();

        // -(instancetype _Nonnull)sfmc_setApplicationId:(NSString * _Nonnull)setApplicationId;
        [Export("sfmc_setApplicationId:")]
        MarketingCloudSDKConfigBuilder SetApplicationId(string setApplicationId);

        // -(instancetype _Nonnull)sfmc_setAccessToken:(NSString * _Nonnull)setAccessToken;
        [Export("sfmc_setAccessToken:")]
        MarketingCloudSDKConfigBuilder SetAccessToken(string setAccessToken);

        // -(instancetype _Nonnull)sfmc_setLocationEnabled:(NSNumber * _Nonnull)setLocationEnabled;
        [Export("sfmc_setLocationEnabled:")]
        MarketingCloudSDKConfigBuilder SetLocationEnabled(NSNumber setLocationEnabled);

        // -(instancetype _Nonnull)sfmc_setInboxEnabled:(NSNumber * _Nonnull)setInboxEnabled;
        [Export("sfmc_setInboxEnabled:")]
        MarketingCloudSDKConfigBuilder SetInboxEnabled(NSNumber setInboxEnabled);

        // -(instancetype _Nonnull)sfmc_setPiAnalyticsEnabled:(NSNumber * _Nonnull)setPiAnalyticsEnabled;
        [Export("sfmc_setPiAnalyticsEnabled:")]
        MarketingCloudSDKConfigBuilder SetPiAnalyticsEnabled(NSNumber setPiAnalyticsEnabled);

        // -(instancetype _Nonnull)sfmc_setUseLegacyPIIdentifier:(NSNumber * _Nonnull)etUseLegacyPIIdentifier;
        [Export("sfmc_setUseLegacyPIIdentifier:")]
        MarketingCloudSDKConfigBuilder SetUseLegacyPIIdentifier(NSNumber etUseLegacyPIIdentifier);

        // -(instancetype _Nonnull)sfmc_setAnalyticsEnabled:(NSNumber * _Nonnull)setAnalyticsEnabled;
        [Export("sfmc_setAnalyticsEnabled:")]
        MarketingCloudSDKConfigBuilder SetAnalyticsEnabled(NSNumber setAnalyticsEnabled);

        // -(instancetype _Nonnull)sfmc_setMid:(NSString * _Nonnull)setMid;
        [Export("sfmc_setMid:")]
        MarketingCloudSDKConfigBuilder SetMid(string setMid);

        // -(instancetype _Nonnull)sfmc_setMarketingCloudServerUrl:(NSString * _Nonnull)setMarketingCloudServerUrl;
        [Export("sfmc_setMarketingCloudServerUrl:")]
        MarketingCloudSDKConfigBuilder SetMarketingCloudServerUrl(string setMarketingCloudServerUrl);

        // -(instancetype _Nonnull)sfmc_setApplicationControlsBadging:(NSNumber * _Nonnull)setApplicationControlsBadging;
        [Export("sfmc_setApplicationControlsBadging:")]
        MarketingCloudSDKConfigBuilder SetApplicationControlsBadging(NSNumber setApplicationControlsBadging);

        // -(instancetype _Nonnull)sfmc_setDelayRegistrationUntilContactKeyIsSet:(NSNumber * _Nonnull)delayRegistrationUntilContactKeyIsSet;
        [Export("sfmc_setDelayRegistrationUntilContactKeyIsSet:")]
        MarketingCloudSDKConfigBuilder SetDelayRegistrationUntilContactKeyIsSet(NSNumber delayRegistrationUntilContactKeyIsSet);
    }

}

