using Ecom.Services;
using Ecom.ViewModel.Absence;
using Ecom.ViewModel.Planner;
using Ecom.ViewModel.Staff;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Ecom.View.Planner
{
    /// <summary>
    /// Interaction logic for RotaPlannerView.xaml
    /// </summary>
    public partial class RotaPlannerView : UserControl, INotifyPropertyChanged
    {
        private readonly StaffService _staffService;
        private readonly AbsenceService _absenceService;
        public ObservableCollection<DayViewModel> Days { get; set; }

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

            Days = new ObservableCollection<DayViewModel>();

            RotaType.ItemsSource = rotas;
            DataContext = this;
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

        private async void LoadWeek()
        {
            var today = DateTime.Now;
            var difference = today.DayOfWeek - ((int) today.DayOfWeek) +2;
            var startDate = today.AddDays((int)difference);
            for (var i = 0; i < 7; i++)
            {
                var vm = new DayViewModel()
                {
                    Date = startDate.AddDays(i),
                };
                vm.StaffAvailability.AddItems(await _staffService.FetchAllStaffAvailability());
                vm.StaffAbsences.AddItems(await _absenceService.FetchAllAbsences());
                
                Days.Add(vm);
            }
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
        }

        private void SelectedDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender == null) return;
            var date = Convert.ToDateTime(SelectedDate.SelectedDate);

            if (date == RotaDate) return;
        }

        private void PreviousWeek_OnClick(object sender, RoutedEventArgs e)
        {
            if (SelectedDate?.SelectedDate != null)
            {
                var selected = (DateTime)SelectedDate?.SelectedDate;
                var last = selected.AddDays(-7);
                SelectedDate.Text = last.ToShortDateString();
            }
        }

        private void NextWeek_OnClick(object sender, RoutedEventArgs e)
        {
            if (SelectedDate?.SelectedDate != null)
            {
                var selected = (DateTime)SelectedDate?.SelectedDate;
                var next = selected.AddDays(7);
                SelectedDate.Text = next.ToShortDateString();
            }
        }

        private void RotaPlannerView_OnLoaded(object sender, RoutedEventArgs e)
        {
            LoadWeek();
        }
    }
}
