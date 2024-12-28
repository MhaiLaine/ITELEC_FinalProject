using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    //each table in the database should have separate maps
    public class flashcard_tbl_map : EntityTypeConfiguration<flashcard_tbl_model>
    {
        public flashcard_tbl_map()
        {
            HasKey(i => i.flashcardID);  //place primary key here (i.primarykeyname)
            ToTable("flashcard_tbl"); //name ng table sa database

        }
    }
}
