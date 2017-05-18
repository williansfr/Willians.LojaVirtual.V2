using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Willians.LojaVirtual.Dominio.Entidade;
using System.Data.Entity;

namespace Willians.LojaVirtual.Dominio.Repositorio
{
    public class PedidosRepositorio
    {
        private readonly EfDbContext _context = new EfDbContext();

        public IEnumerable<Pedido> ObterPedidos(string clienteId)
        {
            return _context.Pedidos.Where(p => p.ClienteId == clienteId) // Select na Tabela Pedidos realizando filtro por cliente
                .Include(p => p.ProdutosPedidos) // Link com a tabela ProdutosPedidos 
                .Include(p => p.ProdutosPedidos.Select(pp => pp.Produto)); // Link com a tabela QuironProdutos
        }

        public Pedido ObterPedido(int id)
        {
            return _context.Pedidos.Where(p => p.Id == id)
                .Include(p => p.ProdutosPedidos).FirstOrDefault();
        }

        public IEnumerable<QuironProduto> ObterProdutosPedido(int id)
        {
            return _context.Pedidos.Find(id).ProdutosPedidos.Select(p => p.Produto); // Retorno da Lista de Produtos com mapeamento por produto
        }

        public Pedido SalvarPedido(Pedido pedido)
        {
            Pedido pedidoReturn = pedido;

            if (pedido.Id == 0)
                pedidoReturn = _context.Pedidos.Add(pedido);            

            _context.SaveChanges();

            return pedidoReturn;
        }

        public void RemoverPedido(Pedido pedido)
        {
            _context.Pedidos.Remove(pedido);
            _context.SaveChanges();
        }

    }
}
