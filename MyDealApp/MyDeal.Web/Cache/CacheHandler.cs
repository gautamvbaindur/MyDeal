using MyDeal.Web.Models;
using System;
using System.Collections.Generic;
using System.Runtime.Caching;

namespace MyDeal.Web.Cache
{
    public static class CacheHandler
    {
        private const string cacheKey = "URL_CACHE";

        public static IList<Url> RetrieveFromCache()
        {
            if (MemoryCache.Default.Get(cacheKey) == null)
            {
                AddToCache(new List<Url>());
            }
            return MemoryCache.Default.Get(cacheKey) as List<Url>;
        }

        public static void AddToCache(IList<Url> collection)
        {
            MemoryCache.Default.Add(cacheKey, collection, new CacheItemPolicy { AbsoluteExpiration = new DateTimeOffset(DateTime.Now.AddHours(20)) });
        }


    }
}