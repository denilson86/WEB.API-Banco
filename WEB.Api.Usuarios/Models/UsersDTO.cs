﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB.Api.Usuarios.Models
{
    public class UsersDTO
    {
        public int id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public List<UsersDTO> Listusers { get; set; }

    }
}
