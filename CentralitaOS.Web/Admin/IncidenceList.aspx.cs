using Centralita.Application;
using Centralita.DAL;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CentralitaOS.Web.Admin
{
    public partial class IncidenceList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario.Text = "Administrador";
        }
    }
}