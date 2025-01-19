using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VClinic.Domain.Entities;
using VClinic.Infrastructure.Persistence.DbContexts;
using VClinic.Infrastructure.Repositories;
using Xunit;

namespace VClinic.UnitTests.Repositories
{
    public class AppointmentRepositoryTests
    {
        private readonly DbContextOptions<VClinicDbContext> _options;
        private readonly VClinicDbContext _context;
        private readonly AppointmentRepository _repository;

        public AppointmentRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<VClinicDbContext>()
                .UseInMemoryDatabase(databaseName: "VClinicTestDb")
                .Options;

            _context = new VClinicDbContext(_options);
            _repository = new AppointmentRepository(_context);
        }

        [Fact]
        public async Task GetAppointmentsByDateRange_ShouldReturnCorrectAppointments()
        {
            // Arrange
            var startDate = DateTime.Now;
            var endDate = startDate.AddDays(7);
            
            var appointments = new List<Appointment>
            {
                new Appointment { AppointmentDateTime = startDate.AddDays(1) },
                new Appointment { AppointmentDateTime = startDate.AddDays(3) },
                new Appointment { AppointmentDateTime = startDate.AddDays(10) }
            };

            await _context.Appointments.AddRangeAsync(appointments);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.GetAppointmentsByDateRange(startDate, endDate);

            // Assert
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetAppointmentsByDoctor_ShouldReturnCorrectAppointments()
        {
            // Arrange
            var doctorId = 1;
            var appointments = new List<Appointment>
            {
                new Appointment { DoctorId = doctorId },
                new Appointment { DoctorId = doctorId },
                new Appointment { DoctorId = 2 }
            };

            await _context.Appointments.AddRangeAsync(appointments);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.GetAppointmentsByDoctor(doctorId);

            // Assert
            Assert.Equal(2, result.Count());
            Assert.All(result, appointment => Assert.Equal(doctorId, appointment.DoctorId));
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}
