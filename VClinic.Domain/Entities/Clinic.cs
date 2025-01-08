using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VClinic.Domain.Entities
{
    public class Clinic
    {
        public int ClinicId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
