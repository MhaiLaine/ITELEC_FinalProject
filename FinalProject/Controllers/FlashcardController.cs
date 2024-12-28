using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace FinalProject.Controllers
{
    public class FlashcardController : Controller
    {
        private readonly FinalProjectContext _context = new FinalProjectContext();

        // Save flashcards to the database
        [HttpPost]
        public JsonResult SaveFlashcards(List<flashcard_tbl_model> flashcards)
        {
            try
            {
                foreach (var flashcard in flashcards)
                {
                    // Check if the front or back character count exceeds the limit
                    if (flashcard.frontCard.Length > 350 || flashcard.backCard.Length > 350)
                    {
                        return Json(new { success = false, message = "One or more flashcards exceed the 350 character limit." });
                    }

                    if (flashcard.flashcardID == 0) // New Flashcard
                    {
                        flashcard.deckID = flashcard.deckID; // Assign deck ID
                        flashcard.flashcardCreated = DateTime.Now;
                        flashcard.flashcardUpdated = DateTime.Now;
                        _context.flashcard_tbl.Add(flashcard);
                    }
                    else // Existing Flashcard
                    {
                        var existingFlashcard = _context.flashcard_tbl.Find(flashcard.flashcardID);
                        if (existingFlashcard != null)
                        {
                            existingFlashcard.frontCard = flashcard.frontCard;
                            existingFlashcard.backCard = flashcard.backCard;
                            existingFlashcard.deckID = flashcard.deckID; // Update deck ID if changed
                            existingFlashcard.flashcardUpdated = DateTime.Now;
                        }
                    }
                }

                _context.SaveChanges();
                return Json(new { success = true, message = "Flashcards saved successfully!" });
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                return Json(new { success = false, message = "Error: " + ex.Message });
            }
        }

        //public ActionResult ManageFlashcards(int deckID)
        //{
        //    using (var db = new FinalProjectContext())
        //    {
        //        var flashcards = db.flashcard_tbl.Where(f => f.deckID == deckID).ToList();
        //        return View(flashcards); // Pass the flashcards to the view
        //    }
        //}

        public ActionResult ManageFlashcards(int deckID)
        {
            var flashcards = _context.flashcard_tbl.Where(f => f.deckID == deckID).ToList();
            return View(flashcards); // This will pass the flashcards to your view
        }

        public JsonResult DeleteFlashcard(int flashcardID)
        {
            try
            {
                var flashcard = _context.flashcard_tbl.Find(flashcardID);
                if (flashcard != null)
                {
                    _context.flashcard_tbl.Remove(flashcard);
                    _context.SaveChanges();
                    return Json(new { success = true });
                }
                else
                {
                    return Json(new { success = false, message = "Flashcard not found." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error: " + ex.Message });
            }
        }

        // Controller Example
        public ActionResult StudyFlashcards(int deckID)
        {
            var flashcards = _context.flashcard_tbl.Where(fc => fc.deckID == deckID).ToList();
            ViewBag.Flashcards = flashcards;  // Pass the flashcards to the view
            return View();
        }

        public JsonResult GetFlashcardsByDeck(int deckID)
        {
            try
            {
                var flashcards = _context.flashcard_tbl.Where(f => f.deckID == deckID).ToList();
                return Json(new { flashcards = flashcards }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        public JsonResult GetAllFlashcards()
        {
            var flashcards = _context.flashcard_tbl.Select(f => new
            {
                f.flashcardID,
                f.frontCard,
                f.backCard
            }).ToList();

            return Json(flashcards, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetFlashcard(int id)
        {
            var flashcard = _context.flashcard_tbl.FirstOrDefault(f => f.flashcardID == id);
            if (flashcard == null) return Json(null, JsonRequestBehavior.AllowGet);

            return Json(flashcard, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveFlashcard(flashcard_tbl_model flashcard)
        {
            if (flashcard.flashcardID == 0)
            {
                flashcard.flashcardCreated = DateTime.Now;
                flashcard.flashcardUpdated = DateTime.Now;
                _context.flashcard_tbl.Add(flashcard);
            }
            else
            {
                var existingFlashcard = _context.flashcard_tbl.FirstOrDefault(f => f.flashcardID == flashcard.flashcardID);
                if (existingFlashcard != null)
                {
                    existingFlashcard.frontCard = flashcard.frontCard;
                    existingFlashcard.backCard = flashcard.backCard;
                    existingFlashcard.flashcardUpdated = DateTime.Now;
                }
            }

            _context.SaveChanges();
            return Json(new { success = true });
        }

        [HttpDelete]
        public JsonResult DeleteFlashcards(int id)
        {
            var flashcard = _context.flashcard_tbl.FirstOrDefault(f => f.flashcardID == id);
            if (flashcard != null)
            {
                _context.flashcard_tbl.Remove(flashcard);
                _context.SaveChanges();
            }

            return Json(new { success = true });
        }
    }
}
