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




    }
}