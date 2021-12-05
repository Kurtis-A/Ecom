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

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var control = sender as TabControl;
            var header = control.SelectedItem as TabItem;

            var selected = header.Name;

            switch (selected)
            {
                case "Home":
                    break;

                case "Planner":
                    PlannerView.Content = Globals.ServiceProvider.GetRequiredService<RotaPlannerView>();
                    break;

                case "Shift":
                    break;

                case "Staff":
                    StaffView.Content = Globals.ServiceProvider.GetRequiredService<StaffView>();
                    break;

                case "Absence":
                    AbsenceView.Content = Globals.ServiceProvider.GetRequiredService<AbsenceView>();
                    break;
            }
        }
    }
}
