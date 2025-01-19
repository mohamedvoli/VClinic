using System.Collections.Generic;
using System.Threading.Tasks;
using VClinic.Domain.Entities;

namespace VClinic.Domain.Repositories
{
    public interface IPatientRepository : IAsyncRepository<Patient>
    {
        Task<IEnumerable<Patient>> GetPatientsByInsuranceProvider(int insuranceProviderId);
        Task<Patient> GetPatientWithFullHistory(int patientId);
        Task<IEnumerable<Appointment>> GetPatientAppointmentHistory(int patientId);
        Task<IEnumerable<Payment>> GetPatientPaymentHistory(int patientId);
    }
}
