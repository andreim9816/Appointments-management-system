using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace Appointments_management_system.Models
{
    public class Clinic
    {
        [Key]
        public int ClinicId { get; set; }

        [Required]
        [MinLength(5, ErrorMessage ="Clinic name should be at least 5 characters long"),
        MaxLength(30, ErrorMessage = "Clinic name should have maximum 30 characters")]
        public string Name { get; set; }

        [RegularExpression(@"07([0-9]){8}", ErrorMessage = "Please enter a valid phone number!")]
        public string PhoneNumber { get; set; }

        [Required]
        public virtual Address Address { get; set; }

        // many-to-many relationship
        public virtual ICollection<Speciality> Specialities { get; set; }

    }

    public class DbCtx : DbContext
    {
        public DbCtx() : base("DbConnectionString")
        {
            // set the initializer here
            Database.SetInitializer<DbCtx>(new Initp());
        }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Clinic> Clinics { get; set; }

    }

    public class Initp : DropCreateDatabaseAlways <DbCtx>
    {
        protected override void Seed(DbCtx context)
        {
            base.Seed(context);
            context.Clinics.Add(new Clinic
            {
                Name = "Sf. Andrei",
                PhoneNumber = "0745563298",
                Address = new Address
                {
                    Street = "Tineretului",
                    No = 3,
                    City = "Bucuresti",
                }
            });

            context.Clinics.Add(new Clinic
            {
                Name = "ProMed",
                PhoneNumber = "0798767868",
                Address = new Address
                {
                    Street = "Cuza Voda",
                    No = 8,
                    City = "Bucuresti",
                }
            });


            context.Clinics.Add(new Clinic
            {
                Name = "MedExpert",
                PhoneNumber = "0747767868",
                Address = new Address
                {
                    Street = "1 Decembrie",
                    No = 44,
                    City = "Roman",
                }
            });

            context.SaveChanges();
            base.Seed(context);
        }
    }
}