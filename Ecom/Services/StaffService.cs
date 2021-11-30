using System.Collections.Generic;
using System.Threading.Tasks;
using Ecom.Data.Model;
using Ecom.Data.Repository;
using Ecom.Helpers;
using Ecom.ViewModel.Staff;

namespace Ecom.Services
{
    public class StaffService
    {
        private readonly StaffRepository _staffRepository;

        public StaffService(StaffRepository staffRepository)
        {
            _staffRepository = staffRepository;
        }

        public async Task<List<StaffListViewModel>> FetchAllUsers()
        {
            var results = await _staffRepository.FindAll();
            return Globals.Mapper.Map<List<Staff>, List<StaffListViewModel>>(results);
        }
    }
}
