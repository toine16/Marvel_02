using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marvel_02.Models.FromDB
{
    public class Adresse
    {
        public int IdAdresse { get; set; }
        public int IdPersonne { get; set; }
        public string Ville { get; set; }
        public int CP { get; set; }
        public string Rue { get; set; }
        public int Numero { get; set; }
        public char Boite { get; set; }

    }
}