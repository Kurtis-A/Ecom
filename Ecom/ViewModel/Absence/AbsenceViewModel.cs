using System;

namespace Ecom.ViewModel.Absence
{
    public class AbsenceViewModel : ViewModelBase
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public DateTime Date { get; set; }

        public string Type { get; set; }
    }
}
