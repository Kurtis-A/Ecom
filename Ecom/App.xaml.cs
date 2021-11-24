﻿using Ecom.Services;
using Ecom.Data.Repository;
using Ecom.ViewModel.User;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using Ecom.Helpers;
using ToastNotifications;
using ToastNotifications.Position;
using ToastNotifications.Lifetime;
using System;

namespace Ecom
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            _serviceProvider = ConfigureServices().BuildServiceProvider();
            ConfigureNotifications();
        }

        private void ConfigureNotifications()
        {
            Globals.Notifier = new Notifier(cfg =>
            {
                cfg.PositionProvider = new WindowPositionProvider(
                    parentWindow: Current.MainWindow,
                    corner: Corner.TopRight,
                    offsetX: 10,
                    offsetY: 55);

                cfg.LifetimeSupervisor = new TimeAndCountBasedLifetimeSupervisor(
                    notificationLifetime: TimeSpan.FromSeconds(3),
                    maximumNotificationCount: MaximumNotificationCount.FromCount(3));

                cfg.Dispatcher = Current.Dispatcher;
            });
        }

        private ServiceCollection ConfigureServices()
        {
            var services = new ServiceCollection();

            //Views
            services.AddTransient<BaseWindow>();

            //View Model
            services.AddScoped<SingleUserViewModel>();

            //Service
            services.AddScoped<UserService>();

            //Repository
            services.AddScoped<UserRepository>();

            return services;
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var window = _serviceProvider.GetService<BaseWindow>();
            window?.Show();
        }
    }
}
