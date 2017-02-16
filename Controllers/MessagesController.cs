using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Wall.Factory;
using Wall.Models;

namespace Wall.Controllers{
    public class MessagesController : Controller{
        private readonly MessageFactory messageFactory;

        public MessagesController(MessageFactory message){
            messageFactory = message;
        }


        // Post: /CreateMessage/
        [HttpPost]
        [Route("CreateMessage")]
        public IActionResult CreateMessage(string MContent)
        {
            System.Console.WriteLine(MContent);
            System.Console.WriteLine(HttpContext.Session.GetInt32("CurrUserId"));
            messageFactory.AddMessage(MContent, (int)HttpContext.Session.GetInt32("CurrUserId"));
            return RedirectToAction("Wall", "Users");
        }




    }
}