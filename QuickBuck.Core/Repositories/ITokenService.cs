using Microsoft.AspNetCore.Identity;
using QuickBuck.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickBuck.Core.Repositories
{
    public interface ITokenService
    {
        public Task<string> CreateTokenAsync(AppUser User, UserManager<AppUser> userManager);
    }
}
