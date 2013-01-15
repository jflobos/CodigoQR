using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Configuration;

namespace qr.Models
{
    public class InvitacionEntities : DbContext
    {
        public InvitacionEntities()
        {
            this.Database.Connection.ConnectionString = ConfigurationManager.ConnectionStrings["qr"].ConnectionString;
        }

        public DbSet<Invitacion> Invitaciones { get; set; }

        public List<Invitacion> getInvitaciones()
        {
            var todos = (from invitacion in Invitaciones
                         orderby invitacion.Id descending
                         select invitacion);
            return todos.ToList();
        }

        public bool SaveNewInvitacion(Invitacion c)
        {
            this.Invitaciones.Add(c);
            this.SaveChanges();
            return true;
        }

        public bool UpdateInvitacion(Invitacion c)
        {
            Invitacion inv = this.Invitaciones.Find(c.Id);

            inv.apellido = c.apellido;
            inv.nombre = c.nombre;
            inv.mail = c.mail;
            inv.estado_id = c.estado_id;
            inv.evento_id = c.evento_id;
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

        public bool DeleteInvitacion(int id)
        {
            Invitacion c = this.Invitaciones.Find(id);
            this.Invitaciones.Remove(c);
            this.SaveChanges();
            return true;
        }

        public Invitacion getOneInvitacion(int id)
        {
            Invitacion c = this.Invitaciones.Find(id);
            
            return c;
        }

        public List<Invitacion> estadiscticabase(int id)
        {
            var todos = (from invitacion in Invitaciones
                         where invitacion.evento_id==id
                         orderby invitacion.estado_id ascending
                         select invitacion);
            
           

            return todos.ToList();
        }
     
    }
}