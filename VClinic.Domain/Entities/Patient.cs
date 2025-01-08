using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VClinic.Domain.Entities
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string MedicalConditions { get; set; }
        public string Allergies { get; set; }
        public string CurrentMedications { get; set; }
        public string OtherMedicalNotes { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int InsuranceProviderId { get; set; }
        [ForeignKey("InsuranceProviderId")]
        public virtual InsuranceProvider InsuranceProvider { get; set; }
    }
}
