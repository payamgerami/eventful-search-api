﻿using System;

namespace Eventful.Contract.V1.Responses
{
    public class EventResponse
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Venue { get; set; }
        public string Performers { get; set; }
        public DateTime Date { get; set; }
        public string ImageUri { get; set; }
    }
}
