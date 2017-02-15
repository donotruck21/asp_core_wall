using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wall.Models;

namespace Wall.Controllers
{
    public class UsersController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            if(TempData["RegErrors"] != null){
                ViewBag.Errors = TempData["RegErrors"];
            }
            return View();
        }


        // GET: /Wall/
        [HttpGet]
        [Route("Wall")]
        public IActionResult Wall()
        {
            return View();
        }


        // POST: /Register/
        [HttpPost]
        [Route("Register")]
        public IActionResult Register(User NewUser)
        {
            if(ModelState.IsValid){
                System.Console.WriteLine("ModelState is valid");
                return RedirectToAction("Wall");
            } else {
                System.Console.WriteLine("ERRORS: Validations triggered");
                TempData["RegErrors"] = ModelState.Values;
                return RedirectToAction("Index");
            }
        }
    }
}
