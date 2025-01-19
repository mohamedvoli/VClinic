using MediatR;
using System;

namespace VClinic.Application.Features.Appointments.Commands.CreateAppointment
{
    public class CreateAppointmentCommand : IRequest<int>
    {
        public DateTime AppointmentDateTime { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public string Notes { get; set; }
        public int AppointmentTypeId { get; set; }
    }
}
