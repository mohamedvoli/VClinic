using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VClinic.Domain.Entities
{
    public class CommunicationChannel
    {
        public int ChannelId { get; set; }
        public string ChannelName { get; set; }
        public virtual ICollection<BranchCommunicationChannel> BranchCommunicationChannels { get; set; }
    }
}
