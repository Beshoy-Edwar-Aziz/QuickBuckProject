using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickBuck.Core.Models;
using QuickBuck.Core.Repositories;
using QuickBuck.Errors;

namespace QuickBuck.Controllers
{
 
    public class PaymentController : ApiBaseController
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        [HttpPost]
        public async Task<ActionResult<Wallet>> CreateOrUpdatePaymentIntent(int WalletId, int Balance)
        {

            var result =await _paymentService.CreateOrUpdatePaymentIntent(WalletId,Balance);
            if (result is null) return BadRequest(new ApiResponse(400,"Wallet is invalid"));
            return Ok(result);

        }
    }
}
