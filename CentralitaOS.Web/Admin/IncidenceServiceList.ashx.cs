using Centralita.Application;
using Centralita.DAL;
using CentralitaOS.Web.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Linq.Dynamic;

namespace CentralitaOS.Web.Admin
{
    /// <summary>
    /// Descripción breve de IncidenceServiceList
    /// </summary>
    public class IncidenceServiceList : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            // Parámetros que serán enviados por el plugin y devolverán los datos. Los recogemos aquí.
            var iDisplayLength = int.Parse(context.Request["iDisplayLength"]);
            var iDisplayStart = int.Parse(context.Request["iDisplayStart"]);
            var sSearch = context.Request["sSearch"];
            var sSortDir = context.Request["sSortDir_0"];
            var iSortCol = context.Request["iSortCol_0"];
            var sortColum = context.Request.QueryString["mDataProp_" + iSortCol];

            // Cargamos el contexto de datos y el manager de las incidencias.
            ApplicationDbContext contextdb = new ApplicationDbContext();
            IncidenceManager incidenceManager = new IncidenceManager(contextdb);

            #region select
            var allIncidences = incidenceManager.GetAll();
            var incidences = allIncidences.Select(p => new AdminIncidenceList
            {
                Id = p.Id,
                Message = p.Messages.FirstOrDefault().Text,
                Date = p.CreateDate,
                Status = p.Status.ToString(),
                User = p.User !=null ? p.User.UserName : "", 
            });

            #endregion

            #region filtro
            if (!string.IsNullOrWhiteSpace(sSearch))
            {
                string where = @"Id.ToString().Contains(@0) ||
                                 Message.ToString().Contains(@0) ||
                                 Date.ToString().Contains(@0) ||
                                 Status.ToString().Contains(@0) ||
                                 User.ToString().Contains(@0)";
                incidences = incidences.Where(where, sSearch);

            }
            #endregion

            #region Paginate
            incidences = incidences
                        .OrderBy(sortColum + " " + sSortDir)
                        .Skip(iDisplayStart)
                        .Take(iDisplayLength);

            #endregion

            var result = new
            {
                iTotalRecords = allIncidences.Count(),
                iTotalDisplayRecords = allIncidences.Count(),
                aaData = incidences
            };

            var serializer = new JavaScriptSerializer();
            var json = serializer.Serialize(result);
            context.Response.ContentType = "application/json";
            context.Response.Write(json);

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}