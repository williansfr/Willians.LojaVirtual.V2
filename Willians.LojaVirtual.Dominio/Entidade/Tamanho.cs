﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Willians.LojaVirtual.Dominio.Entidade
{
    public class Tamanho
    {
        [Key]
        public int TamanhoId { get; set; }

        public string TamanhoCodigo { get; set; }

        public string TamanhoDescricaoResumida { get; set; }

        public string TamanhoDescricao { get; set; }
    }
}
