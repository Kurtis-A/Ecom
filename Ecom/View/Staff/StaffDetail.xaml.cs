using Ecom.Helpers;
using Ecom.Services;
using Ecom.ViewModel.Staff;
using System;
using System.Windows.Controls;
using ToastNotifications.Messages;

namespace Ecom.View.Staff
{
    /// <summary>
    /// Interaction logic for StaffDetail.xaml
    /// </summary>
    public partial class StaffDetail : UserControl
    {
        private readonly StaffService _service;

        public event EventHandler Subscribe = delegate { };

        public StaffDetail(StaffService service)
        {
            InitializeComponent();

            _service = service;
        }

        public StaffViewModel ViewModel;

        public void Updated() => Subscribe(this, new EventArgs());

        public async void Load(StaffListViewModel viewModel)
        {
            try
            {
                ViewModel = await _service.FetchStaffById(viewModel.Id);
                if (ViewModel == null)
                {
                    Globals.Notifier.ShowWarning("Staff Member Details not found");
                }
                else
                {
                    Globals.Notifier.ShowSuccess("Staff Member Details Loaded");
                }

                DataContext = ViewModel;
            }
            catch (Exception e)
            {
                Globals.Notifier.ShowError($"Error: {e.Message}");
            }
        }

        private async void btnSave_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (ViewModel.IsValid())
            {
                if (await _service.UpdateStaffMember(ViewModel))
                {
                    Globals.Notifier.ShowSuccess($"{ViewModel.Firstname} {ViewModel.Surname} deatils updated");
                    Updated();
                }
                else
                {
                    Globals.Notifier.ShowError($"Failed to update staff member details");
                }
            }
            else
            {
                var errors = ViewModel.GetValidationErrors();
                if (errors.Count > 3)
                {
                    Globals.Notifier.ShowError($"There are multiple actions needed before you can save");
                }
                else
                {
                    foreach (var error in ViewModel.GetValidationErrors())
                    {
                        Globals.Notifier.ShowWarning($"Action needed: {error}");
                    }
                }
            }
        }
    }
}
