using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;

namespace WalkOut.Droid
{
    [Activity(Label = "Declaratie proprie raspundere", Icon = "@drawable/ic_icon_launcher", Theme = "@style/SplashScreen", MainLauncher = true, NoHistory = true, ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
        }

        protected override void OnResume()
        {
            base.OnResume();
            Task startup = new Task(() => { SimulateStartup(); });
            startup.Start();
        }

        async void SimulateStartup()
        {
            await Task.Delay(500);
            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
        }
    }
}