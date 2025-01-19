using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VClinic.Domain.Entities;
using VClinic.Domain.Repositories;
using VClinic.Infrastructure.Persistence.DbContexts;

namespace VClinic.Infrastructure.Repositories
{
    public class AppointmentRepository : BaseRepository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(VClinicDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByDateRange(DateTime start, DateTime end)
        {
            return await _dbContext.Appointments
                .Where(a => a.AppointmentDateTime >= start && a.AppointmentDateTime <= end)
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .OrderBy(a => a.AppointmentDateTime)
                .ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int doctorId)
        {
            return await _dbContext.Appointments
                .Where(a => a.DoctorId == doctorId)
                .Include(a => a.Patient)
                .OrderBy(a => a.AppointmentDateTime)
                .ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int patientId)
        {
            return await _dbContext.Appointments
                .Where(a => a.PatientId == patientId)
                .Include(a => a.Doctor)
                .OrderBy(a => a.AppointmentDateTime)
                .ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetUpcomingAppointments(int count)
        {
            return await _dbContext.Appointments
                .Where(a => a.AppointmentDateTime > DateTime.Now)
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .OrderBy(a => a.AppointmentDateTime)
                .Take(count)
                .ToListAsync();
        }
    }
}
