using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Ecom.ViewModel.User
{
    public class SingleUserViewModel : ViewModelBase
    {
        private string _role;
        private string _username;

        
        public int Id { get; set; }

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                Validate(value, nameof(Username));
            }
        }

        public string Role
        {
            get => _role;
            set
            {
                _role = value;
                Validate(value, nameof(Role));
            }
        }
    }
}
