using CarRental.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Business.Constants
{
    public static class Messages
    {
        public static string Added = "Kayıt eklendi";
        public static string Updated = "Kayıt güncellendi";
        public static string Deleted = "Kayıt silindi";
        public static string NotAdded = "Kayıt yapılamadı";
        public static string Listed = "Kayıtlar Listelendi";
        public static string MaintenanceTime = "Bakım zamanı / Ürünler getirilmedi :)";
        public static string CapacityFulled = "5 adet resim seçilebilir";

        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Giriş başarılıdır";
        public static string UserAllreadyExists= "Bu kullanıcı zaten mevcut";
        public static string UserRegistered="Kullanıcı başarı ile kaydedildi";
        public static string AccesTokenCreated="AccessToken Oluşturuldu";
    }
}
