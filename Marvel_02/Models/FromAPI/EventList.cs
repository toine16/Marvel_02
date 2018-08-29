using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marvel_02.Models.FromAPI
{
    public class EventList
    {
        public int available { get; set; }
        public int returned { get; set; }
        public string collectionURI { get; set; }
        public EventSummary[] items { get; set; }
    }
}