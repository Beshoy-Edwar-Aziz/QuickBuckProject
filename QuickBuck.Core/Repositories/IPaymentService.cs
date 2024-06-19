using QuickBuck.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickBuck.Core.Repositories
{
    public interface IPaymentService
    {
        public Task<Wallet> CreateOrUpdatePaymentIntent(int WalletId, int Balance);
    }
}
