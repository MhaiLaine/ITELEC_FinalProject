using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace FinalProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult MainMenu()
        {
            return View();
        }

        public ActionResult RegistrationPage()
        {
            return View();
        }

        public ActionResult LogInPage()
        {
            return View();
        }

        public ActionResult WelcomePage()
        {
            return View();
        }

        public ActionResult Dashboard1()
        {
            return View();
        }

        public ActionResult Dashboard2()
        {
            return View();
        }

        public ActionResult ManageFlashcardPage()
        {
            return View();
        } 
        
        public ActionResult StudyFlashcardsPage()
        {
            return View();
        }


    }
}