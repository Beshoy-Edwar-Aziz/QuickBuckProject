using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickBuck.Core.Models
{
    public class AppUser:IdentityUser
    {
        public Address Address { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }  
    }
}
