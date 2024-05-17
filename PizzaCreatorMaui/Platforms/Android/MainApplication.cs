using Android.App;
using Android.Runtime;

namespace PizzaCreatorMaui
{
// MODIFY THIS TO MAKE IT WORK WITH API
#if DEBUG
    [Application(UsesCleartextTraffic = true)]
#else
    [Application]
#endif
    public class MainApplication : MauiApplication
    {
        public MainApplication(IntPtr handle, JniHandleOwnership ownership)
            : base(handle, ownership)
        {
        }
        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    }

    //--- ORIGINAL THAT WORKS
    //[Application]
    //public class MainApplication : MauiApplication
    //{
    //    public MainApplication(IntPtr handle, JniHandleOwnership ownership)
    //        : base(handle, ownership)
    //    {
    //    }

    //    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    //}
}
