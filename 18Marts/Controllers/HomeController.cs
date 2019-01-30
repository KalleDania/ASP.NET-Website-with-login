using _18Marts.CSClasses;
using _18Marts.Entities;
using _18Marts.Services;
using _18Marts.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _18Marts.Controllers
{

    public class HomeController : Controller
    {

        public HomeController()
        {
        }


        public ViewResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        // Navbar stuff herunder.

        [AllowAnonymous]
        public IActionResult Home()
        {
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult MyWork()
        {
            if (AccountController.currentClearance.Name != "Guest")
            {
                return View();
            }
            else
            {
                AccountController.tryingToAccesRestrictedPage = "MyWork";
                return RedirectToAction("Login", "Account");
            }
        }

        public IActionResult Grades()
        {
            if (AccountController.currentClearance.Name != "Guest")
            {
                return View();
            }
            else
            {
                AccountController.tryingToAccesRestrictedPage = "Grades";
                return RedirectToAction("Login", "Account");
            }
        }
    }
}
