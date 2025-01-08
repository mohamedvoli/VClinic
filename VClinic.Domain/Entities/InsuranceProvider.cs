using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VClinic.Domain.Entities
{
    public class InsuranceProvider
    {
        public int InsuranceProviderId { get; set; }
        public string ProviderName { get; set; }
        public string ContactInfo { get; set; }
        public string Address { get; set; }
    }
}
