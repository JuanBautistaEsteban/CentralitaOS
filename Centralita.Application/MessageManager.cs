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
    /// Manager de Massage
    /// </summary>
    public class MessageManager : GenericManager<Message>

    {
        /// <summary>
        /// Constructo del manager de Message
        /// </summary>
        /// <param name="context">Contexto de datos</param>
        public MessageManager(ApplicationDbContext context) : base(context)
        {
        }
    }
}
