using System;
using ObjCRuntime;

namespace SFMCiOS
{
    [Native]
    public enum SFKeychainItemExceptionErrorCode : ulong
    {
        SFKeychainItemExceptionKeychainInaccessible = 1
    }

    [Native]
    public enum SFMCSdkBehaviorType : long
    {
        AppForegrounded = 0,
        AppBackgrounded = 1,
        AppVersionChanged = 2,
        ScreenEntry = 3
    }

    [Native]
    public enum SFMCSdkConsent : long
    {
        OptIn = 0,
        OptOut = 1,
        Pending = 2,
        None = 3
    }

    [Native]
    public enum SFMCSDKDataMergePolicy : long
    {
        None = 0,
        Auto = 1,
        Manual = 2
    }

    [Native]
    public enum SFMCSdkEventCategory : long
    {
        Engagement = 0,
        Identity = 1,
        System = 2
    }

    [Native]
    public enum SFMCSdkLogLevel : long
    {
        Debug = 0,
        Warn = 1,
        Error = 2,
        Fault = 3,
        None = 4
    }

    [Native]
    public enum SFMCSdkLoggerCategory : long
    {
        Auth = 0,
        Behavior = 1,
        Encryption = 2,
        EventBus = 3,
        Network = 4,
        Module = 5,
        Sdk = 6,
        Storage = 7,
        Consent = 8,
        Coredata = 9,
        Database = 10,
        Event = 11,
        Identity = 12,
        Interface = 13,
        Location = 14,
        Session = 15,
        Util = 16
    }

    [Native]
    public enum SFMCSdkMessageProducer : long
    {
        Cdp = 0,
        Push = 1,
        Sdk = 2
    }

    [Native]
    public enum SFMCSdkModuleName : long
    {
        Cdp = 0,
        Push = 1
    }

    [Native]
    public enum SFMCSdkModuleStatus : long
    {
        Cancelled = 0,
        Disabled = 1,
        Failed = 2,
        Inactive = 3,
        Initializing = 4,
        Operational = 5
    }

    [Native]
    public enum SFMCSdkNetworkManagerError : long
    {
        TokenFetchFailed = 0,
        TokenRefreshFailed = 1,
        TooManyRequests = 2,
        RequestAlreadyInFlight = 3
    }

    [Native]
    public enum SFMCSdkOperationResult : long
    {
        Cancelled = 0,
        Error = 1,
        Success = 2,
        Timeout = 3
    }

    [Native]
    public enum AuthEventType : long
    {
        Login
    }

    [Native]
    public enum configureError : ulong
    {
        firstConfigureErrorIndex = 0,
        configureNoError = firstConfigureErrorIndex,
        configureInvalidAppIDError,
        configureInvalidAccessTokenError,
        configureUnableToReadRandomError,
        configureDatabaseAccessError,
        configureUnableToKeyDatabaseError,
        configureCCKeyDerivationPBKDFError,
        configureCCSymmetricKeyWrapError,
        configureCCSymmetricKeyUnwrapError,
        configureKeyChainError,
        configureUnableToReadCertificateError,
        configureRunOnceSimultaneouslyError,
        configureRunOnceError,
        configureInvalidLocationAndProximityError,
        configureSimulatorBlobError,
        configureKeyChainInvalidError,
        configureIncorrectConfigurationCallingSequenceError,
        configureMissingConfigurationFileError,
        configureInvalidConfigurationFileError,
        configureInvalidConfigurationIndexError,
        configureFailedFrameworkCreationError,
        configureInvalidAppEndpointError,
        lastConfigureErrorIndex = configureInvalidAppEndpointError
    }

}

