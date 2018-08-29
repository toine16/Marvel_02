using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Marvel_02.Models.ToView
{
    public class InscriptionModel
    {
        public InscriptionModel()
        { }
        [Required]
        [DisplayName("Nom")]
        public string Nom { get; set; }
        [Required]
        [DisplayName("Prénom")]
        public string Prenom { get; set; }

        [Required]
        [DisplayName("Age")]
        public int Age { get; set; }

        [Required]
        [DisplayName("Sexe")]
        public bool Sexe { get; set; }
        [Required]
        [DisplayName("Pseudonyme")]
        public string Pseudo { get; set; }

        [Required(ErrorMessage = "Ce champs est requis")]
        [EmailAddress(ErrorMessage = "Ceci n'est pas une adresse email valide")]
        [DisplayName("Adresse email")]
        public string Mail { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Mot de passe")]
        public string MotDePasse { get; set; }

        [DataType(DataType.Password)]
        [Compare(nameof(MotDePasse), ErrorMessage = "Les mots de passe sont différents")]
        [DisplayName("Confirmation du mot de passe")]
        public string confirmeMotDePasse { get; set; }

        [DisplayName("Ville")]
        public string Ville { get; set; }
        [DisplayName("Code postal")]
        public int CP { get; set; }
        [DisplayName("Rue")]
        public string Rue { get; set; }
        [DisplayName("Numero")]
        public int Numero { get; set; }
        [DisplayName("Boite")]
        public char Boite { get; set; }

        [DisplayName("Conditions d'utilisation")]
        public bool ConditionsAgrement { get; set; }
    }
}