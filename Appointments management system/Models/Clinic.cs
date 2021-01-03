using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;

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

        // one-to-many relationship
        public virtual ICollection<Doctor> Doctors { get; set; }
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
        public DbSet<Speciality> Specialities { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
    }

    public class Initp : DropCreateDatabaseAlways <DbCtx>
    {
        protected override void Seed(DbCtx context)
        {
            Speciality speciality1 = new Speciality
            {
                SpecialityId = 1,
                SpecialityName = "Chirurgie"
            };

            Speciality speciality2 = new Speciality
            {
                SpecialityId = 2,
                SpecialityName = "Cardiologie"
            };

            Speciality speciality3 = new Speciality
            {
                SpecialityId = 3,
                SpecialityName = "Neurologie"
            };

            context.Specialities.Add(speciality1);
            context.Specialities.Add(speciality2);
            context.Specialities.Add(speciality3);

            Doctor doctor1 = new Doctor
            {
                SpecialityId = speciality1.SpecialityId,
                FirstName = "Razvan",
                LastName = "Florescu"
            };

            Doctor doctor2 = new Doctor
            {
                SpecialityId = speciality1.SpecialityId,
                FirstName = "Mocanu",
                LastName = "Ciprian"
            };

            Doctor doctor3 = new Doctor
            {
                SpecialityId = speciality3.SpecialityId,
                FirstName = "Horoiu",
                LastName = "Maximilian"
            };


            Clinic clinic1 = new Clinic
            {
                Name = "Sf. Andrei",
                PhoneNumber = "0745563298",
                Address = new Address
                {
                    Street = "Tineretului",
                    No = 3,
                    City = "Bucuresti",
                }
            };

            Clinic clinic2 = new Clinic
            {
                Name = "ProMed",
                PhoneNumber = "0798767868",
                Address = new Address
                {
                    Street = "Cuza Voda",
                    No = 8,
                    City = "Bucuresti",
                },
                Specialities = new List<Speciality> {
                   speciality1, speciality2
                },
                Doctors = new List<Doctor> { doctor1, doctor2 }
            };

            Clinic clinic3 = new Clinic
            {
                Name = "MedExpert",
                PhoneNumber = "0747767868",
                Address = new Address
                {
                    Street = "1 Decembrie",
                    No = 44,
                    City = "Roman",
                },
                Specialities = new List<Speciality> { 
                    speciality3
                },
                Doctors = new List<Doctor> { doctor3 }
            };


            context.Clinics.Add(clinic1);
            context.Clinics.Add(clinic2);
            context.Clinics.Add(clinic3);

            /*
            context.Doctors.Add(doctor1);
            context.Doctors.Add(doctor2);
            context.Doctors.Add(doctor3);
            */

            context.SaveChanges();
            base.Seed(context);
        }
    }
}