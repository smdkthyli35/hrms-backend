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
    }
}
