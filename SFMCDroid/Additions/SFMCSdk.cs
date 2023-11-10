using Android.Content;
using Android.Runtime;
using Java.Interop;
using Java.Util.Functions;
using Kotlin;
using Kotlin.Jvm.Functions;
using System;
using IFunction = Kotlin.IFunction;

namespace Com.Salesforce.Marketingcloud.Sfmcsdk
{
    public partial class SFMCSdk
    {
        public static void Configure(Context context, object config, InitializationListener listener)
        {
            Configure(context, config, listener);
        }
    }

    public class InitializationListener : Java.Lang.Object, IFunction1, IFunction, IJavaObject, IJavaPeerable, IDisposable
    {
        private readonly System.Action<object> OnInvoked;

        public InitializationListener(System.Action<object> onInvoke)
        {
            OnInvoked = onInvoke;
        }

        public Java.Lang.Object Invoke(Java.Lang.Object objParameter)
        {
            try
            {
                object parameter = (object)objParameter;
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
