using Microsoft.MobileBlazorBindings.WebView.Windows;
using System;
using System.Threading.Tasks;
using Hara.Abstractions.Contracts;
using Hara.WebCommon;
using Hara.XamarinCommon;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WPF;

namespace Hara.Windows
{
    public class MainWindow : FormsApplicationPage
    {
        [STAThread]
        public static void Main()
        {
            var app = new System.Windows.Application();
            app.Run(new MainWindow());
        }

        public MainWindow()
        {
            Forms.Init();
            BlazorHybridWindows.Init();
            LoadApplication(new App(null, collection =>
            {
                collection.AddSingleton<INotificationManager, WebNotificationManager>();
                collection.AddSingleton<IConfigProvider, JsInteropConfigProvider>();
                
            }));
        }
    }

    public class StubNotificationManager : INotificationManager
    {
        public bool Initialized { get; } = false;
        public event EventHandler<NotificationEventArgs> NotificationReceived;
        public Task<bool> Initialize()
        {
            return Task.FromResult(false);
        }

        public Task<string> ScheduleNotification(string title, string message)
        {
            throw new NotImplementedException();
        }

        public void ReceiveNotification(string title, string message)
        {
            throw new NotImplementedException();
        }
    }
}
