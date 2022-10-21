using Centralita.DAL;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using Microsoft.AspNet.Identity.Owin;
using Centralita.CORE;

namespace CentralitaOS.Web
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Código que se ejecuta al iniciar la aplicación
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Implementación de seguridad por roles y capetas.
            //Obtenemos los contextos de usuario y de la base de datos
            ApplicationDbContext contextBBDD = new ApplicationDbContext();
            RoleManager<IdentityRole> RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(contextBBDD));

            UserManager<ApplicationUser> UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(contextBBDD));   



            #region Crearción de roles
            if (!RoleManager .RoleExists ("Admin"))
            {
                RoleManager.Create(new IdentityRole("Admin"));
            }
            if (!RoleManager.RoleExists("Client"))
            {
                RoleManager.Create(new IdentityRole("Client"));
            }
            #endregion

            #region Crear usuario con Rol de Administrador
            ApplicationUser user = UserManager.FindByName("admin@admin.es");
            if (user == null)
            {
                user = new ApplicationUser();
                user.UserName = "admin@admin.es";
                user.Email = "admin@admin.es";
                IdentityResult result = UserManager.Create(user, "Centollos1234@");
                if (!result.Succeeded)
                {
                    UserManager.AddToRole(user.Id, "Admin");
                }
                else
                {
                    throw new Exception("Usuario no creado.");
                }
            }
            else
            {
                //El usuario está creado pero, ¿Ya tiene el rol de administrador?
                if (!UserManager.IsInRole (user.Id, "Admin"))
                {
                    UserManager.AddToRole(user.Id, "Admin");
                }
            }
            #endregion 

        }

        
    }
}