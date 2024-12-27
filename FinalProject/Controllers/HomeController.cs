﻿using FinalProject.Models;
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

        public ActionResult ManageFlashcardPage(int deckID)
        {
            ViewBag.DeckID = deckID; // Pass deckID to the view
            return View();
        }

        public ActionResult StudyFlashcardsPage()
        {
            return View();
        }

        public ActionResult Admin()
        {
            return View();
        }

        public ActionResult AdminUserAcc()
        {
            return View();
        }

        public ActionResult AdminDecks()
        {
            return View();
        }

        public ActionResult AdminFlashcards()
        {
            return View();
        }


        // USERS CRUD
        public JsonResult AddUser(UserController registrationData)
        {
            using (var db = new FinalProjectContext())
            {
                var userData = new user_tbl_model
                {
                    firstName = registrationData.firstName,
                    lastName = registrationData.lastName,
                    username = registrationData.username,
                    userPhone = registrationData.userPhone,
                    userEmail = registrationData.userEmail,
                    userPassword = registrationData.userPassword
                };

                db.user_tbl.Add(userData);
                db.SaveChanges();

                return Json(new { success = true });
            }
        }


        public JsonResult LoginUser(UserController loginData)
        {
            using (var db = new FinalProjectContext())
            {
                var user = db.user_tbl
                    .Where(u => (u.username == loginData.username && u.userPassword == loginData.userPassword))
                    .FirstOrDefault();

                if (user != null)
                {
                    Session["username"] = user.username;
                    return Json(new { success = true, firstName = user.firstName });
                }
                else
                {
                    return Json(new { success = false, message = "Invalid username or password." });
                }
            }
        }


        public void UpdateUser(UserController registrationData)
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
                    //userID.userUpdated= DateTime.Now;
                    db.user_tbl.AddOrUpdate(userID);
                    db.SaveChanges();
                }
            }
        }

        public ActionResult loadUsers()
        {
            using (var db = new FinalProjectContext())
            {
                var userData = db.user_tbl
                    .Select(u => new
                    {
                        u.userID,
                        u.deckID,
                        u.firstName,
                        u.lastName,
                        u.username,
                        u.userPhone,
                        u.userEmail,
                        u.userCreated,
                        u.userUpdated
                    }).ToList();

                return Json(userData, JsonRequestBehavior.AllowGet);
            }
        }



        //public ActionResult Login(user_tbl_model model)
        //{
        //    using (var db = new FinalProjectContext()) // Ensure db is declared and initialized
        //    {
        //        var user = db.user_tbl.FirstOrDefault(u => u.username == model.username && u.userPassword == model.userPassword);
        //        if (user != null)
        //        {
        //            return Json(new { success = true });
        //        }
        //        else
        //        {
        //            return Json(new { success = false });
        //        }
        //    }
        //}



        // DECK CRUD
        public JsonResult AddDeck(DeckController newDeck)
        {
            using (var db = new FinalProjectContext())
            {
                if (string.IsNullOrWhiteSpace(newDeck.deckName))
                {
                    return Json(new { success = false, message = "Deck name cannot be empty." });
                }

                var deckData = new deck_tbl_model
                {
                    deckName = newDeck.deckName,
                    //CreatedAt = DateTime.Now // Add a timestamp if needed
                };

                db.deck_tbl.Add(deckData);
                db.SaveChanges();

                return Json(new { success = true });
            }
        }


        public JsonResult loadDecks()
        {
            using (var db = new FinalProjectContext())
            {
                var decks = db.deck_tbl.Select(d => new
                {
                    d.deckName                
                }).ToList();
                return Json(decks, JsonRequestBehavior.AllowGet);
            }
        }


        //FLASHCARDS
        //public JsonResult SaveFlashcard(FlashcardController flashcard)
        //{
        //    using (var db = new FinalProjectContext())
        //    {
        //        var flashcard = new flashcard_tbl_model
        //        {
        //            frontCard = flashcard.frontCard,
        //            backCard = flashcard.backText,
        //            deckID = flashcard.deckID
        //        };

        //        db.flashcard_tbl.Add(flashcard);
        //        db.SaveChanges();

        //        return Json(new { success = true });
        //    }
        //}


        public JsonResult LoadFlashcards(int deckID)
        {
            using (var db = new FinalProjectContext())
            {
                var flashcards = db.flashcard_tbl
                    .Where(fc => fc.deckID == deckID)
                    .Select(fc => new { fc.flashcardID, fc.frontCard, fc.backCard })
                    .ToList();

                return Json(flashcards, JsonRequestBehavior.AllowGet);
            }
        }


        //UserUpdate
        [HttpPost]
        public JsonResult updateUser(user_tbl_model userData)
        {
            try
            {
                using (var db = new FinalProjectContext())
                {

                    var currentUsername = Session["username"]?.ToString();
                    var user = db.user_tbl.FirstOrDefault(u => u.username == currentUsername);

                    if (user != null)
                    {
                        user.userID = userData.userID;
                        user.deckID = userData.deckID;
                        user.firstName = userData.firstName;
                        user.lastName = userData.lastName;
                        user.username = userData.username;
                        user.userPhone = userData.userPhone;
                        user.userEmail = userData.userEmail;
                        user.userCreated = DateTime.Now;
                        user.userUpdated = DateTime.Now;
                        db.SaveChanges();
                        return Json(new { Success = true });
                    }
                    return Json(new { Success = false, Message = "User not found" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message });
            }
        }

        //UserDelete
        public JsonResult deleteUser(int userID)
        {
            try
            {
                using (var db = new FinalProjectContext())
                {
                    var user = db.user_tbl.FirstOrDefault(u => u.userID == userID);

                    if (user != null)
                    {
                        db.user_tbl.Remove(user);
                        db.SaveChanges();
                        return Json(new { Success = true });
                    }

                    return Json(new { Success = false, Message = "User not found" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Message = ex.Message });
            }
        }


        /* CHART/S */

        //public JsonResult LoadPieChartData()
        //{
        //    using (var db = new FinalProjectContext())
        //    {
        //        var getUser = db.user_tbl.Select(x => x).ToList();
        //        List<int> userCount = new List<int>();
        //        foreach (var item in getUser)
        //        {
        //            var uCount = db.user_tbl.Where(x => x.userID == item.userID)
        //                userCount.Add(uCount);
        //        }

        //        var pieData = new
        //        {
        //            Series = getUser.Select(x => x.username)
        //        };
        //    }
        //}



    }
}