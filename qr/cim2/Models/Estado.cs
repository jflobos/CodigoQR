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
    public class Estado
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "nombre")]
        public string nombre { get; set; }        
    }
}