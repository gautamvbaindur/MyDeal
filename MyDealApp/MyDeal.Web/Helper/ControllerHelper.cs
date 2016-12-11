using MyDeal.Web.Cache;
using MyDeal.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyDeal.Web.Helper
{
    public class ControllerHelper
    {
        private static IList<Url> ListOfUrl
        {
            get { return CacheHandler.RetrieveFromCache(); }
        }

        public static Url GenerateShortUrl(string longUrl)
        {
            IList<Url> listofUrl = ListOfUrl;
            Url shortUrl = new Url()
            {
                LongUrl = longUrl,
            };
            var alreadyExistingUrl = listofUrl.Where(url => url.LongUrl.ToLower() == longUrl.ToLower()).FirstOrDefault<Url>();
            if (alreadyExistingUrl == null)
            {
                GenerateShortUrl(shortUrl);
                listofUrl.Add(shortUrl);
                CacheHandler.AddToCache(listofUrl);
                return shortUrl;
            }
            shortUrl = alreadyExistingUrl;
            return shortUrl;
        }

        public static Url GetLongUrl(string shortUrl)
        {
            IList<Url> listofUrl = ListOfUrl;
            return listofUrl.Where(item => item.ShortUrl.ToLower() == shortUrl.ToLower()).FirstOrDefault<Url>();
        }

        private static void GenerateShortUrl(Url url)
        {
            string number = "";
            int j;
            Random random = new Random();

            for (int i = 0; i < 6; i++)
            {
                j = random.Next(0, 35);
                if (j < 10)
                    j += 48;
                else
                    j += 87;
                number = number + char.ConvertFromUtf32(j);
            }
            url.ShortUrl = number;
        }
    }
}