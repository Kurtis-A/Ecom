using System;
using System.ComponentModel.DataAnnotations;

namespace Ecom.ViewModel.Staff
{
    public class StaffViewModel : ViewModelBase
    {
        private string _role;
        private string _username;
        private string firstName;
        private string surname;
        private DateTime startDate;
        private DateTime? leaveDate;
        private string preference;
        private string addressLine1;
        private string addressLine2;
        private string addressLine3;
        private string postcode;

        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a Username")]
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                Validate(value, nameof(Username));
            }
        }

        [Required(ErrorMessage = "Please enter a First Name")]
        public string Firstname
        {
            get => firstName;
            set => firstName = value;
        }

        [Required(ErrorMessage = "Please enter a Surname")]
        public string Surname
        {
            get => surname;
            set => surname = value;
        }

        [Required(ErrorMessage = "Please select a role")]
        public string Role
        {
            get => _role;
            set
            {
                _role = value;
                Validate(value, nameof(Role));
            }
        }

        [Required(ErrorMessage = "Please enter a Start Date")]
        public DateTime StartDate
        {
            get => startDate;
            set
            {
                startDate = value;
            }
        }

        public DateTime? LeaveDate
        {
            get => leaveDate;
            set
            {
                leaveDate = value;
            }
        }

        public string Preference
        {
            get => preference;
            set
            {
                preference = value;
            }
        }

        public bool AvailMonday
        {
            get => preference.Contains("Monday");
            set
            {
                if (!preference.Contains("Monday"))
                {
                    if (string.IsNullOrEmpty(preference))
                    {
                        preference = "Monday";
                    }
                    else
                    {
                        preference += ",Monday";
                    }
                }
            }
        }

        public string AddressLine1
        {
            get => addressLine1;
            set
            {
                addressLine1 = value;
            }
        }

        public string? AddressLine2
        {
            get => addressLine2;
            set
            {
                addressLine2 = value;
            }
        }

        public string? AddressLine3
        {
            get => addressLine3;
            set
            {
                addressLine3 = value;
            }
        }

        public string Postcode
        {
            get => postcode;
            set
            {
                postcode = value;
            }
        }
    }
}
