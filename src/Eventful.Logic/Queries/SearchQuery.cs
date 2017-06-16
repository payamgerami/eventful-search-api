using System;

namespace Eventful.Logic.Queries
{
    public class SearchQuery
    {
        public string Address { get; set; }
        public float Radius { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string Category { get; set; }
    }
}
