using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Hara.Abstractions.Contracts;
using Hara.XamarinCommon;
using LocalNotifications.Droid;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.MobileBlazorBindings.WebView.Android;
using Xamarin.Forms;

namespace Hara.Droid
{
    [Activity(LaunchMode = LaunchMode.SingleTop, Label = "Hara", Icon = "@mipmap/icon", Theme = "@style/MainTheme",
        MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        private App _app;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            BlazorHybridAndroid.Init();

            var fileProvider = new AssetFileProvider(Assets, "wwwroot");

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            Xamarin.Forms.Forms.Init(this, savedInstanceState);
            _app = new App(fileProvider,
                collection => { collection.AddSingleton<INotificationManager, AndroidNotificationManager>(); });
            LoadApplication(_app);

            CreateNotificationFromIntent(Intent);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions,
            [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        protected override void OnNewIntent(Intent intent)
        {
            CreateNotificationFromIntent(intent);
        }

        void CreateNotificationFromIntent(Intent intent)
        {
            if (intent?.Extras != null)
            {
                string title = intent.Extras.GetString(AndroidNotificationManager.TitleKey);
                string message = intent.Extras.GetString(AndroidNotificationManager.MessageKey);
                _app.ServiceProvider.GetService<INotificationManager>().ReceiveNotification(title, message);
            }
        }
    }
}