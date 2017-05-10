using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Willians.LojaVirtual.Dominio.Entidade;

namespace Willians.LojaVirtual.Web.V2.Models
{
    public class WilliansSignInManager : SignInManager<Cliente, string>
    {
        public WilliansSignInManager(WilliansUserManager userManager, IAuthenticationManager authenticationManager) : base(userManager, authenticationManager) { }

        public static WilliansSignInManager Create(IdentityFactoryOptions<WilliansSignInManager> options, IOwinContext context)
        {
            var manager = context.GetUserManager<WilliansUserManager>();
            var sign = new WilliansSignInManager(manager, context.Authentication);
            return sign;
        }
    }
}