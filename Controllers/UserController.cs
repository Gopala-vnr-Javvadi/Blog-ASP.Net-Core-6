using Azure.Core;
using Blog_ASP.Net_Core_6.Data;
using Blog_ASP.Net_Core_6.Models;
using Blog_ASP.Net_Core_6.Services.Interface;
using Blog_ASP.Net_Core_6.Services.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Security.Claims;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Blog_ASP.Net_Core_6.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserRepository _userRepository;

        private readonly IWebHostEnvironment _environment;

     
        public UserController(IWebHostEnvironment environment, IUserRepository userRepository)
        {
            _environment = environment;
            _userRepository = userRepository;
        }

        

        [HttpPost("CreateNewUser")]
       // [Authorize(Roles = "User")]
        public async Task<IActionResult> CreateUser(IFormFile file, [FromForm] UserModel objNewUser)
        {
            var pathNameOnly = string.Empty;
            if (file != null)
            {



                // Process the file and otherData here as needed
                // For example, save the file to a database or storage, etc.

                // Save the uploaded file to the "uploads" folder
                var uploadsPath = Path.Combine(_environment.ContentRootPath, "Images\\Profile");
                if (!Directory.Exists(uploadsPath))
                {
                    Directory.CreateDirectory(uploadsPath);
                }
                string filenameOnly = Path.GetFileNameWithoutExtension(file.FileName);
                string extension = Path.GetExtension(file.FileName);
                string dateTime = DateTime.UtcNow.ToLocalTime().ToString("ddMMyyyyHHmmss");

                var fileName = Path.Combine(uploadsPath, filenameOnly + dateTime + extension);
                using (var stream = new FileStream(fileName, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                pathNameOnly = "https://localhost:7086/" + "Images/Profile/" + filenameOnly + dateTime + extension;
            }
            if (objNewUser != null)
            {
                objNewUser.ImageUrl = pathNameOnly;
                _userRepository.CreateNewUser(objNewUser);
            }

             return Ok( $"User { objNewUser.Username}, is Created");
            

        }


        [HttpPost("UpdateUser")]
        // [Authorize(Roles = "User")]
        public async Task<IActionResult> UpdateUser(IFormFile file, [FromForm] UserModel objNewUser)
        {
            var pathNameOnly = "";
            if (file != null )
            {
             
           

            // Process the file and otherData here as needed
            // For example, save the file to a database or storage, etc.

            // Save the uploaded file to the "uploads" folder
            var uploadsPath = Path.Combine(_environment.ContentRootPath, "Images\\Profile");
            if (!Directory.Exists(uploadsPath))
            {
                Directory.CreateDirectory(uploadsPath);
            }
            string filenameOnly = Path.GetFileNameWithoutExtension(file.FileName);
            string extension = Path.GetExtension(file.FileName);
            string dateTime = DateTime.UtcNow.ToLocalTime().ToString("ddMMyyyyHHmmss");

            var fileName = Path.Combine(uploadsPath, filenameOnly + dateTime + extension);
            using (var stream = new FileStream(fileName, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

             pathNameOnly = "https://localhost:7086/" + "Images/Profile/" + filenameOnly + dateTime + extension;
            }
            if (objNewUser != null)
            {
                objNewUser.ImageUrl = pathNameOnly;
                _userRepository.UpdateUser(objNewUser);
               
            }
            return Ok($"User {objNewUser.Username}, is Updated");


        }


        //[HttpGet("Admins")]
        //[Authorize(Roles = "Administrator")]
        //public IActionResult AdminsEndpoint()
        //{
        //    var currentUser = GetCurrentUser();

        //    return Ok($"Hi {currentUser.Username}, you are an {currentUser.Role}");
        //}


        //[HttpGet("Sellers")]
        //[Authorize(Roles = "Seller")]
        //public IActionResult SellersEndpoint()
        //{
        //    var currentUser = GetCurrentUser();

        //    return Ok($"Hi {currentUser.Username}, you are a {currentUser.Role}");
        //}

        //[HttpGet("AdminsAndSellers")]
        //[Authorize(Roles = "Administrator,Seller")]
        //public IActionResult AdminsAndSellersEndpoint()
        //{
        //    var currentUser = GetCurrentUser();

        //    return Ok($"Hi {currentUser.Username}, you are an {currentUser.Role}");
        //}

        //[HttpGet("Public")]
        //public IActionResult Public()
        //{
        //    return Ok("Hi, you're on public property");
        //}

        private UserModel GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity != null)
            {
                var userClaims = identity.Claims;

                return new UserModel
                {
                    Username = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value,
                    EmailAddress = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Email)?.Value,
                    Surname = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Surname)?.Value,               
                    Role = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Role)?.Value
                };
            }
            return null;
        }


    }
}
