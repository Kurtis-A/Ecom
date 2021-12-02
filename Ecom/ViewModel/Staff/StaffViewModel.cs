using Ecom.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

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
        private string addressLine1;
        private string addressLine2;
        private string addressLine3;
        private string postcode;

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

        public string Preference { get; set; }

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

        private bool GetPreference(string key)
        {
            return Preference.Contains(key);
        }

        private void RemovePreference(string key)
        {
            Preference = Preference.Replace($"{key},", string.Empty);
        }

        private void AddPreference(string key)
        {
            Preference += $"{key},";
        }
    }
}
