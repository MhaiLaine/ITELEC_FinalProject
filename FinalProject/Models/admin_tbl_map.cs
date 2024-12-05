using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    //each table in the database should have separate maps
    public class admin_tbl_map : EntityTypeConfiguration<admin_tbl_model>
    {
        public admin_tbl_map()
        {
            HasKey(i => i.adminID);  //place primary key here (i.primarykeyname)
            ToTable("admin_tbl"); //name ng table sa database

        }
    }
}