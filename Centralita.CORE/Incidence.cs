using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centralita.CORE
{
    /// <summary>
    /// Entidad de dominio Incidencia
    /// </summary>
    public  class Incidence
    {
        /// <summary>
        /// Identificador de la incidencia
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre del equipo donde se produce la incidencia
        /// </summary>
        public string Equipment { get; set; }

        /// <summary>
        /// Fecha de creación de la incidencia
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// Fecha de cierre de la incidencia. Admite valores NULL.
        /// </summary>
        public DateTime? ClosedDate { get; set; }
        /// <summary>
        /// Nota interna del administrador
        /// </summary>
        public string InternalNote { get; set; }
        /// <summary>
        /// Estado de la incidencia. Es un tipo enumerado IncidenceStatus
        /// </summary>
        public IncidenceStatus Status { get; set; }
        /// <summary>
        /// Prioridad de la incidencia. Es un tipo enumerado IncidencePriority
        /// </summary>
        public IncidencePriority Priority { get; set; }

        /// <summary>
        /// Tipo de incidencia. Es un tipo enumerado IncidenceType
        /// </summary>
        public IncidenceType IncidenceType { get; set; }

        /// <summary>
        /// User que ha creado la incidencia.
        /// </summary>
        public ApplicationUser User { get; set; }
        /// <summary>
        /// Identificador del user que ha creado la incidencia.
        /// </summary>
        [ForeignKey ("User")]
        public string User_Id { get; set; }

        public virtual List<Message> Messages { get; set; }

        /*
        /// <summary>
        /// Alias de la incidencia.
        /// </summary>
        public string Alias { get; set; }
        */

    }
}
