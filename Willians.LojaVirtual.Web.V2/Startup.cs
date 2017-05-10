using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using Willians.LojaVirtual.Dominio.Repositorio;
using Willians.LojaVirtual.Web.V2.Models;
using System;

[assembly: OwinStartupAttribute(typeof(Willians.LojaVirtual.Web.V2.Startup))]
namespace Willians.LojaVirtual.Web.V2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext(EfDbContext.Create);
            app.CreatePerOwinContext<WilliansUserManager>(WilliansUserManager.Create);
            app.CreatePerOwinContext<WilliansSignInManager>(WilliansSignInManager.Create);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/cliente/login"),
                CookieName = "clienteLogin",
                CookiePath = "/",
                ExpireTimeSpan = TimeSpan.FromHours(12)
            });
        }
    }
}