using Ecom.Helpers;
using Ecom.View.Absence;
using Ecom.View.Planner;
using Ecom.View.Staff;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using System.Windows.Controls;
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

        private async void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {            
            var control = sender as TabControl;
            var header = control.SelectedItem as TabItem;

            var selected = header.Name;

            PlannerView.Content = null;
            StaffView.Content = null;
            AbsenceView.Content = null;

            switch (selected)
            {
                case "Home":
                    break;

                case "Planner":
                    var planner = Globals.ServiceProvider.GetService<RotaPlannerView>();
                    PlannerView.Content = planner;
                    await planner.Load();

                    break;

                case "Shift":
                    break;

                case "Staff":
                    StaffView.Content = Globals.ServiceProvider.GetService<StaffView>();
                    break;

                case "Absence":
                    AbsenceView.Content = Globals.ServiceProvider.GetService<AbsenceView>();
                    break;
            }
        }
    }
}
