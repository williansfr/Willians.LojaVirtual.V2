using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Willians.LojaVirtual.Dominio.Entidade;
using Willians.LojaVirtual.Dominio.Repositorio;

namespace Willians.LojaVirtual.Web.V2.Models
{
    public class WilliansUserManager : UserManager<Cliente>
    {
        public WilliansUserManager(IUserStore<Cliente> store) : base(store) { }

        public static WilliansUserManager Create(IdentityFactoryOptions<WilliansUserManager> options, IOwinContext context) {

            var userManager = new WilliansUserManager(new UserStore<Cliente>(new EfDbContext()));

            return userManager;
        }
    }
}