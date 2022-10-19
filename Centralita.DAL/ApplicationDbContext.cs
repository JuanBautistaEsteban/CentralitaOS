using Centralita.CORE;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centralita.DAL
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        /// <summary>
        /// Colección persistente de indicencias
        /// </summary>
        public DbSet<Incidence > Incidences { get; set; }

        /// <summary>
        /// Colección persistente de mensajes.
        /// </summary>
        public DbSet<Message> Messages { get; set; }

    }
}
