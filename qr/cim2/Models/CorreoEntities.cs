using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Configuration;

namespace qr.Models
{
    public class CorreoEntities : DbContext
    {
        public CorreoEntities()
        {
            this.Database.Connection.ConnectionString = ConfigurationManager.ConnectionStrings["qr"].ConnectionString;
        }

        public DbSet<Correo> Correos { get; set; }

        public List<Correo> getCorreos()
        {
            var todos = (from correo in Correos
                         orderby correo.Id descending
                         select correo);
            return todos.ToList();
        }

        public bool SaveNewCorreo(Correo c)
        {
            this.Correos.Add(c);
            this.SaveChanges();
            return true;
        }

        public bool UpdateCorreo(Correo c)
        {
            Correo cor = this.Correos.Find(c.Id);

            cor.html = c.html;
            cor.header = c.header;
            cor.footer = c.footer;
            cor.invitacion_id = c.invitacion_id;            
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

        public bool DeleteCorreo(int id)
        {
            Correo c = this.Correos.Find(id);
            this.Correos.Remove(c);
            this.SaveChanges();
            return true;
        }

        public Correo getOneCorreo(int id)
        {
            Correo c = this.Correos.Find(id);
            
            return c;
        }
    }
}