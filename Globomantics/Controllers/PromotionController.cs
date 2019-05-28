﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Globomantics.Controllers
{
    public class PromotionController : Controller
    {
        [HttpGet]
        [Route("promotion/{token}")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("promotion")]
        public IActionResult Submit(int id)
        {
            // TODO: Sweepstakes entry logic
            return View();
        }
    }
}