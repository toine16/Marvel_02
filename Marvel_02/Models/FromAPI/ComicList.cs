using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marvel_02.Models.FromAPI
{
    public class ComicList
    {
        public int avaible { get; set; }
        public int returned { get; set; }
        public string collectionURI { get; set; }
        public ComicSummary[] items { get; set; }
    }
}