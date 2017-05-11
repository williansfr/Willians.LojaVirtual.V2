using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Willians.LojaVirtual.Dominio.Repositorio;

namespace Willians.LojaVirtual.Web.V2.Controllers
{
    [Authorize] // Para acessar médodos, cliente precisa estar logado na aplicação
    public class PedidosController : Controller
    {
        private PedidosRepositorio _repositorio = new PedidosRepositorio();

        // GET: Todos os Pedidos
        public ActionResult Index()
        {
            string id = User.Identity.GetUserId();
            // Pedidos do Cliente
            var pedidos = _repositorio.ObterPedidos(id);
            // View exibirá os pedidos do cliente
            return View(pedidos);
        }

        public ActionResult Details(int id)
        {
            // Filtro de Pedido único
            var pedido = _repositorio.ObterPedido(id);
            // Pedido único para a View
            return View(pedido);
        }
    }
}