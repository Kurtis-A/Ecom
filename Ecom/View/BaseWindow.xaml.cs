using Ecom.Helpers;
using System.Windows;
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

        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e) => DragMove();

        private void Close_Click(object sender, RoutedEventArgs e) => Application.Current.Shutdown();

        private void Maximise_Click(object sender, RoutedEventArgs e)
        {
            Globals.Notifier.ShowInformation("Whoops! Not Implemented yet... Sorry :)");
        }

        private void Minimise_Click(object sender, RoutedEventArgs e)
        {
            Globals.Notifier.ShowInformation("Whoops! Not Implemented yet... Sorry :)");
        }
    }
}
