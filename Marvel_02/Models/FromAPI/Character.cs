using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marvel_02.Models.FromAPI
{
    public class Character
    {

        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }

        public DateTime modified { get; set; }
        public string ressourceURI { get; set; }

        public Url[] urls { get; set; }

        public Image thumbnail { get; set; }

        public ComicList comics { get; set; }
        public StoryList stories { get; set; }
        public EventList events { get; set; }
        public SeriesList series { get; set; }

    }
}