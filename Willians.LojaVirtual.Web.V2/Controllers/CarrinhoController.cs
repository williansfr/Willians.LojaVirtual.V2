using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Willians.LojaVirtual.Dominio.Entidade;
using Willians.LojaVirtual.Dominio.Repositorio;
using Willians.LojaVirtual.Web.V2.Models;

namespace Willians.LojaVirtual.Web.V2.Controllers
{
    public class CarrinhoController : Controller
    {
        private QuironProdutosRepositorio _produtoRepositorio = new QuironProdutosRepositorio();
        private ClientesRepositorio _clienteRepositorio = new ClientesRepositorio();
        private PedidosRepositorio _pedidoRepositorio = new PedidosRepositorio();

        public ViewResult Index(Carrinho carrinho, string returnUrl)
        {
            var carrinhoViewModel = new CarrinhoViewModel();
            carrinhoViewModel.Carrinho = carrinho; // ObterCarrinho();
            carrinhoViewModel.ReturnUrl = returnUrl;

            return View(carrinhoViewModel);
        }

        [Authorize]
        public ViewResult FecharPedido()
        {
            Pedido novoPedido = new Pedido();
            novoPedido.ClienteId = User.Identity.GetUserId();
            novoPedido.Cliente = _clienteRepositorio.ObterCliente(User.Identity.GetUserId());

            return View(novoPedido);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken] // Garantir que o POST veio do cliente autorizado, não um ataque
        public ActionResult FecharPedido(Carrinho carrinho, Pedido pedido)
        {
            //Carrinho carrinho = ObterCarrinho();

            if (!carrinho.ItensDoCarrinho().Any())
                ModelState.AddModelError("", "Carrinho vazio! \nPedido não pode ser concluído!");

            if (ModelState.IsValid)
            {
                pedido.ProdutosPedidos = new List<ProdutoPedido>();

                foreach(var item in carrinho.ItensDoCarrinho())
                {
                    #region Transfere Itens do Carrinho para a Lista de Produtos do Pedido

                    var produtoPedido = new ProdutoPedido();
                    produtoPedido.Quantidade = item.Quantidade;
                    produtoPedido.ProdutoId = item.Produto.ProdutoId;

                    pedido.ProdutosPedidos.Add(produtoPedido);

                    #endregion Transfere Itens do Carrinho para a Lista de Produtos do Pedido                    
                }

                pedido.Pago = false;
                pedido = _pedidoRepositorio.SalvarPedido(pedido); // Recupera o Id do Pedido Efetivado

                return RedirectToAction("PedidoConcluido", new { pedidoId = pedido.Id });
            }
            else
                return View(pedido);
        }

        public PartialViewResult Resumo(Carrinho carrinho)
        {
            //Carrinho carrinho = ObterCarrinho();
            return PartialView(carrinho);
        }

        // GET: Carrinho
        public RedirectToRouteResult Adicionar(Carrinho carrinho, int quantidade,
                    string produto, string Cor, string Tamanho, string returnUrl)
        {
            QuironProduto prod = _produtoRepositorio.ObterProduto(produto, Cor, Tamanho);

            if (prod != null)
            {
                carrinho.AdicionarItem(prod, quantidade);
            }

            return RedirectToAction("Index", "Nav");
        }


        //private Carrinho ObterCarrinho()
        //{           
        //    if (Session["Carrinho"] == null) {
        //        Session["Carrinho"] = new Carrinho();
        //    }

        //    Carrinho carrinho = (Carrinho)Session["Carrinho"];

        //    return carrinho;
        //}

        // GET: Carrinho
        public RedirectToRouteResult Remover(Carrinho carrinho, int produtoId, string returnUrl)
        {
            QuironProduto produto = _produtoRepositorio.Produtos
                .FirstOrDefault(p => p.ProdutoId == produtoId);

            if (produto != null)
            {
                carrinho.RemoverItem(produto);
            }

            return RedirectToAction("Index", "Nav");
        }


        public ViewResult PedidoConcluido(Carrinho carrinho, int pedidoId)
        {
            EmailConfiguracoes emailConfig = new EmailConfiguracoes();
            emailConfig.EscreverArquivo = bool.Parse(ConfigurationManager.AppSettings["Email.EscreverArquivo"]);

            EmailPedido emailPedido = new EmailPedido(emailConfig);

            #region Montagem do Pedido

            Pedido pedido = _pedidoRepositorio.ObterPedido(pedidoId);

            #endregion Montagem do Pedido

            emailPedido.ProcessarPedido(carrinho, pedido);
            carrinho.LimparCarrinho();

            return View(pedido);
        }

    }
}