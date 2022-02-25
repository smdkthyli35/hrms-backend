using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static class City
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiçbir şehir bulunamadı.";
                return "Böyle bir şehir bulunamadı.";
            }

            public static string Add(string cityName)
            {
                return $"{cityName} adlı şehir başarıyla eklendi.";
            }

            public static string Delete(string cityName)
            {
                return $"{cityName} adlı şehir başarıyla silindi.";
            }

            public static string Update(string cityName)
            {
                return $"{cityName} adlı şehir başarıyla güncellendi.";
            }

            public static string HardDelete(string cityName)
            {
                return $"{cityName} adlı şehir başarıyla veritabanından silinmiştir.";
            }
        }

        public static class CompanyStaff
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiçbir şirket personel bulunamadı.";
                return "Böyle bir şirket personeli bulunamadı.";
            }

            public static string Add(string firstName, string lastName)
            {
                return $"{firstName} {lastName} adlı şirket personeli başarıyla eklendi.";
            }

            public static string Delete(string firstName, string lastName)
            {
                return $"{firstName} {lastName} adlı şirket personeli başarıyla silindi.";
            }

            public static string Update(string firstName, string lastName)
            {
                return $"{firstName} {lastName} adlı şirket personeli başarıyla güncellendi.";
            }

            public static string HardDelete(string firstName, string lastName)
            {
                return $"{firstName} {lastName} adlı şirket personeli başarıyla veritabanından silindi.";
            }
        }

        public static class Employer
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiçbir işveren bulunamadı.";
                return "Böyle bir işveren bulunamadı.";
            }

            public static string Add(string firstName, string lastName)
            {
                return $"{firstName} {lastName} adlı işveren başarıyla eklendi.";
            }

            public static string Delete(string firstName, string lastName)
            {
                return $"{firstName} {lastName} adlı işveren başarıyla silindi.";
            }

            public static string Update(string firstName, string lastName)
            {
                return $"{firstName} {lastName} adlı işveren başarıyla güncellendi.";
            }

            public static string HardDelete(string firstName, string lastName)
            {
                return $"{firstName} {lastName} adlı işveren başarıyla veritabanından silindi.";
            }
        }
    }
}
