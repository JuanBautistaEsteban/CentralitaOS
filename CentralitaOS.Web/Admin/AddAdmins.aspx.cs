using Centralita.CORE;
using Centralita.DAL;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CentralitaOS.Web.Admin
{
    public partial class AddAdmins : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void send_Click(object sender, EventArgs e)
        {
            // Vamos a crear el usuario y le vamos a asociar el rol de Administrador
            // Optenemos el contexto de la base de datos
            ApplicationDbContext contextBBDD = new ApplicationDbContext();

            // Creamos el manager de usuarios
            UserManager<ApplicationUser> UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(contextBBDD));

            // Buscamos el usuario, por si ya existe
            ApplicationUser user = UserManager.FindByName(Username.Text.Trim(new char[] { ' ' }));
            if (user == null)
            {
                user = new ApplicationUser();
                user.UserName = Username.Text.Trim(new char[] { ' ' });
                user.Email = Username.Text.Trim(new char[] { ' ' });
                
                // Añadimos la contraseña al registro
                IdentityResult result = UserManager.Create(user, UserPass.Text.Trim(new char[] { ' ' }));

                // Si todo ha ido bien, asignamos el rol de administrador
                if (result.Succeeded)
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
                if (!UserManager.IsInRole(user.Id, "Admin")) 
                {
                    UserManager.AddToRole(user.Id, "Admin");
                }
            }

        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            string texto = UserPass.Text.Trim(new char[] { ' ' });
                                    
            if (CheckBox1.Checked)
            {
                UserPass.TextMode = TextBoxMode.SingleLine;
            }
            else
            {
                UserPass.TextMode = TextBoxMode.Password;
            }
            UserPass.Text = texto;

        }
    }
}