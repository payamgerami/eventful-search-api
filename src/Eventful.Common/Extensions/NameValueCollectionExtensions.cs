using System;
using System.Collections.Specialized;
using System.Linq;
using System.Net;

namespace Eventful.Common.Extensions
{
    public static class NameValueCollectionExtensions
    {
        public static string ToQueryString(this NameValueCollection collection)
        {
            return String.Join("&", collection.AllKeys
                .SelectMany(key => collection.GetValues(key)
                .Select(value => String.Format("{0}={1}", WebUtility.UrlEncode(key), WebUtility.UrlEncode(value))))
                .ToArray());
        }
    }
}
