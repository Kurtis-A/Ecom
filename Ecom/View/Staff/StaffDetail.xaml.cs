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

        public StaffDetail(StaffService service)
        {
            InitializeComponent();

            _service = service;
        }

        public StaffViewModel ViewModel;

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
    }
}
