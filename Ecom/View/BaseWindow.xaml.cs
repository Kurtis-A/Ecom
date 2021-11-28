using Ecom.Helpers;
using Ecom.View.Staff;
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

            StaffView.Content = Globals.ServiceProvider.GetService(typeof(StaffView));
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
