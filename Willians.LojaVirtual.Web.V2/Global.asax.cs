using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Willians.LojaVirtual.Dominio.Entidade;
using Willians.LojaVirtual.Web.V2.Infraestrutura;

namespace Willians.LojaVirtual.Web.V2
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Mappers.AutoMapperConfig.RegisterMappings();
            ModelBinders.Binders.Add(typeof(Carrinho), new CarrinhoModelBinder());
        }
    }
}
