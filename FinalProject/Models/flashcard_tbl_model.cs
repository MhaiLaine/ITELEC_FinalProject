using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class flashcard_tbl_model
    {
        public int flashcardID { get; set; }
        public int deckID { get; set; }
        public string frontCard { get; set; }
        public string backCard { get; set; }
        public DateTime flashcardCreated { get; set; }
        public DateTime flashcardUpdated { get; set; }


    }
}