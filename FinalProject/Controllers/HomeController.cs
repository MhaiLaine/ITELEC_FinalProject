using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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


        public void AddUser(FinalProjectModel registrationData)
        {
            using (var db = new FinalProjectContext())
            {
                var userData = new user_tbl_model()
                {
                    deckID = registrationData.deckID,
                    userID = registrationData.userID,
                    firstName = registrationData.firstName.ToString(),
                    lastName = registrationData.lastName.ToString(),
                    username = registrationData.username.ToString(),
                    userPhone = registrationData.userPhone,
                    userEmail = registrationData.userEmail.ToString(),
                    userPassword = registrationData.userPassword.ToString(),
                };

                db.user_tbl.Add(userData);
                db.SaveChanges();
            }
        }


        public void UpdateUser(FinalProjectModel registrationData)
        {
            using (var db = new FinalProjectContext())
            {
                var userID = db.user_tbl.Where(x => x.firstName.Equals(registrationData.firstName.ToString()) && x.lastName.Equals(registrationData.lastName.ToString())).FirstOrDefault();
                if (userID == null)
                {
                    AddUser(registrationData);
                }
                else
                {
                    userID.userUpdated= DateTime.Now;
                    db.user_tbl.AddOrUpdate(userID);
                    db.SaveChanges();
                }
            }
        }

        public JsonResult LoadUser()
        {
            using (var db = new FinalProjectContext())
            {
                var empData = (from uData in db.user_tbl
                               join dData in db.deck_tbl on uData.userID equals dData.deckID
                               join fData in db.flashcard_tbl on uData.userID equals fData.flashcardID
                               select new { uData, dData }).ToList();

                return Json(empData, JsonRequestBehavior.AllowGet);
            }
        }

    }
}