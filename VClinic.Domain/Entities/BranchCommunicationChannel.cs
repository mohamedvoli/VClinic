using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VClinic.Domain.Entities
{
    public class BranchCommunicationChannel
    {
        public int BranchId { get; set; }
        public int CommunicationChannelId { get; set; }
        public int ClinicId { get; set; }

        // Navigation Properties
        public virtual Branch Branch { get; set; }
        public virtual CommunicationChannel CommunicationChannel { get; set; }
    }
}
