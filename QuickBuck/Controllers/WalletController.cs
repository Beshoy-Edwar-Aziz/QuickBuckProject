using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickBuck.Core.Models;
using QuickBuck.Core.Repositories;
using QuickBuck.Errors;

namespace QuickBuck.Controllers
{
   
    public class WalletController : ApiBaseController
    {
        private readonly IGenericRepository<Wallet> _walletRepo;

        public WalletController(IGenericRepository<Wallet> walletRepo)
        {
            _walletRepo = walletRepo;
        }
        [HttpPut]
        public async Task<ActionResult<Wallet>> UpdateWalletBalance([FromQuery]int WalletId,[FromQuery]int Balance)
        {
            var Wallet = await _walletRepo.GetByIdWithAsync(WalletId);
            if (Wallet is not null)
            {
                if (Wallet.Balance > 0)
                {
                    Wallet.Balance = Wallet.Balance + Balance;

                }
                else
                {
                    Wallet.Balance = Balance;
                }
                await _walletRepo.Update(Wallet);
            }
            else
            {
                return BadRequest(new ApiResponse(400, "Wallet is invalid"));
            }
            return Ok(Wallet);
        }
    }
}
