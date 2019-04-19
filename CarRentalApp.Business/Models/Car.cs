using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentalApp.Business.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Vendor { get; set; }
        public string Model { get; set; }
        public string Class { get; set; }
        public int ManufactureYear { get; set; }
        public string RegistrationNumber { get; set; }
        public Order Order { get; set; }
    }
}
