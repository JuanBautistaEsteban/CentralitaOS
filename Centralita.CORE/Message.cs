using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Centralita.CORE
{
    /// <summary>
    /// Clase de dominio de mensaje
    /// </summary>
    public class Message
    {
        /// <summary>
        /// Identificador del mensaje
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Fecha de creación del mensaje
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Contenido del mensaje.
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Usuario que pone el mensaje
        /// </summary>
        public ApplicationUser User { get; set; }

        /// <summary>
        /// Identificador del usuario que escribe el mensaje
        /// </summary>
        [ForeignKey("User")]
        public string User_Id { get; set; }

        /// <summary>
        /// Incidencia a la que corresponde este mensaje
        /// </summary>
        public Incidence Incidence { get; set; }


        /// <summary>
        /// Identificador de la incidencia a la que corresponde este mensaje
        /// </summary>
        [ForeignKey ("Incidence")]
        public int Incidence_Id { get; set; }

    }
}