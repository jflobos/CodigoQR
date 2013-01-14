using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Net.Mail;

namespace qr.Models
{
    [Serializable]
    public class Evento
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "nombre")]
        public string nombre { get; set; }

        [Display(Name = "lugar")]
        public string lugar { get; set; }

        [Required]
        [Display(Name = "inicio")]
        public DateTime inicio { get; set; }

        [Required]
        [Display(Name = "termino")]
        public DateTime termino { get; set; }

        [Required]
        [Display(Name = "descripcion")]
        public string descripcion { get; set; }        
    }
}