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
        private DateTime day2Date;
        private DateTime day3Date;
        private DateTime day4Date;
        private DateTime day5Date;
        private DateTime day6Date;
        private DateTime day7Date;

        public string Day1Day
        {
            get => day1Date.DayOfWeek.ToString();
        }

        public string Day2Day
        {
            get => day2Date.DayOfWeek.ToString();
        }

        public string Day3Day
        {
            get => day3Date.DayOfWeek.ToString();
        }

        public string Day4Day
        {
            get => day4Date.DayOfWeek.ToString();
        }

        public string Day5Day
        {
            get => day5Date.DayOfWeek.ToString();
        }

        public string Day6Day
        {
            get => day6Date.DayOfWeek.ToString();
        }

        public string Day7Day
        {
            get => day7Date.DayOfWeek.ToString();
        }

        public string Day1Date
        {
            get => day1Date.ToString("dd MMM yy");
            set
            {
                day1Date = DateTime.Parse(value);
                OnPropertyChanged();
                OnPropertyChanged(nameof(Day1Day));
            }
        }

        public string Day2Date
        {
            get => day2Date.ToString("dd MMM yy");
            set
            {
                day2Date = DateTime.Parse(value);
                OnPropertyChanged();
                OnPropertyChanged(nameof(Day2Day));
            }
        }

        public string Day3Date
        {
            get => day3Date.ToString("dd MMM yy");
            set
            {
                day3Date = DateTime.Parse(value);
                OnPropertyChanged();
                OnPropertyChanged(nameof(Day3Day));
            }
        }

        public string Day4Date
        {
            get => day4Date.ToString("dd MMM yy");
            set
            {
                day4Date = DateTime.Parse(value);
                OnPropertyChanged();
                OnPropertyChanged(nameof(Day4Day));
            }
        }

        public string Day5Date
        {
            get => day5Date.ToString("dd MMM yy");
            set
            {
                day5Date = DateTime.Parse(value);
                OnPropertyChanged();
                OnPropertyChanged(nameof(Day5Day));
            }
        }

        public string Day6Date
        {
            get => day6Date.ToString("dd MMM yy");
            set
            {
                day6Date = DateTime.Parse(value);
                OnPropertyChanged();
                OnPropertyChanged(nameof(Day6Day));
            }
        }

        public string Day7Date
        {
            get => day7Date.ToString("dd MMM yy");
            set
            {
                day7Date = DateTime.Parse(value);
                OnPropertyChanged();
                OnPropertyChanged(nameof(Day7Day));
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
