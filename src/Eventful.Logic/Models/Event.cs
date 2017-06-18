using System;

namespace Eventful.Logic.Models
{
    public class Event
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Venue { get; set; }
        public string Performers { get; set; }
        public DateTime Date { get; set; }
        public string ImageUri { get; set; }
    }
}