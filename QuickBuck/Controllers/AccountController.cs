using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QuickBuck.Core.Models;
using QuickBuck.Core.Repositories;
using QuickBuck.DTOs;
using QuickBuck.Errors;
using QuickBuck.Helpers;
using System.Data;
using System.Text;
using System.Text.Json;

namespace QuickBuck.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IGenericRepository<JobSeeker> _jobSeekerRepo;
        private readonly IGenericRepository<Wallet> _walletRepo;
        private readonly IGenericRepository<JobProvider> _jobProviderRepo;
        private readonly ITokenService _tokenService;

        public AccountController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<AppUser> signInManager, IGenericRepository<JobSeeker> jobSeekerRepo, IGenericRepository<Wallet> walletRepo, IGenericRepository<JobProvider> jobProvider, ITokenService tokenService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _jobSeekerRepo = jobSeekerRepo;
            _walletRepo = walletRepo;
            _jobProviderRepo = jobProvider;
            _tokenService = tokenService;
        }
        [HttpPost("Register")]
        public async Task<ActionResult<UserDTO>> Register(RegisterDTO Model)
        {
            var EmailExist = await _userManager.FindByEmailAsync(Model.Email);

            if (Model is not null&&EmailExist is null)
            {
                var User = new AppUser()
                {
                    Email = Model.Email,
                    FirstName = Model.FirstName,
                    LastName = Model.LastName,
                    UserName = Model.Email.Split("@")[0],
                    PhoneNumber = Model.Phone,
                    Address = Model.Address
                };
                
                if (Model.Role == "JobProvider")
                {
                    var Role = new IdentityRole()
                    {
                        Name = Model.Role
                    };
                    if (!_roleManager.Roles.Contains(Role))
                    {
                        await _roleManager.CreateAsync(Role);
                    }
                    await _userManager.CreateAsync(User,Model.Password);
                    var x = Model.JobProvider.Logo.Split(',')[1];
                    var Photo = Convert.FromBase64String(x);
                    var result = DocumentSettings.UploadFile(Photo,"image","photos");
                    var JobProvider=new JobProvider()
                    {
                        CompanyName= Model.JobProvider.CompanyName,
                        Category = Model.JobProvider.Category,
                        Location = Model.JobProvider.Location,
                        CompanySize = Model.JobProvider.CompanySize,
                        Description = Model.JobProvider.Description,
                        WebSite = Model.JobProvider.WebSite,
                        Logo = result,
                        NoOfEmployees = Model.JobProvider.NoOfEmployees,
                        AppUser = User
                    };
                    await _jobProviderRepo.Add(JobProvider);
                    await _userManager.AddToRoleAsync(User, Model.Role);
                    return Ok(new UserDTO()
                    {
                        Email = Model.Email,
                        DisplayName = string.Concat(Model.FirstName,Model.LastName),
                        Role = Model.Role,
                        Token = await _tokenService.CreateTokenAsync(User,_userManager)
                    });;
                }
                else if (Model.Role=="JobSeeker")
                {
                   var Role= new IdentityRole()
                    {
                        Name = Model.Role
                    };
                    if (!_roleManager.Roles.Contains(Role))
                    {
                        await _roleManager.CreateAsync(Role);
                    }

                    await _userManager.CreateAsync(User, Model.Password);
                    var Wallet = new Wallet()
                    {
                        Balance = 0
                    };
                   var x= Model.JobSeeker.Photo.Split(',')[1];
                    var Photo = Convert.FromBase64String(x);
                    var result=DocumentSettings.UploadFile(Photo,"image","photos");
                    var JobSeeker = new JobSeeker()
                    {
                        BirthDate = Model.JobSeeker.BirthDate,
                        College = Model.JobSeeker.College,
                        CurrentYear = Model.JobSeeker.CurrentYear,
                        Photo = result,
                        Skills = Model.JobSeeker.Skills,
                        Status = Model.JobSeeker.Status,
                        University = Model.JobSeeker.University,
                        Wallet = Wallet,
                        AppUser = User
                    };
                    await _walletRepo.Add(Wallet);
                     await _jobSeekerRepo.Add(JobSeeker);
                    await _userManager.AddToRoleAsync(User, Model.Role);
                    return Ok(new UserDTO()
                    {
                        Email = Model.Email,
                        DisplayName = string.Concat(Model.FirstName, Model.LastName),
                        Role = Model.Role,
                        Token = await _tokenService.CreateTokenAsync(User, _userManager)
                    });
                   
                }
                return BadRequest(new ApiResponse(400));
            }
            else
            {
                return BadRequest(new ApiResponse(400));
            }
        }
        [HttpPost("Login")]
        public async Task<ActionResult<UserDTO>> Login(LoginDTO Model)
        {
            if (Model is not null)
            {
                var User=await _userManager.FindByEmailAsync(Model.Email);
                
                
                var Role = await _userManager.GetRolesAsync(User);
                var Auth=await _signInManager.CheckPasswordSignInAsync(User,Model.Password,false);
                if (Auth.Succeeded)
                {
                    return Ok(new UserDTO()
                    {
                        DisplayName = string.Concat(User.FirstName,User.LastName),
                        Email = Model.Email,
                        Role = Role[0],
                        Token = await _tokenService.CreateTokenAsync(User,_userManager)
                    });
                }
                else
                {
                    return Unauthorized(new ApiResponse(401));
                }
            }
            else
            {
                return Unauthorized(new ApiResponse(401));
            }
        }
    }
}
