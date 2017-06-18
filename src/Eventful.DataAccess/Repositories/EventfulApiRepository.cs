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

namespace Eventful.DataAccess.Repositories
{
    public class EventfulApiRepository : IEventfulApiRepository
    {
        private const string _appKey = "app_key";
        private const string _where = "where";
        private const string _within = "within";
        private const string _date = "date";

        private static readonly HttpClient _httpClient = new HttpClient();
        private readonly EventfulOptions _eventfulOptions;

        public EventfulApiRepository(IOptions<EventfulOptions> eventfulOptions)
        {
            _eventfulOptions = eventfulOptions.Value;
        }

        public async Task<IEnumerable<EventfulEvent>> GetEvents(float latitude, float longitude, float radius, DateTime dateStart, DateTime dateEnd, string category)
        {
            UriBuilder uriBuilder = new UriBuilder(_eventfulOptions.BaseAddress);
            uriBuilder.Path = _eventfulOptions.EventsSearchPath;

            NameValueCollection parameters = new NameValueCollection();
            parameters.Add(_appKey, _eventfulOptions.AppKey);
            parameters.Add(_where, $"{latitude},{longitude}");
            parameters.Add(_within, radius.ToString());
            parameters.Add(_date, $"{dateStart}-{dateEnd}");
            uriBuilder.Query = parameters.ToQueryString();

            HttpResponseMessage response = await _httpClient.GetAsync(uriBuilder.Uri);
            if (response.IsSuccessStatusCode)
            {
                var xmlString = await response.Content.ReadAsStringAsync();

                var reader = new StringReader(xmlString);
                var elements = XElement.Load(reader);

                return
                    from s in elements.Descendants("event")
                    select new EventfulEvent
                    {
                        Title = (string)s.Descendants("title").FirstOrDefault(),
                        Venue = (string)s.Descendants("venue_name").FirstOrDefault(),
                        Date = (DateTime)s.Descendants("start_time").FirstOrDefault(),
                        Performers = (string)s.Descendants("performers").FirstOrDefault(),
                        Image = (string)s.Descendants("image").FirstOrDefault()
                    };
            }

            return null;
        }
    }
}