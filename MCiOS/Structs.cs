using System;
using ObjCRuntime;

namespace MarketingIOS
{
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

