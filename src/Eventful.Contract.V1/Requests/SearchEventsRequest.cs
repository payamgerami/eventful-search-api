using Eventful.Contract.V1.Models;
using System;

namespace Eventful.Contract.V1.Requests
{
    public class SearchEventsRequest
    {
        public string Address { get; set; }
        public float Radius { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public EventCategory EventCategory { get; set; }
    }
}
