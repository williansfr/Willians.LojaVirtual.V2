﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Willians.LojaVirtual.Dominio.Entidade
{
    public class Cliente : IdentityUser
    {
        [NotMapped]
        public string Senha { get; set; }

        [Required]
        public string NomeCompleto { get; set; }

        public ICollection<Pedido> Pedidos { get; set; }

        // Telefone
        [Required]
        public virtual TelefoneCliente Telefone { get; set; }

        // Documento
        [Required]
        public virtual DocumentoCliente Documento { get; set; }

        // Endereço
        [Required]
        public virtual EnderecoCliente Endereco { get; set; }
    }
}
