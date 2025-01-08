using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VClinic.Domain.Entities
{
    public class Branch
    {
        public int BranchId { get; set; }
        public string Address { get; set; }
        //_________________________________________ One to many relationship with Clinics table
        public int ClinicId { get; set; }
        [ForeignKey("ClinicId")]
        public virtual Clinic Clinic { get; set; }
        //_________________________________________ 
        public virtual ICollection<BranchCommunicationChannel> BranchCommunicationChannels { get; set; }
        public virtual ICollection<DoctorBranchAssignment> DoctorBranchAssignment { get; set; }
        public virtual ICollection<Doctor> Doctors { get; set; }
        //_________________________________________ One to many relationship with Users(Managers) table
        public int ManagerId { get; set; }
        [ForeignKey("ManagerId")]
        [Display(Name = "Clinic Manager")]
        public virtual ApplicationUser User { get; set; }
    }
}
