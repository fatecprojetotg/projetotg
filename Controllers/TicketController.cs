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

        public IActionResult GetTicketsUser(){
            return View();
        }
        public IActionResult GetTicketsSuport(){
            return View();
        }
        
        [HttpGet]
        public IActionResult CreateTicket(){
            return View();
        }

        [HttpPut]
        public IActionResult UpdateTicket(){
            return View();
        }

        [HttpDelete]
        public IActionResult DeleteTicket(){
            return View();
        }

        // [HttpPost]
        // public IActionResult CreateTicketUser(){
        //     return View();
        // }
        
        // [HttpPost]
        //  public IActionResult CreateTicketSuport(){
        //     return View();
        // }

    }
}