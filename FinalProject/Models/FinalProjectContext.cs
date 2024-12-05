using MySql.Data.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace FinalProject.Models
{
    //by default, visual studio reads sql, but here we need mysql so we need to declare the ff:
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class FinalProjectContext : DbContext
    //context = connection to database
    {
        static FinalProjectContext()
        {
            //in projects, all databases need to be SET
            Database.SetInitializer<FinalProjectContext>(null);
        }

        public FinalProjectContext() : base("Name-spellcardsdb") { } //insert name ng database
                                                                  //name-companydb here is 

        public virtual DbSet<admin_tbl_model> admin_tbl { get; set; }
        public virtual DbSet<deck_tbl_model> deck_tbl { get; set; }
        public virtual DbSet<flashcard_tbl_model> flashcard_tbl { get; set; }
        public virtual DbSet<user_tbl_model> user_tbl { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        { //override the function to cater sa created models natin
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new admin_tbl_map());
            modelBuilder.Configurations.Add(new deck_tbl_map());
            modelBuilder.Configurations.Add(new flashcard_tbl_map());
            modelBuilder.Configurations.Add(new user_tbl_map());
        }


    }
}