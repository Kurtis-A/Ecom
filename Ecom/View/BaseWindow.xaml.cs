using Ecom.Helpers;
using Ecom.View.Absence;
using Ecom.View.Planner;
using Ecom.View.Staff;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using System.Windows.Input;
using ToastNotifications.Messages;

namespace Ecom
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class BaseWindow : Window
    {
        public BaseWindow()
        {
            InitializeComponent();

            PlannerView.Content = Globals.ServiceProvider.GetRequiredService<RotaPlannerView>();
            StaffView.Content = Globals.ServiceProvider.GetRequiredService<StaffView>();
            AbsenceView.Content = Globals.ServiceProvider.GetRequiredService<AbsenceView>();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e) 
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e) => Application.Current.Shutdown();

        private void Maximise_Click(object sender, RoutedEventArgs e) => Globals.Notifier.ShowInformation("Whoops! Not Implemented yet... Sorry :)");

        private void Minimise_Click(object sender, RoutedEventArgs e) => Globals.Notifier.ShowInformation("Whoops! Not Implemented yet... Sorry :)");


    }
}
