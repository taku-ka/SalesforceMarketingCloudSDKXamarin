using System;

using ObjCRuntime;
using Foundation;
using UIKit;
using UserNotifications;
using CoreLocation;
using SFMCiOS;

namespace SFMCiOS
{
    // @interface SFMCEncryptionKey : NSObject <NSCoding, NSCopying>
    [BaseType(typeof(NSObject))]
    interface SFMCEncryptionKey : INSCoding, INSCopying
    {
        // -(id _Nonnull)initWithData:(NSData * _Nonnull)keyData initializationVector:(NSData * _Nullable)iv;
        [Export("initWithData:initializationVector:")]
        IntPtr Constructor(NSData keyData, [NullAllowed] NSData iv);

        // +(SFMCEncryptionKey * _Nonnull)createKey;
        [Static]
        [Export("createKey")]
        SFMCEncryptionKey CreateKey { get; }

        // -(NSData * _Nullable)encryptData:(NSData * _Nonnull)dataToEncrypt;
        [Export("encryptData:")]
        [return: NullAllowed]
        NSData EncryptData(NSData dataToEncrypt);

        // -(NSData * _Nullable)decryptData:(NSData * _Nonnull)dataToDecrypt;
        [Export("decryptData:")]
        [return: NullAllowed]
        NSData DecryptData(NSData dataToDecrypt);

        // @property (copy, nonatomic) NSData * _Nullable key;
        [NullAllowed, Export("key", ArgumentSemantic.Copy)]
        NSData Key { get; set; }

        // @property (copy, nonatomic) NSData * _Nonnull initializationVector;
        [Export("initializationVector", ArgumentSemantic.Copy)]
        NSData InitializationVector { get; set; }

        // @property (readonly, nonatomic) NSString * _Nullable keyAsString;
        [NullAllowed, Export("keyAsString")]
        string KeyAsString { get; }

        // @property (readonly, nonatomic) NSString * _Nullable initializationVectorAsString;
        [NullAllowed, Export("initializationVectorAsString")]
        string InitializationVectorAsString { get; }
    }

    // @interface SFMCKeyStoreManager : NSObject
    [BaseType(typeof(NSObject))]
    interface SFMCKeyStoreManager
    {
        // +(instancetype _Nonnull)sharedInstance;
        [Static]
        [Export("sharedInstance")]
        SFMCKeyStoreManager SharedInstance();

        // -(SFMCEncryptionKey * _Nonnull)retrieveKeyWithLabel:(NSString * _Nonnull)keyLabel autoCreate:(BOOL)create;
        [Export("retrieveKeyWithLabel:autoCreate:")]
        SFMCEncryptionKey RetrieveKeyWithLabel(string keyLabel, bool create);

        // -(void)storeKey:(SFMCEncryptionKey * _Nonnull)key withLabel:(NSString * _Nonnull)keyLabel;
        [Export("storeKey:withLabel:")]
        void StoreKey(SFMCEncryptionKey key, string keyLabel);

        // -(void)removeKeyWithLabel:(NSString * _Nonnull)keyLabel;
        [Export("removeKeyWithLabel:")]
        void RemoveKeyWithLabel(string keyLabel);

        // -(BOOL)keyWithLabelExists:(NSString * _Nonnull)keyLabel;
        [Export("keyWithLabelExists:")]
        bool KeyWithLabelExists(string keyLabel);

        // -(BOOL)keyExists:(NSString * _Nonnull)keyLabel keychain:(NSString * _Nonnull)keychain;
        [Export("keyExists:keychain:")]
        bool KeyExists(string keyLabel, string keychain);

        // -(OSStatus)storeData:(NSData * _Nonnull)data forKey:(NSString * _Nonnull)key keychainID:(NSString * _Nonnull)keychain;
        [Export("storeData:forKey:keychainID:")]
        int StoreData(NSData data, string key, string keychain);

        // -(NSData * _Nullable)dataForKey:(NSString * _Nonnull)key keychainID:(NSString * _Nonnull)keychain;
        [Export("dataForKey:keychainID:")]
        [return: NullAllowed]
        NSData DataForKey(string key, string keychain);

        // -(BOOL)removeKeyChainWithID:(NSString * _Nonnull)keychain;
        [Export("removeKeyChainWithID:")]
        bool RemoveKeyChainWithID(string keychain);
    }

    partial interface Constants
    {
        // extern NSString *const _Nullable kSFKeychainItemExceptionType;
        [Field("kSFKeychainItemExceptionType", "__Internal")]
        [NullAllowed]
        NSString kSFKeychainItemExceptionType { get; }

        // extern NSString *const _Nullable kSFKeychainItemExceptionErrorCodeKey;
        [Field("kSFKeychainItemExceptionErrorCodeKey", "__Internal")]
        [NullAllowed]
        NSString kSFKeychainItemExceptionErrorCodeKey { get; }
    }

    // @interface SFMCKeychainItemWrapper : NSObject
    [BaseType(typeof(NSObject))]
    interface SFMCKeychainItemWrapper
    {
        // +(SFMCKeychainItemWrapper * _Nullable)itemWithIdentifier:(NSString * _Nullable)identifier account:(NSString * _Nullable)account;
        [Static]
        [Export("itemWithIdentifier:account:")]
        [return: NullAllowed]
        SFMCKeychainItemWrapper ItemWithIdentifier([NullAllowed] string identifier, [NullAllowed] string account);

        // -(BOOL)resetKeychainItem;
        [Export("resetKeychainItem")]
        bool ResetKeychainItem { get; }

        // -(OSStatus)setValueData:(NSData * _Nullable)data;
        [Export("setValueData:")]
        int SetValueData([NullAllowed] NSData data);

        // -(NSString * _Nullable)valueString;
        [NullAllowed, Export("valueString")]
        string ValueString { get; }

        // -(OSStatus)setValueString:(NSString * _Nullable)string;
        [Export("setValueString:")]
        int SetValueString([NullAllowed] string @string);

        // -(NSData * _Nullable)valueData;
        [NullAllowed, Export("valueData")]
        NSData ValueData { get; }

        // +(NSString * _Nullable)keychainErrorCodeString:(OSStatus)errorCode;
        [Static]
        [Export("keychainErrorCodeString:")]
        [return: NullAllowed]
        string KeychainErrorCodeString(int errorCode);


        //TODO Causing Crash
        //// +(BOOL)updateKeychainAccessibleAttribute:(CFTypeRef _Nonnull)accessibleAttributeToUpdate;
        //[Static]
        //[Export("updateKeychainAccessibleAttribute:")]
        //unsafe bool UpdateKeychainAccessibleAttribute(void* accessibleAttributeToUpdate);
    }

    // @interface  (UIViewController)
    [Category]
    [BaseType(typeof(UIViewController))]
    interface UIViewController_
    {
        // +(void)swizzleViewDidAppearForScreenTracking;
        [Static]
        [Export("swizzleViewDidAppearForScreenTracking")]
        void SwizzleViewDidAppearForScreenTracking();
    }

    partial interface Constants
    {
        // extern double SFMCSdkVersionNumber;
        [Field("SFMCSdkVersionNumber", "__Internal")]
        double SFMCSdkVersionNumber { get; }

        // extern const unsigned char[] SFMCSdkVersionString;
        [Field("SFMCSdkVersionString", "__Internal")]
        byte[] SFMCSdkVersionString { get; }
    }

    // @protocol SFMCSdkEvent
    /*
      Check whether adding [Model] to this declaration is appropriate.
      [Model] is used to generate a C# class that implements this protocol,
      and might be useful for protocols that consumers are supposed to implement,
      since consumers can subclass the generated class instead of implementing
      the generated interface. If consumers are not supposed to implement this
      protocol, then [Model] is redundant and will generate code that will never
      be used.
    */
    [Protocol]
    [BaseType(typeof(NSObject), Name = "SFMCSdkEvent")]
    interface SFMCSdkEvent
    {
        // @required @property (readonly, copy, nonatomic) NSString * _Nonnull id;
        [Abstract]
        [Export("id")]
        string Id { get; }

        // @required @property (readonly, copy, nonatomic) NSString * _Nonnull name;
        [Abstract]
        [Export("name")]
        string Name { get; }

        // @required @property (readonly, nonatomic) enum SFMCSdkEventCategory category;
        [Abstract]
        [Export("category")]
        SFMCSdkEventCategory Category { get; }

        // @required @property (readonly, copy, nonatomic) NSDictionary<NSString *,id> * _Nullable attributes;
        [Abstract]
        [NullAllowed, Export("attributes", ArgumentSemantic.Copy)]
        NSDictionary<NSString, NSObject> Attributes { get; }
    }

    // @interface SFMCSdkEngagementEvent : NSObject <SFMCSdkEvent>
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface SFMCSdkEngagementEvent : SFMCSdkEvent
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull id;
        [Export("id")]
        string Id { get; }

        // @property (readonly, nonatomic) enum SFMCSdkEventCategory category;
        [Export("category")]
        SFMCSdkEventCategory Category { get; }

        // @property (readonly, copy, nonatomic) NSDictionary<NSString *,id> * _Nullable attributes;
        [NullAllowed, Export("attributes", ArgumentSemantic.Copy)]
        NSDictionary<NSString, NSObject> Attributes { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull name;
        [Export("name")]
        string Name { get; }
    }

    // @interface SFMCSdkCartEvent : SFMCSdkEngagementEvent
    [BaseType(typeof(SFMCSdkEngagementEvent))]
    interface SFMCSdkCartEvent
    {
        // @property (readonly, copy, nonatomic) NSArray<SFMCSdkLineItem *> * _Nonnull lineItems;
        [Export("lineItems", ArgumentSemantic.Copy)]
        SFMCSdkLineItem[] LineItems { get; }
    }

    // @interface SFMCSdkAddToCartEvent : SFMCSdkCartEvent
    [BaseType(typeof(SFMCSdkCartEvent))]
    interface SFMCSdkAddToCartEvent
    {
        // -(instancetype _Nonnull)initWithLineItem:(SFMCSdkLineItem * _Nonnull)lineItem __attribute__((objc_designated_initializer));
        [Export("initWithLineItem:")]
        [DesignatedInitializer]
        IntPtr Constructor(SFMCSdkLineItem lineItem);
    }

    // @interface SFMCSdkBehavior : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface SFMCSdkBehavior
    {
    }

    // @interface SFMCSdkAppBackgrounded : SFMCSdkBehavior
    [BaseType(typeof(SFMCSdkBehavior))]
    interface SFMCSdkAppBackgrounded
    {
    }

    // @interface SFMCSdkAppForegrounded : SFMCSdkBehavior
    [BaseType(typeof(SFMCSdkBehavior))]
    interface SFMCSdkAppForegrounded
    {
    }

    // @interface SFMCSdkAppVersionChanged : SFMCSdkBehavior
    [BaseType(typeof(SFMCSdkBehavior))]
    interface SFMCSdkAppVersionChanged
    {
    }

    // @interface SFMCSdkAuthHeader : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface SFMCSdkAuthHeader
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull key;
        [Export("key")]
        string Key { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull value;
        [Export("value")]
        string Value { get; }

        // -(instancetype _Nonnull)initWithKey:(NSString * _Nonnull)key value:(NSString * _Nonnull)value __attribute__((objc_designated_initializer));
        [Export("initWithKey:value:")]
        [DesignatedInitializer]
        IntPtr Constructor(string key, string value);
    }

    // @protocol SFMCSdkAuthenticator
    /*
      Check whether adding [Model] to this declaration is appropriate.
      [Model] is used to generate a C# class that implements this protocol,
      and might be useful for protocols that consumers are supposed to implement,
      since consumers can subclass the generated class instead of implementing
      the generated interface. If consumers are not supposed to implement this
      protocol, then [Model] is redundant and will generate code that will never
      be used.
    */
    [Protocol]
    [BaseType(typeof(NSObject), Name = "SFMCSdkAuthenticator")]
    interface SFMCSdkAuthenticator
    {
        // @required @property (readonly, nonatomic, strong) NSLock * _Nonnull lock;
        [Abstract]
        [Export("lock", ArgumentSemantic.Strong)]
        NSLock Lock { get; }

        // @required -(SFMCSdkAuthHeader * _Nullable)getCachedTokenHeader __attribute__((warn_unused_result("")));
        [Abstract]
        [NullAllowed, Export("getCachedTokenHeader")]
        SFMCSdkAuthHeader CachedTokenHeader { get; }

        // @required -(SFMCSdkAuthHeader * _Nullable)refreshAuthTokenHeader __attribute__((warn_unused_result("")));
        [Abstract]
        [NullAllowed, Export("refreshAuthTokenHeader")]
        SFMCSdkAuthHeader RefreshAuthTokenHeader { get; }

        // @required -(void)deleteCachedToken;
        [Abstract]
        [Export("deleteCachedToken")]
        void DeleteCachedToken();
    }

    // @interface SFMCSdkBehaviorManager : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface SFMCSdkBehaviorManager
    {
    }

    // @protocol SFMCSdkBehaviorObserver
    /*
      Check whether adding [Model] to this declaration is appropriate.
      [Model] is used to generate a C# class that implements this protocol,
      and might be useful for protocols that consumers are supposed to implement,
      since consumers can subclass the generated class instead of implementing
      the generated interface. If consumers are not supposed to implement this
      protocol, then [Model] is redundant and will generate code that will never
      be used.
    */
    [Protocol]
    interface SFMCSdkBehaviorObserver
    {
        // @required @property (readonly, copy, nonatomic) NSSet<NSNumber *> * _Nonnull behaviorTypesToObserve;
        [Abstract]
        [Export("behaviorTypesToObserve", ArgumentSemantic.Copy)]
        NSSet<NSNumber> BehaviorTypesToObserve { get; }

        // @required -(void)onBehaviorWithBehavior:(SFMCSdkBehavior * _Nonnull)behavior;
        [Abstract]
        [Export("onBehaviorWithBehavior:")]
        void OnBehaviorWithBehavior(SFMCSdkBehavior behavior);
    }

    // @protocol CdpInterface
    /*
      Check whether adding [Model] to this declaration is appropriate.
      [Model] is used to generate a C# class that implements this protocol,
      and might be useful for protocols that consumers are supposed to implement,
      since consumers can subclass the generated class instead of implementing
      the generated interface. If consumers are not supposed to implement this
      protocol, then [Model] is redundant and will generate code that will never
      be used.
    */
    [Protocol(Name = "_TtP7SFMCSDK12CdpInterface_")]
    interface CdpInterface
    {
        // @required -(enum SFMCSdkConsent)getConsent __attribute__((warn_unused_result("")));
        [Abstract]
        [Export("getConsent")]
        SFMCSdkConsent Consent { get; }

        // @required -(void)setConsentWithConsent:(enum SFMCSdkConsent)consent;
        [Abstract]
        [Export("setConsentWithConsent:")]
        void SetConsentWithConsent(SFMCSdkConsent consent);

        // @required -(void)setLocationWithCoordinates:(id<SFMCSdkCoordinates> _Nullable)coordinates expiresIn:(NSInteger)expiresIn;
        [Abstract]
        [Export("setLocationWithCoordinates:expiresIn:")]
        void SetLocationWithCoordinates([NullAllowed] SFMCSdkCoordinates coordinates, nint expiresIn);

        // @required -(id<SFMCSdkModuleIdentity> _Nullable)getIdentity __attribute__((warn_unused_result("")));
        [Abstract]
        [NullAllowed, Export("getIdentity")]
        SFMCSdkModuleIdentity Identity { get; }
    }

    // @interface SFMCSdkCDP : NSObject <CdpInterface>
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface SFMCSdkCDP : CdpInterface
    {
        // -(enum SFMCSdkModuleStatus)getStatus __attribute__((warn_unused_result("")));
        [Export("getStatus")]
        SFMCSdkModuleStatus Status { get; }

        // -(id<SFMCSdkModuleIdentity> _Nullable)getIdentity __attribute__((warn_unused_result("")));
        [NullAllowed, Export("getIdentity")]
        SFMCSdkModuleIdentity Identity { get; }

        // -(enum SFMCSdkConsent)getConsent __attribute__((warn_unused_result("")));
        [Export("getConsent")]
        SFMCSdkConsent Consent { get; }

        // -(void)setConsentWithConsent:(enum SFMCSdkConsent)consent;
        [Export("setConsentWithConsent:")]
        void SetConsentWithConsent(SFMCSdkConsent consent);

        // -(void)setLocationWithCoordinates:(id<SFMCSdkCoordinates> _Nullable)coordinates expiresIn:(NSInteger)expiresIn;
        [Export("setLocationWithCoordinates:expiresIn:")]
        void SetLocationWithCoordinates([NullAllowed] SFMCSdkCoordinates coordinates, nint expiresIn);
    }

    // @interface SFMCSdkOrderEvent : SFMCSdkEngagementEvent
    [BaseType(typeof(SFMCSdkEngagementEvent))]
    interface SFMCSdkOrderEvent
    {
        // @property (readonly, nonatomic, strong) SFMCSdkOrder * _Nonnull order;
        [Export("order", ArgumentSemantic.Strong)]
        SFMCSdkOrder Order { get; }
    }

    // @interface SFMCSdkCancelOrderEvent : SFMCSdkOrderEvent
    [BaseType(typeof(SFMCSdkOrderEvent))]
    interface SFMCSdkCancelOrderEvent
    {
        // -(instancetype _Nonnull)initWithOrder:(SFMCSdkOrder * _Nonnull)order __attribute__((objc_designated_initializer));
        [Export("initWithOrder:")]
        [DesignatedInitializer]
        IntPtr Constructor(SFMCSdkOrder order);
    }

    // @interface SFMCSdkCatalogObject : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface SFMCSdkCatalogObject
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull type;
        [Export("type")]
        string Type { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull id;
        [Export("id")]
        string Id { get; }

        // @property (readonly, copy, nonatomic) NSDictionary<NSString *,id> * _Nonnull attributes;
        [Export("attributes", ArgumentSemantic.Copy)]
        NSDictionary<NSString, NSObject> Attributes { get; }

        // @property (readonly, copy, nonatomic) NSDictionary<NSString *,NSArray<NSString *> *> * _Nonnull relatedCatalogObjects;
        [Export("relatedCatalogObjects", ArgumentSemantic.Copy)]
        NSDictionary<NSString, NSArray<NSString>> RelatedCatalogObjects { get; }

        // -(instancetype _Nonnull)initWithType:(NSString * _Nonnull)type id:(NSString * _Nonnull)id attributes:(NSDictionary<NSString *,id> * _Nonnull)attributes relatedCatalogObjects:(NSDictionary<NSString *,NSArray<NSString *> *> * _Nonnull)relatedCatalogObjects __attribute__((objc_designated_initializer));
        [Export("initWithType:id:attributes:relatedCatalogObjects:")]
        [DesignatedInitializer]
        IntPtr Constructor(string type, string id, NSDictionary<NSString, NSObject> attributes, NSDictionary<NSString, NSArray<NSString>> relatedCatalogObjects);
    }

    // @interface SFMCSdkCatalogObjectEvent : SFMCSdkEngagementEvent
    [BaseType(typeof(SFMCSdkEngagementEvent))]
    interface SFMCSdkCatalogObjectEvent
    {
        // @property (readonly, nonatomic, strong) SFMCSdkCatalogObject * _Nonnull catalogObject;
        [Export("catalogObject", ArgumentSemantic.Strong)]
        SFMCSdkCatalogObject CatalogObject { get; }
    }

    // @interface SFMCSdkCommentCatalogObjectEvent : SFMCSdkCatalogObjectEvent
    [BaseType(typeof(SFMCSdkCatalogObjectEvent))]
    interface SFMCSdkCommentCatalogObjectEvent
    {
        // -(instancetype _Nonnull)initWithCatalogObject:(SFMCSdkCatalogObject * _Nonnull)catalogObject __attribute__((objc_designated_initializer));
        [Export("initWithCatalogObject:")]
        [DesignatedInitializer]
        IntPtr Constructor(SFMCSdkCatalogObject catalogObject);
    }

    // @interface SFMCSdkCompatibility : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface SFMCSdkCompatibility
    {
    }

