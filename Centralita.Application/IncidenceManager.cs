using Centralita.CORE;
using Centralita.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centralita.Application
{
    /// <summary>
    /// Manager de Incidence
    /// </summary>
    public class IncidenceManager : GenericManager<Incidence>
    {
        /// <summary>
        /// Constructor del manager de Incidence
        /// </summary>
        /// <param name="context">Contexto de datos</param>
        public IncidenceManager(ApplicationDbContext context) : base(context)
        {
        }

        // Vamos a crear un método especifico que devuelva todas las incidencias que ha creado un usuario
        // utilizando el id del usuario.

        /// <summary>
        /// Método que retorna todas las incidencias de un usuario. Solo los datos de las incidencias,
        /// no los datos asociados a esa incidencia, no traerá los mensajes.
        /// </summary>
        /// <param name="UserId">Id del usuario</param>
        /// <returns>Listado de incidencias de un usuario</returns>
        public IQueryable<Incidence> GetByUserId(string UserId)
        { 
            // Cualquier de estas dos opciones es válida.
            // return Context.Set<Incidence>().Where (e=> e.User_Id == UserId);
            // o
            return Context.Incidences.Where(e => e.User_Id == UserId);

        }

        /// <summary>
        /// Método que retorna una incidencia, incluyendo sus mensajes. Buscará la incidencia por su Id
        /// </summary>
        /// <param name="Id">Identificador de la incidencia</param>
        /// <returns>Incidencia si es encontrada o NULL en caso de no encontrarse.</returns>

        public Incidence GetByIdWithMessage (int Id)
        {
            return Context.Set<Incidence>().Include("Messages").Where(e => e.Id == Id).SingleOrDefault();

        }
    }
}
