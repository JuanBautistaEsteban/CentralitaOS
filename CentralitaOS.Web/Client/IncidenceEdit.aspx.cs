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
using CentralitaOS.Web.Controles;

namespace CentralitaOS.Web.Client
{
    public partial class IncidenceEdit : System.Web.UI.Page
    {
        // Ahora creamos un contexto de base de datos, que se lo pasaremos al constructor del incidenceManager
        ApplicationDbContext context = null;
        IncidenceManager incidenceManager = null;
        MessageManager messageManager = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            context = new ApplicationDbContext();
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
                var incidence = incidenceManager.GetByIdWithMessage (int.Parse(txtId.Value));
                incidence.Messages.Add(message);
                context.SaveChanges();

                CargarIncidencia (incidence);
                txtIncidence.Text = "";

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
        private void CargarIncidencia(Incidence incidence)
        {
            // Cargamos los datos de la incidencia: lo que son estaticos y tienen pintado los controles
            // en el formulario
            // Almacenamos en el campo oculto el valor de id de la incidencia
            txtId.Value = incidence.Id.ToString();
            txtEquiment.Text = incidence.Equipment;
            dllType.Text = incidence.IncidenceType.ToString();
            //txtEquiment.Text = incidence.User.UserName ;



            // Ahora es necesario ir añadiendo un control Bubbles por cada un de los mensajes que
            // estén vinculados a esta incidencia.

            var content = (ContentPlaceHolder)Master.FindControl("MainContent");
            var div = content.FindControl("messages");
            div.Controls.Clear();
            foreach (var message in incidence.Messages)
            {
                var control = (Bubble)Page.LoadControl("~/Controles/Bubble.ascx");
                control.Message = message;
                control.userName = User.Identity.GetUserName();
                div.Controls.Add(control);
            }

        }

    }
}