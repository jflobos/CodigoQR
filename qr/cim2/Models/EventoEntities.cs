using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Configuration;

namespace qr.Models
{
    public class EventoEntities : DbContext
    {
        public EventoEntities()
        {
            this.Database.Connection.ConnectionString = ConfigurationManager.ConnectionStrings["qr"].ConnectionString;
        }

        public DbSet<Evento> Eventos { get; set; }

        public List<Evento> getEventos()
        {
            var todos = (from evento in Eventos
                         orderby evento.inicio descending
                         select evento);
            return todos.ToList();
        }

        public bool SaveNewEvento(Evento c)
        {
            this.Eventos.Add(c);
            this.SaveChanges();
            return true;
        }

        public bool UpdateEvento(Evento c)
        {
            Evento even = this.Eventos.Find(c.Id);

            even.inicio = c.inicio;
            even.termino = c.termino;
            even.nombre = c.nombre;
            even.lugar = c.lugar;
            even.descripcion = c.descripcion;
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

        public bool DeleteEvento(int id)
        {
            Evento c = this.Eventos.Find(id);
            this.Eventos.Remove(c);
            this.SaveChanges();
            return true;
        }

        public Evento getOneEvento(int id)
        {
            Evento c = this.Eventos.Find(id);
            
            return c;
        }



    }
}