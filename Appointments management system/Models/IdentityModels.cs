using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Appointments_management_system.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CNP { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer<ApplicationDbContext>(new Initp());
        }

        /* Tabelele */
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<Speciality> Specialities { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }

    public class Initp : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
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
                LastName = "Florescu",
                PhoneNumber = "0741130693",
                Details = "Specialized in Cardiothoracic Surgery",
                Appointments = new List<Appointment>
                {
                    new Appointment
                    {
                        AppointmentDate = new System.DateTime(2021,1,9),
                        AppointmentHour = "12:00",
                        Details = "Control de rutina",
                      //  ApplicationUserId = "2132"
                    }
                }
            };

            Doctor doctor2 = new Doctor
            {
                SpecialityId = speciality1.SpecialityId,
                FirstName = "Mocanu",
                LastName = "Ciprian",
                PhoneNumber = "0755514235",
                Details = "Specialized in Paediatric and Otolaryngology Surgery"
            };

            Doctor doctor3 = new Doctor
            {
                SpecialityId = speciality3.SpecialityId,
                FirstName = "Horoiu",
                LastName = "Maximilian",
                PhoneNumber = "0785524378",
                Details = "Specialized in Geriatric Neurology and Epilepsy seizures"
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

            context.SaveChanges();
            base.Seed(context);
        }
    }
}