using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VClinic.Domain.Entities;
using VClinic.Domain.Repositories;

namespace VClinic.Application.Features.Appointments.Commands.CreateAppointment
{
    public class CreateAppointmentCommandHandler : IRequestHandler<CreateAppointmentCommand, int>
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IDoctorRepository _doctorRepository;

        public CreateAppointmentCommandHandler(
            IAppointmentRepository appointmentRepository,
            IDoctorRepository doctorRepository)
        {
            _appointmentRepository = appointmentRepository;
            _doctorRepository = doctorRepository;
        }

        public async Task<int> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
        {
            // Check if doctor is available
            var isDoctorAvailable = await _doctorRepository.IsDoctorAvailable(
                request.DoctorId, 
                request.AppointmentDateTime);

            if (!isDoctorAvailable)
            {
                throw new System.Exception("Doctor is not available at the specified time.");
            }

            var appointment = new Appointment
            {
                AppointmentDateTime = request.AppointmentDateTime,
                PatientId = request.PatientId,
                DoctorId = request.DoctorId,
                Notes = request.Notes,
                AppointmentTypeId = request.AppointmentTypeId
            };

            appointment = await _appointmentRepository.AddAsync(appointment);
            return appointment.AppointmentId;
        }
    }
}
