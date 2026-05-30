using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreetChildrenCareSystem.Models
{
    // Base Class — Abstraction
    public abstract class User
    {
        public string UserID { get; set; }
        public string Password { get; set; }
        public string UserRole { get; set; }

        // Abstract method —
        // Polymorphism 
        public abstract string GetRole();
    }

    // Admin Class — Inheritance
    public class Admin : User
    {
        public override string GetRole()
        {
            return "Admin";
        }

        // Admin specific permission
        public bool CanDelete()
        {
            return true;
        }
    }

    // Staff Class - Inheritance
    public class Staff : User
    {
        public override string GetRole()
        {
            return "Staff";
        }

        // Staff specific permission
        public bool CanDelete()
        {
            return false;
        }
    }
}
