using Ecom.ViewModel.Absence;
using Ecom.ViewModel.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.ViewModel.Planner
{
    public class PlannerViewModel : ViewModelBase
    {
        private List<AbsenceViewModel> staffAbsences;
        private List<StaffViewModel> staffAvailability;
        private string day1Day;
        private string day2Day;
        private string day3Day;
        private string day4Day;
        private string day5Day;
        private string day6Day;
        private string day7Day;
        private DateTime day1Date;

        public string Day1Day
        {
            get => day1Day;
            set
            {
                day1Day = value;
                OnPropertyChanged();
            }
        }

        public string Day2Day
        {
            get => day2Day;
            set
            {
                day2Day = value;
                OnPropertyChanged();
            }
        }

        public string Day3Day
        {
            get => day3Day;
            set
            {
                day3Day = value;
                OnPropertyChanged();
            }
        }

        public string Day4Day
        {
            get => day4Day;
            set
            {
                day4Day = value;
                OnPropertyChanged();
            }
        }

        public string Day5Day
        {
            get => day5Day;
            set
            {
                day5Day = value;
                OnPropertyChanged();
            }
        }

        public string Day6Day
        {
            get => day6Day;
            set
            {
                day6Day = value;
                OnPropertyChanged();
            }
        }

        public string Day7Day
        {
            get => day7Day;
            set
            {
                day7Day = value;
                OnPropertyChanged();
            }
        }

        public DateTime Day1Date
        {
            get => day1Date;
            set
            {
                day1Date = value;
                OnPropertyChanged();
            }
        }


        public List<StaffViewModel> StaffAvailability
        {
            get => staffAvailability;
            set
            {
                staffAvailability = value;
                OnPropertyChanged();
            }
        }

        public List<AbsenceViewModel> StaffAbsences
        {
            get => staffAbsences;
            set
            {
                staffAbsences = value;
                OnPropertyChanged();
            }
        }

        public List<string> Day1Availability { get; set; }
    }
}
