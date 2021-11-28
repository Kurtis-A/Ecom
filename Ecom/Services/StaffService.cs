using System.Collections.Generic;
using System.Threading.Tasks;
using Ecom.Data.Repository;
using Ecom.ViewModel.User;
using Microsoft.Extensions.Logging;

namespace Ecom.Services
{
    public class StaffService
    {
        private readonly ILogger<StaffService> _logger;
        private readonly StaffRepository _userRepository;

        public StaffService(ILogger<StaffService> logger, StaffRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        public async Task<List<StaffListViewModel>> FetchAllUsers()
        {
            return null;
        }
    }
}
