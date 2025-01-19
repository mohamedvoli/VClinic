using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VClinic.Domain.Entities;
using VClinic.Domain.Repositories;
using VClinic.Infrastructure.Persistence.DbContexts;

namespace VClinic.Infrastructure.Repositories
{
    public class PatientRepository : BaseRepository<Patient>, IPatientRepository
    {
        public PatientRepository(VClinicDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Patient>> GetPatientsByInsuranceProvider(int insuranceProviderId)
        {
            return await _dbContext.Patients
                .Where(p => p.InsuranceProviderId == insuranceProviderId)
                .Include(p => p.InsuranceProvider)
                .OrderBy(p => p.LastName)
                .ToListAsync();
        }

        public async Task<Patient> GetPatientWithFullHistory(int patientId)
        {
            return await _dbContext.Patients
                .Where(p => p.PatientId == patientId)
                .Include(p => p.InsuranceProvider)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Appointment>> GetPatientAppointmentHistory(int patientId)
        {
            return await _dbContext.Appointments
                .Where(a => a.PatientId == patientId)
                .Include(a => a.Doctor)
                .Include(a => a.Payment)
                .OrderByDescending(a => a.AppointmentDateTime)
                .ToListAsync();
        }

        public async Task<IEnumerable<Payment>> GetPatientPaymentHistory(int patientId)
        {
            return await _dbContext.Payments
                .Where(p => p.Appointment.PatientId == patientId)
                .Include(p => p.Appointment)
                    .ThenInclude(a => a.Doctor)
                .OrderByDescending(p => p.PaymentDate)
                .ToListAsync();
        }
    }
}
