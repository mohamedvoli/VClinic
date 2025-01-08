using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Emit;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using VClinic.Domain.Entities;


namespace VClinic.Infrastructure.Persistence.DbContexts
{
    public class VClinicDbContext : IdentityDbContext<ApplicationUser>
    {
        public VClinicDbContext(DbContextOptions<VClinicDbContext> options)
        : base(options)
        {

        }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<AppointmentType> AppointmentTypes { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<BranchCommunicationChannel> BranchCommunicationChannels { get; set; }
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<CommunicationChannel> CommunicationChannels { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<DoctorBranchAssignment> DoctorBranchAssignments { get; set; }
        public DbSet<InsuranceProvider> InsuranceProviders { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Service> Services { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Apply configurations
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
