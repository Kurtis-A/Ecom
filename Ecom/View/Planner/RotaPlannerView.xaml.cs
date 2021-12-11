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
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using ToastNotifications.Messages;

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

            BuildViewDates(RotaDate);

            if (RotaType.SelectedItem != null)
                Populate();
        }

        public void BuildViewDates(DateTime date)
        {
            try
            {
                PropertyInfo[] properties = ViewModel.GetType().GetProperties();

                int count = 0;
                foreach (var property in properties.Where(x => x.Name.Contains("Date")).OrderBy(o => o.Name))
                {
                    //property.GetType().GetProperty(property.Name).SetValue(ViewModel, date.AddDays(count).ToString());

                    var pType = property.GetType();
                    var pProp = pType.GetProperty(property.Name);
                    pProp.SetValue(ViewModel, date.AddDays(count).ToString());
                    count++;
                }
            }
            catch (Exception e)
            {
                Globals.Notifier.ShowError($"Opps something went wrong!");
                Globals.Notifier.ShowInformation($"Error Info: {e.Message}");
            }
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

            Chip chip = new()
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

            ChipSwitch(chipType, parent);
        }

        private bool ChipSwitch(Chip StaffMember, DependencyObject parent)
        {
            //Remove from Available Panel
            var previousPanel = (WrapPanel)parent;
            previousPanel.Children.Remove(StaffMember);


            //Reassign PanelName
            var parentName = string.Empty;
            if (parent.GetValue(NameProperty).ToString().Contains("Avail"))
            {
                //Add Staff to Rota
                parentName = parent.GetValue(NameProperty).ToString().Replace("Avail", "Rota");
            }
                

            if (parent.GetValue(NameProperty).ToString().Contains("Rota"))
            {
                //Remove Staff from Rota
                parentName = parent.GetValue(NameProperty).ToString().Replace("Rota", "Avail");
            }
                

            //Find New Panel and add item to new panel
            var newPanel = GridAvail.FindName(parentName) as WrapPanel;
            newPanel.Children.Add(StaffMember);

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

            BuildViewDates(date);
            Populate();
        }

        private void PreviousWeek_OnClick(object sender, RoutedEventArgs e)
        {
            if (SelectedDate?.SelectedDate != null)
            {
                var selected = (DateTime)SelectedDate?.SelectedDate;
                var last = selected.AddDays(-7);
                SelectedDate.Text = last.ToShortDateString();
                BuildViewDates(last);
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
                BuildViewDates(next);
            }

            Populate();
        }
    }
}