    // @interface SFMCSdkCompletedCall : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface SFMCSdkCompletedCall
    {
        // @property (readonly, nonatomic, strong) SFMCSdkWrappedRequest * _Nonnull wrappedRequest;
        [Export("wrappedRequest", ArgumentSemantic.Strong)]
        SFMCSdkWrappedRequest WrappedRequest { get; }

        // @property (readonly, nonatomic, strong) SFMCSdkWrappedResponse * _Nonnull wrappedResponse;
        [Export("wrappedResponse", ArgumentSemantic.Strong)]
        SFMCSdkWrappedResponse WrappedResponse { get; }

        // -(instancetype _Nonnull)init:(SFMCSdkWrappedRequest * _Nonnull)wrappedRequest :(SFMCSdkWrappedResponse * _Nonnull)wrappedResponse __attribute__((objc_designated_initializer));
        [Export("init::")]
        [DesignatedInitializer]
        IntPtr Constructor(SFMCSdkWrappedRequest wrappedRequest, SFMCSdkWrappedResponse wrappedResponse);
    }

    // @interface SFMCSdkConfig : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface SFMCSdkConfig
    {
    }

    // @interface SFMCSdkConfigBuilder : NSObject
    [BaseType(typeof(NSObject))]
    interface SFMCSdkConfigBuilder
    {
        // -(SFMCSdkConfigBuilder * _Nonnull)setCdpWithConfig:(id<SFMCSdkModuleConfig> _Nonnull)config onCompletion:(void (^ _Nullable)(enum SFMCSdkOperationResult))onCompletion __attribute__((warn_unused_result("")));
        [Export("setCdpWithConfig:onCompletion:")]
        SFMCSdkConfigBuilder SetCdpWithConfig(SFMCSdkModuleConfig config, [NullAllowed] Action<SFMCSdkOperationResult> onCompletion);

        // -(SFMCSdkConfigBuilder * _Nonnull)setPushWithConfig:(id<SFMCSdkModuleConfig> _Nonnull)config onCompletion:(void (^ _Nullable)(enum SFMCSdkOperationResult))onCompletion __attribute__((warn_unused_result("")));
        [Export("setPushWithConfig:onCompletion:")]
        SFMCSdkConfigBuilder SetPushWithConfig(SFMCSdkModuleConfig config, [NullAllowed] Action<SFMCSdkOperationResult> onCompletion);

        // -(SFMCSdkConfig * _Nonnull)build __attribute__((warn_unused_result("")));
        [Export("build")]
        SFMCSdkConfig Build { get; }
    }

    // @protocol SFMCSdkCoordinates
    /*
      Check whether adding [Model] to this declaration is appropriate.
      [Model] is used to generate a C# class that implements this protocol,
      and might be useful for protocols that consumers are supposed to implement,
      since consumers can subclass the generated class instead of implementing
      the generated interface. If consumers are not supposed to implement this
      protocol, then [Model] is redundant and will generate code that will never
      be used.
    */
    [Protocol]
    [BaseType(typeof(NSObject), Name = "SFMCSdkCoordinates")]
    interface SFMCSdkCoordinates
    {
        // @required @property (readonly, nonatomic) double latitude;
        [Abstract]
        [Export("latitude")]
        double Latitude { get; }

        // @required @property (readonly, nonatomic) double longitude;
        [Abstract]
        [Export("longitude")]
        double Longitude { get; }
    }

    // @interface SFMCSdkCustomEvent : NSObject <SFMCSdkEvent>
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface SFMCSdkCustomEvent : SFMCSdkEvent
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull id;
        [Export("id")]
        string Id { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull name;
        [Export("name")]
        string Name { get; }

        // @property (readonly, nonatomic) enum SFMCSdkEventCategory category;
        [Export("category")]
        SFMCSdkEventCategory Category { get; }

        // @property (readonly, copy, nonatomic) NSDictionary<NSString *,id> * _Nullable attributes;
        [NullAllowed, Export("attributes", ArgumentSemantic.Copy)]
        NSDictionary<NSString, NSObject> Attributes { get; }

        // -(instancetype _Nullable)initWithName:(NSString * _Nonnull)name attributes:(NSDictionary<NSString *,id> * _Nullable)attributes __attribute__((objc_designated_initializer));
        [Export("initWithName:attributes:")]
        [DesignatedInitializer]
        IntPtr Constructor(string name, [NullAllowed] NSDictionary<NSString, NSObject> attributes);
    }

    // @interface SFMCSdkDeliverOrderEvent : SFMCSdkOrderEvent
    [BaseType(typeof(SFMCSdkOrderEvent))]
    interface SFMCSdkDeliverOrderEvent
    {
        // -(instancetype _Nonnull)initWithOrder:(SFMCSdkOrder * _Nonnull)order __attribute__((objc_designated_initializer));
        [Export("initWithOrder:")]
        [DesignatedInitializer]
        IntPtr Constructor(SFMCSdkOrder order);
    }

    // @interface SFMCSdkEncryptionManager : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface SFMCSdkEncryptionManager
    {
        // -(NSData * _Nullable)encryptWithString:(NSString * _Nonnull)string __attribute__((warn_unused_result("")));
        [Export("encryptWithString:")]
        [return: NullAllowed]
        NSData EncryptWithString(string @string);

        // -(NSString * _Nullable)decryptWithStringData:(NSData * _Nonnull)stringData __attribute__((warn_unused_result("")));
        [Export("decryptWithStringData:")]
        [return: NullAllowed]
        string DecryptWithStringData(NSData stringData);
    }

    // @interface SFMCSdkEventBus : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface SFMCSdkEventBus
    {
        // +(void)publishWithProducer:(enum SFMCSdkMessageProducer)producer event:(id<SFMCSdkEvent> _Nonnull)event;
        [Static]
        [Export("publishWithProducer:event:")]
        void PublishWithProducer(SFMCSdkMessageProducer producer, SFMCSdkEvent @event);

        // +(void)publishToTarget:(enum SFMCSdkModuleName)target producer:(enum SFMCSdkMessageProducer)producer event:(id<SFMCSdkEvent> _Nonnull)event;
        [Static]
        [Export("publishToTarget:producer:event:")]
        void PublishToTarget(SFMCSdkModuleName target, SFMCSdkMessageProducer producer, SFMCSdkEvent @event);

        // +(void)subscribeWithSubscriber:(id<Subscriber> _Nonnull)subscriber;
        [Static]
        [Export("subscribeWithSubscriber:")]
        void SubscribeWithSubscriber(Subscriber subscriber);

        // +(void)unsubscribeWithSubscriber:(id<Subscriber> _Nonnull)subscriber;
        [Static]
        [Export("unsubscribeWithSubscriber:")]
        void UnsubscribeWithSubscriber(Subscriber subscriber);
    }

    // @interface SFMCSdkExchangeOrderEvent : SFMCSdkOrderEvent
    [BaseType(typeof(SFMCSdkOrderEvent))]
    interface SFMCSdkExchangeOrderEvent
    {
        // -(instancetype _Nonnull)initWithOrder:(SFMCSdkOrder * _Nonnull)order __attribute__((objc_designated_initializer));
        [Export("initWithOrder:")]
        [DesignatedInitializer]
        IntPtr Constructor(SFMCSdkOrder order);
    }

    // @interface SFMCSdkFakeEvent : NSObject <SFMCSdkEvent>
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface SFMCSdkFakeEvent : SFMCSdkEvent
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull id;
        [Export("id")]
        string Id { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull name;
        [Export("name")]
        string Name { get; }

        // @property (readonly, nonatomic) enum SFMCSdkEventCategory category;
        [Export("category")]
        SFMCSdkEventCategory Category { get; }

        // @property (readonly, copy, nonatomic) NSDictionary<NSString *,id> * _Nullable attributes;
        [NullAllowed, Export("attributes", ArgumentSemantic.Copy)]
        NSDictionary<NSString, NSObject> Attributes { get; }

        // -(instancetype _Nullable)initWithName:(NSString * _Nonnull)name __attribute__((objc_designated_initializer));
        [Export("initWithName:")]
        [DesignatedInitializer]
        IntPtr Constructor(string name);
    }

    // @interface SFMCSdkFavoriteCatalogObjectEvent : SFMCSdkCatalogObjectEvent
    [BaseType(typeof(SFMCSdkCatalogObjectEvent))]
    interface SFMCSdkFavoriteCatalogObjectEvent
    {
        // -(instancetype _Nonnull)initWithCatalogObject:(SFMCSdkCatalogObject * _Nonnull)catalogObject __attribute__((objc_designated_initializer));
        [Export("initWithCatalogObject:")]
        [DesignatedInitializer]
        IntPtr Constructor(SFMCSdkCatalogObject catalogObject);
    }

    // @interface SFMCSdkIDENTITY : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface SFMCSdkIDENTITY
    {
        // -(NSString * _Nonnull)toJson __attribute__((warn_unused_result("")));
        [Export("toJson")]
        string ToJson { get; }

        // -(void)setProfileId:(NSString * _Nonnull)profile;
        [Export("setProfileId:")]
        void SetProfileId(string profile);

        // -(void)setProfileIdWithProfile:(NSString * _Nonnull)profile rawModules:(NSArray<NSNumber *> * _Nonnull)rawModules;
        [Export("setProfileIdWithProfile:rawModules:")]
        void SetProfileIdWithProfile(string profile, NSNumber[] rawModules);

        // -(void)setProfileIdWithProfiles:(NSDictionary<NSNumber *,NSString *> * _Nonnull)profiles;
        [Export("setProfileIdWithProfiles:")]
        void SetProfileIdWithProfiles(NSDictionary<NSNumber, NSString> profiles);

        // -(void)clearProfileAttributeWithKey:(NSString * _Nonnull)key;
        [Export("clearProfileAttributeWithKey:")]
        void ClearProfileAttributeWithKey(string key);

        // -(void)clearProfileAttributesWithKeys:(NSArray<NSString *> * _Nonnull)keys;
        [Export("clearProfileAttributesWithKeys:")]
        void ClearProfileAttributesWithKeys(string[] keys);

        // -(void)setProfileAttributes:(NSDictionary<NSString *,NSString *> * _Nonnull)attributes;
        [Export("setProfileAttributes:")]
        void SetProfileAttributes(NSDictionary<NSString, NSString> attributes);

        // -(void)setProfileAttributesNamedWithAttributes:(NSDictionary<NSString *,NSString *> * _Nonnull)attributes rawModules:(NSArray<NSNumber *> * _Nonnull)rawModules;
        [Export("setProfileAttributesNamedWithAttributes:rawModules:")]
        void SetProfileAttributesNamedWithAttributes(NSDictionary<NSString, NSString> attributes, NSNumber[] rawModules);

        // -(void)setProfileAttributesNamed:(NSDictionary<NSNumber *,NSDictionary<NSString *,NSString *> *> * _Nonnull)attributes;
        [Export("setProfileAttributesNamed:")]
        void SetProfileAttributesNamed(NSDictionary<NSNumber, NSDictionary<NSString, NSString>> attributes);
    }

    // @protocol SFMCSdkIdentityEventProtocol <SFMCSdkEvent>
    /*
      Check whether adding [Model] to this declaration is appropriate.
      [Model] is used to generate a C# class that implements this protocol,
      and might be useful for protocols that consumers are supposed to implement,
      since consumers can subclass the generated class instead of implementing
      the generated interface. If consumers are not supposed to implement this
      protocol, then [Model] is redundant and will generate code that will never
      be used.
    */
    [Protocol]
    interface SFMCSdkIdentityEventProtocol : SFMCSdkEvent
    {
        // @required @property (readonly, copy, nonatomic) NSString * _Nullable profileId;
        [Abstract]
        [NullAllowed, Export("profileId")]
        string ProfileId { get; }

        // @required @property (readonly, copy, nonatomic) NSDictionary<NSString *,NSString *> * _Nullable profileAttributes;
        [Abstract]
        [NullAllowed, Export("profileAttributes", ArgumentSemantic.Copy)]
        NSDictionary<NSString, NSString> ProfileAttributes { get; }

        // @required @property (readonly, copy, nonatomic) NSDictionary<NSString *,id> * _Nullable attributes;
        [Abstract]
        [NullAllowed, Export("attributes", ArgumentSemantic.Copy)]
        NSDictionary<NSString, NSObject> Attributes { get; }
    }

