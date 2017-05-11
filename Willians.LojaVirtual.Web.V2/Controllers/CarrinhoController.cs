﻿using System;
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

        public ViewResult Index(Carrinho carrinho, string returnUrl)
        {
            var carrinhoViewModel = new CarrinhoViewModel();
            carrinhoViewModel.Carrinho = carrinho; // ObterCarrinho();
            carrinhoViewModel.ReturnUrl = returnUrl;

            return View(carrinhoViewModel);
        }

        public ViewResult FecharPedido()
        {
            return View(new Pedido());
        }

        [HttpPost]
        public ViewResult FecharPedido(Carrinho carrinho, Pedido pedido)
        {
            //Carrinho carrinho = ObterCarrinho();
            EmailConfiguracoes emailConfig = new EmailConfiguracoes();
            emailConfig.EscreverArquivo = bool.Parse(ConfigurationManager.AppSettings["Email.EscreverArquivo"]);

            EmailPedido emailPedido = new EmailPedido(emailConfig);

            if (!carrinho.ItensDoCarrinho().Any())
                ModelState.AddModelError("", "Carrinho vazio! \nPedido não pode ser concluído!");

            if (ModelState.IsValid)
            {
                emailPedido.ProcessarPedido(carrinho, pedido);
                carrinho.LimparCarrinho();
                return View("PedidoConcluido");
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


        public ViewResult PedidoConcluido()
        {
            return View();
        }

    }
}