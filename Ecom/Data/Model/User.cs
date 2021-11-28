using System;
using Ecom.Data.Model.Base;

namespace Ecom.Data.Model
{
    public class User : ISoftDeleteEntity
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Firstname { get; set; }

        public string Surname { get; set; }

        public string Role { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime LeaveDate { get; set; }

        public bool AvailMonday { get; set; }

        public bool AvailTuesday { get; set; }

        public bool AvailWednesday { get; set; }

        public bool AvailThursday { get; set; }

        public bool AvailFriday { get; set; }

        public bool AvailSaturday { get; set; }

        public bool AvailSunday{ get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime LastUpdated { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string AddressLine3 { get; set; }

        public string Postcode { get; set; }

        public int ContactNumber { get; set; }

        public string ContactEmail { get; set; }

        public string NextOfKinName { get; set; }

        public string NextOfKinRelation { get; set; }

        public int NextOfKinContactNumber { get; set; }

        public DateTime? Archived { get; set; }
    }
}
