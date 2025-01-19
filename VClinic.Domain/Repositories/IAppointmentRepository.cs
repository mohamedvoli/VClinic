using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VClinic.Domain.Entities;

namespace VClinic.Domain.Repositories
{
    public interface IAppointmentRepository : IAsyncRepository<Appointment>
    {
        Task<IEnumerable<Appointment>> GetAppointmentsByDateRange(DateTime start, DateTime end);
        Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int doctorId);
        Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int patientId);
        Task<IEnumerable<Appointment>> GetUpcomingAppointments(int count);
    }
}
