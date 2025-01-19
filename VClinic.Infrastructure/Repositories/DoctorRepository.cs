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
    public class DoctorRepository : BaseRepository<Doctor>, IDoctorRepository
    {
        public DoctorRepository(VClinicDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Doctor>> GetDoctorsBySpecialization(string specialization)
        {
            return await _dbContext.Doctors
                .Where(d => d.Specialization == specialization)
                .Include(d => d.DoctorBranchAssignment)
                    .ThenInclude(dba => dba.Branch)
                .OrderBy(d => d.LastName)
                .ToListAsync();
        }

        public async Task<IEnumerable<Doctor>> GetDoctorsByBranch(int branchId)
        {
            return await _dbContext.Doctors
                .Where(d => d.DoctorBranchAssignment.Any(dba => dba.BranchId == branchId))
                .Include(d => d.DoctorBranchAssignment)
                .OrderBy(d => d.LastName)
                .ToListAsync();
        }

        public async Task<IEnumerable<Doctor>> GetAvailableDoctors(int branchId, DateTime dateTime)
        {
            var busyDoctorIds = await _dbContext.Appointments
                .Where(a => a.AppointmentDateTime.Date == dateTime.Date &&
                           a.AppointmentDateTime.Hour == dateTime.Hour)
                .Select(a => a.DoctorId)
                .ToListAsync();

            return await _dbContext.Doctors
                .Where(d => d.DoctorBranchAssignment.Any(dba => dba.BranchId == branchId) &&
                           !busyDoctorIds.Contains(d.DoctorId))
                .Include(d => d.DoctorBranchAssignment)
                    .ThenInclude(dba => dba.Branch)
                .OrderBy(d => d.LastName)
                .ToListAsync();
        }

        public async Task<bool> IsDoctorAvailable(int doctorId, DateTime dateTime)
        {
            return !await _dbContext.Appointments
                .AnyAsync(a => a.DoctorId == doctorId &&
                              a.AppointmentDateTime.Date == dateTime.Date &&
                              a.AppointmentDateTime.Hour == dateTime.Hour);
        }
    }
}
