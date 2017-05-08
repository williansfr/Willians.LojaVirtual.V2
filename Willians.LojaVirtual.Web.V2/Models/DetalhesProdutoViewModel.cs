﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Willians.LojaVirtual.Dominio.Dto;
using Willians.LojaVirtual.Dominio.Entidade;

namespace Willians.LojaVirtual.Web.V2.Models
{
    public class DetalhesProdutoViewModel
    {
        public QuironProduto Produto { get; set; }
        public IEnumerable<Cor> Cores { get; set; }
        public IEnumerable<Tamanho> Tamanhos { get; set; }
        public BreadCrumbDto Breadcrumb { get; set; }
        public SelectList CoresList { get; set; }
        public SelectList TamanhoList { get; set; }
    }
}