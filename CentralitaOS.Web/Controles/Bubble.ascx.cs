using Centralita.CORE;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CentralitaOS.Web.Controles
{
    public partial class Bubble : System.Web.UI.UserControl
    {
        public Message Message { get; set; }

        public string  userName  { get; set; }
        public bool IsAdmin { get; private set; }
                
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Message != null)
            {
                var userManager = Context.GetOwinContext ().GetUserManager <ApplicationUserManager>();
                try
                {
                    IsAdmin = userManager.IsInRoleAsync(Message.User_Id, "Admin").Result;
                    //IsAdmin = true;
                }
                catch
                {
                    IsAdmin = false;
                }
                
                text.Text = Message.Text;
                //txtEquiment .Text = User.Identity.GetUserName() ;
                name.Text = userName;
                date.Text = Message.CreateDate.ToString("dd/MM/yy HH:mm");
            }

        }
    }
}