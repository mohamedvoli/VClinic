using System;

namespace VClinic.Application.Features.Appointments.Queries.GetAppointmentsList
{
    public class AppointmentsListVm
    {
        public int AppointmentId { get; set; }
        public DateTime AppointmentDateTime { get; set; }
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public string AppointmentType { get; set; }
        public string Status { get; set; }
    }
}
