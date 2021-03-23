using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Core.Utilities.Security.JWT
{
    public class TokenOptions
    {
        public string Audience { get; set; } //Tokenin kullanıcı kitlesi
        public string Issuer { get; set; } //imzalayan
        public int AccessTokenExpration { get; set; } //süre dk cinsinden
        public string SecurityKey { get; set; } //buda api projesindeki appsetting.json dosyasındaki bilgilerden geliyor
    }
}
