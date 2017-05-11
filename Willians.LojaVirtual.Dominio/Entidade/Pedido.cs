using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Willians.LojaVirtual.Dominio.Entidade
{
    public class Pedido
    {
        [Key]
        public int Id { get; set; }

        public string ClienteId { get; set; }
        
        // Por causa do EntityFrameWork, precisa fazer a referência
        [ForeignKey("ClienteId")]
        public virtual Cliente Cliente { get; set; }

        public virtual ICollection<ProdutoPedido> ProdutosPedidos { get; set; }

        public bool EmbrulhaPresente { get; set; }

        public bool Pago { get; set; }
    }
}
