﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class user_tbl_model
    {
        public int userID { get; set; }
        public int deckID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string username { get; set; }
        public string userPhone { get; set; }
        public string userEmail { get; set; }
        public string userPassword { get; set; }


    }
}