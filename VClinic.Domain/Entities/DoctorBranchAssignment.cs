using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VClinic.Domain.Entities
{
    public class DoctorBranchAssignment
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        [ForeignKey("DoctorId")]
        public virtual Doctor Doctor { get; set; }
        public int BranchId { get; set; }
        [ForeignKey("BranchId")]
        public virtual Doctor Branch { get; set; }
    }
}
