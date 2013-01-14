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
            return View();
        }
        [HttpGet]
        [Authorize]
        public ActionResult EnviarInvitaciones()
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
            //evento.GeographicLocation = new DDay.iCal.GeographicLocation(-33.372909, -70.581080);            
            DDay.iCal.Serialization.iCalendar.iCalendarSerializer serializer = new DDay.iCal.Serialization.iCalendar.iCalendarSerializer(calendario);
            String ruta = Server.MapPath("..\\Content\\Eventos\\");
            serializer.Serialize(ruta+"filename.ics");
            return View();
        }
       
       

   
       
    }
}
