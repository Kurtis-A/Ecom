using Ecom.Helpers;
using Ecom.View.User;
using Microsoft.Extensions.DependencyInjection;
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

        public object WindowPage { get; set; }

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

        private void TabItem_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            using var scope = Globals.ServiceProvider.CreateScope();
            var newPage = scope.ServiceProvider.GetRequiredService<UserList>();
            WindowPage = newPage;
        }
    }
}
