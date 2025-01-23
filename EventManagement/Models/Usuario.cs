using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventManagement.Models
{
    public class Usuario
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public int RolID { get; set; }

        // Relación con la clase Rol
        public Rol Rol { get; set; }
    }
}
