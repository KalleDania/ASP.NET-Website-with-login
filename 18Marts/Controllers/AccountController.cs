using _18Marts.Entities;
using _18Marts.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _18Marts.CSClasses;

namespace _18Marts.Controllers
{
    public class AccountController : Controller
    {


        public AccountController()
        {

        }


        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            currentClearance = new Clearance { Name = "Guest", Password = "" };
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = "")
        {
            var model = new LoginViewModel { ReturnUrl = returnUrl };
            return View(model);
            //return RedirectToAction("Index");
        }


        private static Clearance[] clearances = new Clearance[4]
        {
            new Clearance { Name = "Admin", Password = "AdminPassword321" },
            new Clearance { Name = "Trusted", Password = "TrustedPassword321" },
            new Clearance { Name = "Cleared", Password = "ClearedPassword" },
            new Clearance { Name = "Guest", Password = "" },
        };

        public static Clearance currentClearance = new Clearance { Name = "Guest", Password = "" };

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid) return View(model);


            for (int i = 0; i < clearances.Length; i++)
            {
                if (model.Username == clearances[i].Name)
                {
                    if (model.Password == clearances[i].Password)
                    {
                        currentClearance = clearances[i];

                        if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                        {
                            return Redirect(model.ReturnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                }
            }

            return View(model);
        }



        public async Task<IActionResult> RequestAccess(ContactViewModel model)
        {
            if (model.InputAccessRequestMail != null && model.InputAccessRequestMail.Length > 0)
            {
                MailSender ms = new MailSender();
                ms.SendAccessUpgradeRequest(model.InputAccessRequestWho, model.InputAccessRequestMail);
            }

            return RedirectToAction("Contact", "Home");
        }

        public async Task<IActionResult> Feedback(ContactViewModel model)
        {
            if (model.InputFeedback != null && model.InputFeedback.Length > 0)
            {
                string senderIp = "Sender IP: " + Request.HttpContext.Connection.RemoteIpAddress.ToString();
                MailSender ms = new MailSender();
                ms.SendFeedback(senderIp + " " + model.InputFeedback);
            }

          return RedirectToAction("Contact", "Home");
        }
    }
}
