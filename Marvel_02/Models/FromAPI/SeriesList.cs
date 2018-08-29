﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marvel_02.Models.FromAPI
{
    public class SeriesList
    {
        public int available { get; set; }
        public int returned { get; set; }
        public string collectionURI { get; set; }

        public SeriesSummary[] items { get; set; }
    }
}