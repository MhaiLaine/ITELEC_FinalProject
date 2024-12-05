using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class admin_tbl_model
    {
        public int adminID { get; set; }
        public int userID { get; set; }
        public int deckID { get; set; }
        public int flashcardID { get; set; }
        public string adminEmail { get; set; }
        public string adminPassword { get; set; }


    }
}