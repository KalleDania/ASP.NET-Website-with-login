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
    [Authorize]  // login
    public class HomeController : Controller
    {
        // Der eksisterer åbenbart en naming convention der gør at mine metoder med params ikke virker hvis jeg kalder variablerne med _ først som jeg plejer. (deres param bliver sat til null)
        private IVideoData videos;

        public HomeController(IVideoData videos)
        {
            this.videos = videos;
        }

        [AllowAnonymous]  // login
        public ViewResult Index()
        {
            return View();
        }

        public IActionResult Details(int id)
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
            return View();
        }

        public IActionResult Skills()
        {
            return View();
        }

        public IActionResult MyWork()
        {
            return View();
        }

        public IActionResult Grades()
        {
            return View();
        }

        public IActionResult Future()
        {
            return View();
        }

        public IActionResult Private()
        {
            if (AccountController.SignedInUser == "Admin")
            {
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
