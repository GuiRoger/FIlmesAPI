﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosDomain.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }       
        [Required]
        public string Email { get; set; }


    }
}
