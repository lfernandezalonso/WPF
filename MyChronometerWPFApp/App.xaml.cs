using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace MyChronometerWPFApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override async void OnStartup(StartupEventArgs startupEventArgs)
        {
            base.OnStartup(startupEventArgs);
            ServiceCollection services = new ServiceCollection();

            // Register your views and view models
            services.AddScoped<MainWindow>();

            // Register any other services (e.g., ITimerManager)
            services.AddScoped<ITimerManager>(provider => new MyDispatcherTimerManager());

            var temp = new MyDispatcherTimerManager();

            ServiceProvider serviceProvider = services.BuildServiceProvider();
            MainWindow mainWindow = serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
}
