using Ecom.Helpers;
using Ecom.Services;
using Ecom.ViewModel.Absence;
using Ecom.ViewModel.Planner;
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
        public PlannerViewModel ViewModel;
        
        public enum RotaTypes { Team, Supervisor, Manager }

        public RotaPlannerView(StaffService staffService, AbsenceService absenceService)
        {
            InitializeComponent();

            _staffService = staffService;
            _absenceService = absenceService;

            var rotas = new List<string>
            {
                "Team",
                "Supervisor",
                "Manager"
            };

            RotaType.ItemsSource = rotas;
        }

        public DateTime RotaDate { get; set; }

        public async Task Load()
        {
            ViewModel = new PlannerViewModel();

            ViewModel.StaffAvailability = new List<StaffViewModel>();
            ViewModel.StaffAbsences = new List<AbsenceViewModel>();

            ViewModel.StaffAvailability = new List<StaffViewModel>(await _staffService.FetchAllStaffAvailability());
            ViewModel.StaffAbsences = new List<AbsenceViewModel>(await _absenceService.FetchAllAbsences());

            DataContext = ViewModel;

            RotaDate = DateTime.Today.AddMonths(1);
            SelectedDate.SelectedDate = RotaDate;

            BuildRotaDates(RotaDate);

            if (RotaType.SelectedItem != null)
                Populate();
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

            var staffAbsences = ViewModel.StaffAbsences;

            foreach (var staffAvailability in ViewModel.StaffAvailability.Where(x => x.Preference.Contains(Day1_Day.Text) && x.Role.Contains(RotaType.SelectedItem.ToString()) && x.StartDate <= Convert.ToDateTime(Day1_Date.Text) && x.LeaveDate == null))
            {
                Day1Avail.Children.Add(staffAbsences.Any(x =>
                    x.Date == Convert.ToDateTime(Day1_Date.Text) && x.Username == staffAvailability.Username)
                    ? CreateStaffChip(staffAvailability.Username, staffAbsences.FirstOrDefault(x => x.Username == staffAvailability.Username))
                    : CreateStaffChip(staffAvailability.Username, null));
            }

            foreach (var staffAvailability in ViewModel.StaffAvailability.Where(x => x.Preference.Contains(Day2_Day.Text) && x.Role.Contains(RotaType.SelectedItem.ToString()) && x.StartDate <= Convert.ToDateTime(Day2_Date.Text) && x.LeaveDate == null))
            {
                Day2Avail.Children.Add(ViewModel.StaffAbsences.Any(x =>
                    x.Date == Convert.ToDateTime(Day2_Date.Text) && x.Username == staffAvailability.Username)
                    ? CreateStaffChip(staffAvailability.Username, staffAbsences.FirstOrDefault(x => x.Username == staffAvailability.Username))
                    : CreateStaffChip(staffAvailability.Username, null));
            }

            foreach (var staffAvailability in ViewModel.StaffAvailability.Where(x => x.Preference.Contains(Day3_Day.Text) && x.Role.Contains(RotaType.SelectedItem.ToString()) && x.StartDate <= Convert.ToDateTime(Day3_Date.Text) && x.LeaveDate == null))
            {
                Day3Avail.Children.Add(ViewModel.StaffAbsences.Any(x =>
                    x.Date == Convert.ToDateTime(Day3_Date.Text) && x.Username == staffAvailability.Username)
                    ? CreateStaffChip(staffAvailability.Username, staffAbsences.FirstOrDefault(x => x.Username == staffAvailability.Username))
                    : CreateStaffChip(staffAvailability.Username, null));
            }

            foreach (var staffAvailability in ViewModel.StaffAvailability.Where(x => x.Preference.Contains(Day4_Day.Text) && x.Role.Contains(RotaType.SelectedItem.ToString()) && x.StartDate <= Convert.ToDateTime(Day4_Date.Text) && x.LeaveDate == null))
            {
                Day4Avail.Children.Add(ViewModel.StaffAbsences.Any(x =>
                    x.Date == Convert.ToDateTime(Day4_Date.Text) && x.Username == staffAvailability.Username)
                    ? CreateStaffChip(staffAvailability.Username, staffAbsences.FirstOrDefault(x => x.Username == staffAvailability.Username))
                    : CreateStaffChip(staffAvailability.Username, null));
            }

            foreach (var staffAvailability in ViewModel.StaffAvailability.Where(x => x.Preference.Contains(Day5_Day.Text) && x.Role.Contains(RotaType.SelectedItem.ToString()) && x.StartDate <= Convert.ToDateTime(Day5_Date.Text) && x.LeaveDate == null))
            {
                Day5Avail.Children.Add(ViewModel.StaffAbsences.Any(x =>
                    x.Date == Convert.ToDateTime(Day5_Date.Text) && x.Username == staffAvailability.Username)
                    ? CreateStaffChip(staffAvailability.Username, staffAbsences.FirstOrDefault(x => x.Username == staffAvailability.Username))
                    : CreateStaffChip(staffAvailability.Username, null));
            }

            foreach (var staffAvailability in ViewModel.StaffAvailability.Where(x => x.Preference.Contains(Day6_Day.Text) && x.Role.Contains(RotaType.SelectedItem.ToString()) && x.StartDate <= Convert.ToDateTime(Day6_Date.Text) && x.LeaveDate == null))
            {
                Day6Avail.Children.Add(ViewModel.StaffAbsences.Any(x =>
                    x.Date == Convert.ToDateTime(Day6_Date.Text) && x.Username == staffAvailability.Username)
                    ? CreateStaffChip(staffAvailability.Username, staffAbsences.FirstOrDefault(x => x.Username == staffAvailability.Username))
                    : CreateStaffChip(staffAvailability.Username, null));
            }

            foreach (var staffAvailability in ViewModel.StaffAvailability.Where(x => x.Preference.Contains(Day7_Day.Text) && x.Role.Contains(RotaType.SelectedItem.ToString()) && x.StartDate <= Convert.ToDateTime(Day7_Date.Text) && x.LeaveDate == null))
            {
                Day7Avail.Children.Add(ViewModel.StaffAbsences.Any(x =>
                    x.Date == Convert.ToDateTime(Day7_Date.Text) && x.Username == staffAvailability.Username)
                    ? CreateStaffChip(staffAvailability.Username, staffAbsences.FirstOrDefault(x => x.Username == staffAvailability.Username))
                    : CreateStaffChip(staffAvailability.Username, null));
            }
        }

        public UIElement CreateStaffChip(string username, AbsenceViewModel? absenceViewModel)
        {
            var type = "Available";
            if (absenceViewModel != null)
                type = absenceViewModel.Type;
            

            var background = type == "Available" ? Brushes.Green : Brushes.Red;
            PackIcon icon = null;
            var toolTip = string.Empty;
            switch (type)
            {
                case "Available":
                    icon = new PackIcon() { Kind = PackIconKind.Tick };
                    toolTip = "Available";
                    break;

                case "Annual Leave":
                    icon = new PackIcon() { Kind = PackIconKind.AeroplaneTakeoff };
                    toolTip = "on Annual Leave";
                    break;

                case "Medical":
                    icon = new PackIcon() { Kind = PackIconKind.MedicalBag };
                    toolTip = "off for Medical Reasons";
                    break;
            }

            Chip chip = new Chip()
            {
                Content = username,
                Icon = icon,
                IconBackground = background,
                ToolTip = $"{username} {toolTip}",
                Background = Application.Current.FindResource("PrimaryHueLightBrush") as Brush
            };
            chip.Click += Chip_Click;

            return chip;
        }

        private void Chip_Click(object sender, RoutedEventArgs e)
        {
            var chipType = sender as Chip;
            var parent = chipType.Parent;

            AddStaffToRota(chipType, parent);
        }

        private bool AddStaffToRota(Chip StaffMember, DependencyObject Parent)
        {
            //Remove from Available Panel
            var previousPanel = Parent as WrapPanel;
            previousPanel.Children.Remove(StaffMember);

            //Reassign PanelName
            var parentName = Parent.GetValue(NameProperty);
            var newParentstring = parentName.ToString().Replace("Avail", "Rota");

            //Find new Parent Object
            Parent.SetValue(NameProperty, newParentstring);
            var rotaPanel = (WrapPanel)LogicalTreeHelper.FindLogicalNode(GridRota,newParentstring);

            rotaPanel.Children.Add(StaffMember);
            return false;   
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        private void RotaType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = sender as ComboBox;
            if (sender == null && item.SelectedItem == null) return;
            Populate();
        }

        private void SelectedDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender == null) return;
            var date = Convert.ToDateTime(SelectedDate.SelectedDate);

            if (date == RotaDate) return;

            BuildRotaDates(date);
            Populate();
        }

        private void PreviousWeek_OnClick(object sender, RoutedEventArgs e)
        {
            if (SelectedDate?.SelectedDate != null)
            {
                var selected = (DateTime)SelectedDate?.SelectedDate;
                var last = selected.AddDays(-7);
                SelectedDate.Text = last.ToShortDateString();
                BuildRotaDates(last);
            }

            Populate();
        }

        private void NextWeek_OnClick(object sender, RoutedEventArgs e)
        {
            if (SelectedDate?.SelectedDate != null)
            {
                var selected = (DateTime)SelectedDate?.SelectedDate;
                var next = selected.AddDays(7);
                SelectedDate.Text = next.ToShortDateString();
                BuildRotaDates(next);
            }

            Populate();
        }
    }
}
