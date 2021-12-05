using Ecom.Helpers;
using Ecom.Services;
using Ecom.ViewModel.Absence;
using Ecom.ViewModel.Staff;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ecom.View.Planner
{
    /// <summary>
    /// Interaction logic for RotaPlannerView.xaml
    /// </summary>
    public partial class RotaPlannerView : UserControl, INotifyPropertyChanged
    {
        private readonly StaffService _staffService;
        private readonly AbsenceService _absenceService;

        public event PropertyChangedEventHandler PropertyChanged;

        public RotaPlannerView(StaffService staffService, AbsenceService absenceService)
        {
            InitializeComponent();

            _staffService = staffService;
            _absenceService = absenceService;

            StaffAvailability = new List<StaffViewModel>();
            StaffAbsences = new List<AbsenceViewModel>();

            Load();

            var startDate = DateTime.Today.AddMonths(1);
            SelectedDate.SelectedDate = startDate;
            BuildRotaDates(startDate);
            Populate();

            DataContext = this;
        }

        public List<StaffViewModel> StaffAvailability { get; set; }

        public List<AbsenceViewModel> StaffAbsences { get; set; }

        private async void Load()
        {
            var availability = await _staffService.FetchAllStaffAvailability();
            var absences = await _absenceService.FetchAllAbsences();

            StaffAvailability = availability;
            StaffAbsences = absences;

            //OnPropertyChanged(nameof(StaffAvailability));
            //OnPropertyChanged(nameof(StaffAbsences));
        }

        public void BuildRotaDates(DateTime selectDate)
        {
            var rotaWeek = new Dictionary<string, DateTime>();

            for (var i = 0; i < 7; i++)
            {
                var date = selectDate.AddDays(i);
                rotaWeek.Add(date.DayOfWeek.ToString(), date);
            }

            var rotaDates = rotaWeek.ToList();

            //Availability Population
            Day1_Day.Text = rotaDates[0].Key;
            Day1_Date.Text = rotaDates[0].Value.ToString("dd MMM yy");

            Day2_Day.Text = rotaDates[1].Key;
            Day2_Date.Text = rotaDates[1].Value.ToString("dd MMM yy");

            Day3_Day.Text = rotaDates[2].Key;
            Day3_Date.Text = rotaDates[2].Value.ToString("dd MMM yy");

            Day4_Day.Text = rotaDates[3].Key;
            Day4_Date.Text = rotaDates[3].Value.ToString("dd MMM yy");

            Day5_Day.Text = rotaDates[4].Key;
            Day5_Date.Text = rotaDates[4].Value.ToString("dd MMM yy");

            Day6_Day.Text = rotaDates[5].Key;
            Day6_Date.Text = rotaDates[5].Value.ToString("dd MMM yy");

            Day7_Day.Text = rotaDates[6].Key;
            Day7_Date.Text = rotaDates[6].Value.ToString("dd MMM yy");

            //Rota Population
            Day1_DayRota.Text = rotaDates[0].Key;
            Day1_DateRota.Text = rotaDates[0].Value.ToString("dd MMM yy");

            Day2_DayRota.Text = rotaDates[1].Key;
            Day2_DateRota.Text = rotaDates[1].Value.ToString("dd MMM yy");

            Day3_DayRota.Text = rotaDates[2].Key;
            Day3_DateRota.Text = rotaDates[2].Value.ToString("dd MMM yy");

            Day4_DayRota.Text = rotaDates[3].Key;
            Day4_DateRota.Text = rotaDates[3].Value.ToString("dd MMM yy");

            Day5_DayRota.Text = rotaDates[4].Key;
            Day5_DateRota.Text = rotaDates[4].Value.ToString("dd MMM yy");

            Day6_DayRota.Text = rotaDates[5].Key;
            Day6_DateRota.Text = rotaDates[5].Value.ToString("dd MMM yy");

            Day7_DayRota.Text = rotaDates[6].Key;
            Day7_DateRota.Text = rotaDates[6].Value.ToString("dd MMM yy");
        }

        private void Populate()
        {
            Day1Avail.Children.Clear();
            Day2Avail.Children.Clear();
            Day3Avail.Children.Clear();
            Day4Avail.Children.Clear();
            Day5Avail.Children.Clear();
            Day6Avail.Children.Clear();
            Day7Avail.Children.Clear();

            foreach (var staffAvailability in StaffAvailability.Where(x => x.Preference.Contains(Day1_Day.Text)))
            {
                Day1Avail.Children.Add(StaffAbsences.Any(x =>
                    x.Date == Convert.ToDateTime(Day1_Date.Text) && x.Username == staffAvailability.Username)
                    ? CreateStaffChip(staffAvailability.Username, "Holiday")
                    : CreateStaffChip(staffAvailability.Username, "Available"));
            }

            foreach (var staffAvailability in StaffAvailability.Where(x => x.Preference.Contains(Day2_Day.Text)))
            {
                Day2Avail.Children.Add(StaffAbsences.Any(x =>
                    x.Date == Convert.ToDateTime(Day2_Date.Text) && x.Username == staffAvailability.Username)
                    ? CreateStaffChip(staffAvailability.Username, "Holiday")
                    : CreateStaffChip(staffAvailability.Username, "Available"));
            }

            foreach (var staffAvailability in StaffAvailability.Where(x => x.Preference.Contains(Day3_Day.Text)))
            {
                Day3Avail.Children.Add(StaffAbsences.Any(x =>
                    x.Date == Convert.ToDateTime(Day3_Date.Text) && x.Username == staffAvailability.Username)
                    ? CreateStaffChip(staffAvailability.Username, "Holiday")
                    : CreateStaffChip(staffAvailability.Username, "Available"));
            }

            foreach (var staffAvailability in StaffAvailability.Where(x => x.Preference.Contains(Day4_Day.Text)))
            {
                Day4Avail.Children.Add(StaffAbsences.Any(x =>
                    x.Date == Convert.ToDateTime(Day4_Date.Text) && x.Username == staffAvailability.Username)
                    ? CreateStaffChip(staffAvailability.Username, "Holiday")
                    : CreateStaffChip(staffAvailability.Username, "Available"));
            }

            foreach (var staffAvailability in StaffAvailability.Where(x => x.Preference.Contains(Day5_Day.Text)))
            {
                Day5Avail.Children.Add(StaffAbsences.Any(x =>
                    x.Date == Convert.ToDateTime(Day5_Date.Text) && x.Username == staffAvailability.Username)
                    ? CreateStaffChip(staffAvailability.Username, "Holiday")
                    : CreateStaffChip(staffAvailability.Username, "Available"));
            }

            foreach (var staffAvailability in StaffAvailability.Where(x => x.Preference.Contains(Day6_Day.Text)))
            {
                Day6Avail.Children.Add(StaffAbsences.Any(x =>
                    x.Date == Convert.ToDateTime(Day6_Date.Text) && x.Username == staffAvailability.Username)
                    ? CreateStaffChip(staffAvailability.Username, "Holiday")
                    : CreateStaffChip(staffAvailability.Username, "Available"));
            }

            foreach (var staffAvailability in StaffAvailability.Where(x => x.Preference.Contains(Day7_Day.Text)))
            {
                Day7Avail.Children.Add(StaffAbsences.Any(x =>
                    x.Date == Convert.ToDateTime(Day7_Date.Text) && x.Username == staffAvailability.Username)
                    ? CreateStaffChip(staffAvailability.Username, "Holiday")
                    : CreateStaffChip(staffAvailability.Username, "Available"));
            }
        }

        public UIElement CreateStaffChip(string username, string status)
        {
            var background = status == "Available" ? Brushes.PaleGreen : Brushes.PaleVioletRed;
            PackIcon icon = null;
            switch (status)
            {
                case "Available":
                    icon = new PackIcon() { Kind = PackIconKind.Tick };
                    break;

                case "Holiday":
                    icon = new PackIcon() { Kind = PackIconKind.AeroplaneTakeoff };
                    break;

                case "Illness":
                    icon = new PackIcon() { Kind = PackIconKind.MedicalBag };
                    break;
            }

            return new Chip()
            {
                Content = username,
                Background = background,
                Icon = icon
            };
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
