﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Willians.LojaVirtual.Dominio.Entidade
{
    public class Cor
    {
        [Key]
        public int CorId { get; set; }

        public string CorDescricao { get; set; }

        public string CorCodigo { get; set; }

        public string Tamanho { get; set; }
    }
}
