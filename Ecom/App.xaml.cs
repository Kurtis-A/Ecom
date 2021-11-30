using Ecom.Services;
using Ecom.Data.Repository;
using Ecom.ViewModel.Staff;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using Ecom.Helpers;
using ToastNotifications;
using ToastNotifications.Position;
using ToastNotifications.Lifetime;
using System;
using AutoMapper;
using Ecom.Data.Model;
using Ecom.Data;
using Ecom.View.Staff;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Ecom
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IConfiguration Configuration { get; set; }

        public App()
        {
            //Add Appsettings
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true);

            Configuration = builder.Build();

            Globals.ServiceProvider = ConfigureServices().BuildServiceProvider();
            ConfigureNotifications();
            ConfigureMapper();
        }

        private void ConfigureNotifications()
        {
            Globals.Notifier = new Notifier(cfg =>
            {
                cfg.PositionProvider = new WindowPositionProvider(
                    parentWindow: Current.MainWindow,
                    corner: Corner.TopRight,
                    offsetX: 10,
                    offsetY: 65);

                cfg.LifetimeSupervisor = new TimeAndCountBasedLifetimeSupervisor(
                    notificationLifetime: TimeSpan.FromSeconds(3),
                    maximumNotificationCount: MaximumNotificationCount.FromCount(3));

                cfg.Dispatcher = Current.Dispatcher;
            });
        }

        private void ConfigureMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<StaffListViewModel, Staff>();
                cfg.CreateMap<StaffViewModel, Staff>();
                cfg.CreateMap<Staff, StaffListViewModel>();
                cfg.CreateMap<Staff, StaffViewModel>();
            });

            Globals.Mapper = config.CreateMapper();
        }

        private ServiceCollection ConfigureServices()
        {
            var services = new ServiceCollection();

            //Views
            services.AddSingleton(typeof(BaseWindow));
            services.AddSingleton(typeof(StaffView));

            //View Model
            services.AddScoped<StaffViewModel>();

            //Service
            services.AddScoped<StaffService>();

            //Repository
            services.AddScoped<StaffRepository>();

            //Db Context
            services.AddDbContext<ApplicationDbContext>(option =>
            {
                option.UseSqlServer(Configuration.GetConnectionString("Local"));
            },ServiceLifetime.Transient);
            

            return services;
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var window = Globals.ServiceProvider.GetService<BaseWindow>();
            window?.Show();
        }
    }
}
