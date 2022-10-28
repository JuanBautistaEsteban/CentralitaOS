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
    public partial class WebForm1 : System.Web.UI.Page
    {
        // Creamos un objeto de la clase ManagerIncidence y lo hacemos aquí para que sea accesible desde cualquiera de los eventos.
        IncidenceManager inicidenceManager = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            ddlType.DataSource = Enum.GetValues(typeof(IncidenceType ));
            //DataBind() carga esos datos de la fuente en el control.
            ddlType.DataBind();

            // Ahora creamos un contexto de base de datos, que se lo pasaremos al constructor del incidenceManager
            ApplicationDbContext context = new ApplicationDbContext();
            inicidenceManager = new IncidenceManager(context);


        }

        /// <summary>
        /// Evento que se ejecuta cuando se pulsa el botón Alta del formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // Creamos el objeto Incidencia y le asignamos el valor a las propiedades. No se pone el ; despues del new Incidence(),
            // se abren las llaves y se asignan los valores a las propiedades y luego se pone ;
            Incidence incidence = new Incidence()
            {
                CreateDate = DateTime.Now,  
                Equipment = txtEquipment .Text,
                IncidenceType = (IncidenceType)Enum.Parse (typeof (IncidenceType), ddlType.SelectedValue),
                Priority = IncidencePriority.Low ,
                Status = IncidenceStatus.Open ,
                User_Id=User.Identity.GetUserId (),
                Messages = new ...
            };
            // con el manager lo añadimos a la BBDD
            inicidenceManager .Add (incidence );
            // salvamos lo cambios 
            inicidenceManager.Context.SaveChanges ();

            // redirigimos a otra supuesta página
            Response.Redirect("Incidencias");



        }
    }
}