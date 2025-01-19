using System.Collections.Generic;
using System.Threading.Tasks;
using VClinic.Domain.Entities;

namespace VClinic.Domain.Repositories
{
    public interface IDoctorRepository : IAsyncRepository<Doctor>
    {
        Task<IEnumerable<Doctor>> GetDoctorsBySpecialization(string specialization);
        Task<IEnumerable<Doctor>> GetDoctorsByBranch(int branchId);
        Task<IEnumerable<Doctor>> GetAvailableDoctors(int branchId, System.DateTime dateTime);
        Task<bool> IsDoctorAvailable(int doctorId, System.DateTime dateTime);
    }
}
