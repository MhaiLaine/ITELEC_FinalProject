﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class usertbl_model
    {
        public int userID { get; set; }
        public int deckID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string username { get; set; }
        public int userPhone { get; set; }
        public string userEmail { get; set; }
        public string userPassword { get; set; }
        public DateTime userCreated { get; set; }
        public DateTime userUpdated { get; set; }


    }
}