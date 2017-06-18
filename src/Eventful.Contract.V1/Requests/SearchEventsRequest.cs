using System;

namespace Eventful.Contract.V1.Requests
{
    public class SearchEventsRequest
    {
        public string Address { get; set; }
        public float Radius { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string Category { get; set; }

        public SearchEventsRequest()
        {
            Radius = 1;
            DateStart = DateTime.Today;
            DateEnd = DateTime.Today.AddDays(1);
            Category = "Music";
        }
    }
}