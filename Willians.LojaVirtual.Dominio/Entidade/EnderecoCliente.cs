﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Willians.LojaVirtual.Dominio.Entidade
{
    public class EnderecoCliente
    {
        [Key, ForeignKey("Id")]
        public virtual Cliente Cliente { get; set; }

        public string Id { get; set; }
        public string Pais { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }
        public string Rua { get; set; }
        public string Complemento { get; set; }
        public string Numero { get; set; }
    }
}
