using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ecom.Data.Model;
using Ecom.Data.Repository;
using Ecom.Helpers;
using Ecom.ViewModel.Staff;
using ToastNotifications.Messages;

namespace Ecom.Services
{
    public class StaffService
    {
        private readonly StaffRepository _staffRepository;

        public StaffService(StaffRepository staffRepository)
        {
            _staffRepository = staffRepository;
        }

        public async Task<List<StaffListViewModel>> FetchAllStaff()
        {
            var results = await _staffRepository.FindAll();
            return Globals.Mapper.Map<List<Staff>, List<StaffListViewModel>>(results);
        }

        public async Task<List<StaffViewModel>> FetchAllStaffAvailability() => Globals.Mapper.Map<List<Staff>, List<StaffViewModel>>(await _staffRepository.FindAll());

        public async Task<StaffViewModel> FetchStaffById(int id)
        {
            var results = await _staffRepository.Find(id);
            var viewModel = new StaffViewModel();

            return results == null ? viewModel : Globals.Mapper.Map<StaffViewModel>(results);
        }

        public async Task<bool> CreateNewStaffMember(StaffViewModel viewModel)
        {
            try
            {
                await _staffRepository.Add(Globals.Mapper.Map<Staff>(viewModel));
                return true;
            }
            catch (Exception ex)
            {
                Globals.Notifier.ShowError($"An error occured: {ex.Message}");
            }
            return false;   
        }

        public async Task<bool> UpdateStaffMember(StaffViewModel viewModel)
        {
            try
            {
                var entity = await _staffRepository.Find(viewModel.Id);
                if (entity != null)
                {
                    entity = Globals.Mapper.Map(viewModel, entity);
                    await _staffRepository.Update(entity);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Globals.Notifier.ShowError($"An error occured: {ex.Message}");
            }
            return false;
        }
    }
}
