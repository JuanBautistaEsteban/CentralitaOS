using Centralita.Application;
using Centralita.CORE;
using Centralita.DAL;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CentralitaOS.Web.Client
{
    public partial class IncidenceEdit : System.Web.UI.Page
    {
        IncidenceManager incidenceManager = null;
        // Ahora creamos un contexto de base de datos, que se lo pasaremos al constructor del incidenceManager
        ApplicationDbContext context = new ApplicationDbContext();
        MessageManager messageManager = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            incidenceManager = new IncidenceManager(context);
            messageManager = new MessageManager(context);

            int id = 0;
            // Preguntamos si el parametro "id" no es nulo.
            if(Request.QueryString["id"] != null)
            {
                // Si no es null, vamos a intentar convertir el parámetro en un entero. Si se pasa un número se podrá convertir
                // y lo almacenará en la variable id y devolvera True. En caso contrario devolverá False.
                if(int.TryParse (Request.QueryString["id"], out id))
                {
                    //Intentamos coger la incidencia por el Id con el incidenceManager
                    var incidence = incidenceManager.GetById(id);
                    if (incidence != null)
                    {
                        //Esta incidencia es del usuario con el que estamos logeados??
                        if(incidence.User_Id == User.Identity.GetUserId())
                        {
                            CargarIncidencia(incidence);
                        }
                    }
                }
            }
        }




        private void CargarIncidencia(Incidence incidence)
        {
            // Almacenamos en el campo oculto el valor de id de la incidencia
            txtId.Value = incidence.Id.ToString();
            txtEquiment.Text = incidence.Equipment;
            dllType .Text = incidence.IncidenceType .ToString();    

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                var message = new Message
                {
                    CreateDate = DateTime.Now,
                    Text = txtIncidence.Text,
                    User_Id = User.Identity.GetUserId(),
                    Incidence_Id = int.Parse(txtId .Value)
                };
                messageManager.Add (message);
                context.SaveChanges();

            }
            catch (Exception ex)
            {
                //TODO: Registrar error en el log de errores.
                var err = new CustomValidator
                {
                    ErrorMessage = "Se ha producido un error al actualizar",
                    IsValid = false
                };
                Page.Validators .Add (err);
            }

        }
    }
}