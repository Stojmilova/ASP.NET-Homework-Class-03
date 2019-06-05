﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SEDC.App.Models.DomainModels;

namespace SEDC.App.Controllers
{
 
    //[Route("Start/[Action]")]
    public class HomeController : Controller
    {

        //[Route("Begin")]
        public IActionResult Index()
        {
            return View();
        }
        //[HttpGet("CallMe")]
        public ViewResult Contact()
        {
            return View();
        }
        public ViewResult AboutUs()
        {
            return View();
        }
        public IActionResult Nothing()
        {
            return new EmptyResult();
        }
        public IActionResult BackToHome()
        {
            return RedirectToAction("Index");
        }
        public IActionResult JsonData()
        {
            object order = new { OrderId = 12, OrderName = "Zdrave" };
            return new JsonResult(order);
        }

        public IActionResult Promotion()
        {
            ViewBag.Header = "Today's Promotion";
            
            var pizza = new OrderController()._pizzas;
            return View(pizza);
        }            

    }
}