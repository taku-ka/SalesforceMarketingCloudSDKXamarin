using Android.Content;
using Android.Runtime;
using Java.Interop;
using Kotlin;
using Kotlin.Jvm.Functions;
using System;

namespace Com.Salesforce.Marketingcloud.Sfmcsdk
{
    public partial class SFMCSdk
    {
        public static void Configure(Context context, SFMCSdkModuleConfig config, InitializationListener listener)
        {
            Configure(context, config, listener);
        }
    }

    public class InitializationListener : Java.Lang.Object, IFunction1, IFunction, IJavaObject, IJavaPeerable, IDisposable
    {
        private readonly System.Action<SFMCSdkInitializationStatus> OnInvoked;

        public InitializationListener(System.Action<SFMCSdkInitializationStatus> onInvoke)
        {
            OnInvoked = onInvoke;
        }

        public Java.Lang.Object Invoke(Java.Lang.Object objParameter)
        {
            try
            {
                SFMCSdkInitializationStatus parameter = (SFMCSdkInitializationStatus)objParameter;
                OnInvoked?.Invoke(parameter);
            }
            catch (Java.Lang.Exception ex)
            {
                // Exception handling, if needed
            }
            catch (System.Exception se)
            {
                // Exception handling, if needed
            }

            return null;
        }
    }
}
