using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickBuck.Core.Models
{
    public class Wallet:BaseEntity
    {
        public decimal Balance { get; set; }
        public JobProvider JobProvider { get; set; }
        public string? PaymentIntentId { get; set; }
        public string? ClientSecret { get; set; }
        public ICollection<Transactions> Transactions { get; set; } = new HashSet<Transactions>();
    }
}
