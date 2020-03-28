using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using Com.Karumi.Dexter;
using Com.Karumi.Dexter.Listener;
using Com.Karumi.Dexter.Listener.Single;
using Prism;
using Prism.Ioc;
using WalkOut.Droid.PrintService;

namespace WalkOut.Droid
{
    [Activity(Label = "WalkOut", Icon = "@drawable/ic_icon_launcher", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity, IPermissionListener
    {
        internal static Context AppContext;

        public void OnPermissionDenied(PermissionDeniedResponse p0)
        {
            //throw new System.NotImplementedException();
        }

        public void OnPermissionGranted(PermissionGrantedResponse p0)
        {
            
        }

        public void OnPermissionRationaleShouldBeShown(PermissionRequest p0, IPermissionToken p1)
        {
            Toast.MakeText(this, "You must accept this permission", ToastLength.Short).Show();
        }

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App(new AndroidInitializer()));

            Dexter.WithActivity(this)
                .WithPermission(Manifest.Permission.WriteExternalStorage)
                .WithListener(this)
                .Check();

            AppContext = this;

            CommonTasks.WriteFileToStorage("calibri.ttf");
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }

    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Register any platform specific implementations
        }
    }
}

