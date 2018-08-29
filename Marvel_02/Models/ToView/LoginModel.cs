using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Marvel_02.Models.ToView
{
    public class LoginModel
    {
        [Required]
        [DisplayName("Pseudo")]
        public string Login { get; set; }
        [Required]
        [DisplayName("Mot de Passe")]
        [DataType(DataType.Password)]
        public string MotDePasse { get; set; }
        
    }
}