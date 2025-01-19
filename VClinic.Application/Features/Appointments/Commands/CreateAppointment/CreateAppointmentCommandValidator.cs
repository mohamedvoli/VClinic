using FluentValidation;
using System;

namespace VClinic.Application.Features.Appointments.Commands.CreateAppointment
{
    public class CreateAppointmentCommandValidator : AbstractValidator<CreateAppointmentCommand>
    {
        public CreateAppointmentCommandValidator()
        {
            RuleFor(v => v.AppointmentDateTime)
                .NotEmpty()
                .Must(BeAFutureDate).WithMessage("Appointment must be in the future");

            RuleFor(v => v.PatientId)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(v => v.DoctorId)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(v => v.AppointmentTypeId)
                .NotEmpty()
                .GreaterThan(0);
        }

        private bool BeAFutureDate(DateTime date)
        {
            return date > DateTime.Now;
        }
    }
}
