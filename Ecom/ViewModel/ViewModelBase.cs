using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Ecom.ViewModel
{
    public class ViewModelBase : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        public ViewModelBase()
        {
            ValidationResults = new List<ValidationResult>();
        }

        public bool HasErrors => errors.Any();

        public bool IsValid()
        {
            var context = new ValidationContext(this, null, null);
            return Validator.TryValidateObject(this, context, ValidationResults, true);
        }

        public List<string> GetValidationErrors()
        {
            return ValidationResults.Select(v => v.ErrorMessage).ToList();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            return errors.ContainsKey(propertyName) ? errors[propertyName] : null;
        }

        public void ClearErrors()
        {
            errors = new Dictionary<string, List<string>>();
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void Validate(object val, [CallerMemberName] string propertyName = null)
        {
            if (errors.ContainsKey(propertyName)) errors.Remove(propertyName);

            var context = new ValidationContext(this) { MemberName = propertyName };
            var results = new List<ValidationResult>();

            if (!Validator.TryValidateProperty(val, context, results))
            {
                errors[propertyName] = results.Select(e => e.ErrorMessage).ToList();
            }

            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        private List<ValidationResult> ValidationResults { get; set; }

        private IDictionary<string, List<string>> errors = new Dictionary<string, List<string>>();
    }
}
