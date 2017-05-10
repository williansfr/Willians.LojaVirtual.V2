﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Willians.LojaVirtual.Web.V2.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Nome de usuário")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Display(Name = "Lembre-me")]
        public bool RememberMe { get; set; }
    }
}