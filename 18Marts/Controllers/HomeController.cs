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
        // Der eksisterer åbenbart en naming convention der gør at mine metoder med params ikke virker hvis jeg kalder variablerne med _ først som jeg plejer. (deres param bliver sat til null)
        private IVideoData videos;

        public HomeController(IVideoData videos)
        {
            this.videos = videos;
        }


        public ViewResult Index()
        {
            return View();
        }

        public IActionResult Details(int id) // Uuuhuuuuuh baby!dfgasdk
        {
            var model = videos.Get(id);

            if (model == null) return RedirectToAction("Index");

            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(VideoEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var video = new Video
                {
                    Title = model.Title,
                    Genre = model.Genre
                };

                videos.Add(video);
                videos.Commit();

                return RedirectToAction("Details", new { id = video.Id });
            }

            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var video = videos.Get(id);

            if (video == null) return RedirectToAction("Index");

            return View(video);
        }

        [HttpPost]
        public IActionResult Edit(int id, VideoEditViewModel model)
        {
            var video = videos.Get(id);

            if (video == null || !ModelState.IsValid) return View(model);

            video.Title = model.Title;
            video.Genre = model.Genre;

            videos.Commit();

            return RedirectToAction("Details", new { id = video.Id });
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


        public IActionResult CV()
        {
            if (AccountController.currentClearance.Name != "Guest")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public IActionResult Skills()
        {
            if (AccountController.currentClearance.Name != "Guest")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public IActionResult MyWork()
        {
            if (AccountController.currentClearance.Name != "Guest")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
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
                return RedirectToAction("Index");
            }
        }

        public IActionResult Future()
        {
            if (AccountController.currentClearance.Name != "Guest")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public IActionResult Private()
        {
            if (AccountController.currentClearance.Name == "Admin")
            {

                ViewBag.DropDown = PrivateViewModel.Instance.dropDownItemList;

                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }







        //public HomeViewModel()
        //{
        //    //Thread t = new Thread(ImageCarouselLoop); husk og sluk tråden igen
        //}

        public ActionResult carousel() // bruges denne overhovedet? brug @functions til et eller andet
        {
            //while (true)
            //{
            //    foreach (var item in HomeViewModel.FileList)
            //    {
            //        if (item.FileName.Contains("private"))
            //        {
            //            UpdateImageCarousel("@item.FileName", "@item.AzureUrl");
            //            Thread.Sleep(10000);
            //        }
            //    }

            //}

            return View(); /*SerializableAttribute den der csharp corner carousel guide*/
        }
    }
}
