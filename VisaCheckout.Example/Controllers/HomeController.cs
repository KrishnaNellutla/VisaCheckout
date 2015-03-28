﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VisaCheckout.Example.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Visa Checkout example.";

            return View();
        }

        [HttpPost]
        public ActionResult Success(string response)
        {
            ViewBag.Message = "Visa Checkout - Success result.";

            return View();
        }

        [HttpPost]
        public ActionResult Cancel(string response)
        {
            ViewBag.Message = "Visa Checkout - Cancel result.";

            dynamic result = JsonConvert.DeserializeObject(response);
            ViewBag.Result = JsonConvert.SerializeObject(result, Formatting.Indented);

            return View();
        }

        [HttpPost]
        public ActionResult Error(string response)
        {
            ViewBag.Message = "Visa Checkout - Error result.";

            dynamic result = JsonConvert.DeserializeObject(response);
            ViewBag.Result = JsonConvert.SerializeObject(result, Formatting.Indented);

            return View();
        }
    }
}
