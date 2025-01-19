using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VClinic.Domain.Repositories;

namespace VClinic.Application.Features.Appointments.Queries.GetAppointmentsList
{
    public class GetAppointmentsListQueryHandler : IRequestHandler<GetAppointmentsListQuery, List<AppointmentsListVm>>
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public GetAppointmentsListQueryHandler(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task<List<AppointmentsListVm>> Handle(GetAppointmentsListQuery request, CancellationToken cancellationToken)
        {
            var appointments = await _appointmentRepository.GetAsync(
                a => (!request.StartDate.HasValue || a.AppointmentDateTime >= request.StartDate) &&
                     (!request.EndDate.HasValue || a.AppointmentDateTime <= request.EndDate) &&
                     (!request.DoctorId.HasValue || a.DoctorId == request.DoctorId) &&
                     (!request.PatientId.HasValue || a.PatientId == request.PatientId),
                orderBy: q => q.OrderBy(a => a.AppointmentDateTime),
                includes: new List<System.Linq.Expressions.Expression<System.Func<Domain.Entities.Appointment, object>>>
                {
                    a => a.Doctor,
                    a => a.Patient,
                    a => a.AppointmentType
                });

            return appointments.Select(a => new AppointmentsListVm
            {
                AppointmentId = a.AppointmentId,
                AppointmentDateTime = a.AppointmentDateTime,
                PatientName = $"{a.Patient.FirstName} {a.Patient.LastName}",
                DoctorName = $"Dr. {a.Doctor.FirstName} {a.Doctor.LastName}",
                AppointmentType = a.AppointmentType.Name,
                Status = a.Status
            }).ToList();
        }
    }
}
