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




    }
}
