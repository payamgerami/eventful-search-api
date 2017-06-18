using System.Threading.Tasks;
using Eventful.DataAccess.Entities;
using Microsoft.Extensions.Options;
using Eventful.Common.Configurations;
using System.Net.Http;
using System.Net;
using System;
using System.Collections.Specialized;
using Eventful.Common.Extensions;
using Newtonsoft.Json.Linq;
using Eventful.Common.Exceptions;

namespace Eventful.DataAccess.Repositories
{
    public class GoogleApiRepository : IGoogleApiRepository
    {
        private const string _apiKey = "key";
        private const string _address = "address";

        private static readonly HttpClient _httpClient = new HttpClient();
        private readonly GoogleApiOptions _googleApiOptions;

        public GoogleApiRepository(IOptions<GoogleApiOptions> googleApiOptions)
        {
            _googleApiOptions = googleApiOptions.Value;
        }

        public async Task<GoogleLocation> GetLocation(string address)
        {
            UriBuilder uriBuilder = new UriBuilder(_googleApiOptions.BaseAddress);
            uriBuilder.Path = _googleApiOptions.GeocodingPath;

            NameValueCollection parameters = new NameValueCollection();
            parameters.Add(_apiKey, _googleApiOptions.ApiKey);
            parameters.Add(_address, address);
            uriBuilder.Query = parameters.ToQueryString();

            HttpResponseMessage response = await _httpClient.GetAsync(uriBuilder.Uri);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();

                var geocoding = JObject.Parse(jsonString);

                string status = geocoding["status"].ToString();
                if (status.Equals("ZERO_RESULTS", StringComparison.OrdinalIgnoreCase))
                {
                    throw new InternalApiBadRequestException("Please specify a valid address.");
                }

                return new GoogleLocation
                {
                    Latitude = float.Parse(geocoding["results"][0]["geometry"]["location"]["lat"].ToString()),
                    Longitude = float.Parse(geocoding["results"][0]["geometry"]["location"]["lng"].ToString())
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
