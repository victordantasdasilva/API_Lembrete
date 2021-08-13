using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace API_Lembretes.Models
{
    public class LembretesContext : DbContext
    {
        public LembretesContext():base("PostgreSQL")
        {

        }

        public DbSet<Lembrete> Lembretes { get; set; }
    }
}