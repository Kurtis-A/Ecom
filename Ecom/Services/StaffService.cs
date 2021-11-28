using System.Collections.Generic;
using System.Threading.Tasks;
using Ecom.Data.Repository;
using Ecom.ViewModel.User;

namespace Ecom.Services
{
    public class StaffService
    {
        private readonly StaffRepository _userRepository;

        public StaffService(StaffRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<StaffListViewModel>> FetchAllUsers()
        {
            return null;
        }
    }
}
