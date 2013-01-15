using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using qr.Models;
namespace qr.Controllers
{
    public class HomeController : Controller
    {
        public static string urlPath = "http://cimuaicl001.web703.discountasp.net/";
        public static string serverPath = "";

        public ActionResult Index()
        {  
            SetConnectionStrings();
            return View();
        }

          /// <summary>
        /// Setea los strings de conexion que va a utilizar la aplicacion MVC
        /// </summary>
        private void SetConnectionStrings()
        {

            //Si es una llamada local, utiliza los strings locales.
            if (this.Request.IsLocal)
            {
                urlPath = System.Web.Configuration.WebConfigurationManager.AppSettings.GetValues("mainPath").First();
                serverPath = System.Web.Configuration.WebConfigurationManager.AppSettings.GetValues("mainMachPath").First();
              
            }
            //Si no es una llamada local, utiliza los strings de conexion que se utilizan para el deploy de la apl
            else
            {
                urlPath = System.Web.Configuration.WebConfigurationManager.AppSettings.GetValues("mainPathDeploy").First();
                serverPath = System.Web.Configuration.WebConfigurationManager.AppSettings.GetValues("mainMachPathDeploy").First();

            }
        
        
        }




        [HttpGet]
        [Authorize]
        public ActionResult Eventos()
        {
              return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult Invitados()
        {
            return View();
        }
        [HttpGet]
        [Authorize]
        public ActionResult Informacion()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult Estadisticas()
        {
            EventoEntities evEtn = new EventoEntities();

            List<Evento> list = evEtn.getEventos();
            ViewBag.eventos = list;

            return View();
        }


        [HttpPost]
        [Authorize]
        public ActionResult Estadisticas(string Evento)
        {
            InvitacionEntities invent = new InvitacionEntities();
            EstadoEntities est= new EstadoEntities();
            EventoEntities eventoEnt=new EventoEntities();
            List<Invitacion> lsita = invent.estadiscticabase(int.Parse(Evento));
            List<Estado> listaestados = est.getEstados();

            Dictionary<int, string> estados = new Dictionary<int, string>();

            foreach (Estado estado in listaestados)
            {
                estados.Add(estado.Id, estado.nombre);
            }


            Dictionary<string, int> estadis = new Dictionary<string, int>();

            foreach(Estado esta in listaestados){

                estadis.Add(esta.nombre, 0);

            }

            foreach (Invitacion invita in lsita)
            {

                if (estadis.ContainsKey(estados[invita.estado_id]))
                {
                    int total= estadis[estados[invita.estado_id]] + 1;
                    estadis[estados[invita.estado_id]] = total;

                }
                else
                {
                    estadis.Add(estados[invita.estado_id], 1);
                }

            }

            ViewBag.evento = eventoEnt.getOneEvento(int.Parse(Evento)).nombre;
            ViewBag.est = estadis;
            int a = 0;
            
            return View("VerEstadistica");
        }

        [HttpGet]
        [Authorize]
        public ActionResult EnviarInvitaciones()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult ConfirmarInvitacion(string idinvi,string estadoel)
        {
            int idinv = int.Parse(idinvi);
            int estado = int.Parse(estadoel);
            InvitacionEntities invEnt= new InvitacionEntities();
            Invitacion invi = invEnt.getOneInvitacion(idinv);

            invi.estado_id = estado;
            invEnt.UpdateInvitacion(invi);

            EventoEntities evenEnt = new EventoEntities();

            Evento evento = evenEnt.getOneEvento(invi.evento_id);

            ViewBag.evento = evento;
            ViewBag.invitacio = invi;

            if (estado == 2)
            {
                return View();
            }
            if (estado == 3)
            {
                return View("Respuesta");
            }
            if (estado == 4)
            {
                return View("Respuesta");
            }

            return View("Respuesta");

        }


        [HttpGet]
        [Authorize]
        public ActionResult Acreditar(string idinv)
        {
            int id = int.Parse(idinv);
            InvitacionEntities invEnt = new InvitacionEntities();
            Invitacion invit = invEnt.getOneInvitacion(id);

            EventoEntities evenEnt = new EventoEntities();
            Evento evento = evenEnt.getOneEvento(invit.evento_id);

            invit.estado_id = 5;
            invEnt.UpdateInvitacion(invit);

            ViewBag.invit = invit;
            ViewBag.evento = evento;

            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult Respuesta()
        {
            return View();
        }
    


        [HttpGet]
        public ActionResult TestIcal()
        {
            DDay.iCal.iCalendar calendario = new DDay.iCal.iCalendar();
            DDay.iCal.Event evento = calendario.Create<DDay.iCal.Event>();
            evento.Start = new DDay.iCal.iCalDateTime(System.DateTime.Now);
             evento.Summary = "Presentacion Demo";
            evento.End = new DDay.iCal.iCalDateTime(System.DateTime.Now).AddHours(2);
            evento.GeographicLocation = new DDay.iCal.GeographicLocation(-33.372909, -70.581080);            
             DDay.iCal.Serialization.iCalendar.iCalendarSerializer serializer = new DDay.iCal.Serialization.iCalendar.iCalendarSerializer(calendario);
            String ruta = Server.MapPath("..\\Content\\Eventos\\");
            serializer.Serialize(ruta+"filename.ics");
            return View();
        }
       
       

   
       
    }
}
