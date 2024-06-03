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
        public ICollection<Transactions> Transactions { get; set; } = new HashSet<Transactions>();
    }
}
