using MediatR;
using System;
using System.Collections.Generic;

namespace VClinic.Application.Features.Appointments.Queries.GetAppointmentsList
{
    public class GetAppointmentsListQuery : IRequest<List<AppointmentsListVm>>
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? DoctorId { get; set; }
        public int? PatientId { get; set; }
    }
}