    // @interface SFMCSdkIdentityEvent : NSObject <SFMCSdkIdentityEventProtocol>
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface SFMCSdkIdentityEvent : SFMCSdkIdentityEventProtocol
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull id;
        [Export("id")]
        string Id { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull name;
        [Export("name")]
        string Name { get; }

        // @property (readonly, nonatomic) enum SFMCSdkEventCategory category;
        [Export("category")]
        SFMCSdkEventCategory Category { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nullable profileId;
        [NullAllowed, Export("profileId")]
        string ProfileId { get; }

        // @property (readonly, copy, nonatomic) NSDictionary<NSString *,NSString *> * _Nullable profileAttributes;
        [NullAllowed, Export("profileAttributes", ArgumentSemantic.Copy)]
        NSDictionary<NSString, NSString> ProfileAttributes { get; }

        // @property (readonly, copy, nonatomic) NSDictionary<NSString *,id> * _Nullable attributes;
        [NullAllowed, Export("attributes", ArgumentSemantic.Copy)]
        NSDictionary<NSString, NSObject> Attributes { get; }

        // -(instancetype _Nonnull)initWithProfileId:(NSString * _Nonnull)profileId __attribute__((objc_designated_initializer));
        [Export("initWithProfileId:")]
        [DesignatedInitializer]
        IntPtr Constructor(string profileId);

        // -(instancetype _Nonnull)initWithProfileAttributes:(NSDictionary<NSString *,NSString *> * _Nonnull)profileAttributes __attribute__((objc_designated_initializer));
        [Export("initWithProfileAttributes:")]
        [DesignatedInitializer]
        IntPtr Constructor(NSDictionary<NSString, NSString> profileAttributes);

        // -(instancetype _Nonnull)initWithAttributes:(NSDictionary<NSString *,id> * _Nonnull)attributes __attribute__((objc_designated_initializer));
        [Export("initWithAttributes:")]
        [DesignatedInitializer]
        IntPtr Constructor(NSDictionary<NSString, NSObject> attributes);
    }

    // @protocol SFMCSdkInAppMessageEventDelegate
    [Protocol, Model(AutoGeneratedName = true)]
    [BaseType(typeof(NSObject), Name = "SFMCSdkInAppMessageEventDelegate")]
    interface SFMCSdkInAppMessageEventDelegate
    {
        // @optional -(BOOL)sfmc_shouldShowInAppMessage:(NSDictionary * _Nonnull)message __attribute__((warn_unused_result("")));
        [Export("sfmc_shouldShowInAppMessage:")]
        bool Sfmc_shouldShowInAppMessage(NSDictionary message);

        // @optional -(void)sfmc_didShowInAppMessage:(NSDictionary * _Nonnull)message;
        [Export("sfmc_didShowInAppMessage:")]
        void Sfmc_didShowInAppMessage(NSDictionary message);

        // @optional -(void)sfmc_didCloseInAppMessage:(NSDictionary * _Nonnull)message;
        [Export("sfmc_didCloseInAppMessage:")]
        void Sfmc_didCloseInAppMessage(NSDictionary message);
    }

    // @protocol SFMCSdkInboxMessagesDataSource <UITableViewDataSource>
    [Protocol, Model(AutoGeneratedName = true)]
    [BaseType(typeof(NSObject), Name = "SFMCSdkInboxMessagesDataSource")]
    interface SFMCSdkInboxMessagesDataSource : IUITableViewDataSource
    {
    }

    // @protocol SFMCSdkInboxMessagesDelegate <UITableViewDelegate>
    [Protocol, Model(AutoGeneratedName = true)]
    [BaseType(typeof(NSObject), Name = "SFMCSdkInboxMessagesDelegate")]
    interface SFMCSdkInboxMessagesDelegate : IUITableViewDelegate
    {
    }

    // @interface SFMCSdkLineItem : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface SFMCSdkLineItem
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull catalogObjectType;
        [Export("catalogObjectType")]
        string CatalogObjectType { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull catalogObjectId;
        [Export("catalogObjectId")]
        string CatalogObjectId { get; }

        // @property (readonly, nonatomic) NSInteger quantity;
        [Export("quantity")]
        nint Quantity { get; }

        // @property (readonly, nonatomic, strong) NSDecimalNumber * _Nullable price;
        [NullAllowed, Export("price", ArgumentSemantic.Strong)]
        NSDecimalNumber Price { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nullable currency;
        [NullAllowed, Export("currency")]
        string Currency { get; }

        // @property (readonly, copy, nonatomic) NSDictionary<NSString *,id> * _Nullable attributes;
        [NullAllowed, Export("attributes", ArgumentSemantic.Copy)]
        NSDictionary<NSString, NSObject> Attributes { get; }

        // -(instancetype _Nonnull)initWithCatalogObjectType:(NSString * _Nonnull)catalogObjectType catalogObjectId:(NSString * _Nonnull)catalogObjectId quantity:(NSInteger)quantity price:(NSDecimalNumber * _Nullable)price currency:(NSString * _Nullable)currency attributes:(NSDictionary<NSString *,id> * _Nonnull)attributes __attribute__((objc_designated_initializer));
        [Export("initWithCatalogObjectType:catalogObjectId:quantity:price:currency:attributes:")]
        [DesignatedInitializer]
        IntPtr Constructor(string catalogObjectType, string catalogObjectId, nint quantity, [NullAllowed] NSDecimalNumber price, [NullAllowed] string currency, NSDictionary<NSString, NSObject> attributes);
    }

    // @protocol SFMCSdkLocationDelegate
    [Protocol, Model(AutoGeneratedName = true)]
    [BaseType(typeof(NSObject), Name = "SFMCSdkLocationDelegate")]
    interface SFMCSdkLocationDelegate
    {
        // @required -(BOOL)sfmc_shouldShowLocationMessage:(NSDictionary * _Nonnull)message forRegion:(NSDictionary * _Nonnull)region __attribute__((warn_unused_result("")));
        [Abstract]
        [Export("sfmc_shouldShowLocationMessage:forRegion:")]
        bool ForRegion(NSDictionary message, NSDictionary region);
    }

    // @interface SFMCSdkLogOutputter : NSObject
    [BaseType(typeof(NSObject))]
    interface SFMCSdkLogOutputter
    {
        // -(void)outWithLevel:(enum SFMCSdkLogLevel)level subsystem:(NSString * _Nonnull)subsystem category:(enum SFMCSdkLoggerCategory)category message:(NSString * _Nonnull)message;
        [Export("outWithLevel:subsystem:category:message:")]
        void OutWithLevel(SFMCSdkLogLevel level, string subsystem, SFMCSdkLoggerCategory category, string message);
    }

    // @protocol Logger
    /*
      Check whether adding [Model] to this declaration is appropriate.
      [Model] is used to generate a C# class that implements this protocol,
      and might be useful for protocols that consumers are supposed to implement,
      since consumers can subclass the generated class instead of implementing
      the generated interface. If consumers are not supposed to implement this
      protocol, then [Model] is redundant and will generate code that will never
      be used.
    */
    [Protocol(Name = "_TtP7SFMCSDK6Logger_")]
    interface Logger
    {
        // @required @property (readonly, copy, nonatomic) NSArray<NSString *> * _Nonnull redactedValues;
        [Abstract]
        [Export("redactedValues", ArgumentSemantic.Copy)]
        string[] RedactedValues { get; }
    }

    // @interface SFMCSdkMessage : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface SFMCSdkMessage
    {
    }

    // @protocol SFMCSdkModuleConfig
    /*
      Check whether adding [Model] to this declaration is appropriate.
      [Model] is used to generate a C# class that implements this protocol,
      and might be useful for protocols that consumers are supposed to implement,
      since consumers can subclass the generated class instead of implementing
      the generated interface. If consumers are not supposed to implement this
      protocol, then [Model] is redundant and will generate code that will never
      be used.
    */
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface SFMCSdkModuleConfig
    {
        // @required @property (readonly, nonatomic) enum SFMCSdkModuleName name;
        [Abstract]
        [Export("name")]
        SFMCSdkModuleName Name { get; }

        // @required @property (readonly, copy, nonatomic) NSString * _Nonnull appId;
        [Abstract]
        [Export("appId")]
        string AppId { get; }

        // @required @property (readonly, nonatomic) BOOL trackScreens;
        [Abstract]
        [Export("trackScreens")]
        bool TrackScreens { get; }
    }

    // @protocol SFMCSdkModuleIdentity
    /*
      Check whether adding [Model] to this declaration is appropriate.
      [Model] is used to generate a C# class that implements this protocol,
      and might be useful for protocols that consumers are supposed to implement,
      since consumers can subclass the generated class instead of implementing
      the generated interface. If consumers are not supposed to implement this
      protocol, then [Model] is redundant and will generate code that will never
      be used.
    */
    [Protocol]
    [BaseType(typeof(NSObject), Name = "SFMCSdkModuleIdentity")]
    interface SFMCSdkModuleIdentity
    {
        // @required @property (readonly, copy, nonatomic) NSString * _Nonnull applicationId;
        [Abstract]
        [Export("applicationId")]
        string ApplicationId { get; }

        // @required @property (readonly, copy, nonatomic) NSString * _Nullable profileId;
        [Abstract]
        [NullAllowed, Export("profileId")]
        string ProfileId { get; }

        // @required @property (readonly, copy, nonatomic) NSString * _Nullable installationId;
        [Abstract]
        [NullAllowed, Export("installationId")]
        string InstallationId { get; }

        // @required @property (readonly, copy, nonatomic) NSDictionary<NSString *,id> * _Nullable customProperties;
        [Abstract]
        [NullAllowed, Export("customProperties", ArgumentSemantic.Copy)]
        NSDictionary<NSString, NSObject> CustomProperties { get; }

        // @required -(NSString * _Nullable)customPropertiesToJson __attribute__((warn_unused_result("")));
        [Abstract]
        [NullAllowed, Export("customPropertiesToJson")]
        string CustomPropertiesToJson { get; }
    }

    // @interface SFMCSdkModuleLogger : NSObject <Logger>
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface SFMCSdkModuleLogger : Logger
    {
        // @property (copy, nonatomic) NSArray<NSString *> * _Nonnull redactedValues;
        [Export("redactedValues", ArgumentSemantic.Copy)]
        string[] RedactedValues { get; set; }

        // -(instancetype _Nonnull)initWithModule:(enum SFMCSdkModuleName)module_ redactedValues:(NSArray<NSString *> * _Nonnull)redactedValues __attribute__((objc_designated_initializer));
        [Export("initWithModule:redactedValues:")]
        [DesignatedInitializer]
        IntPtr Constructor(SFMCSdkModuleName module_, string[] redactedValues);

        // -(void)setWithRedactedValues:(NSArray<NSString *> * _Nonnull)redactedValues;
        [Export("setWithRedactedValues:")]
        void SetWithRedactedValues(string[] redactedValues);

        // -(void)debugWithCategory:(enum SFMCSdkLoggerCategory)category message:(NSString * _Nonnull)message;
        [Export("debugWithCategory:message:")]
        void DebugWithCategory(SFMCSdkLoggerCategory category, string message);

        // -(void)warningWithCategory:(enum SFMCSdkLoggerCategory)category message:(NSString * _Nonnull)message;
        [Export("warningWithCategory:message:")]
        void WarningWithCategory(SFMCSdkLoggerCategory category, string message);

        // -(void)errorWithCategory:(enum SFMCSdkLoggerCategory)category message:(NSString * _Nonnull)message;
        [Export("errorWithCategory:message:")]
        void ErrorWithCategory(SFMCSdkLoggerCategory category, string message);

        // -(void)faultWithCategory:(enum SFMCSdkLoggerCategory)category message:(NSString * _Nonnull)message;
        [Export("faultWithCategory:message:")]
        void FaultWithCategory(SFMCSdkLoggerCategory category, string message);
    }

    // @interface SFMCSdkNetworkManager : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface SFMCSdkNetworkManager
    {
        // -(instancetype _Nonnull)initWithNetworkPreferences:(SFMCSdkSecurePrefs * _Nonnull)networkPreferences authenticator:(id<SFMCSdkAuthenticator> _Nullable)authenticator __attribute__((objc_designated_initializer));
        [Export("initWithNetworkPreferences:authenticator:")]
        [DesignatedInitializer]
        IntPtr Constructor(SFMCSdkSecurePrefs networkPreferences, [NullAllowed] SFMCSdkAuthenticator authenticator);

        // -(SFMCSdkCompletedCall * _Nonnull)executeSync:(SFMCSdkWrappedRequest * _Nonnull)wrappedRequest __attribute__((warn_unused_result("")));
        [Export("executeSync:")]
        SFMCSdkCompletedCall ExecuteSync(SFMCSdkWrappedRequest wrappedRequest);

        // -(void)executeAsync:(SFMCSdkWrappedRequest * _Nonnull)wrappedRequest completionHandler:(void (^ _Nonnull)(SFMCSdkCompletedCall * _Nonnull))completionHandler;
        [Export("executeAsync:completionHandler:")]
        void ExecuteAsync(SFMCSdkWrappedRequest wrappedRequest, Action<SFMCSdkCompletedCall> completionHandler);

        // -(BOOL)isBlockedByRetryAfter:(NSString * _Nonnull)requestName __attribute__((warn_unused_result("")));
        [Export("isBlockedByRetryAfter:")]
        bool IsBlockedByRetryAfter(string requestName);
    }

    // @interface SFMCSdkOrder : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface SFMCSdkOrder
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull id;
        [Export("id")]
        string Id { get; }

        // @property (readonly, copy, nonatomic) NSArray<SFMCSdkLineItem *> * _Nonnull lineItems;
        [Export("lineItems", ArgumentSemantic.Copy)]
        SFMCSdkLineItem[] LineItems { get; }

        // @property (readonly, nonatomic, strong) NSDecimalNumber * _Nullable totalValue;
        [NullAllowed, Export("totalValue", ArgumentSemantic.Strong)]
        NSDecimalNumber TotalValue { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nullable currency;
        [NullAllowed, Export("currency")]
        string Currency { get; }

        // @property (readonly, copy, nonatomic) NSDictionary<NSString *,id> * _Nonnull attributes;
        [Export("attributes", ArgumentSemantic.Copy)]
        NSDictionary<NSString, NSObject> Attributes { get; }

        // -(instancetype _Nonnull)initWithId:(NSString * _Nonnull)id lineItems:(NSArray<SFMCSdkLineItem *> * _Nonnull)lineItems totalValue:(NSDecimalNumber * _Nullable)totalValue currency:(NSString * _Nullable)currency attributes:(NSDictionary<NSString *,id> * _Nonnull)attributes __attribute__((objc_designated_initializer));
        [Export("initWithId:lineItems:totalValue:currency:attributes:")]
        [DesignatedInitializer]
        IntPtr Constructor(string id, SFMCSdkLineItem[] lineItems, [NullAllowed] NSDecimalNumber totalValue, [NullAllowed] string currency, NSDictionary<NSString, NSObject> attributes);
    }

    // @protocol PushInterface
    /*
      Check whether adding [Model] to this declaration is appropriate.
      [Model] is used to generate a C# class that implements this protocol,
      and might be useful for protocols that consumers are supposed to implement,
      since consumers can subclass the generated class instead of implementing
      the generated interface. If consumers are not supposed to implement this
      protocol, then [Model] is redundant and will generate code that will never
      be used.
    */
    [Protocol(Name = "_TtP7SFMCSDK13PushInterface_")]
    [BaseType(typeof(NSObject), Name = "PushInterface")]
    interface PushInterface
    {
        // @required -(id<SFMCSdkModuleIdentity> _Nullable)getIdentity __attribute__((warn_unused_result("")));
        [Abstract]
        [NullAllowed, Export("getIdentity")]
        SFMCSdkModuleIdentity Identity { get; }

        // @required -(void)tearDown;
        [Abstract]
        [Export("tearDown")]
        void TearDown();

        // @required -(NSString * _Nullable)contactKey __attribute__((warn_unused_result("")));
        [Abstract]
        [NullAllowed, Export("contactKey")]
        string ContactKey { get; }

        // @required -(BOOL)addTag:(NSString * _Nonnull)tag __attribute__((warn_unused_result("")));
        [Abstract]
        [Export("addTag:")]
        bool AddTag(string tag);

        // @required -(NSSet * _Nullable)addTags:(NSArray * _Nonnull)tags __attribute__((warn_unused_result("")));
        [Abstract]
        [Export("addTags:")]
        [return: NullAllowed]
        NSSet AddTags(NSObject[] tags);

        // @required -(BOOL)removeTag:(NSString * _Nonnull)tag __attribute__((warn_unused_result("")));
        [Abstract]
        [Export("removeTag:")]
        bool RemoveTag(string tag);

        // @required -(NSSet * _Nullable)tags __attribute__((warn_unused_result("")));
        [Abstract]
        [NullAllowed, Export("tags")]
        NSSet Tags { get; }

        // @required -(void)setDeviceToken:(NSData * _Nonnull)deviceToken;
        [Abstract]
        [Export("setDeviceToken:")]
        void SetDeviceToken(NSData deviceToken);

        // @required -(void)setDebugLoggingEnabled:(BOOL)enabled;
        [Abstract]
        [Export("setDebugLoggingEnabled:")]
        void SetDebugLoggingEnabled(bool enabled);

        // @required -(NSDictionary * _Nullable)attributes __attribute__((warn_unused_result("")));
        [Abstract]
        [NullAllowed, Export("attributes")]
        NSDictionary Attributes { get; }

        // @required -(NSString * _Nullable)deviceToken __attribute__((warn_unused_result("")));
        [Abstract]
        [NullAllowed, Export("deviceToken")]
        string DeviceToken { get; }

        // @required -(NSString * _Nullable)accessToken __attribute__((warn_unused_result("")));
        [Abstract]
        [NullAllowed, Export("accessToken")]
        string AccessToken { get; }

        // @required -(NSString * _Nullable)deviceIdentifier __attribute__((warn_unused_result("")));
        [Abstract]
        [NullAllowed, Export("deviceIdentifier")]
        string DeviceIdentifier { get; }

        // @required -(UNNotificationRequest * _Nullable)notificationRequest __attribute__((warn_unused_result("")));
        // @required -(void)setNotificationRequest:(UNNotificationRequest * _Nonnull)request;
        [Abstract]
        [NullAllowed, Export("notificationRequest")]
        UNNotificationRequest NotificationRequest { get; set; }

        // @required -(NSDictionary * _Nonnull)notificationUserInfo __attribute__((warn_unused_result("")));
        // @required -(void)setNotificationUserInfo:(NSDictionary * _Nonnull)userInfo;
        [Abstract]
        [Export("notificationUserInfo")]
        NSDictionary NotificationUserInfo { get; set; }

        // @required -(BOOL)pushEnabled __attribute__((warn_unused_result("")));
        // @required -(void)setPushEnabled:(BOOL)pushEnabled;
        [Abstract]
        [Export("pushEnabled")]
        bool PushEnabled { get; set; }

        // @required -(BOOL)refreshWithFetchCompletionHandler:(void (^ _Nullable)(UIBackgroundFetchResult))completionHandler __attribute__((warn_unused_result("")));
        [Abstract]
        [Export("refreshWithFetchCompletionHandler:")]
        bool RefreshWithFetchCompletionHandler([NullAllowed] Action<UIBackgroundFetchResult> completionHandler);

        // @required -(void)setRegistrationCallback:(void (^ _Nonnull)(NSDictionary * _Nonnull))registrationCallback;
        [Abstract]
        [Export("setRegistrationCallback:")]
        void SetRegistrationCallback(Action<NSDictionary> registrationCallback);

        // @required -(void)unsetRegistrationCallback;
        [Abstract]
        [Export("unsetRegistrationCallback")]
        void UnsetRegistrationCallback();

        // @required -(BOOL)setSignedString:(NSString * _Nullable)signedString __attribute__((warn_unused_result("")));
        [Abstract]
        [Export("setSignedString:")]
        bool SetSignedString([NullAllowed] string signedString);

        // @required -(NSString * _Nullable)signedString __attribute__((warn_unused_result("")));
        [Abstract]
        [NullAllowed, Export("signedString")]
        string SignedString { get; }

        // @required -(void)setEventDelegate:(id<SFMCSdkInAppMessageEventDelegate> _Nullable)delegate;
        [Abstract]
        [Export("setEventDelegate:")]
        void SetEventDelegate([NullAllowed] SFMCSdkInAppMessageEventDelegate @delegate);

        // @required -(NSString * _Nullable)messageIdForMessage:(NSDictionary * _Nonnull)forMessage __attribute__((warn_unused_result("")));
        [Abstract]
        [Export("messageIdForMessage:")]
        [return: NullAllowed]
        string MessageIdForMessage(NSDictionary forMessage);

        // @required -(void)showInAppMessageWithMessageId:(NSString * _Nonnull)messageId;
        [Abstract]
        [Export("showInAppMessageWithMessageId:")]
        void ShowInAppMessageWithMessageId(string messageId);

        // @required -(BOOL)setInAppMessageWithFontName:(NSString * _Nullable)fontName __attribute__((warn_unused_result("")));
        [Abstract]
        [Export("setInAppMessageWithFontName:")]
        bool SetInAppMessageWithFontName([NullAllowed] string fontName);

        // @required -(NSArray * _Nullable)getAllMessages __attribute__((warn_unused_result("")));
        [Abstract]
        [NullAllowed, Export("getAllMessages")]
        NSObject[] AllMessages { get; }

        // @required -(NSArray * _Nullable)getUnreadMessages __attribute__((warn_unused_result("")));
        [Abstract]
        [NullAllowed, Export("getUnreadMessages")]
        NSObject[] UnreadMessages { get; }

        // @required -(NSArray * _Nullable)getReadMessages __attribute__((warn_unused_result("")));
        [Abstract]
        [NullAllowed, Export("getReadMessages")]
        NSObject[] ReadMessages { get; }

        // @required -(NSArray * _Nullable)getDeletedMessages __attribute__((warn_unused_result("")));
        [Abstract]
        [NullAllowed, Export("getDeletedMessages")]
        NSObject[] DeletedMessages { get; }

        // @required -(NSUInteger)getAllMessagesCount __attribute__((warn_unused_result("")));
        [Abstract]
        [Export("getAllMessagesCount")]
        nuint AllMessagesCount { get; }

        // @required -(NSUInteger)getUnreadMessagesCount __attribute__((warn_unused_result("")));
        [Abstract]
        [Export("getUnreadMessagesCount")]
        nuint UnreadMessagesCount { get; }

        // @required -(NSUInteger)getReadMessagesCount __attribute__((warn_unused_result("")));
        [Abstract]
        [Export("getReadMessagesCount")]
        nuint ReadMessagesCount { get; }

        // @required -(NSUInteger)getDeletedMessagesCount __attribute__((warn_unused_result("")));
        [Abstract]
        [Export("getDeletedMessagesCount")]
        nuint DeletedMessagesCount { get; }

        // @required -(BOOL)markMessageRead:(NSDictionary * _Nonnull)messageDictionary __attribute__((warn_unused_result("")));
        [Abstract]
        [Export("markMessageRead:")]
        bool MarkMessageRead(NSDictionary messageDictionary);

        // @required -(BOOL)markMessageDeleted:(NSDictionary * _Nonnull)messageDictionary __attribute__((warn_unused_result("")));
        [Abstract]
        [Export("markMessageDeleted:")]
        bool MarkMessageDeleted(NSDictionary messageDictionary);

        // @required -(BOOL)markMessageWithIdReadWithMessageId:(NSString * _Nonnull)messageId __attribute__((warn_unused_result("")));
        [Abstract]
        [Export("markMessageWithIdReadWithMessageId:")]
        bool MarkMessageWithIdReadWithMessageId(string messageId);

        // @required -(BOOL)markMessageWithIdDeletedWithMessageId:(NSString * _Nonnull)messageId __attribute__((warn_unused_result("")));
        [Abstract]
        [Export("markMessageWithIdDeletedWithMessageId:")]
        bool MarkMessageWithIdDeletedWithMessageId(string messageId);

        // @required -(BOOL)markAllMessagesRead __attribute__((warn_unused_result("")));
        [Abstract]
        [Export("markAllMessagesRead")]
        bool MarkAllMessagesRead { get; }

        // @required -(BOOL)markAllMessagesDeleted __attribute__((warn_unused_result("")));
        [Abstract]
        [Export("markAllMessagesDeleted")]
        bool MarkAllMessagesDeleted { get; }

        // @required -(BOOL)refreshMessages __attribute__((warn_unused_result("")));
        [Abstract]
        [Export("refreshMessages")]
        bool RefreshMessages { get; }

        // @required -(id<SFMCSdkInboxMessagesDataSource> _Nullable)inboxMessagesTableViewDataSourceForTableView:(UITableView * _Nonnull)tableView __attribute__((warn_unused_result("")));
        [Abstract]
        [Export("inboxMessagesTableViewDataSourceForTableView:")]
        [return: NullAllowed]
        SFMCSdkInboxMessagesDataSource InboxMessagesTableViewDataSourceForTableView(UITableView tableView);

        // @required -(id<SFMCSdkInboxMessagesDelegate> _Nullable)inboxMessagesTableViewDelegateForTableView:(UITableView * _Nonnull)tableView dataSource:(id<SFMCSdkInboxMessagesDataSource> _Nonnull)dataSource __attribute__((warn_unused_result("")));
        [Abstract]
        [Export("inboxMessagesTableViewDelegateForTableView:dataSource:")]
        [return: NullAllowed]
        SFMCSdkInboxMessagesDelegate InboxMessagesTableViewDelegateForTableView(UITableView tableView, SFMCSdkInboxMessagesDataSource dataSource);

        // @required -(BOOL)setPiIdentifier:(NSString * _Nullable)identifier __attribute__((warn_unused_result("")));
        [Abstract]
        [Export("setPiIdentifier:")]
        bool SetPiIdentifier([NullAllowed] string identifier);

        // @required -(NSString * _Nullable)piIdentifier __attribute__((warn_unused_result("")));
        [Abstract]
        [NullAllowed, Export("piIdentifier")]
        string PiIdentifier { get; }

        // @required -(void)trackMessageOpened:(NSDictionary * _Nonnull)inboxMessage;
        [Abstract]
        [Export("trackMessageOpened:")]
        void TrackMessageOpened(NSDictionary inboxMessage);

        // @required -(void)trackPageViewWithUrl:(NSString * _Nonnull)url title:(NSString * _Nullable)title item:(NSString * _Nullable)item search:(NSString * _Nullable)search;
        [Abstract]
        [Export("trackPageViewWithUrl:title:item:search:")]
        void TrackPageViewWithUrl(string url, [NullAllowed] string title, [NullAllowed] string item, [NullAllowed] string search);

        // @required -(void)trackCartContents:(NSDictionary * _Nonnull)cartDictionary;
        [Abstract]
        [Export("trackCartContents:")]
        void TrackCartContents(NSDictionary cartDictionary);

        // @required -(void)trackCartConversion:(NSDictionary * _Nonnull)orderDictionary;
        [Abstract]
        [Export("trackCartConversion:")]
        void TrackCartConversion(NSDictionary orderDictionary);

        // @required -(NSDictionary * _Nullable)cartItemDictionaryWithPrice:(NSNumber * _Nonnull)price quantity:(NSNumber * _Nonnull)quantity item:(NSString * _Nonnull)item uniqueId:(NSString * _Nullable)uniqueId __attribute__((warn_unused_result("")));
        [Abstract]
        [Export("cartItemDictionaryWithPrice:quantity:item:uniqueId:")]
        [return: NullAllowed]
        NSDictionary CartItemDictionaryWithPrice(NSNumber price, NSNumber quantity, string item, [NullAllowed] string uniqueId);

        // @required -(NSDictionary * _Nullable)cartDictionaryWithCartItem:(NSArray * _Nonnull)cartItem __attribute__((warn_unused_result("")));
        [Abstract]
        [Export("cartDictionaryWithCartItem:")]
        [return: NullAllowed]
        NSDictionary CartDictionaryWithCartItem(NSObject[] cartItem);

        // @required -(NSDictionary * _Nullable)orderDictionaryWithOrderNumber:(NSString * _Nonnull)orderNumber shipping:(NSNumber * _Nonnull)shipping discount:(NSNumber * _Nonnull)discount cart:(NSDictionary * _Nonnull)cart __attribute__((warn_unused_result("")));
        [Abstract]
        [Export("orderDictionaryWithOrderNumber:shipping:discount:cart:")]
        [return: NullAllowed]
        NSDictionary OrderDictionaryWithOrderNumber(string orderNumber, NSNumber shipping, NSNumber discount, NSDictionary cart);

        // @required -(void)setLocationDelegate:(id<SFMCSdkLocationDelegate> _Nullable)delegate;
        [Abstract]
        [Export("setLocationDelegate:")]
        void SetLocationDelegate([NullAllowed] SFMCSdkLocationDelegate @delegate);

        // @required -(CLRegion * _Nullable)regionFromDictionary:(NSDictionary * _Nonnull)dictionary __attribute__((warn_unused_result("")));
        [Abstract]
        [Export("regionFromDictionary:")]
        [return: NullAllowed]
        CLRegion RegionFromDictionary(NSDictionary dictionary);

        // @required -(BOOL)locationEnabled __attribute__((warn_unused_result("")));
        // @required -(void)setLocationEnabled:(BOOL)geoFenceEnabled;
        [Abstract]
        [Export("locationEnabled")]
        bool LocationEnabled { get; set; }

        // @required -(void)startWatchingLocation;
        [Abstract]
        [Export("startWatchingLocation")]
        void StartWatchingLocation();

        // @required -(void)stopWatchingLocation;
        [Abstract]
        [Export("stopWatchingLocation")]
        void StopWatchingLocation();

        // @required -(BOOL)watchingLocation __attribute__((warn_unused_result("")));
        [Abstract]
        [Export("watchingLocation")]
        bool WatchingLocation { get; }

        // @required -(NSDictionary<NSString *,NSString *> * _Nullable)lastKnownLocation __attribute__((warn_unused_result("")));
        [Abstract]
        [NullAllowed, Export("lastKnownLocation")]
        NSDictionary<NSString, NSString> LastKnownLocation { get; }

        // @required -(void)setURLHandlingDelegate:(id<SFMCSdkURLHandlingDelegate> _Nullable)delegate;
        [Abstract]
        [Export("setURLHandlingDelegate:")]
        void SetURLHandlingDelegate([NullAllowed] SFMCSdkURLHandlingDelegate @delegate);

        // @required -(BOOL)resetDataPolicy __attribute__((warn_unused_result("")));
        [Abstract]
        [Export("resetDataPolicy")]
        bool ResetDataPolicy { get; }

        // @required -(BOOL)isAnalyticsEnabled __attribute__((warn_unused_result("")));
        [Abstract]
        [Export("isAnalyticsEnabled")]
        bool IsAnalyticsEnabled { get; }

        // @required -(void)setAnalyticsEnabled:(BOOL)analyticsEnabled;
        [Abstract]
        [Export("setAnalyticsEnabled:")]
        void SetAnalyticsEnabled(bool analyticsEnabled);

        // @required -(BOOL)isPiAnalyticsEnabled __attribute__((warn_unused_result("")));
        [Abstract]
        [Export("isPiAnalyticsEnabled")]
        bool IsPiAnalyticsEnabled { get; }

        // @required -(void)setPiAnalyticsEnabled:(BOOL)analyticsEnabled;
        [Abstract]
        [Export("setPiAnalyticsEnabled:")]
        void SetPiAnalyticsEnabled(bool analyticsEnabled);

        // @required -(BOOL)isLocationEnabled __attribute__((warn_unused_result("")));
        [Abstract]
        [Export("isLocationEnabled")]
        bool IsLocationEnabled { get; }

        // @required -(void)setInboxEnabled:(BOOL)inboxEnabled;
        [Abstract]
        [Export("setInboxEnabled:")]
        void SetInboxEnabled(bool inboxEnabled);

        // @required -(BOOL)isInboxEnabled __attribute__((warn_unused_result("")));
        [Abstract]
        [Export("isInboxEnabled")]
        bool IsInboxEnabled { get; }
    }

    // @interface SFMCSdkPUSH : NSObject <PushInterface>
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface SFMCSdkPUSH : PushInterface
    {
        // -(enum SFMCSdkModuleStatus)getStatus __attribute__((warn_unused_result("")));
        [Export("getStatus")]
        SFMCSdkModuleStatus Status { get; }

        // -(id<SFMCSdkModuleIdentity> _Nullable)getIdentity __attribute__((warn_unused_result("")));
        [NullAllowed, Export("getIdentity")]
        SFMCSdkModuleIdentity Identity { get; }

        // -(void)tearDown __attribute__((deprecated("The SFMCSdk takes care of tear downs during initializations, making this method unnecessary. Its usage should be avoided to prevent race conditions.")));
        [Export("tearDown")]
        void TearDown();

        // -(NSString * _Nullable)contactKey __attribute__((warn_unused_result("")));
        [NullAllowed, Export("contactKey")]
        string ContactKey { get; }

        // -(BOOL)addTag:(NSString * _Nonnull)tag __attribute__((warn_unused_result("")));
        [Export("addTag:")]
        bool AddTag(string tag);

        // -(NSSet * _Nullable)addTags:(NSArray * _Nonnull)tags __attribute__((warn_unused_result("")));
        [Export("addTags:")]
        [return: NullAllowed]
        NSSet AddTags(NSObject[] tags);

        // -(BOOL)removeTag:(NSString * _Nonnull)tag __attribute__((warn_unused_result("")));
        [Export("removeTag:")]
        bool RemoveTag(string tag);

        // -(NSSet * _Nullable)tags __attribute__((warn_unused_result("")));
        [NullAllowed, Export("tags")]
        NSSet Tags { get; }

        // -(void)setDeviceToken:(NSData * _Nonnull)deviceToken;
        [Export("setDeviceToken:")]
        void SetDeviceToken(NSData deviceToken);

        // -(void)setDebugLoggingEnabled:(BOOL)enabled;
        [Export("setDebugLoggingEnabled:")]
        void SetDebugLoggingEnabled(bool enabled);

        // -(NSDictionary * _Nullable)attributes __attribute__((warn_unused_result("")));
        [NullAllowed, Export("attributes")]
        NSDictionary Attributes { get; }

        // -(NSString * _Nullable)deviceToken __attribute__((warn_unused_result("")));
        [NullAllowed, Export("deviceToken")]
        string DeviceToken { get; }

        // -(NSString * _Nullable)accessToken __attribute__((warn_unused_result("")));
        [NullAllowed, Export("accessToken")]
        string AccessToken { get; }

        // -(NSString * _Nullable)deviceIdentifier __attribute__((warn_unused_result("")));
        [NullAllowed, Export("deviceIdentifier")]
        string DeviceIdentifier { get; }

        // -(UNNotificationRequest * _Nullable)notificationRequest __attribute__((warn_unused_result("")));
        // -(void)setNotificationRequest:(UNNotificationRequest * _Nonnull)request;
        [NullAllowed, Export("notificationRequest")]
        UNNotificationRequest NotificationRequest { get; set; }

        // -(NSDictionary * _Nonnull)notificationUserInfo __attribute__((warn_unused_result("")));
        // -(void)setNotificationUserInfo:(NSDictionary * _Nonnull)userInfo;
        [Export("notificationUserInfo")]
        NSDictionary NotificationUserInfo { get; set; }

        // -(BOOL)pushEnabled __attribute__((warn_unused_result("")));
        // -(void)setPushEnabled:(BOOL)pushEnabled;
        [Export("pushEnabled")]
        bool PushEnabled { get; set; }

        // -(BOOL)refreshWithFetchCompletionHandler:(void (^ _Nullable)(UIBackgroundFetchResult))completionHandler __attribute__((warn_unused_result("")));
        [Export("refreshWithFetchCompletionHandler:")]
        bool RefreshWithFetchCompletionHandler([NullAllowed] Action<UIBackgroundFetchResult> completionHandler);

        // -(void)setRegistrationCallback:(void (^ _Nonnull)(NSDictionary * _Nonnull))registrationCallback;
        [Export("setRegistrationCallback:")]
        void SetRegistrationCallback(Action<NSDictionary> registrationCallback);

        // -(void)unsetRegistrationCallback;
        [Export("unsetRegistrationCallback")]
        void UnsetRegistrationCallback();

        // -(BOOL)setSignedString:(NSString * _Nullable)signedString __attribute__((warn_unused_result("")));
        [Export("setSignedString:")]
        bool SetSignedString([NullAllowed] string signedString);

        // -(NSString * _Nullable)signedString __attribute__((warn_unused_result("")));
        [NullAllowed, Export("signedString")]
        string SignedString { get; }

        // -(void)setEventDelegate:(id<SFMCSdkInAppMessageEventDelegate> _Nullable)delegate;
        [Export("setEventDelegate:")]
        void SetEventDelegate([NullAllowed] SFMCSdkInAppMessageEventDelegate @delegate);

        // -(NSString * _Nullable)messageIdForMessage:(NSDictionary * _Nonnull)forMessage __attribute__((warn_unused_result("")));
        [Export("messageIdForMessage:")]
        [return: NullAllowed]
        string MessageIdForMessage(NSDictionary forMessage);

        // -(void)showInAppMessageWithMessageId:(NSString * _Nonnull)messageId;
        [Export("showInAppMessageWithMessageId:")]
        void ShowInAppMessageWithMessageId(string messageId);

        // -(BOOL)setInAppMessageWithFontName:(NSString * _Nullable)fontName __attribute__((warn_unused_result("")));
        [Export("setInAppMessageWithFontName:")]
        bool SetInAppMessageWithFontName([NullAllowed] string fontName);

        // -(NSArray * _Nullable)getAllMessages __attribute__((warn_unused_result("")));
        [NullAllowed, Export("getAllMessages")]
        NSObject[] AllMessages { get; }

        // -(NSArray * _Nullable)getUnreadMessages __attribute__((warn_unused_result("")));
        [NullAllowed, Export("getUnreadMessages")]
        NSObject[] UnreadMessages { get; }

        // -(NSArray * _Nullable)getReadMessages __attribute__((warn_unused_result("")));
        [NullAllowed, Export("getReadMessages")]
        NSObject[] ReadMessages { get; }

        // -(NSArray * _Nullable)getDeletedMessages __attribute__((warn_unused_result("")));
        [NullAllowed, Export("getDeletedMessages")]
        NSObject[] DeletedMessages { get; }

        // -(NSUInteger)getAllMessagesCount __attribute__((warn_unused_result("")));
        [Export("getAllMessagesCount")]
        nuint AllMessagesCount { get; }

        // -(NSUInteger)getUnreadMessagesCount __attribute__((warn_unused_result("")));
        [Export("getUnreadMessagesCount")]
        nuint UnreadMessagesCount { get; }

        // -(NSUInteger)getReadMessagesCount __attribute__((warn_unused_result("")));
        [Export("getReadMessagesCount")]
        nuint ReadMessagesCount { get; }

        // -(NSUInteger)getDeletedMessagesCount __attribute__((warn_unused_result("")));
        [Export("getDeletedMessagesCount")]
        nuint DeletedMessagesCount { get; }

        // -(BOOL)markMessageRead:(NSDictionary * _Nonnull)messageDictionary __attribute__((warn_unused_result("")));
        [Export("markMessageRead:")]
        bool MarkMessageRead(NSDictionary messageDictionary);

        // -(BOOL)markMessageDeleted:(NSDictionary * _Nonnull)messageDictionary __attribute__((warn_unused_result("")));
        [Export("markMessageDeleted:")]
        bool MarkMessageDeleted(NSDictionary messageDictionary);

        // -(BOOL)markMessageWithIdReadWithMessageId:(NSString * _Nonnull)messageId __attribute__((warn_unused_result("")));
        [Export("markMessageWithIdReadWithMessageId:")]
        bool MarkMessageWithIdReadWithMessageId(string messageId);

        // -(BOOL)markMessageWithIdDeletedWithMessageId:(NSString * _Nonnull)messageId __attribute__((warn_unused_result("")));
        [Export("markMessageWithIdDeletedWithMessageId:")]
        bool MarkMessageWithIdDeletedWithMessageId(string messageId);

        // -(BOOL)markAllMessagesRead __attribute__((warn_unused_result("")));
        [Export("markAllMessagesRead")]
        bool MarkAllMessagesRead { get; }

        // -(BOOL)markAllMessagesDeleted __attribute__((warn_unused_result("")));
        [Export("markAllMessagesDeleted")]
        bool MarkAllMessagesDeleted { get; }

        // -(BOOL)refreshMessages __attribute__((warn_unused_result("")));
        [Export("refreshMessages")]
        bool RefreshMessages { get; }

        // -(id<SFMCSdkInboxMessagesDataSource> _Nullable)inboxMessagesTableViewDataSourceForTableView:(UITableView * _Nonnull)tableView __attribute__((warn_unused_result("")));
        [Export("inboxMessagesTableViewDataSourceForTableView:")]
        [return: NullAllowed]
        SFMCSdkInboxMessagesDataSource InboxMessagesTableViewDataSourceForTableView(UITableView tableView);

        // -(id<SFMCSdkInboxMessagesDelegate> _Nullable)inboxMessagesTableViewDelegateForTableView:(UITableView * _Nonnull)tableView dataSource:(id<SFMCSdkInboxMessagesDataSource> _Nonnull)dataSource __attribute__((warn_unused_result("")));
        [Export("inboxMessagesTableViewDelegateForTableView:dataSource:")]
        [return: NullAllowed]
        SFMCSdkInboxMessagesDelegate InboxMessagesTableViewDelegateForTableView(UITableView tableView, SFMCSdkInboxMessagesDataSource dataSource);

        // -(BOOL)setPiIdentifier:(NSString * _Nullable)identifier __attribute__((warn_unused_result("")));
        [Export("setPiIdentifier:")]
        bool SetPiIdentifier([NullAllowed] string identifier);

        // -(NSString * _Nullable)piIdentifier __attribute__((warn_unused_result("")));
        [NullAllowed, Export("piIdentifier")]
        string PiIdentifier { get; }

        // -(void)trackMessageOpened:(NSDictionary * _Nonnull)inboxMessage;
        [Export("trackMessageOpened:")]
        void TrackMessageOpened(NSDictionary inboxMessage);

        // -(void)trackPageViewWithUrl:(NSString * _Nonnull)url title:(NSString * _Nullable)title item:(NSString * _Nullable)item search:(NSString * _Nullable)search;
        [Export("trackPageViewWithUrl:title:item:search:")]
        void TrackPageViewWithUrl(string url, [NullAllowed] string title, [NullAllowed] string item, [NullAllowed] string search);

        // -(void)trackCartContents:(NSDictionary * _Nonnull)cartDictionary;
        [Export("trackCartContents:")]
        void TrackCartContents(NSDictionary cartDictionary);

        // -(void)trackCartConversion:(NSDictionary * _Nonnull)orderDictionary;
        [Export("trackCartConversion:")]
        void TrackCartConversion(NSDictionary orderDictionary);

        // -(NSDictionary * _Nullable)cartItemDictionaryWithPrice:(NSNumber * _Nonnull)price quantity:(NSNumber * _Nonnull)quantity item:(NSString * _Nonnull)item uniqueId:(NSString * _Nullable)uniqueId __attribute__((warn_unused_result("")));
        [Export("cartItemDictionaryWithPrice:quantity:item:uniqueId:")]
        [return: NullAllowed]
        NSDictionary CartItemDictionaryWithPrice(NSNumber price, NSNumber quantity, string item, [NullAllowed] string uniqueId);

        // -(NSDictionary * _Nullable)cartDictionaryWithCartItem:(NSArray * _Nonnull)cartItem __attribute__((warn_unused_result("")));
        [Export("cartDictionaryWithCartItem:")]
        [return: NullAllowed]
        NSDictionary CartDictionaryWithCartItem(NSObject[] cartItem);

        // -(NSDictionary * _Nullable)orderDictionaryWithOrderNumber:(NSString * _Nonnull)orderNumber shipping:(NSNumber * _Nonnull)shipping discount:(NSNumber * _Nonnull)discount cart:(NSDictionary * _Nonnull)cart __attribute__((warn_unused_result("")));
        [Export("orderDictionaryWithOrderNumber:shipping:discount:cart:")]
        [return: NullAllowed]
        NSDictionary OrderDictionaryWithOrderNumber(string orderNumber, NSNumber shipping, NSNumber discount, NSDictionary cart);

        // -(void)setLocationDelegate:(id<SFMCSdkLocationDelegate> _Nullable)delegate;
        [Export("setLocationDelegate:")]
        void SetLocationDelegate([NullAllowed] SFMCSdkLocationDelegate @delegate);

        // -(CLRegion * _Nullable)regionFromDictionary:(NSDictionary * _Nonnull)dictionary __attribute__((warn_unused_result("")));
        [Export("regionFromDictionary:")]
        [return: NullAllowed]
        CLRegion RegionFromDictionary(NSDictionary dictionary);

        // -(BOOL)locationEnabled __attribute__((warn_unused_result("")));
        // -(void)setLocationEnabled:(BOOL)locationEnabled;
        [Export("locationEnabled")]
        bool LocationEnabled { get; set; }

        // -(void)startWatchingLocation;
        [Export("startWatchingLocation")]
        void StartWatchingLocation();

        // -(void)stopWatchingLocation;
        [Export("stopWatchingLocation")]
        void StopWatchingLocation();

        // -(BOOL)watchingLocation __attribute__((warn_unused_result("")));
        [Export("watchingLocation")]
        bool WatchingLocation { get; }

        // -(NSDictionary<NSString *,NSString *> * _Nullable)lastKnownLocation __attribute__((warn_unused_result("")));
        [NullAllowed, Export("lastKnownLocation")]
        NSDictionary<NSString, NSString> LastKnownLocation { get; }

        // -(void)setURLHandlingDelegate:(id<SFMCSdkURLHandlingDelegate> _Nullable)delegate;
        [Export("setURLHandlingDelegate:")]
        void SetURLHandlingDelegate([NullAllowed] SFMCSdkURLHandlingDelegate @delegate);

        // -(BOOL)resetDataPolicy __attribute__((warn_unused_result("")));
        [Export("resetDataPolicy")]
        bool ResetDataPolicy { get; }

        // -(BOOL)isAnalyticsEnabled __attribute__((warn_unused_result("")));
        [Export("isAnalyticsEnabled")]
        bool IsAnalyticsEnabled { get; }

        // -(void)setAnalyticsEnabled:(BOOL)analyticsEnabled;
        [Export("setAnalyticsEnabled:")]
        void SetAnalyticsEnabled(bool analyticsEnabled);

        // -(BOOL)isPiAnalyticsEnabled __attribute__((warn_unused_result("")));
        [Export("isPiAnalyticsEnabled")]
        bool IsPiAnalyticsEnabled { get; }

        // -(void)setPiAnalyticsEnabled:(BOOL)analyticsEnabled;
        [Export("setPiAnalyticsEnabled:")]
        void SetPiAnalyticsEnabled(bool analyticsEnabled);

        // -(BOOL)isLocationEnabled __attribute__((warn_unused_result("")));
        [Export("isLocationEnabled")]
        bool IsLocationEnabled { get; }

        // -(void)setInboxEnabled:(BOOL)inboxEnabled;
        [Export("setInboxEnabled:")]
        void SetInboxEnabled(bool inboxEnabled);

        // -(BOOL)isInboxEnabled __attribute__((warn_unused_result("")));
        [Export("isInboxEnabled")]
        bool IsInboxEnabled { get; }
    }

    // @interface SFMCSdkPreorderEvent : SFMCSdkOrderEvent
    [BaseType(typeof(SFMCSdkOrderEvent))]
    interface SFMCSdkPreorderEvent
    {
        // -(instancetype _Nonnull)initWithOrder:(SFMCSdkOrder * _Nonnull)order __attribute__((objc_designated_initializer));
        [Export("initWithOrder:")]
        [DesignatedInitializer]
        IntPtr Constructor(SFMCSdkOrder order);
    }

    // @interface SFMCSdkPurchaseOrderEvent : SFMCSdkOrderEvent
    [BaseType(typeof(SFMCSdkOrderEvent))]
    interface SFMCSdkPurchaseOrderEvent
    {
        // -(instancetype _Nonnull)initWithOrder:(SFMCSdkOrder * _Nonnull)order __attribute__((objc_designated_initializer));
        [Export("initWithOrder:")]
        [DesignatedInitializer]
        IntPtr Constructor(SFMCSdkOrder order);
    }

    // @interface SFMCSdkQuickViewCatalogObjectEvent : SFMCSdkCatalogObjectEvent
    [BaseType(typeof(SFMCSdkCatalogObjectEvent))]
    interface SFMCSdkQuickViewCatalogObjectEvent
    {
        // -(instancetype _Nonnull)initWithCatalogObject:(SFMCSdkCatalogObject * _Nonnull)catalogObject __attribute__((objc_designated_initializer));
        [Export("initWithCatalogObject:")]
        [DesignatedInitializer]
        IntPtr Constructor(SFMCSdkCatalogObject catalogObject);
    }

    // @interface SFMCSdkRemoveFromCartEvent : SFMCSdkCartEvent
    [BaseType(typeof(SFMCSdkCartEvent))]
    interface SFMCSdkRemoveFromCartEvent
    {
        // -(instancetype _Nonnull)initWithLineItem:(SFMCSdkLineItem * _Nonnull)lineItem __attribute__((objc_designated_initializer));
        [Export("initWithLineItem:")]
        [DesignatedInitializer]
        IntPtr Constructor(SFMCSdkLineItem lineItem);
    }

    // @interface SFMCSdkReplaceCartEvent : SFMCSdkCartEvent
    [BaseType(typeof(SFMCSdkCartEvent))]
    interface SFMCSdkReplaceCartEvent
    {
        // -(instancetype _Nonnull)initWithLineItems:(NSArray<SFMCSdkLineItem *> * _Nonnull)lineItems __attribute__((objc_designated_initializer));
        [Export("initWithLineItems:")]
        [DesignatedInitializer]
        IntPtr Constructor(SFMCSdkLineItem[] lineItems);
    }

    // @interface SFMCSdkReturnOrderEvent : SFMCSdkOrderEvent
    [BaseType(typeof(SFMCSdkOrderEvent))]
    interface SFMCSdkReturnOrderEvent
    {
        // -(instancetype _Nonnull)initWithOrder:(SFMCSdkOrder * _Nonnull)order __attribute__((objc_designated_initializer));
        [Export("initWithOrder:")]
        [DesignatedInitializer]
        IntPtr Constructor(SFMCSdkOrder order);
    }

    // @interface SFMCSdkReviewCatalogObjectEvent : SFMCSdkCatalogObjectEvent
    [BaseType(typeof(SFMCSdkCatalogObjectEvent))]
    interface SFMCSdkReviewCatalogObjectEvent
    {
        // -(instancetype _Nonnull)initWithCatalogObject:(SFMCSdkCatalogObject * _Nonnull)catalogObject __attribute__((objc_designated_initializer));
        [Export("initWithCatalogObject:")]
        [DesignatedInitializer]
        IntPtr Constructor(SFMCSdkCatalogObject catalogObject);
    }

    // @protocol SFMCModule
    /*
      Check whether adding [Model] to this declaration is appropriate.
      [Model] is used to generate a C# class that implements this protocol,
      and might be useful for protocols that consumers are supposed to implement,
      since consumers can subclass the generated class instead of implementing
      the generated interface. If consumers are not supposed to implement this
      protocol, then [Model] is redundant and will generate code that will never
      be used.
    */
    [Protocol(Name = "_TtP7SFMCSDK10SFMCModule_")]
    [BaseType(typeof(NSObject), Name = "SFMCModule")]
    interface SFMCModule
    {
        // @required @property (readonly, nonatomic) enum SFMCSdkModuleName name;
        [Abstract]
        [Export("name")]
        SFMCSdkModuleName Name { get; }

        // @required @property (readonly, copy, nonatomic, class) NSString * _Nonnull moduleVersion;
        [Static, Abstract]
        [Export("moduleVersion")]
        string ModuleVersion { get; }

        // @required @property (copy, nonatomic, class) NSDictionary<NSString *,NSString *> * _Nullable stateProperties;
        [Static, Abstract]
        [NullAllowed, Export("stateProperties", ArgumentSemantic.Copy)]
        NSDictionary<NSString, NSString> StateProperties { get; set; }

        // @required +(id<SFMCModule> _Nullable)initModuleWithConfig:(id<SFMCSdkModuleConfig> _Nonnull)config components:(SFMCSdkComponents * _Nonnull)components __attribute__((objc_method_family("none"))) __attribute__((warn_unused_result("")));
        [Abstract]
        [Export("initModuleWithConfig:components:")]
        [return: NullAllowed]
        SFMCModule Components(SFMCSdkModuleConfig config, SFMCSdkComponents components);
    }

    // @interface SFMCSdk : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface SFMCSdk
    {
        // @property (nonatomic, strong, class) SFMCSdkCDP * _Nonnull cdp;
        [Static]
        [Export("cdp", ArgumentSemantic.Strong)]
        SFMCSdkCDP Cdp { get; set; }

        // @property (nonatomic, strong, class) SFMCSdkPUSH * _Nonnull mp;
        [Static]
        [Export("mp", ArgumentSemantic.Strong)]
        SFMCSdkPUSH Mp { get; set; }

        // @property (nonatomic, strong, class) SFMCSdkIDENTITY * _Nonnull identity;
        [Static]
        [Export("identity", ArgumentSemantic.Strong)]
        SFMCSdkIDENTITY Identity { get; set; }

        // @property (copy, nonatomic, class) NSString * _Nonnull sdkVersion;
        [Static]
        [Export("sdkVersion")]
        string SdkVersion { get; set; }

        // +(void)initializeSdk:(SFMCSdkConfig * _Nonnull)configuration;
        [Static]
        [Export("initializeSdk:")]
        void InitializeSdk(SFMCSdkConfig configuration);

        // +(void)trackWithEvent:(id<SFMCSdkEvent> _Nonnull)event;
        [Static]
        [Export("trackWithEvent:")]
        void TrackWithEvent(SFMCSdkEvent @event);

        // +(NSString * _Nonnull)state __attribute__((warn_unused_result("")));
        [Static]
        [Export("state")]
        string State { get; }

        // +(void)tearDownModuleWithName:(enum SFMCSdkModuleName)name __attribute__((deprecated("The SFMCSdk takes care of tear downs during initializations, making this method unnecessary. Its usage should be avoided to prevent race conditions.")));
        [Static]
        [Export("tearDownModuleWithName:")]
        void TearDownModuleWithName(SFMCSdkModuleName name);

        // +(void)setLoggerWithLogLevel:(enum SFMCSdkLogLevel)logLevel logOutputter:(SFMCSdkLogOutputter * _Nullable)logOutputter;
        [Static]
        [Export("setLoggerWithLogLevel:logOutputter:")]
        void SetLoggerWithLogLevel(SFMCSdkLogLevel logLevel, [NullAllowed] SFMCSdkLogOutputter logOutputter);

        // +(enum SFMCSdkLogLevel)getLogLevel __attribute__((warn_unused_result("")));
        [Static]
        [Export("getLogLevel")]
        SFMCSdkLogLevel LogLevel { get; }

        // +(void)clearLoggerFilters;
        [Static]
        [Export("clearLoggerFilters")]
        void ClearLoggerFilters();

        // +(void)setAutoMergePolicyOnCompletion:(void (^ _Nonnull)(BOOL))onCompletion;
        [Static]
        [Export("setAutoMergePolicyOnCompletion:")]
        void SetAutoMergePolicyOnCompletion(Action<bool> onCompletion);

        // +(void)setManualMergePolicyWithHandler:(void (^ _Nonnull)(NSDictionary * _Nonnull, NSDictionary * _Nonnull))handler;
        [Static]
        [Export("setManualMergePolicyWithHandler:")]
        void SetManualMergePolicyWithHandler(Action<NSDictionary, NSDictionary> handler);

        // +(enum SFMCSDKDataMergePolicy)getDataMergePolicy __attribute__((warn_unused_result("")));
        [Static]
        [Export("getDataMergePolicy")]
        SFMCSDKDataMergePolicy DataMergePolicy { get; }

        // +(BOOL)resetDataPolicyWithAppId:(NSString * _Nonnull)appId __attribute__((warn_unused_result("")));
        [Static]
        [Export("resetDataPolicyWithAppId:")]
        bool ResetDataPolicyWithAppId(string appId);

        // +(void (^ _Nullable)(BOOL))getAutoDataPolicyCallBack __attribute__((warn_unused_result("")));
        [Static]
        [NullAllowed, Export("getAutoDataPolicyCallBack")]
        Action<bool> AutoDataPolicyCallBack { get; }

        // +(void (^ _Nullable)(NSDictionary * _Nonnull, NSDictionary * _Nonnull))getManualDataPolicyCallBack __attribute__((warn_unused_result("")));
        [Static]
        [NullAllowed, Export("getManualDataPolicyCallBack")]
        Action<NSDictionary, NSDictionary> ManualDataPolicyCallBack { get; }

        //TODO Causing errors
        //// +(void)setKeychainAccessibleAttributeWithAccessibleAttribute:(CFTypeRef _Nullable)accessibleAttribute __attribute__((deprecated("This method is obsolete and has been deprecated")));
        //[Static]
        //[Export("setKeychainAccessibleAttributeWithAccessibleAttribute:")]
        //unsafe void SetKeychainAccessibleAttributeWithAccessibleAttribute([NullAllowed] void* accessibleAttribute);

        //TODO Causing errors
        //// +(CFTypeRef _Nullable)keychainAccessibleAttribute __attribute__((warn_unused_result(""))) __attribute__((deprecated("This method is obsolete and has been deprecated")));
        //[Static]
        //[NullAllowed, Export("keychainAccessibleAttribute")]
        //unsafe void* KeychainAccessibleAttribute { get; }

        // +(void)setKeychainAccessErrorsAreFatalWithErrorsAreFatal:(BOOL)errorsAreFatal __attribute__((deprecated("This method has no effect, SFMCSdk does not throw fatal exceptions anymore")));
        [Static]
        [Export("setKeychainAccessErrorsAreFatalWithErrorsAreFatal:")]
        void SetKeychainAccessErrorsAreFatalWithErrorsAreFatal(bool errorsAreFatal);

        // +(BOOL)keychainAccessErrorsAreFatal __attribute__((warn_unused_result(""))) __attribute__((deprecated("This method has no effect, SFMCSdk does not throw fatal exceptions anymore")));
        [Static]
        [Export("keychainAccessErrorsAreFatal")]
        bool KeychainAccessErrorsAreFatal { get; }

        // +(void)setFileProtectionTypeWithFileProtectionType:(NSFileProtectionType _Nullable)fileProtectionType;
        [Static]
        [Export("setFileProtectionTypeWithFileProtectionType:")]
        void SetFileProtectionTypeWithFileProtectionType([NullAllowed] string fileProtectionType);

        // +(NSFileProtectionType _Nullable)fileProtectionType __attribute__((warn_unused_result("")));
        [Static]
        [NullAllowed, Export("fileProtectionType")]
        string FileProtectionType { get; }

        // +(void)requestPushSdk:(void (^ _Nonnull)(id<PushInterface> _Nonnull))callback;
        [Static]
        [Export("requestPushSdk:")]
        void RequestPushSdk(Action<PushInterface> callback);
    }

    // @interface SFMCSdkComponents : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface SFMCSdkComponents
    {
        // @property (readonly, nonatomic, strong) SFMCSdkEncryptionManager * _Nonnull encryptionManager;
        [Export("encryptionManager", ArgumentSemantic.Strong)]
        SFMCSdkEncryptionManager EncryptionManager { get; }

        // @property (readonly, nonatomic, strong) SFMCSdkStorageManager * _Nonnull storageManager;
        [Export("storageManager", ArgumentSemantic.Strong)]
        SFMCSdkStorageManager StorageManager { get; }

        // @property (readonly, nonatomic, strong) SFMCSdkBehaviorManager * _Nonnull behaviorManager;
        [Export("behaviorManager", ArgumentSemantic.Strong)]
        SFMCSdkBehaviorManager BehaviorManager { get; }

        // -(SFMCSdkNetworkManager * _Nonnull)createNetworkManagerWithAuthenticator:(id<SFMCSdkAuthenticator> _Nullable)authenticator __attribute__((warn_unused_result("")));
        [Export("createNetworkManagerWithAuthenticator:")]
        SFMCSdkNetworkManager CreateNetworkManagerWithAuthenticator([NullAllowed] SFMCSdkAuthenticator authenticator);
    }

    // @interface SFMCSdkLogger : NSObject <Logger>
    [BaseType(typeof(NSObject), Name = "_TtC7SFMCSDK13SFMCSdkLogger")]
    interface SFMCSdkLogger : Logger
    {
        // @property (readonly, nonatomic, strong, class) SFMCSdkLogger * _Nonnull shared;
        [Static]
        [Export("shared", ArgumentSemantic.Strong)]
        SFMCSdkLogger Shared { get; }

        // @property (readonly, copy, nonatomic) NSArray<NSString *> * _Nonnull redactedValues;
        [Export("redactedValues", ArgumentSemantic.Copy)]
        string[] RedactedValues { get; }

        // -(enum SFMCSdkLogLevel)getLogLevel __attribute__((warn_unused_result("")));
        [Export("getLogLevel")]
        SFMCSdkLogLevel GetLogLevel { get; }

        // -(void)debugWithCategory:(enum SFMCSdkLoggerCategory)category message:(NSString * _Nonnull)message;
        [Export("debugWithCategory:message:")]
        void DebugWithCategory(SFMCSdkLoggerCategory category, string message);

        // -(void)warningWithCategory:(enum SFMCSdkLoggerCategory)category message:(NSString * _Nonnull)message;
        [Export("warningWithCategory:message:")]
        void WarningWithCategory(SFMCSdkLoggerCategory category, string message);

        // -(void)errorWithCategory:(enum SFMCSdkLoggerCategory)category message:(NSString * _Nonnull)message;
        [Export("errorWithCategory:message:")]
        void ErrorWithCategory(SFMCSdkLoggerCategory category, string message);

        // -(void)faultWithCategory:(enum SFMCSdkLoggerCategory)category message:(NSString * _Nonnull)message;
        [Export("faultWithCategory:message:")]
        void FaultWithCategory(SFMCSdkLoggerCategory category, string message);
    }

    // @interface SFMCSdkScreenEntry : SFMCSdkBehavior
    [BaseType(typeof(SFMCSdkBehavior))]
    interface SFMCSdkScreenEntry
    {
    }

    // @interface SFMCSdkSecurePrefs : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface SFMCSdkSecurePrefs
    {
        // -(void)setString:(NSString * _Nonnull)value for:(NSString * _Nonnull)key;
        [Export("setString:for:")]
        void SetString(string value, string key);

        // -(void)setInt:(NSInteger)value for:(NSString * _Nonnull)key;
        [Export("setInt:for:")]
        void SetInt(nint value, string key);

        // -(void)setBool:(BOOL)value for:(NSString * _Nonnull)key;
        [Export("setBool:for:")]
        void SetBool(bool value, string key);

        // -(void)setFloat:(float)value for:(NSString * _Nonnull)key;
        [Export("setFloat:for:")]
        void SetFloat(float value, string key);

        // -(void)setDouble:(double)value for:(NSString * _Nonnull)key;
        [Export("setDouble:for:")]
        void SetDouble(double value, string key);

        // -(NSString * _Nullable)stringForKey:(NSString * _Nonnull)key __attribute__((warn_unused_result("")));
        [Export("stringForKey:")]
        [return: NullAllowed]
        string StringForKey(string key);

        // -(void)removeWithKey:(NSString * _Nonnull)key;
        [Export("removeWithKey:")]
        void RemoveWithKey(string key);

        // -(void)clearAll;
        [Export("clearAll")]
        void ClearAll();
    }

    // @interface SFMCSdkShareCatalogObjectEvent : SFMCSdkCatalogObjectEvent
    [BaseType(typeof(SFMCSdkCatalogObjectEvent))]
    interface SFMCSdkShareCatalogObjectEvent
    {
        // -(instancetype _Nonnull)initWithCatalogObject:(SFMCSdkCatalogObject * _Nonnull)catalogObject __attribute__((objc_designated_initializer));
        [Export("initWithCatalogObject:")]
        [DesignatedInitializer]
        IntPtr Constructor(SFMCSdkCatalogObject catalogObject);
    }

    // @interface SFMCSdkShipOrderEvent : SFMCSdkOrderEvent
    [BaseType(typeof(SFMCSdkOrderEvent))]
    interface SFMCSdkShipOrderEvent
    {
        // -(instancetype _Nonnull)initWithOrder:(SFMCSdkOrder * _Nonnull)order __attribute__((objc_designated_initializer));
        [Export("initWithOrder:")]
        [DesignatedInitializer]
        IntPtr Constructor(SFMCSdkOrder order);
    }

    // @interface SFMCSdkStorageManager : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface SFMCSdkStorageManager
    {
        // -(NSString * _Nonnull)getRegistrationId __attribute__((warn_unused_result("")));
        [Export("getRegistrationId")]
        string RegistrationId { get; }

        // -(SFMCSdkSecurePrefs * _Nonnull)getOrCreateSecurePrefsWithName:(NSString * _Nonnull)name __attribute__((warn_unused_result("")));
        [Export("getOrCreateSecurePrefsWithName:")]
        SFMCSdkSecurePrefs GetOrCreateSecurePrefsWithName(string name);

        // -(NSString * _Nonnull)getFilenameForModuleInstallationWithFileName:(NSString * _Nonnull)fileName __attribute__((warn_unused_result("")));
        [Export("getFilenameForModuleInstallationWithFileName:")]
        string GetFilenameForModuleInstallationWithFileName(string fileName);

        // +(void)setFileSystemProtectionTypeWithFileProtectionType:(NSFileProtectionType _Nullable)fileProtectionType;
        [Static]
        [Export("setFileSystemProtectionTypeWithFileProtectionType:")]
        void SetFileSystemProtectionTypeWithFileProtectionType([NullAllowed] string fileProtectionType);

        // +(NSFileProtectionType _Nullable)fileSystemProtectionType __attribute__((warn_unused_result("")));
        [Static]
        [NullAllowed, Export("fileSystemProtectionType")]
        string FileSystemProtectionType { get; }
    }

    // @protocol Subscriber
    /*
      Check whether adding [Model] to this declaration is appropriate.
      [Model] is used to generate a C# class that implements this protocol,
      and might be useful for protocols that consumers are supposed to implement,
      since consumers can subclass the generated class instead of implementing
      the generated interface. If consumers are not supposed to implement this
      protocol, then [Model] is redundant and will generate code that will never
      be used.
    */
    [Protocol(Name = "_TtP7SFMCSDK10Subscriber_")]
    [BaseType(typeof(NSObject), Name = "Subscriber")]
    interface Subscriber
    {
        // @required @property (readonly, nonatomic) enum SFMCSdkModuleName name;
        [Abstract]
        [Export("name")]
        SFMCSdkModuleName Name { get; }

        // @required -(void)receiveWithMessage:(SFMCSdkMessage * _Nonnull)message;
        [Abstract]
        [Export("receiveWithMessage:")]
        void ReceiveWithMessage(SFMCSdkMessage message);
    }

    // @interface SFMCSdkSystemEvent : NSObject <SFMCSdkEvent>
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface SFMCSdkSystemEvent : SFMCSdkEvent
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull id;
        [Export("id")]
        string Id { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull name;
        [Export("name")]
        string Name { get; }

        // @property (readonly, nonatomic) enum SFMCSdkEventCategory category;
        [Export("category")]
        SFMCSdkEventCategory Category { get; }

        // @property (readonly, copy, nonatomic) NSDictionary<NSString *,id> * _Nullable attributes;
        [NullAllowed, Export("attributes", ArgumentSemantic.Copy)]
        NSDictionary<NSString, NSObject> Attributes { get; }

        // -(instancetype _Nonnull)initWithName:(NSString * _Nonnull)name attributes:(NSDictionary<NSString *,id> * _Nullable)attributes __attribute__((objc_designated_initializer));
        [Export("initWithName:attributes:")]
        [DesignatedInitializer]
        IntPtr Constructor(string name, [NullAllowed] NSDictionary<NSString, NSObject> attributes);
    }

    // @protocol SFMCSdkURLHandlingDelegate
    [Protocol, Model(AutoGeneratedName = true)]
    [BaseType(typeof(NSObject), Name = "SFMCSdkURLHandlingDelegate")]
    interface SFMCSdkURLHandlingDelegate
    {
        // @required -(void)sfmc_handleURL:(NSURL * _Nonnull)url type:(NSString * _Nonnull)type;
        [Abstract]
        [Export("sfmc_handleURL:type:")]
        void Type(NSUrl url, string type);
    }

    // @interface SFMCSdkViewCatalogObjectDetailEvent : SFMCSdkCatalogObjectEvent
    [BaseType(typeof(SFMCSdkCatalogObjectEvent))]
    interface SFMCSdkViewCatalogObjectDetailEvent
    {
        // -(instancetype _Nonnull)initWithCatalogObject:(SFMCSdkCatalogObject * _Nonnull)catalogObject __attribute__((objc_designated_initializer));
        [Export("initWithCatalogObject:")]
        [DesignatedInitializer]
        IntPtr Constructor(SFMCSdkCatalogObject catalogObject);
    }

    // @interface SFMCSdkViewCatalogObjectEvent : SFMCSdkCatalogObjectEvent
    [BaseType(typeof(SFMCSdkCatalogObjectEvent))]
    interface SFMCSdkViewCatalogObjectEvent
    {
        // -(instancetype _Nonnull)initWithCatalogObject:(SFMCSdkCatalogObject * _Nonnull)catalogObject __attribute__((objc_designated_initializer));
        [Export("initWithCatalogObject:")]
        [DesignatedInitializer]
        IntPtr Constructor(SFMCSdkCatalogObject catalogObject);
    }

    // @interface SFMCSdkWrappedRequest : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface SFMCSdkWrappedRequest
    {
        // @property (copy, nonatomic) NSURLRequest * _Nonnull request;
        [Export("request", ArgumentSemantic.Copy)]
        NSUrlRequest Request { get; set; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull name;
        [Export("name")]
        string Name { get; }

        // @property (readonly, nonatomic) NSTimeInterval rateLimit;
        [Export("rateLimit")]
        double RateLimit { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nullable tag;
        [NullAllowed, Export("tag")]
        string Tag { get; }
    }

    // @interface SFMCSdkWrappedRequestBuilder : NSObject
    [BaseType(typeof(NSObject))]
    interface SFMCSdkWrappedRequestBuilder
    {
        // -(SFMCSdkWrappedRequestBuilder * _Nonnull)method:(NSString * _Nonnull)method __attribute__((warn_unused_result("")));
        [Export("method:")]
        SFMCSdkWrappedRequestBuilder Method(string method);

        // -(SFMCSdkWrappedRequestBuilder * _Nonnull)url:(NSString * _Nonnull)url __attribute__((warn_unused_result("")));
        [Export("url:")]
        SFMCSdkWrappedRequestBuilder Url(string url);

        // -(SFMCSdkWrappedRequestBuilder * _Nonnull)urlWithBase:(NSString * _Nonnull)base path:(NSString * _Nonnull)path __attribute__((warn_unused_result("")));
        [Export("urlWithBase:path:")]
        SFMCSdkWrappedRequestBuilder UrlWithBase(string @base, string path);

        // -(SFMCSdkWrappedRequestBuilder * _Nonnull)addOrReplaceHeaderWithKey:(NSString * _Nonnull)key value:(NSString * _Nonnull)value __attribute__((warn_unused_result("")));
        [Export("addOrReplaceHeaderWithKey:value:")]
        SFMCSdkWrappedRequestBuilder AddOrReplaceHeaderWithKey(string key, string value);

        // -(SFMCSdkWrappedRequestBuilder * _Nonnull)body:(NSData * _Nonnull)body __attribute__((warn_unused_result("")));
        [Export("body:")]
        SFMCSdkWrappedRequestBuilder Body(NSData body);

        // -(SFMCSdkWrappedRequestBuilder * _Nonnull)timeout:(NSTimeInterval)seconds __attribute__((warn_unused_result("")));
        [Export("timeout:")]
        SFMCSdkWrappedRequestBuilder Timeout(double seconds);

        // -(SFMCSdkWrappedRequestBuilder * _Nonnull)rateLimit:(NSTimeInterval)seconds __attribute__((warn_unused_result("")));
        [Export("rateLimit:")]
        SFMCSdkWrappedRequestBuilder RateLimit(double seconds);

        // -(SFMCSdkWrappedRequestBuilder * _Nonnull)name:(NSString * _Nonnull)name __attribute__((warn_unused_result("")));
        [Export("name:")]
        SFMCSdkWrappedRequestBuilder Name(string name);

        // -(SFMCSdkWrappedRequestBuilder * _Nonnull)tag:(NSString * _Nonnull)tag __attribute__((warn_unused_result("")));
        [Export("tag:")]
        SFMCSdkWrappedRequestBuilder Tag(string tag);

        // -(SFMCSdkWrappedRequest * _Nullable)build __attribute__((warn_unused_result("")));
        [NullAllowed, Export("build")]
        SFMCSdkWrappedRequest Build { get; }
    }

    // @interface SFMCSdkWrappedResponse : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface SFMCSdkWrappedResponse
    {
        // @property (readonly, copy, nonatomic) NSData * _Nullable data;
        [NullAllowed, Export("data", ArgumentSemantic.Copy)]
        NSData Data { get; }

        // @property (readonly, nonatomic, strong) NSHTTPURLResponse * _Nullable response;
        [NullAllowed, Export("response", ArgumentSemantic.Strong)]
        NSHttpUrlResponse Response { get; }

        // @property (readonly, nonatomic) NSError * _Nullable error;
        [NullAllowed, Export("error")]
        NSError Error { get; }

        // @property (readonly, nonatomic) BOOL isSuccess;
        [Export("isSuccess")]
        bool IsSuccess { get; }

        // @property (readonly, nonatomic) BOOL isUnauthorized;
        [Export("isUnauthorized")]
        bool IsUnauthorized { get; }

        // @property (readonly, nonatomic) int64_t timeToExecute;
        [Export("timeToExecute")]
        long TimeToExecute { get; }

        // -(instancetype _Nonnull)initWithData:(NSData * _Nullable)data response:(NSURLResponse * _Nullable)response error:(NSError * _Nullable)error startTimeMillis:(int64_t)startTimeMillis endTimeMillis:(int64_t)endTimeMillis __attribute__((objc_designated_initializer));
        [Export("initWithData:response:error:startTimeMillis:endTimeMillis:")]
        [DesignatedInitializer]
        IntPtr Constructor([NullAllowed] NSData data, [NullAllowed] NSUrlResponse response, [NullAllowed] NSError error, long startTimeMillis, long endTimeMillis);
    }

    // @interface MobilePushSDK : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MobilePushSDK
    {
        // +(instancetype _Nonnull)sharedInstance;
        [Static]
        [Export("sharedInstance")]
        MobilePushSDK SharedInstance();

        // -(BOOL)sfmc_configureWithDictionary:(NSDictionary * _Nonnull)configuration error:(NSError * _Nullable * _Nullable)error;
        [Export("sfmc_configureWithDictionary:error:")]
        bool Sfmc_configureWithDictionary(NSDictionary configuration, [NullAllowed] out NSError error);

        // -(BOOL)sfmc_configureWithDictionary:(NSDictionary * _Nonnull)configuration error:(NSError * _Nullable * _Nullable)error completionHandler:(void (^ _Nullable)(BOOL, NSString * _Nonnull, NSError * _Nonnull))completionHandler;
        [Export("sfmc_configureWithDictionary:error:completionHandler:")]
        bool Sfmc_configureWithDictionary(NSDictionary configuration, [NullAllowed] out NSError error, [NullAllowed] Action<bool, NSString, NSError> completionHandler);

        // -(void)sfmc_tearDown;
        [Export("sfmc_tearDown")]
        void Sfmc_tearDown();

        // -(BOOL)sfmc_setContactKey:(NSString * _Nonnull)contactKey;
        [Export("sfmc_setContactKey:")]
        bool Sfmc_setContactKey(string contactKey);

        // -(NSString * _Nullable)sfmc_contactKey;
        [NullAllowed, Export("sfmc_contactKey")]
        string Sfmc_contactKey { get; }

        // -(BOOL)sfmc_addTag:(NSString * _Nonnull)tag;
        [Export("sfmc_addTag:")]
        bool Sfmc_addTag(string tag);

        // -(BOOL)sfmc_removeTag:(NSString * _Nonnull)tag;
        [Export("sfmc_removeTag:")]
        bool Sfmc_removeTag(string tag);

        // -(NSSet * _Nullable)sfmc_addTags:(NSArray * _Nonnull)tags;
        [Export("sfmc_addTags:")]
        [return: NullAllowed]
        NSSet Sfmc_addTags(NSObject[] tags);

        // -(NSSet * _Nullable)sfmc_removeTags:(NSArray * _Nonnull)tags;
        [Export("sfmc_removeTags:")]
        [return: NullAllowed]
        NSSet Sfmc_removeTags(NSObject[] tags);

        // -(NSSet * _Nullable)sfmc_tags;
        [NullAllowed, Export("sfmc_tags")]
        NSSet Sfmc_tags { get; }

        // -(BOOL)sfmc_setAttributeNamed:(NSString * _Nonnull)name value:(NSString * _Nonnull)value;
        [Export("sfmc_setAttributeNamed:value:")]
        bool Sfmc_setAttributeNamed(string name, string value);

        // -(BOOL)sfmc_clearAttributeNamed:(NSString * _Nonnull)name;
        [Export("sfmc_clearAttributeNamed:")]
        bool Sfmc_clearAttributeNamed(string name);

        // -(NSDictionary * _Nullable)sfmc_attributes;
        [NullAllowed, Export("sfmc_attributes")]
        NSDictionary Sfmc_attributes { get; }

        // -(NSDictionary * _Nullable)sfmc_setAttributes:(NSArray * _Nonnull)attributes;
        [Export("sfmc_setAttributes:")]
        [return: NullAllowed]
        NSDictionary Sfmc_setAttributes(NSObject[] attributes);

        // -(NSDictionary * _Nullable)sfmc_clearAttributesNamed:(NSArray * _Nonnull)attributeNames;
        [Export("sfmc_clearAttributesNamed:")]
        [return: NullAllowed]
        NSDictionary Sfmc_clearAttributesNamed(NSObject[] attributeNames);

        // -(void)sfmc_setDeviceToken:(NSData * _Nonnull)deviceToken;
        [Export("sfmc_setDeviceToken:")]
        void Sfmc_setDeviceToken(NSData deviceToken);

        // -(NSString * _Nullable)sfmc_deviceToken;
        [NullAllowed, Export("sfmc_deviceToken")]
        string Sfmc_deviceToken { get; }

        // -(NSString * _Nullable)sfmc_appID;
        [NullAllowed, Export("sfmc_appID")]
        string Sfmc_appID { get; }

        // -(NSString * _Nullable)sfmc_accessToken;
        [NullAllowed, Export("sfmc_accessToken")]
        string Sfmc_accessToken { get; }

        // -(NSString * _Nullable)sfmc_deviceIdentifier;
        [NullAllowed, Export("sfmc_deviceIdentifier")]
        string Sfmc_deviceIdentifier { get; }

        // -(void)sfmc_setNotificationRequest:(UNNotificationRequest * _Nonnull)request __attribute__((availability(ios, introduced=10)));
        [iOS(10, 0)]
        [Export("sfmc_setNotificationRequest:")]
        void Sfmc_setNotificationRequest(UNNotificationRequest request);

        // -(UNNotificationRequest * _Nonnull)sfmc_notificationRequest __attribute__((availability(ios, introduced=10)));
        [iOS(10, 0)]
        [Export("sfmc_notificationRequest")]
        UNNotificationRequest Sfmc_notificationRequest { get; }

        // -(void)sfmc_setNotificationUserInfo:(NSDictionary * _Nonnull)userInfo;
        [Export("sfmc_setNotificationUserInfo:")]
        void Sfmc_setNotificationUserInfo(NSDictionary userInfo);

        // -(NSDictionary * _Nonnull)sfmc_notificationUserInfo;
        [Export("sfmc_notificationUserInfo")]
        NSDictionary Sfmc_notificationUserInfo { get; }

        // -(void)sfmc_setPushEnabled:(BOOL)pushEnabled;
        [Export("sfmc_setPushEnabled:")]
        void Sfmc_setPushEnabled(bool pushEnabled);

        // -(BOOL)sfmc_pushEnabled;
        [Export("sfmc_pushEnabled")]
        bool Sfmc_pushEnabled { get; }

        // -(NSString * _Nullable)sfmc_getSDKState __attribute__((swift_name("sfmc_getSDKState()")));
        [NullAllowed, Export("sfmc_getSDKState")]
        string Sfmc_getSDKState { get; }

        // -(void)sfmc_setDebugLoggingEnabled:(BOOL)enabled;
        [Export("sfmc_setDebugLoggingEnabled:")]
        void Sfmc_setDebugLoggingEnabled(bool enabled);

        // -(BOOL)sfmc_getDebugLoggingEnabled;
        [Export("sfmc_getDebugLoggingEnabled")]
        bool Sfmc_getDebugLoggingEnabled { get; }

        // -(BOOL)sfmc_refreshWithFetchCompletionHandler:(void (^ _Nullable)(UIBackgroundFetchResult))completionHandler;
        [Export("sfmc_refreshWithFetchCompletionHandler:")]
        bool Sfmc_refreshWithFetchCompletionHandler([NullAllowed] Action<UIBackgroundFetchResult> completionHandler);

        // -(BOOL)sfmc_setSignedString:(NSString * _Nullable)signedString;
        [Export("sfmc_setSignedString:")]
        bool Sfmc_setSignedString([NullAllowed] string signedString);

        // -(void)sfmc_setRegistrationCallback:(void (^ _Nonnull)(NSDictionary * _Nonnull))registrationCallback;
        [Export("sfmc_setRegistrationCallback:")]
        void Sfmc_setRegistrationCallback(Action<NSDictionary> registrationCallback);

        // -(void)sfmc_unsetRegistrationCallback;
        [Export("sfmc_unsetRegistrationCallback")]
        void Sfmc_unsetRegistrationCallback();

        // -(NSString * _Nullable)sfmc_signedString;
        [NullAllowed, Export("sfmc_signedString")]
        string Sfmc_signedString { get; }

        // -(BOOL)sfmc_isReady;
        [Export("sfmc_isReady")]
        bool Sfmc_isReady { get; }

        // -(BOOL)sfmc_isInitializing;
        [Export("sfmc_isInitializing")]
        bool Sfmc_isInitializing { get; }

        // -(BOOL)sfmc_resetDataPolicy;
        [Export("sfmc_resetDataPolicy")]
        bool Sfmc_resetDataPolicy { get; }
    }

    // @protocol SFMCEvent <NSObject>
    /*
      Check whether adding [Model] to this declaration is appropriate.
      [Model] is used to generate a C# class that implements this protocol,
      and might be useful for protocols that consumers are supposed to implement,
      since consumers can subclass the generated class instead of implementing
      the generated interface. If consumers are not supposed to implement this
      protocol, then [Model] is redundant and will generate code that will never
      be used.
    */
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface SFMCEvent
    {
        // @required -(NSString * _Nonnull)key;
        [Abstract]
        [Export("key")]
        string Key { get; }

        // @required -(NSString * _Nullable)eventId;
        [Abstract]
        [NullAllowed, Export("eventId")]
        string EventId { get; }

        // @required -(NSDictionary<NSString *,id> * _Nullable)parameters;
        [Abstract]
        [NullAllowed, Export("parameters")]
        NSDictionary<NSString, NSObject> Parameters { get; }


        // +(id<SFMCEvent> _Nullable)customEventWithName:(NSString * _Nonnull)key;
        [Static]
        [Export("customEventWithName:")]
        [return: NullAllowed]
        SFMCEvent CustomEventWithName(string key);

        // +(id<SFMCEvent> _Nullable)customEventWithName:(NSString * _Nonnull)key withEventId:(NSString * _Nonnull)eventId;
        [Static]
        [Export("customEventWithName:withEventId:")]
        [return: NullAllowed]
        SFMCEvent CustomEventWithName(string key, string eventId);

        // +(id<SFMCEvent> _Nullable)customEventWithName:(NSString * _Nonnull)key withAttributes:(NSDictionary<NSString *,id> * _Nonnull)parameters;
        [Static]
        [Export("customEventWithName:withAttributes:")]
        [return: NullAllowed]
        SFMCEvent CustomEventWithName(string key, NSDictionary<NSString, NSObject> parameters);

        // +(id<SFMCEvent> _Nullable)customEventWithName:(NSString * _Nonnull)key withEventId:(NSString * _Nonnull)eventId withAttributes:(NSDictionary<NSString *,id> * _Nonnull)parameters;
        [Static]
        [Export("customEventWithName:withEventId:withAttributes:")]
        [return: NullAllowed]
        SFMCEvent CustomEventWithName(string key, string eventId, NSDictionary<NSString, NSObject> parameters);

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



    // @interface Intelligence (MobilePushSDK)
    [Category]
    [BaseType(typeof(MobilePushSDK))]
    interface MobilePushSDK_Intelligence
    {
        // -(BOOL)sfmc_setPiIdentifier:(NSString * _Nullable)identifier;
        [Export("sfmc_setPiIdentifier:")]
        bool Sfmc_setPiIdentifier([NullAllowed] string identifier);

        // -(NSString * _Nullable)sfmc_piIdentifier;
        [NullAllowed, Export("sfmc_piIdentifier")]
        string Sfmc_piIdentifier();

        // -(void)sfmc_trackMessageOpened:(NSDictionary * _Nonnull)inboxMessage;
        [Export("sfmc_trackMessageOpened:")]
        void Sfmc_trackMessageOpened(NSDictionary inboxMessage);

        // -(void)sfmc_trackPageViewWithURL:(NSString * _Nonnull)url title:(NSString * _Nullable)title item:(NSString * _Nullable)item search:(NSString * _Nullable)search;
        [Export("sfmc_trackPageViewWithURL:title:item:search:")]
        void Sfmc_trackPageViewWithURL(string url, [NullAllowed] string title, [NullAllowed] string item, [NullAllowed] string search);

        // -(void)sfmc_trackCartContents:(NSDictionary * _Nonnull)cartDictionary;
        [Export("sfmc_trackCartContents:")]
        void Sfmc_trackCartContents(NSDictionary cartDictionary);

        // -(void)sfmc_trackCartConversion:(NSDictionary * _Nonnull)orderDictionary;
        [Export("sfmc_trackCartConversion:")]
        void Sfmc_trackCartConversion(NSDictionary orderDictionary);

        // -(NSDictionary * _Nullable)sfmc_cartItemDictionaryWithPrice:(NSNumber * _Nonnull)price quantity:(NSNumber * _Nonnull)quantity item:(NSString * _Nonnull)item uniqueId:(NSString * _Nullable)uniqueId;
        [Export("sfmc_cartItemDictionaryWithPrice:quantity:item:uniqueId:")]
        [return: NullAllowed]
        NSDictionary Sfmc_cartItemDictionaryWithPrice(NSNumber price, NSNumber quantity, string item, [NullAllowed] string uniqueId);

        // -(NSDictionary * _Nullable)sfmc_cartDictionaryWithCartItemDictionaryArray:(NSArray * _Nonnull)cartItemDictionaryArray;
        [Export("sfmc_cartDictionaryWithCartItemDictionaryArray:")]
        [return: NullAllowed]
        NSDictionary Sfmc_cartDictionaryWithCartItemDictionaryArray(NSObject[] cartItemDictionaryArray);

        // -(NSDictionary * _Nullable)sfmc_orderDictionaryWithOrderNumber:(NSString * _Nonnull)orderNumber shipping:(NSNumber * _Nonnull)shipping discount:(NSNumber * _Nonnull)discount cart:(NSDictionary * _Nonnull)cartDictionary;
        [Export("sfmc_orderDictionaryWithOrderNumber:shipping:discount:cart:")]
        [return: NullAllowed]
        NSDictionary Sfmc_orderDictionaryWithOrderNumber(string orderNumber, NSNumber shipping, NSNumber discount, NSDictionary cartDictionary);
    }

    partial interface Constants
    {
        // extern NSString *const _Nonnull MarketingCloudSDKInboxMessageKey;
        [Field("MarketingCloudSDKInboxMessageKey", "__Internal")]
        NSString MarketingCloudSDKInboxMessageKey { get; }
    }

    // @interface MarketingCloudSDKInboxMessagesDataSource : NSObject <SFMCSdkInboxMessagesDataSource>
    [BaseType(typeof(NSObject))]
    interface MarketingCloudSDKInboxMessagesDataSource : SFMCSdkInboxMessagesDataSource
    {
        // -(id _Nullable)initWithMarketingCloudSDK:(MobilePushSDK * _Nonnull)sdk tableView:(UITableView * _Nonnull)tableView;
        [Export("initWithMarketingCloudSDK:tableView:")]
        IntPtr Constructor(MobilePushSDK sdk, UITableView tableView);
    }

    // @interface MarketingCloudSDKInboxMessagesDelegate : NSObject <SFMCSdkInboxMessagesDelegate>
    [BaseType(typeof(NSObject))]
    interface MarketingCloudSDKInboxMessagesDelegate : SFMCSdkInboxMessagesDelegate
    {
        // -(id _Nullable)initWithMarketingCloudSDK:(MobilePushSDK * _Nonnull)sdk tableView:(UITableView * _Nonnull)tableView dataSource:(MarketingCloudSDKInboxMessagesDataSource * _Nonnull)dataSource;
        [Export("initWithMarketingCloudSDK:tableView:dataSource:")]
        IntPtr Constructor(MobilePushSDK sdk, UITableView tableView, MarketingCloudSDKInboxMessagesDataSource dataSource);
    }

    // @interface InboxMessages (MobilePushSDK)
    [Category]
    [BaseType(typeof(MobilePushSDK))]
    interface MobilePushSDK_InboxMessages
    {
        // -(NSArray * _Nullable)sfmc_getAllMessages;
        [NullAllowed, Export("sfmc_getAllMessages")]
        NSObject[] Sfmc_getAllMessages();

        // -(NSArray * _Nullable)sfmc_getUnreadMessages;
        [NullAllowed, Export("sfmc_getUnreadMessages")]
        NSObject[] Sfmc_getUnreadMessages();

        // -(NSArray * _Nullable)sfmc_getReadMessages;
        [NullAllowed, Export("sfmc_getReadMessages")]
        NSObject[] Sfmc_getReadMessages();

        // -(NSArray * _Nullable)sfmc_getDeletedMessages;
        [NullAllowed, Export("sfmc_getDeletedMessages")]
        NSObject[] Sfmc_getDeletedMessages();

        // -(NSUInteger)sfmc_getAllMessagesCount;
        [Export("sfmc_getAllMessagesCount")]
        nuint Sfmc_getAllMessagesCount();

        // -(NSUInteger)sfmc_getUnreadMessagesCount;
        [Export("sfmc_getUnreadMessagesCount")]
        nuint Sfmc_getUnreadMessagesCount();

        // -(NSUInteger)sfmc_getReadMessagesCount;
        [Export("sfmc_getReadMessagesCount")]
        nuint Sfmc_getReadMessagesCount();

        // -(NSUInteger)sfmc_getDeletedMessagesCount;
        [Export("sfmc_getDeletedMessagesCount")]
        nuint Sfmc_getDeletedMessagesCount();

        // -(BOOL)sfmc_markMessageRead:(NSDictionary * _Nonnull)messageDictionary;
        [Export("sfmc_markMessageRead:")]
        bool Sfmc_markMessageRead(NSDictionary messageDictionary);

        // -(BOOL)sfmc_markMessageDeleted:(NSDictionary * _Nonnull)messageDictionary;
        [Export("sfmc_markMessageDeleted:")]
        bool Sfmc_markMessageDeleted(NSDictionary messageDictionary);

        // -(BOOL)sfmc_markMessageWithIdRead:(NSString * _Nonnull)messageId;
        [Export("sfmc_markMessageWithIdRead:")]
        bool Sfmc_markMessageWithIdRead(string messageId);

        // -(BOOL)sfmc_markMessageWithIdDeleted:(NSString * _Nonnull)messageId;
        [Export("sfmc_markMessageWithIdDeleted:")]
        bool Sfmc_markMessageWithIdDeleted(string messageId);

        // -(BOOL)sfmc_markAllMessagesRead;
        [Export("sfmc_markAllMessagesRead")]
        bool Sfmc_markAllMessagesRead();

        // -(BOOL)sfmc_markAllMessagesDeleted;
        [Export("sfmc_markAllMessagesDeleted")]
        bool Sfmc_markAllMessagesDeleted();

        // -(BOOL)sfmc_refreshMessages;
        [Export("sfmc_refreshMessages")]
        bool Sfmc_refreshMessages();

        // -(MarketingCloudSDKInboxMessagesDataSource * _Nullable)sfmc_inboxMessagesTableViewDataSourceForTableView:(UITableView * _Nonnull)tableView;
        [Export("sfmc_inboxMessagesTableViewDataSourceForTableView:")]
        [return: NullAllowed]
        MarketingCloudSDKInboxMessagesDataSource Sfmc_inboxMessagesTableViewDataSourceForTableView(UITableView tableView);

        // -(MarketingCloudSDKInboxMessagesDelegate * _Nullable)sfmc_inboxMessagesTableViewDelegateForTableView:(UITableView * _Nonnull)tableView dataSource:(MarketingCloudSDKInboxMessagesDataSource * _Nonnull)dataSource;
        [Export("sfmc_inboxMessagesTableViewDelegateForTableView:dataSource:")]
        [return: NullAllowed]
        MarketingCloudSDKInboxMessagesDelegate Sfmc_inboxMessagesTableViewDelegateForTableView(UITableView tableView, MarketingCloudSDKInboxMessagesDataSource dataSource);
    }

    // @protocol MarketingCloudSDKLocationDelegate <NSObject>
    [Protocol, Model(AutoGeneratedName = true)]
    [BaseType(typeof(NSObject))]
    interface MarketingCloudSDKLocationDelegate
    {
        // @required -(BOOL)sfmc_shouldShowLocationMessage:(NSDictionary * _Nonnull)message forRegion:(NSDictionary * _Nonnull)region;
        [Abstract]
        [Export("sfmc_shouldShowLocationMessage:forRegion:")]
        bool ForRegion(NSDictionary message, NSDictionary region);
    }

    // @interface Location (MobilePushSDK)
    [Category]
    [BaseType(typeof(MobilePushSDK))]
    interface MobilePushSDK_Location
    {
        // -(void)sfmc_setLocationDelegate:(id<MarketingCloudSDKLocationDelegate> _Nullable)delegate;
        [Export("sfmc_setLocationDelegate:")]
        void Sfmc_setLocationDelegate([NullAllowed] MarketingCloudSDKLocationDelegate @delegate);

        // -(void)sfmc_setSFMCSdkLocationDelegate:(id<SFMCSdkLocationDelegate> _Nullable)delegate;
        [Export("sfmc_setSFMCSdkLocationDelegate:")]
        void Sfmc_setSFMCSdkLocationDelegate([NullAllowed] SFMCSdkLocationDelegate @delegate);

        // -(CLRegion * _Nullable)sfmc_regionFromDictionary:(NSDictionary * _Nonnull)dictionary;
        [Export("sfmc_regionFromDictionary:")]
        [return: NullAllowed]
        CLRegion Sfmc_regionFromDictionary(NSDictionary dictionary);

        // -(BOOL)sfmc_locationEnabled;
        [Export("sfmc_locationEnabled")]
        bool Sfmc_locationEnabled();

        // -(void)sfmc_startWatchingLocation;
        [Export("sfmc_startWatchingLocation")]
        void Sfmc_startWatchingLocation();

        // -(void)sfmc_stopWatchingLocation;
        [Export("sfmc_stopWatchingLocation")]
        void Sfmc_stopWatchingLocation();

        // -(BOOL)sfmc_watchingLocation;
        [Export("sfmc_watchingLocation")]
        bool Sfmc_watchingLocation();

        // -(NSDictionary<NSString *,NSString *> * _Nullable)sfmc_lastKnownLocation;
        [NullAllowed, Export("sfmc_lastKnownLocation")]
        NSDictionary<NSString, NSString> Sfmc_lastKnownLocation();
    }

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

    // @interface URLHandling (MobilePushSDK)
    [Category]
    [BaseType(typeof(MobilePushSDK))]
    interface MobilePushSDK_URLHandling
    {
        // -(void)sfmc_setURLHandlingDelegate:(id<MarketingCloudSDKURLHandlingDelegate> _Nullable)delegate;
        [Export("sfmc_setURLHandlingDelegate:")]
        void Sfmc_setURLHandlingDelegate([NullAllowed] MarketingCloudSDKURLHandlingDelegate @delegate);

        // -(void)sfmc_setSFMCSdkURLHandlingDelegate:(id<SFMCSdkURLHandlingDelegate> _Nullable)delegate;
        [Export("sfmc_setSFMCSdkURLHandlingDelegate:")]
        void Sfmc_setSFMCSdkURLHandlingDelegate([NullAllowed] SFMCSdkURLHandlingDelegate @delegate);
    }

    // @protocol MarketingCloudSDKEventDelegate <NSObject>
    [Protocol, Model(AutoGeneratedName = true)]
    [BaseType(typeof(NSObject))]
    interface MarketingCloudSDKEventDelegate
    {
        // @optional -(BOOL)sfmc_shouldShowInAppMessage:(NSDictionary * _Nonnull)message;
        [Export("sfmc_shouldShowInAppMessage:")]
        bool Sfmc_shouldShowInAppMessage(NSDictionary message);

        // @optional -(void)sfmc_didShowInAppMessage:(NSDictionary * _Nonnull)message;
        [Export("sfmc_didShowInAppMessage:")]
        void Sfmc_didShowInAppMessage(NSDictionary message);

        // @optional -(void)sfmc_didCloseInAppMessage:(NSDictionary * _Nonnull)message;
        [Export("sfmc_didCloseInAppMessage:")]
        void Sfmc_didCloseInAppMessage(NSDictionary message);
    }

    // @interface Events (MobilePushSDK)
    [Category]
    [BaseType(typeof(MobilePushSDK))]
    interface MobilePushSDK_Events
    {
        // -(void)sfmc_setInAppEventDelegate:(id<SFMCSdkInAppMessageEventDelegate> _Nullable)delegate;
        [Export("sfmc_setInAppEventDelegate:")]
        void Sfmc_setInAppEventDelegate([NullAllowed] SFMCSdkInAppMessageEventDelegate @delegate);

        // -(NSString * _Nullable)sfmc_messageIdForMessage:(NSDictionary * _Nonnull)message;
        [Export("sfmc_messageIdForMessage:")]
        [return: NullAllowed]
        string Sfmc_messageIdForMessage(NSDictionary message);

        // -(void)sfmc_showInAppMessage:(NSString * _Nonnull)messageId;
        [Export("sfmc_showInAppMessage:")]
        void Sfmc_showInAppMessage(string messageId);

        // -(BOOL)sfmc_setInAppMessageFontName:(NSString * _Nullable)fontName;
        [Export("sfmc_setInAppMessageFontName:")]
        bool Sfmc_setInAppMessageFontName([NullAllowed] string fontName);

        // -(void)sfmc_track:(id _Nullable)events;
        [Export("sfmc_track:")]
        void Sfmc_track([NullAllowed] NSObject events);
    }

    // @interface FeatureToggle (MobilePushSDK)
    [Category]
    [BaseType(typeof(MobilePushSDK))]
    interface MobilePushSDK_FeatureToggle
    {
        // -(void)sfmc_setAnalyticsEnabled:(BOOL)analyticsEnabled;
        [Export("sfmc_setAnalyticsEnabled:")]
        void Sfmc_setAnalyticsEnabled(bool analyticsEnabled);

        // -(BOOL)sfmc_isAnalyticsEnabled;
        [Export("sfmc_isAnalyticsEnabled")]
        bool Sfmc_isAnalyticsEnabled();

        // -(void)sfmc_setPiAnalyticsEnabled:(BOOL)analyticsEnabled;
        [Export("sfmc_setPiAnalyticsEnabled:")]
        void Sfmc_setPiAnalyticsEnabled(bool analyticsEnabled);

        // -(BOOL)sfmc_isPiAnalyticsEnabled;
        [Export("sfmc_isPiAnalyticsEnabled")]
        bool Sfmc_isPiAnalyticsEnabled();

        // -(void)sfmc_setLocationEnabled:(BOOL)locationEnabled;
        [Export("sfmc_setLocationEnabled:")]
        void Sfmc_setLocationEnabled(bool locationEnabled);

        // -(BOOL)sfmc_isLocationEnabled;
        [Export("sfmc_isLocationEnabled")]
        bool Sfmc_isLocationEnabled();

        // -(void)sfmc_setInboxEnabled:(BOOL)inboxEnabled;
        [Export("sfmc_setInboxEnabled:")]
        void Sfmc_setInboxEnabled(bool inboxEnabled);

        // -(BOOL)sfmc_isInboxEnabled;
        [Export("sfmc_isInboxEnabled")]
        bool Sfmc_isInboxEnabled();
    }

    // @interface MarketingCloudSDKConfigBuilder : NSObject
    [BaseType(typeof(NSObject))]
    interface MarketingCloudSDKConfigBuilder
    {
        // -(NSDictionary * _Nullable)sfmc_build;
        [NullAllowed, Export("sfmc_build")]
        NSDictionary Sfmc_build { get; }

        // -(instancetype _Nonnull)sfmc_setApplicationId:(NSString * _Nonnull)setApplicationId;
        [Export("sfmc_setApplicationId:")]
        MarketingCloudSDKConfigBuilder Sfmc_setApplicationId(string setApplicationId);

        // -(instancetype _Nonnull)sfmc_setAccessToken:(NSString * _Nonnull)setAccessToken;
        [Export("sfmc_setAccessToken:")]
        MarketingCloudSDKConfigBuilder Sfmc_setAccessToken(string setAccessToken);

        // -(instancetype _Nonnull)sfmc_setLocationEnabled:(NSNumber * _Nonnull)setLocationEnabled;
        [Export("sfmc_setLocationEnabled:")]
        MarketingCloudSDKConfigBuilder Sfmc_setLocationEnabled(NSNumber setLocationEnabled);

        // -(instancetype _Nonnull)sfmc_setInboxEnabled:(NSNumber * _Nonnull)setInboxEnabled;
        [Export("sfmc_setInboxEnabled:")]
        MarketingCloudSDKConfigBuilder Sfmc_setInboxEnabled(NSNumber setInboxEnabled);

        // -(instancetype _Nonnull)sfmc_setPiAnalyticsEnabled:(NSNumber * _Nonnull)setPiAnalyticsEnabled;
        [Export("sfmc_setPiAnalyticsEnabled:")]
        MarketingCloudSDKConfigBuilder Sfmc_setPiAnalyticsEnabled(NSNumber setPiAnalyticsEnabled);

        // -(instancetype _Nonnull)sfmc_setUseLegacyPIIdentifier:(NSNumber * _Nonnull)etUseLegacyPIIdentifier;
        [Export("sfmc_setUseLegacyPIIdentifier:")]
        MarketingCloudSDKConfigBuilder Sfmc_setUseLegacyPIIdentifier(NSNumber etUseLegacyPIIdentifier);

        // -(instancetype _Nonnull)sfmc_setAnalyticsEnabled:(NSNumber * _Nonnull)setAnalyticsEnabled;
        [Export("sfmc_setAnalyticsEnabled:")]
        MarketingCloudSDKConfigBuilder Sfmc_setAnalyticsEnabled(NSNumber setAnalyticsEnabled);

        // -(instancetype _Nonnull)sfmc_setMid:(NSString * _Nonnull)setMid;
        [Export("sfmc_setMid:")]
        MarketingCloudSDKConfigBuilder Sfmc_setMid(string setMid);

        // -(instancetype _Nonnull)sfmc_setMarketingCloudServerUrl:(NSString * _Nonnull)setMarketingCloudServerUrl;
        [Export("sfmc_setMarketingCloudServerUrl:")]
        MarketingCloudSDKConfigBuilder Sfmc_setMarketingCloudServerUrl(string setMarketingCloudServerUrl);

        // -(instancetype _Nonnull)sfmc_setApplicationControlsBadging:(NSNumber * _Nonnull)setApplicationControlsBadging;
        [Export("sfmc_setApplicationControlsBadging:")]
        MarketingCloudSDKConfigBuilder Sfmc_setApplicationControlsBadging(NSNumber setApplicationControlsBadging);

        // -(instancetype _Nonnull)sfmc_setDelayRegistrationUntilContactKeyIsSet:(NSNumber * _Nonnull)delayRegistrationUntilContactKeyIsSet;
        [Export("sfmc_setDelayRegistrationUntilContactKeyIsSet:")]
        MarketingCloudSDKConfigBuilder Sfmc_setDelayRegistrationUntilContactKeyIsSet(NSNumber delayRegistrationUntilContactKeyIsSet);
    }

    // @interface MarketingCloudSDKSelectorUtils : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC17MarketingCloudSDK30MarketingCloudSDKSelectorUtils")]
    interface MarketingCloudSDKSelectorUtils
    {
        // +(BOOL)isAppDelegateImplementsSelector:(NSString * _Nonnull)selector __attribute__((warn_unused_result("")));
        [Static]
        [Export("isAppDelegateImplementsSelector:")]
        bool IsAppDelegateImplementsSelector(string selector);

        // +(BOOL)isUserNotificationDelegateImplementsSelector:(NSString * _Nonnull)selector __attribute__((warn_unused_result("")));
        [Static]
        [Export("isUserNotificationDelegateImplementsSelector:")]
        bool IsUserNotificationDelegateImplementsSelector(string selector);
    }

    public interface ISFMCSdkModuleConfig
    {
    }

    // @interface PushConfig : NSObject <SFMCSdkModuleConfig>
    [BaseType(typeof(NSObject), Name = "_TtC17MarketingCloudSDK10PushConfig")]
    [DisableDefaultCtor]
    interface PushConfig : ISFMCSdkModuleConfig
    {
        // @property (nonatomic) BOOL trackScreens;
        [Export("trackScreens")]
        bool TrackScreens { get; set; }

        // @property (readonly, nonatomic) enum SFMCSdkModuleName name;
        [Export("name")]
        SFMCSdkModuleName Name { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull appId;
        [Export("appId")]
        string AppId { get; }
    }

    // @interface PushConfigBuilder : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC17MarketingCloudSDK17PushConfigBuilder")]
    [DisableDefaultCtor]
    interface PushConfigBuilder
    {
        // -(instancetype _Nonnull)initWithAppId:(NSString * _Nonnull)appId __attribute__((objc_designated_initializer));
        [Export("initWithAppId:")]
        [DesignatedInitializer]
        IntPtr Constructor(string appId);

        // -(PushConfigBuilder * _Nonnull)setAccessToken:(NSString * _Nonnull)accessToken;
        [Export("setAccessToken:")]
        PushConfigBuilder SetAccessToken(string accessToken);

        // -(PushConfigBuilder * _Nonnull)setMarketingCloudServerUrl:(NSURL * _Nonnull)endpoint;
        [Export("setMarketingCloudServerUrl:")]
        PushConfigBuilder SetMarketingCloudServerUrl(NSUrl endpoint);

        // -(PushConfigBuilder * _Nonnull)setMid:(NSString * _Nonnull)mid;
        [Export("setMid:")]
        PushConfigBuilder SetMid(string mid);

        // -(PushConfigBuilder * _Nonnull)setLocationEnabled:(BOOL)enabled;
        [Export("setLocationEnabled:")]
        PushConfigBuilder SetLocationEnabled(bool enabled);

        // -(PushConfigBuilder * _Nonnull)setInboxEnabled:(BOOL)enabled;
        [Export("setInboxEnabled:")]
        PushConfigBuilder SetInboxEnabled(bool enabled);

        // -(PushConfigBuilder * _Nonnull)setAnalyticsEnabled:(BOOL)enabled;
        [Export("setAnalyticsEnabled:")]
        PushConfigBuilder SetAnalyticsEnabled(bool enabled);

        // -(PushConfigBuilder * _Nonnull)setPIAnalyticsEnabled:(BOOL)enabled;
        [Export("setPIAnalyticsEnabled:")]
        PushConfigBuilder SetPIAnalyticsEnabled(bool enabled);

        // -(PushConfigBuilder * _Nonnull)setUseLegacyPIIdentifier:(BOOL)enabled;
        [Export("setUseLegacyPIIdentifier:")]
        PushConfigBuilder SetUseLegacyPIIdentifier(bool enabled);

        // -(PushConfigBuilder * _Nonnull)setApplicationControlsBadging:(BOOL)enabled;
        [Export("setApplicationControlsBadging:")]
        PushConfigBuilder SetApplicationControlsBadging(bool enabled);

        // -(PushConfigBuilder * _Nonnull)setDelayRegistrationUntilContactKeyIsSet:(BOOL)enabled;
        [Export("setDelayRegistrationUntilContactKeyIsSet:")]
        PushConfigBuilder SetDelayRegistrationUntilContactKeyIsSet(bool enabled);

        // -(PushConfigBuilder * _Nonnull)setEnableScreenEntryTracking:(BOOL)enabled;
        [Export("setEnableScreenEntryTracking:")]
        PushConfigBuilder SetEnableScreenEntryTracking(bool enabled);

        // -(PushConfig * _Nonnull)build;
        [Export("build")]
        PushConfig Build { get; }
    }

    // @interface SFMCSdkPushModule : NSObject <PushInterface, SFMCModule, Subscriber>
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface SFMCSdkPushModule : PushInterface, SFMCModule, Subscriber
    {
        // @property (nonatomic) enum SFMCSdkModuleName name;
        [Export("name", ArgumentSemantic.Assign)]
        SFMCSdkModuleName Name { get; set; }

        // @property (copy, nonatomic, class) NSString * _Nonnull moduleVersion;
        [Static]
        [Export("moduleVersion")]
        string ModuleVersion { get; set; }

        // @property (copy, nonatomic, class) NSDictionary<NSString *,NSString *> * _Nullable stateProperties;
        [Static]
        [NullAllowed, Export("stateProperties", ArgumentSemantic.Copy)]
        NSDictionary<NSString, NSString> StateProperties { get; set; }

        // @property (nonatomic, class) enum SFMCSdkModuleStatus status;
        [Static]
        [Export("status", ArgumentSemantic.Assign)]
        SFMCSdkModuleStatus Status { get; set; }

        // @property (readonly, nonatomic, strong, class) SFMCSdkPushModule * _Nonnull shared;
        [Static]
        [Export("shared", ArgumentSemantic.Strong)]
        SFMCSdkPushModule Shared { get; }

        // @property (readonly, nonatomic, strong, class) SFMCSdkModuleLogger * _Nonnull logger;
        [Static]
        [Export("logger", ArgumentSemantic.Strong)]
        SFMCSdkModuleLogger Logger { get; }

        // +(NSDictionary<NSString *,id> * _Nonnull)metadata __attribute__((warn_unused_result("")));
        [Static]
        [Export("metadata")]
        NSDictionary<NSString, NSObject> Metadata { get; }

        // -(BOOL)refreshWithFetchCompletionHandler:(void (^ _Nullable)(UIBackgroundFetchResult))completionHandler __attribute__((warn_unused_result("")));
        [Export("refreshWithFetchCompletionHandler:")]
        bool RefreshWithFetchCompletionHandler([NullAllowed] Action<UIBackgroundFetchResult> completionHandler);

        // -(void)tearDown __attribute__((deprecated("This method will be removed as the Push Module will automatically handle tear downs upon initializations")));
        [Export("tearDown")]
        void TearDown();

        // -(BOOL)resetDataPolicy __attribute__((warn_unused_result("")));
        [Export("resetDataPolicy")]
        bool ResetDataPolicy { get; }

        // -(void)setDebugLoggingEnabled:(BOOL)enabled;
        [Export("setDebugLoggingEnabled:")]
        void SetDebugLoggingEnabled(bool enabled);

        // +(SFMCSdkModuleLogger * _Nonnull)getLogger __attribute__((warn_unused_result("")));
        [Static]
        [Export("getLogger")]
        SFMCSdkModuleLogger GetLogger { get; }

        // -(NSString * _Nullable)contactKey __attribute__((warn_unused_result("")));
        [NullAllowed, Export("contactKey")]
        string ContactKey { get; }

        // -(BOOL)addTag:(NSString * _Nonnull)tag __attribute__((warn_unused_result("")));
        [Export("addTag:")]
        bool AddTag(string tag);

        // -(NSSet * _Nullable)addTags:(NSArray * _Nonnull)tags __attribute__((warn_unused_result("")));
        [Export("addTags:")]
        [return: NullAllowed]
        NSSet AddTags(NSObject[] tags);

        // -(BOOL)removeTag:(NSString * _Nonnull)tag __attribute__((warn_unused_result("")));
        [Export("removeTag:")]
        bool RemoveTag(string tag);

        // -(NSSet * _Nullable)tags __attribute__((warn_unused_result("")));
        [NullAllowed, Export("tags")]
        NSSet Tags { get; }

        // -(void)setDeviceToken:(NSData * _Nonnull)deviceToken;
        [Export("setDeviceToken:")]
        void SetDeviceToken(NSData deviceToken);

        // -(NSString * _Nullable)deviceToken __attribute__((warn_unused_result("")));
        [NullAllowed, Export("deviceToken")]
        string DeviceToken { get; }

        // -(NSDictionary * _Nullable)attributes __attribute__((warn_unused_result("")));
        [NullAllowed, Export("attributes")]
        NSDictionary Attributes { get; }

        // -(NSString * _Nullable)accessToken __attribute__((warn_unused_result("")));
        [NullAllowed, Export("accessToken")]
        string AccessToken { get; }

        // -(NSString * _Nullable)deviceIdentifier __attribute__((warn_unused_result("")));
        [NullAllowed, Export("deviceIdentifier")]
        string DeviceIdentifier { get; }

        // -(BOOL)setSignedString:(NSString * _Nullable)signedString __attribute__((warn_unused_result("")));
        [Export("setSignedString:")]
        bool SetSignedString([NullAllowed] string signedString);

        // -(NSString * _Nullable)signedString __attribute__((warn_unused_result("")));
        [NullAllowed, Export("signedString")]
        string SignedString { get; }

        // -(void)setRegistrationCallback:(void (^ _Nonnull)(NSDictionary * _Nonnull))registrationCallback;
        [Export("setRegistrationCallback:")]
        void SetRegistrationCallback(Action<NSDictionary> registrationCallback);

        // -(void)unsetRegistrationCallback;
        [Export("unsetRegistrationCallback")]
        void UnsetRegistrationCallback();

        // -(BOOL)pushEnabled __attribute__((warn_unused_result("")));
        // -(void)setPushEnabled:(BOOL)pushEnabled;
        [Export("pushEnabled")]
        bool PushEnabled { get; set; }

        // -(void)setAnalyticsEnabled:(BOOL)analyticsEnabled;
        [Export("setAnalyticsEnabled:")]
        void SetAnalyticsEnabled(bool analyticsEnabled);

        // -(BOOL)isAnalyticsEnabled __attribute__((warn_unused_result("")));
        [Export("isAnalyticsEnabled")]
        bool IsAnalyticsEnabled { get; }

        // -(void)setPiAnalyticsEnabled:(BOOL)analyticsEnabled;
        [Export("setPiAnalyticsEnabled:")]
        void SetPiAnalyticsEnabled(bool analyticsEnabled);

        // -(BOOL)isPiAnalyticsEnabled __attribute__((warn_unused_result("")));
        [Export("isPiAnalyticsEnabled")]
        bool IsPiAnalyticsEnabled { get; }

        // -(BOOL)isLocationEnabled __attribute__((warn_unused_result("")));
        [Export("isLocationEnabled")]
        bool IsLocationEnabled { get; }

        // -(BOOL)isInboxEnabled __attribute__((warn_unused_result("")));
        [Export("isInboxEnabled")]
        bool IsInboxEnabled { get; }

        // -(void)setInboxEnabled:(BOOL)inboxEnabled;
        [Export("setInboxEnabled:")]
        void SetInboxEnabled(bool inboxEnabled);

        // -(UNNotificationRequest * _Nullable)notificationRequest __attribute__((warn_unused_result("")));
        // -(void)setNotificationRequest:(UNNotificationRequest * _Nonnull)request;
        [NullAllowed, Export("notificationRequest")]
        UNNotificationRequest NotificationRequest { get; set; }

        // -(NSDictionary * _Nonnull)notificationUserInfo __attribute__((warn_unused_result("")));
        // -(void)setNotificationUserInfo:(NSDictionary * _Nonnull)userInfo;
        [Export("notificationUserInfo")]
        NSDictionary NotificationUserInfo { get; set; }

        // -(id<SFMCSdkModuleIdentity> _Nullable)getIdentity __attribute__((warn_unused_result("")));
        [NullAllowed, Export("getIdentity")]
        SFMCSdkModuleIdentity Identity { get; }

        // -(void)setEventDelegate:(id<SFMCSdkInAppMessageEventDelegate> _Nullable)delegate;
        [Export("setEventDelegate:")]
        void SetEventDelegate([NullAllowed] SFMCSdkInAppMessageEventDelegate @delegate);

        // -(NSString * _Nullable)messageIdForMessage:(NSDictionary * _Nonnull)forMessage __attribute__((warn_unused_result("")));
        [Export("messageIdForMessage:")]
        [return: NullAllowed]
        string MessageIdForMessage(NSDictionary forMessage);

        // -(void)showInAppMessageWithMessageId:(NSString * _Nonnull)messageId;
        [Export("showInAppMessageWithMessageId:")]
        void ShowInAppMessageWithMessageId(string messageId);

        // -(BOOL)setInAppMessageWithFontName:(NSString * _Nullable)fontName __attribute__((warn_unused_result("")));
        [Export("setInAppMessageWithFontName:")]
        bool SetInAppMessageWithFontName([NullAllowed] string fontName);

        // -(NSArray * _Nullable)getAllMessages __attribute__((warn_unused_result("")));
        [NullAllowed, Export("getAllMessages")]
        NSObject[] AllMessages { get; }

        // -(NSArray * _Nullable)getUnreadMessages __attribute__((warn_unused_result("")));
        [NullAllowed, Export("getUnreadMessages")]
        NSObject[] UnreadMessages { get; }

        // -(NSArray * _Nullable)getReadMessages __attribute__((warn_unused_result("")));
        [NullAllowed, Export("getReadMessages")]
        NSObject[] ReadMessages { get; }

        // -(NSArray * _Nullable)getDeletedMessages __attribute__((warn_unused_result("")));
        [NullAllowed, Export("getDeletedMessages")]
        NSObject[] DeletedMessages { get; }

        // -(NSUInteger)getAllMessagesCount __attribute__((warn_unused_result("")));
        [Export("getAllMessagesCount")]
        nuint AllMessagesCount { get; }

        // -(NSUInteger)getUnreadMessagesCount __attribute__((warn_unused_result("")));
        [Export("getUnreadMessagesCount")]
        nuint UnreadMessagesCount { get; }

        // -(NSUInteger)getReadMessagesCount __attribute__((warn_unused_result("")));
        [Export("getReadMessagesCount")]
        nuint ReadMessagesCount { get; }

        // -(NSUInteger)getDeletedMessagesCount __attribute__((warn_unused_result("")));
        [Export("getDeletedMessagesCount")]
        nuint DeletedMessagesCount { get; }

        // -(BOOL)markMessageRead:(NSDictionary * _Nonnull)messageDictionary __attribute__((warn_unused_result("")));
        [Export("markMessageRead:")]
        bool MarkMessageRead(NSDictionary messageDictionary);

        // -(BOOL)markMessageDeleted:(NSDictionary * _Nonnull)messageDictionary __attribute__((warn_unused_result("")));
        [Export("markMessageDeleted:")]
        bool MarkMessageDeleted(NSDictionary messageDictionary);

        // -(BOOL)markMessageWithIdReadWithMessageId:(NSString * _Nonnull)messageId __attribute__((warn_unused_result("")));
        [Export("markMessageWithIdReadWithMessageId:")]
        bool MarkMessageWithIdReadWithMessageId(string messageId);

        // -(BOOL)markMessageWithIdDeletedWithMessageId:(NSString * _Nonnull)messageId __attribute__((warn_unused_result("")));
        [Export("markMessageWithIdDeletedWithMessageId:")]
        bool MarkMessageWithIdDeletedWithMessageId(string messageId);

        // -(BOOL)markAllMessagesRead __attribute__((warn_unused_result("")));
        [Export("markAllMessagesRead")]
        bool MarkAllMessagesRead { get; }

        // -(BOOL)markAllMessagesDeleted __attribute__((warn_unused_result("")));
        [Export("markAllMessagesDeleted")]
        bool MarkAllMessagesDeleted { get; }

        // -(BOOL)refreshMessages __attribute__((warn_unused_result("")));
        [Export("refreshMessages")]
        bool RefreshMessages { get; }

        // -(id<SFMCSdkInboxMessagesDataSource> _Nullable)inboxMessagesTableViewDataSourceForTableView:(UITableView * _Nonnull)tableView __attribute__((warn_unused_result("")));
        [Export("inboxMessagesTableViewDataSourceForTableView:")]
        [return: NullAllowed]
        SFMCSdkInboxMessagesDataSource InboxMessagesTableViewDataSourceForTableView(UITableView tableView);

        // -(id<SFMCSdkInboxMessagesDelegate> _Nullable)inboxMessagesTableViewDelegateForTableView:(UITableView * _Nonnull)tableView dataSource:(id<SFMCSdkInboxMessagesDataSource> _Nonnull)dataSource __attribute__((warn_unused_result("")));
        [Export("inboxMessagesTableViewDelegateForTableView:dataSource:")]
        [return: NullAllowed]
        SFMCSdkInboxMessagesDelegate InboxMessagesTableViewDelegateForTableView(UITableView tableView, SFMCSdkInboxMessagesDataSource dataSource);

        // -(BOOL)setPiIdentifier:(NSString * _Nullable)identifier __attribute__((warn_unused_result("")));
        [Export("setPiIdentifier:")]
        bool SetPiIdentifier([NullAllowed] string identifier);

        // -(NSString * _Nullable)piIdentifier __attribute__((warn_unused_result("")));
        [NullAllowed, Export("piIdentifier")]
        string PiIdentifier { get; }

        // -(void)trackMessageOpened:(NSDictionary * _Nonnull)inboxMessage;
        [Export("trackMessageOpened:")]
        void TrackMessageOpened(NSDictionary inboxMessage);

        // -(void)trackPageViewWithUrl:(NSString * _Nonnull)url title:(NSString * _Nullable)title item:(NSString * _Nullable)item search:(NSString * _Nullable)search;
        [Export("trackPageViewWithUrl:title:item:search:")]
        void TrackPageViewWithUrl(string url, [NullAllowed] string title, [NullAllowed] string item, [NullAllowed] string search);

        // -(void)trackCartContents:(NSDictionary * _Nonnull)cartDictionary;
        [Export("trackCartContents:")]
        void TrackCartContents(NSDictionary cartDictionary);

        // -(void)trackCartConversion:(NSDictionary * _Nonnull)orderDictionary;
        [Export("trackCartConversion:")]
        void TrackCartConversion(NSDictionary orderDictionary);

        // -(NSDictionary * _Nullable)cartItemDictionaryWithPrice:(NSNumber * _Nonnull)price quantity:(NSNumber * _Nonnull)quantity item:(NSString * _Nonnull)item uniqueId:(NSString * _Nullable)uniqueId __attribute__((warn_unused_result("")));
        [Export("cartItemDictionaryWithPrice:quantity:item:uniqueId:")]
        [return: NullAllowed]
        NSDictionary CartItemDictionaryWithPrice(NSNumber price, NSNumber quantity, string item, [NullAllowed] string uniqueId);

        // -(NSDictionary * _Nullable)cartDictionaryWithCartItem:(NSArray * _Nonnull)cartItem __attribute__((warn_unused_result("")));
        [Export("cartDictionaryWithCartItem:")]
        [return: NullAllowed]
        NSDictionary CartDictionaryWithCartItem(NSObject[] cartItem);

        // -(NSDictionary * _Nullable)orderDictionaryWithOrderNumber:(NSString * _Nonnull)orderNumber shipping:(NSNumber * _Nonnull)shipping discount:(NSNumber * _Nonnull)discount cart:(NSDictionary * _Nonnull)cart __attribute__((warn_unused_result("")));
        [Export("orderDictionaryWithOrderNumber:shipping:discount:cart:")]
        [return: NullAllowed]
        NSDictionary OrderDictionaryWithOrderNumber(string orderNumber, NSNumber shipping, NSNumber discount, NSDictionary cart);

        // -(void)setLocationDelegate:(id<SFMCSdkLocationDelegate> _Nullable)delegate;
        [Export("setLocationDelegate:")]
        void SetLocationDelegate([NullAllowed] SFMCSdkLocationDelegate @delegate);

        // -(CLRegion * _Nullable)regionFromDictionary:(NSDictionary * _Nonnull)dictionary __attribute__((warn_unused_result("")));
        [Export("regionFromDictionary:")]
        [return: NullAllowed]
        CLRegion RegionFromDictionary(NSDictionary dictionary);

        // -(BOOL)locationEnabled __attribute__((warn_unused_result("")));
        // -(void)setLocationEnabled:(BOOL)locationEnabled;
        [Export("locationEnabled")]
        bool LocationEnabled { get; set; }

        // -(void)startWatchingLocation;
        [Export("startWatchingLocation")]
        void StartWatchingLocation();

        // -(void)stopWatchingLocation;
        [Export("stopWatchingLocation")]
        void StopWatchingLocation();

        // -(BOOL)watchingLocation __attribute__((warn_unused_result("")));
        [Export("watchingLocation")]
        bool WatchingLocation { get; }

        // -(NSDictionary<NSString *,NSString *> * _Nullable)lastKnownLocation __attribute__((warn_unused_result("")));
        [NullAllowed, Export("lastKnownLocation")]
        NSDictionary<NSString, NSString> LastKnownLocation { get; }

        // -(void)setURLHandlingDelegate:(id<SFMCSdkURLHandlingDelegate> _Nullable)delegate;
        [Export("setURLHandlingDelegate:")]
        void SetURLHandlingDelegate([NullAllowed] SFMCSdkURLHandlingDelegate @delegate);

        // +(id<SFMCModule> _Nullable)initModuleWithConfig:(id<SFMCSdkModuleConfig> _Nonnull)config components:(SFMCSdkComponents * _Nonnull)components __attribute__((objc_method_family("none"))) __attribute__((warn_unused_result("")));
        [Static]
        [Export("initModuleWithConfig:components:")]
        [return: NullAllowed]
        SFMCModule InitModuleWithConfig(SFMCSdkModuleConfig config, SFMCSdkComponents components);

        // +(void)sendIdentityEventForTags;
        [Static]
        [Export("sendIdentityEventForTags")]
        void SendIdentityEventForTags();

        // +(void)sendIdentityEventForContactKey;
        [Static]
        [Export("sendIdentityEventForContactKey")]
        void SendIdentityEventForContactKey();

        // +(void)sendIdentityEventForAttributes;
        [Static]
        [Export("sendIdentityEventForAttributes")]
        void SendIdentityEventForAttributes();

        // -(void)receiveWithMessage:(SFMCSdkMessage * _Nonnull)message;
        [Export("receiveWithMessage:")]
        void ReceiveWithMessage(SFMCSdkMessage message);

        // +(void)sendSfmcEvent:(SFMCEvent * _Nonnull)event category:(enum SFMCSdkEventCategory)category;
        [Static]
        [Export("sendSfmcEvent:category:")]
        void SendSfmcEvent(SFMCEvent @event, SFMCSdkEventCategory category);
    }

}

