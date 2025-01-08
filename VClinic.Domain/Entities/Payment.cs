using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VClinic.Domain.Entities
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public bool InsuranceCovered { get; set; }
        public int InsuranceCoveredPercentage { get; set; }
        public int PatientId { get; set; }
        [ForeignKey("PatientId")]
        public virtual Patient Patient { get; set; }
    }
}
