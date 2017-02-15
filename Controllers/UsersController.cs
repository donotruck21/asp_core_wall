using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Wall.Factory;
using Wall.Models;

namespace Wall.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserFactory userFactory;

        public UsersController(UserFactory user){
            userFactory = user;
        }

        
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.Errors = new List<User>();
            return View();
        }


        // GET: /Wall/
        [HttpGet]
        [Route("Wall")]
        public IActionResult Wall()
        {
            // Get User by User Id
            ViewBag.CurrentUser = userFactory.FindByUserId((int)HttpContext.Session.GetInt32("CurrUserId"));
            return View();
        }


        // POST: /Register/
        [HttpPost]
        [Route("Register")]
        public IActionResult Register(User NewUser)
        {
            if(ModelState.IsValid){
                System.Console.WriteLine("ModelState is valid");

                // Add User
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                NewUser.Password = Hasher.HashPassword(NewUser, NewUser.Password);
                userFactory.AddUser(NewUser);
                // Get Added User
                User CurrentUser = userFactory.GetLastUser();
                HttpContext.Session.SetInt32("CurrUserId", CurrentUser.UserId);

                return RedirectToAction("Wall");
            } else {
                System.Console.WriteLine("ERRORS: Validations triggered");
                ViewBag.Errors = ModelState.Values;
                return View("Index");
            }
        }
    }
}
