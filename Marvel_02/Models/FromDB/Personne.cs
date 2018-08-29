using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marvel_02.Models.FromDB
{
    public class Personne
    {
        public int IdPersonne { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public int Age { get; set; }
        public bool Sexe { get; set; } // true = Homme
        public string Mail { get; set; }
        public string MotDePasse { get; set; }

        public string Pseudo { get; set; }
        public string Hash { get; set; }

    }
}