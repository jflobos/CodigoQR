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
    public class Correo
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "header")]
        public string header { get; set; }

        [Display(Name = "footer")]
        public string footer { get; set; }

        [Required]
        [Display(Name = "html")]
        public DateTime html { get; set; }

        [Required]
        [Display(Name = "invitacion_id")]
        public DateTime invitacion_id { get; set; }
    }
}