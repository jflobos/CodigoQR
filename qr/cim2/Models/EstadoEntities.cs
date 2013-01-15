using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Configuration;

namespace qr.Models
{
    public class EstadoEntities : DbContext
    {
        public EstadoEntities()
        {
            this.Database.Connection.ConnectionString = ConfigurationManager.ConnectionStrings["qr"].ConnectionString;
        }

        public DbSet<Estado> Estados { get; set; }

        public List<Estado> getEstados()
        {
            var todos = (from estado in Estados
                         orderby estado.Id ascending                         
                         select estado);
            return todos.ToList();
        }

        public bool SaveNewEstado(Estado c)
        {
            this.Estados.Add(c);
            this.SaveChanges();
            return true;
        }

        public bool UpdateEstado(Estado c)
        {
            Estado est = this.Estados.Find(c.Id);
            
            est.nombre = c.nombre;
            
            try
            {
                this.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

       }

        public bool DeleteEstado(int id)
        {
            Estado c = this.Estados.Find(id);
            this.Estados.Remove(c);
            this.SaveChanges();
            return true;
        }

        public Estado getOneEstado(int id)
        {
            Estado c = this.Estados.Find(id);
            
            return c;
        }

       

    }
}