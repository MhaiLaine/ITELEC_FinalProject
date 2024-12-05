using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    //each table in the database should have separate maps
    public class deck_tbl_map : EntityTypeConfiguration<deck_tbl_model>
    {
        public deck_tbl_map()
        {
            HasKey(i => i.deckID);  //place primary key here (i.primarykeyname)
            ToTable("deck_tbl"); //name ng table sa database

        }
    }
}