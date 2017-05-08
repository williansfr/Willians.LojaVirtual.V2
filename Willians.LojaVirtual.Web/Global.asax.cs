﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Willians.LojaVirtual.Dominio.Entidade;
using Willians.LojaVirtual.Web.App_Start;
using Willians.LojaVirtual.Web.Infraestrutura;

namespace Willians.LojaVirtual.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ModelBinders.Binders.Add(typeof(Carrinho), new CarrinhoModelBinder());            
        }
    }
}
