﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Controllers
{
    public class DeckController
    {
        public int deckID {  get; set; }
        public int flashcardID { get; set; }
        public string deckName { get; set; }

        public DateTime deckCreated { get; set; }
        public DateTime deckUpdated { get; set; }

    }
}