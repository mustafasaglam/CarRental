using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Core.Utilities.Security.JWT
{
    public class AccessToken
    {
        public string Token { get; set; } //token in kenfdiis
        public DateTime Expiration { get; set; } //Tokenin ne zmaana kadar geçerli olacağı

        // ek olarak başka alanlarda girilebilir mesela tokenin yeniden uzatılma süresi
    }
}
