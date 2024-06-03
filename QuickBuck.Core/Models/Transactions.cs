using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickBuck.Core.Models
{
    public class Transactions
    {
        public int Id { get; set; }
        public int WalletId { get; set; }
        public int JobProviderId { get; set; }
        public string Type { get; set; }
        public DateTime DateTime { get; set; }
        public decimal Amount { get; set; }
        public Wallet Wallet { get; set; }
        public JobProvider JobProvider { get; set; }
    }
}
