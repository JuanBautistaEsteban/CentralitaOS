using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentralitaOS.Web.Client
{
    /// <summary>
    /// Descripción breve de IncidenceServiceList
    /// </summary>
    public class IncidenceServiceList : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hola a todos");
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