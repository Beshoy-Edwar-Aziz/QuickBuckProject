using Microsoft.Extensions.Configuration;
using QuickBuck.Core.Models;
using QuickBuck.Core.Repositories;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickBuck.Service
{
    public class PaymentService : IPaymentService
    {
        private readonly IConfiguration _configuration;
        private readonly IGenericRepository<Wallet> _walletRepo;

        public PaymentService(IConfiguration configuration, IGenericRepository<Wallet> walletRepo)
        {
            _configuration = configuration;
            _walletRepo = walletRepo;
        }
        public async Task<Wallet> CreateOrUpdatePaymentIntent(int WalletId, int Balance)
        {
            StripeConfiguration.ApiKey = _configuration["Stripe:SecretKey"];
            var Wallet = await _walletRepo.GetByIdWithAsync(WalletId);
            var Service = new PaymentIntentService();
            PaymentIntent paymentIntent;
            if (string.IsNullOrEmpty(Wallet.PaymentIntentId))
            {
                var Options = new PaymentIntentCreateOptions()
                {
                    Amount = (long)Balance+10000,
                    Currency= "usd",
                    PaymentMethodTypes= new List<string>() {"card"}
                };
                paymentIntent = await Service.CreateAsync(Options);
                Wallet.PaymentIntentId = paymentIntent.Id;
                Wallet.ClientSecret = paymentIntent.ClientSecret;
            }
            else
            {
                var Options = new PaymentIntentUpdateOptions()
                {
                    Amount = (long)Balance+10000
                };
                paymentIntent = await Service.UpdateAsync(Wallet.PaymentIntentId, Options);
                Wallet.PaymentIntentId = paymentIntent.Id;
                Wallet.ClientSecret = paymentIntent.ClientSecret;
            }
            return Wallet;
        }
    }
}
