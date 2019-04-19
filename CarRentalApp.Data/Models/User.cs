using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentalApp.Data.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public DateTime BirthDate { get; set; }
        public string LicenseNumber { get; set; }
        public Order Order { get; set; }
    }
}
