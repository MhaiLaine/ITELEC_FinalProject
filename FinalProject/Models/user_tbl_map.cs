using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    //each table in the database should have separate maps
    public class user_tbl_map : EntityTypeConfiguration<user_tbl_model>
    {
        public user_tbl_map()
        {
            HasKey(i => i.userID);  //place primary key here (i.primarykeyname)
            ToTable("user_tbl"); //name ng table sa database

        }
    }
}