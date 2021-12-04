using Ecom.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ecom.ViewModel.Staff
{
    public class StaffViewModel : ViewModelBase
    {
        private string _role;
        private string _username;
        private string firstName;
        private string surname;
        private DateTime dateOfBirth;
        private DateTime startDate;
        private DateTime? leaveDate;
        private string addressLine1;
        private string addressLine2;
        private string addressLine3;
        private string postcode;
        private ObservableCollection<StaffListViewModel> staffMembers;
        private string contactEmail;
        private string contactNumber;
        private string displayAddress;
        private string preference;
        private string displayAvailability;

        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a Username")]
        [StringLength(3)]
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                Validate(value);
                OnPropertyChanged();
            }
        }

        [Required(ErrorMessage = "Please enter a First Name")]
        public string Firstname
        {
            get => firstName;
            set
            {
                firstName = value;
                Validate(value);
                OnPropertyChanged();
            }
        }

        [Required(ErrorMessage = "Please enter a Surname")]
        public string Surname
        {
            get => surname;
            set
            {
                surname = value;
                Validate(value);
                OnPropertyChanged();
            }
        }

        [Required(ErrorMessage = "Please enter a Surname")]
        public DateTime DateOfBirth
        {
            get => dateOfBirth;
            set
            {
                dateOfBirth = value;
                Validate(value);
                OnPropertyChanged();
            }
        }

        [Required(ErrorMessage = "Please select a role")]
        public string Role
        {
            get => _role;
            set
            {
                _role = value;
                Validate(value);
                OnPropertyChanged();
            }
        }

        [Required(ErrorMessage = "Please enter a Start Date")]
        public DateTime StartDate
        {
            get => startDate;
            set
            {
                startDate = value;
                Validate(value);
                OnPropertyChanged();
            }
        }

        public DateTime? LeaveDate
        {
            get => leaveDate;
            set
            {
                leaveDate = value;
                OnPropertyChanged();
            }
        }

        public string Preference
        {
            get => preference;
            set
            {
                preference = value;
                OnPropertyChanged();
            }
        }

        public bool AvailMonday
        {
            get => GetPreference(Globals.DaysOfWeek.Monday.ToString());
            set
            {
                if (value)
                    AddPreference(Globals.DaysOfWeek.Monday.ToString());
                else
                    RemovePreference(Globals.DaysOfWeek.Monday.ToString());

                OnPropertyChanged();
                OnPropertyChanged(nameof(DisplayAvailability));
            }
        }

        public bool AvailTuesday
        {
            get => GetPreference(Globals.DaysOfWeek.Tuesday.ToString());
            set
            {
                if (value)
                    AddPreference(Globals.DaysOfWeek.Tuesday.ToString());
                else
                    RemovePreference(Globals.DaysOfWeek.Tuesday.ToString());

                OnPropertyChanged();
                OnPropertyChanged(nameof(DisplayAvailability));
            }
        }

        public bool AvailWednesday
        {
            get => GetPreference(Globals.DaysOfWeek.Wednesday.ToString());
            set
            {
                if (value)
                    AddPreference(Globals.DaysOfWeek.Wednesday.ToString());
                else
                    RemovePreference(Globals.DaysOfWeek.Wednesday.ToString());

                OnPropertyChanged();
                OnPropertyChanged(nameof(DisplayAvailability));
            }
        }

        public bool AvailThursday
        {
            get => GetPreference(Globals.DaysOfWeek.Thursday.ToString());
            set
            {
                if (value)
                    AddPreference(Globals.DaysOfWeek.Thursday.ToString());
                else
                    RemovePreference(Globals.DaysOfWeek.Thursday.ToString());

                OnPropertyChanged();
                OnPropertyChanged(nameof(DisplayAvailability));
            }
        }

        public bool AvailFriday
        {
            get => GetPreference(Globals.DaysOfWeek.Friday.ToString());
            set
            {
                if (value)
                    AddPreference(Globals.DaysOfWeek.Friday.ToString());
                else
                    RemovePreference(Globals.DaysOfWeek.Friday.ToString());

                OnPropertyChanged();
                OnPropertyChanged(nameof(DisplayAvailability));
            }
        }

        public bool AvailSaturday
        {
            get => GetPreference(Globals.DaysOfWeek.Saturday.ToString());
            set
            {
                if (value)
                    AddPreference(Globals.DaysOfWeek.Saturday.ToString());
                else
                    RemovePreference(Globals.DaysOfWeek.Saturday.ToString());

                OnPropertyChanged();
                OnPropertyChanged(nameof(DisplayAvailability));
            }
        }

        public bool AvailSunday
        {
            get => GetPreference(Globals.DaysOfWeek.Sunday.ToString());
            set
            {
                if (value)
                    AddPreference(Globals.DaysOfWeek.Sunday.ToString());
                else
                    RemovePreference(Globals.DaysOfWeek.Sunday.ToString());

                OnPropertyChanged();
                OnPropertyChanged(nameof(DisplayAvailability));
            }
        }

        [DisplayName("House Name / Number")]
        public string AddressLine1
        {
            get => addressLine1;
            set
            {
                addressLine1 = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(DisplayAddress));
            }
        }

        [DisplayName("Street Name")]
        public string? AddressLine2
        {
            get => addressLine2;
            set
            {
                addressLine2 = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(DisplayAddress));
            }
        }

        [DisplayName("Town / City Name")]
        public string? AddressLine3
        {
            get => addressLine3;
            set
            {
                addressLine3 = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(DisplayAddress));
            }
        }

        public string Postcode
        {
            get => postcode;
            set
            {
                postcode = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(DisplayAddress));
            }
        }

        [DisplayName("Phone Number")]
        public string ContactNumber
        {
            get => contactNumber;
            set
            {
                contactNumber = value;
                OnPropertyChanged();
            }
        }

        [DisplayName("Email Address")]
        public string ContactEmail
        {
            get => contactEmail;
            set
            {
                contactEmail = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<StaffListViewModel> StaffMembers
        {
            get => staffMembers;
            set
            {
                staffMembers = value;
                OnPropertyChanged();
            }
        }

        public string DisplayAddress => GenerateDisplayAddress();

        public string DisplayAvailability => GenerateDisplayAvailability();

        private string GenerateDisplayAddress()
        {
            var address = string.Empty;
            if (!string.IsNullOrEmpty(addressLine1))
                address += $"{addressLine1} ";

            if (!string.IsNullOrEmpty(addressLine2))
                address += $"{addressLine2}, ";

            if (!string.IsNullOrEmpty(addressLine3))
                address += $"{addressLine3}, ";

            if (!string.IsNullOrEmpty(postcode))
                address += $"{postcode}";

            return address;
        }

        private string GenerateDisplayAvailability()
        {
            var dayCount = Preference?.Split(",", StringSplitOptions.RemoveEmptyEntries).Length;
            
            if (dayCount == null) return $"Available 0 days a week";

            if (dayCount == 1)
                return $"Available {dayCount} day a week";
            else
                return $"Available {dayCount} days a week";
        }

        private bool GetPreference(string key)
        {
            if (Preference != null)
                return Preference.Contains(key);

            return false;
        }

        private void RemovePreference(string key)
        {
            if (Preference.Contains(key))
                Preference = Preference.Replace($"{key},", string.Empty);
        }

        private void AddPreference(string key)
        {
            if (!Preference.Contains(key))
                Preference += $"{key},";
        }


    }
}
