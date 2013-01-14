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
    public class Invitacion
    {
        
        public int Id { get; set; }

        [Required]
        [Display(Name = "nombre")]
        public string nombre { get; set; }

        [Display(Name = "apellido")]
        public string apellido { get; set; }

        [Required]
        [Display(Name = "mail")]
        public string mail { get; set; }

        [Required]
        [Display(Name = "estado_id")]
        public int estado_id { get; set; }

        [Required]
        [Display(Name = "evento_id")]
        public int evento_id { get; set; }
        
    }
}