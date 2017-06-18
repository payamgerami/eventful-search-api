using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Eventful.DataAccess.Entities;
using Eventful.Common.Configurations;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Collections.Specialized;
using Eventful.Common.Extensions;
using System.IO;
using System.Xml.Linq;
using System.Linq;
using System.Net;
using Eventful.Common.Exceptions;

namespace Eventful.DataAccess.Repositories
{
    public class EventfulApiRepository : IEventfulApiRepository
    {
        private const string _appKey = "app_key";
        private const string _where = "where";
        private const string _within = "within";
        private const string _date = "date";
        private const string _category = "category";

        private static readonly HttpClient _httpClient = new HttpClient();
        private readonly EventfulApiOptions _eventfulApiOptions;

        public EventfulApiRepository(IOptions<EventfulApiOptions> eventfulApiOptions)
        {
            _eventfulApiOptions = eventfulApiOptions.Value;
        }

        public async Task<IEnumerable<EventfulEvent>> GetEvents(float latitude, float longitude, float radius, DateTime dateStart, DateTime dateEnd, string category)
        {
            UriBuilder uriBuilder = new UriBuilder(_eventfulApiOptions.BaseAddress);
            uriBuilder.Path = _eventfulApiOptions.EventsSearchPath;

            NameValueCollection parameters = new NameValueCollection();
            parameters.Add(_appKey, _eventfulApiOptions.AppKey);
            parameters.Add(_where, $"{latitude},{longitude}");
            parameters.Add(_within, radius.ToString());
            parameters.Add(_date, $"{dateStart}-{dateEnd}");
            parameters.Add(_category, category);
            uriBuilder.Query = parameters.ToQueryString();

            HttpResponseMessage response = await _httpClient.GetAsync(uriBuilder.Uri);
            if (response.IsSuccessStatusCode)
            {
                var xmlString = await response.Content.ReadAsStringAsync();

                var reader = new StringReader(xmlString);
                var search = XElement.Load(reader);

                return
                    from s in search.Descendants("event")
                    select new EventfulEvent
                    {
                        Title = (string)s.Descendants("title").FirstOrDefault(),
                        Venue = (string)s.Descendants("venue_name").FirstOrDefault(),
                        Date = (DateTime)s.Descendants("start_time").FirstOrDefault(),
                        Performers = (string)s.Descendants("performers").FirstOrDefault(),
                        ImageUri = (string)s.Descendants("image").FirstOrDefault().Descendants("url").FirstOrDefault()
                    };
            }

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                string message = await response.Content.ReadAsStringAsync();
                throw new InternalApiBadRequestException(message);
            }

            throw new InternalApiException();
        }
    }
}