using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class RegistrationModel {
        // attributes to transfer data from controller.js to cs
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string userEmail { get; set; }
        public int userPhone { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

    }
}