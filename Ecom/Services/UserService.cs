using System.Collections.Generic;
using System.Threading.Tasks;
using Ecom.Data.Repository;
using Ecom.ViewModel.User;
using Microsoft.Extensions.Logging;

namespace Ecom.Services
{
    public class UserService
    {
        private readonly ILogger<UserService> _logger;
        private readonly UserRepository _userRepository;

        public UserService(ILogger<UserService> logger, UserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        public async Task<List<UserListViewModel>> FetchAllUsers()
        {
            return null;
        }
    }
}
