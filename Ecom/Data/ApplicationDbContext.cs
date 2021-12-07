using Ecom.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace Ecom.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Staff> Staff { get; set; }

        public DbSet<Absence> Absence { get; set; }

        public DbSet<Rota> Rota { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            Staff[] staff = GetStaff();
            builder.Entity<Staff>().HasData(staff);
        }

        private Staff[] GetStaff()
        {
            Staff[] staff = new Staff[10];

            staff[0] = new Staff()
            {
                Id = 1,
                Firstname = "Kurtis",
                Surname = "Aspden",
                Role = "Super Admin",
                Username = "KAS",
                Preference = "Monday,Tuesday,Wednesday,Thursday,Friday,Saturday,Sunday,",
                DateOfBirth = Faker.Identification.DateOfBirth(),
                StartDate = DateTime.Parse("01/10/2021"),
                Created = DateTime.Parse("01/10/2021"),
                Updated = DateTime.Parse("01/10/2021"),
                AddressLine1 = "1",
                AddressLine2 = Faker.Address.StreetName(),
                AddressLine3 = Faker.Address.City(),
                Postcode = Faker.Address.UkPostCode(),
                ContactNumber = Faker.Phone.Number()
            };

            staff[1] = new Staff()
            {
                Id = 2,
                Firstname = "Joe",
                Surname = "Bloggs",
                Role = "Manager",
                Username = "JBL",
                Preference = "Monday,Tuesday,Wednesday,Thursday,Friday,Saturday,Sunday,",
                DateOfBirth = Faker.Identification.DateOfBirth(),
                StartDate = DateTime.Parse("01/10/2021"),
                Created = DateTime.Parse("01/10/2021"),
                Updated = DateTime.Parse("01/10/2021"),
                AddressLine1 = "1",
                AddressLine2 = Faker.Address.StreetName(),
                AddressLine3 = Faker.Address.City(),
                Postcode = Faker.Address.UkPostCode(),
                ContactNumber = Faker.Phone.Number()
            };

            staff[2] = new Staff()
            {
                Id = 3,
                Firstname = "Jane",
                Surname = "Doe",
                Role = "Supervisor",
                Username = "JDO",
                Preference = "Friday,Saturday,Sunday,",
                DateOfBirth = Faker.Identification.DateOfBirth(),
                StartDate = DateTime.Parse("01/10/2021"),
                Created = DateTime.Parse("01/10/2021"),
                Updated = DateTime.Parse("01/10/2021"),
                AddressLine1 = "1",
                AddressLine2 = Faker.Address.StreetName(),
                AddressLine3 = Faker.Address.City(),
                Postcode = Faker.Address.UkPostCode(),
                ContactNumber = Faker.Phone.Number()
            };

            staff[3] = new Staff()
            {
                Id = 4,
                Firstname = "Susan",
                Surname = "Samples",
                Role = "Supervisor",
                Username = "SSA",
                Preference = "Monday,Tuesday,Wednesday,Thursday,",
                DateOfBirth = Faker.Identification.DateOfBirth(),
                StartDate = DateTime.Parse("01/10/2021"),
                Created = DateTime.Parse("01/10/2021"),
                Updated = DateTime.Parse("01/10/2021"),
                AddressLine1 = "1",
                AddressLine2 = Faker.Address.StreetName(),
                AddressLine3 = Faker.Address.City(),
                Postcode = Faker.Address.UkPostCode(),
                ContactNumber = Faker.Phone.Number()
            };

            staff[4] = new Staff()
            {
                Id = 5,
                Firstname = "Adam",
                Surname = "Apple",
                Role = "Team Member",
                Username = "AAP",
                Preference = "Friday,Saturday,Sunday,",
                DateOfBirth = Faker.Identification.DateOfBirth(),
                StartDate = DateTime.Parse("01/10/2021"),
                Created = DateTime.Parse("01/10/2021"),
                Updated = DateTime.Parse("01/10/2021"),
                AddressLine1 = "1",
                AddressLine2 = Faker.Address.StreetName(),
                AddressLine3 = Faker.Address.City(),
                Postcode = Faker.Address.UkPostCode(),
                ContactNumber = Faker.Phone.Number()
            };

            staff[5] = new Staff()
            {
                Id = 6,
                Firstname = "Ben",
                Surname = "Banana",
                Role = "Team Member",
                Username = "BBA",
                Preference = "Friday,Saturday,Sunday,",
                DateOfBirth = Faker.Identification.DateOfBirth(),
                StartDate = DateTime.Parse("01/10/2021"),
                Created = DateTime.Parse("01/10/2021"),
                Updated = DateTime.Parse("01/10/2021"),
                AddressLine1 = "1",
                AddressLine2 = Faker.Address.StreetName(),
                AddressLine3 = Faker.Address.City(),
                Postcode = Faker.Address.UkPostCode(),
                ContactNumber = Faker.Phone.Number()
            };

            staff[6] = new Staff()
            {
                Id = 7,
                Firstname = "Chris",
                Surname = "Cucumber",
                Role = "Team Member",
                Username = "CCU",
                Preference = "Friday,Saturday,Sunday,",
                DateOfBirth = Faker.Identification.DateOfBirth(),
                StartDate = DateTime.Parse("01/10/2021"),
                Created = DateTime.Parse("01/10/2021"),
                Updated = DateTime.Parse("01/10/2021"),
                AddressLine1 = "1",
                AddressLine2 = Faker.Address.StreetName(),
                AddressLine3 = Faker.Address.City(),
                Postcode = Faker.Address.UkPostCode(),
                ContactNumber = Faker.Phone.Number()
            };

            staff[7] = new Staff()
            {
                Id = 8,
                Firstname = "Darren",
                Surname = "Dates",
                Role = "Team Member",
                Username = "DDA",
                Preference = "Monday,Tuesday,Wednesday,Thursday,",
                DateOfBirth = Faker.Identification.DateOfBirth(),
                StartDate = DateTime.Parse("01/10/2021"),
                Created = DateTime.Parse("01/10/2021"),
                Updated = DateTime.Parse("01/10/2021"),
                AddressLine1 = "1",
                AddressLine2 = Faker.Address.StreetName(),
                AddressLine3 = Faker.Address.City(),
                Postcode = Faker.Address.UkPostCode(),
                ContactNumber = Faker.Phone.Number()
            };

            staff[8] = new Staff()
            {
                Id = 9,
                Firstname = "Eric",
                Surname = "Elderberry",
                Role = "Team Member",
                Username = "EEL",
                Preference = "Monday,Tuesday,Wednesday,Thursday,",
                DateOfBirth = Faker.Identification.DateOfBirth(),
                StartDate = DateTime.Parse("01/10/2021"),
                Created = DateTime.Parse("01/10/2021"),
                Updated = DateTime.Parse("01/10/2021"),
                AddressLine1 = "1",
                AddressLine2 = Faker.Address.StreetName(),
                AddressLine3 = Faker.Address.City(),
                Postcode = Faker.Address.UkPostCode(),
                ContactNumber = Faker.Phone.Number()
            };

            staff[9] = new Staff()
            {
                Id = 10,
                Firstname = "Freddy",
                Surname = "Fig",
                Role = "Team Member",
                Username = "FFI",
                Preference = "Monday,Tuesday,Wednesday,Thursday,",
                DateOfBirth = Faker.Identification.DateOfBirth(),
                StartDate = DateTime.Parse("01/10/2021"),
                Created = DateTime.Parse("01/10/2021"),
                Updated = DateTime.Parse("01/10/2021"),
                AddressLine1 = "1",
                AddressLine2 = Faker.Address.StreetName(),
                AddressLine3 = Faker.Address.City(),
                Postcode = Faker.Address.UkPostCode(),
                ContactNumber = Faker.Phone.Number()
            };

            return staff;
        }
    }
}
