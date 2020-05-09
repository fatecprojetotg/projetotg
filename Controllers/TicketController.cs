using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using projetotg.Models;

namespace projetotg.Controllers{
    public class TicketController : Controller{
        private readonly ILogger<HomeController> _logger;

        public TicketController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult CreateTicketUser(){
            return View();
        }
         public IActionResult CreateTicketSuport(){
            return View();
        }
         public IActionResult (){
            return View();
        }
         public IActionResult CreateUser(){
            return View();
        }
         public IActionResult CreateUser(){
            return View();
        }
        

    }
}