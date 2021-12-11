using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Ecom.Controls;
using Ecom.ViewModel.Absence;
using Ecom.ViewModel.Staff;

namespace Ecom.ViewModel.Planner
{
    public class DayViewModel :ViewModelBase
    {
        public DateTime Date { get; set; }

        public DayViewModel()
        {
            StaffAvailability = new ThreadSafeCollection<StaffViewModel>();
            StaffAbsences = new ThreadSafeCollection<AbsenceViewModel>();
        }
        
        public ThreadSafeCollection<StaffViewModel> StaffAvailability { get; set; }

        public ThreadSafeCollection<AbsenceViewModel> StaffAbsences { get; set; }
    }
}