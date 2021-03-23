using CarRental.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Entities.DTOs
{
    public class UserForRegisterDto:IDto
    {
        public string Email { get; set; }
        public string Password { get; set; } // burda kulalnııcdan textboxdan veri okuyacağımız için string tutuyoruz. Sornasında Salt ve hashleyip kullancağız
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
