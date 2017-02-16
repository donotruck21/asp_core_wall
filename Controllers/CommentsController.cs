using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Wall.Factory;
using Wall.Models;

namespace Wall.Controllers{
    public class CommentsController : Controller{
        private readonly CommentFactory commentFactory;

        public CommentsController(CommentFactory comment){
            commentFactory = comment;
        }


        // Post: /CreateComment/
        [HttpPost]
        [Route("CreateComment")]
        public IActionResult CreateComment(string CContent, int MessageId)
        {
            System.Console.WriteLine(CContent);
            System.Console.WriteLine(MessageId);
            System.Console.WriteLine(HttpContext.Session.GetInt32("CurrUserId"));
            commentFactory.AddComment(CContent, MessageId, (int)HttpContext.Session.GetInt32("CurrUserId"));
            return RedirectToAction("Wall", "Users");
        }








    }
}