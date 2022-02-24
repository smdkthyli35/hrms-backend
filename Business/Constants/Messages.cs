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
            public static string Add(string cityName)
            {
                return $"{cityName} adlı şehir başarıyla eklenmiştir.";
            }
        }
    }
}
