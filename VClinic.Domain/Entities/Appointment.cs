using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using VClinic.Domain.Entities;

namespace VClinic.Domain.Entities
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public DateTime AppointmentDateTime { get; set; }
        public int Status { get; set; }
        //___________________________One to many relationship with Patients table___________________________
        public int PatientId { get; set; }//Foreign Key
        [ForeignKey("PatientId")]
        public virtual Patient Patient { get; set; } //Navigation Property
        //__________________________One to many relationship with AppointType table____________________________
        public int AppointmentTypeId { get; set; } //Foreign Key
        [ForeignKey("AppointmentTypeId")]
        public virtual AppointmentType AppointmentType { get; set; } //Navigation Property
        //__________________________One to many relationship with Doctors table____________________________
        public int DoctorId { get; set; } //Foreign Key
        [ForeignKey("DoctorId")]
        public virtual Doctor Doctor { get; set; } //Navigation Property
        //________________________________One to many relationship with Branches table______________________
        public int BranchId { get; set; } //Foreign Key
        [ForeignKey("BranchId")]
        public virtual Branch Branche { get; set; } //Navigation Property

    }
}
