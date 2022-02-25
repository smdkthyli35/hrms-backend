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

        public static class JobAdvert
        {
            public static string jobAdvertAdded = "İş ilanı başarıyla eklendi.";
            public static string jobAdvertDeleted = "İş ilanı başarıyla silindi.";
            public static string jobAdvertHardDeleted = "İş ilanı başarıyla veritabanından silindi.";
            public static string jobAdvertUpdated = "İş ilanı başarıyla güncellendi.";

            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiçbir iş ilanı bulunamadı";
                return "Böyle bir iş ilanı bulunamadı.";
            }
        }

        public static class JobPosition
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiçbir iş poziyonu bulunamadı.";
                return "Böyle bir iş poziyonu bulunamadı.";
            }

            public static string Add(string jobPositionTitle)
            {
                return $"{jobPositionTitle} adlı iş pozisyonu başarıyla eklendi.";
            }

            public static string Update(string jobPositionTitle)
            {
                return $"{jobPositionTitle} adlı iş pozisyonu başarıyla güncellendi.";
            }

            public static string Delete(string jobPositionTitle)
            {
                return $"{jobPositionTitle} adlı iş pozisyonu başarıyla silindi.";
            }

            public static string HardDelete(string jobPositionTitle)
            {
                return $"{jobPositionTitle} adlı iş pozisyonu başarıyla veritabanından silindi.";
            }
        }

        public static class JobSeeker
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiçbir iş arayan bulunamadı.";
                return "Böyle bir iş arayan bulunamadı.";
            }

            public static string Add(string firstName, string lastName)
            {
                return $"{firstName} {lastName} adlı iş arayan başarıyla eklendi.";
            }

            public static string Delete(string firstName, string lastName)
            {
                return $"{firstName} {lastName} adlı iş arayan başarıyla silindi.";
            }

            public static string Update(string firstName, string lastName)
            {
                return $"{firstName} {lastName} adlı iş arayan başarıyla güncellendi.";
            }

            public static string HardDelete(string firstName, string lastName)
            {
                return $"{firstName} {lastName} adlı iş arayan başarıyla veritabanından silindi.";
            }
        }

        public static class JobSeekerCv
        {
            public static string jobSeekerCvAdded = "İş arayan cv'si başarıyla eklendi.";
            public static string jobSeekerCvDeleted = "İş arayan cv'si başarıyla silindi.";
            public static string jobSeekerCvHardDeleted = "İş arayan cv'si başarıyla veritabanından silindi.";
            public static string jobSeekerCvUpdated = "İş arayan cv'si başarıyla güncellendi.";

            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiçbir iş arayan cv'si bulunamadı";
                return "Böyle bir iş arayan cv'si bulunamadı.";
            }
        }

        public static class JobSeekerCvEducation
        {
            public static string jobSeekerCvEducationAdded = "İş arayan cv eğitim bilgileri başarıyla eklendi.";
            public static string jobSeekerCvEducationDeleted = "İş arayan cv eğitim bilgileri başarıyla silindi.";
            public static string jobSeekerCvEducationHardDeleted = "İş arayan cv eğitim bilgileri başarıyla veritabanından silindi.";
            public static string jobSeekerCvEducationUpdated = "İş arayan cv eğitim bilgileri başarıyla güncellendi.";

            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiçbir iş arayan cv eğitim bilgisi bulunamadı";
                return "Böyle bir iş arayan cv eğitim bilgisi bulunamadı.";
            }
        }

        public static class JobSeekerCvExperience
        {
            public static string jobSeekerCvExperienceAdded = "İş arayan cv deneyim bilgileri başarıyla eklendi.";
            public static string jobSeekerCvExperienceDeleted = "İş arayan cv deneyim bilgileri başarıyla silindi.";
            public static string jobSeekerCvExperienceHardDeleted = "İş arayan cv deneyim bilgileri başarıyla veritabanından silindi.";
            public static string jobSeekerCvExperienceUpdated = "İş arayan cv deneyim bilgileri başarıyla güncellendi.";

            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiçbir iş arayan cv deneyim bilgisi bulunamadı";
                return "Böyle bir iş arayan cv deneyim bilgisi bulunamadı.";
            }
        }

        public static class JobSeekerCvImage
        {
            public static string jobSeekerCvImageAdded = "İş arayan cv resmi başarıyla eklendi.";
            public static string jobSeekerCvImageDeleted = "İş arayan cv resmi başarıyla silindi.";
            public static string jobSeekerCvImageHardDeleted = "İş arayan cv resmi başarıyla veritabanından silindi.";
            public static string jobSeekerCvImageUpdated = "İş arayan cv resmi başarıyla güncellendi.";

            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiçbir iş arayan cv resim bilgisi bulunamadı";
                return "Böyle bir iş arayan cv resim bilgisi bulunamadı.";
            }
        }
    }
}
