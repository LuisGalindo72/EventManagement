using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventManagement.Models
{
    public class Evento
    {
        public int ID { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Lugar { get; set; }
        public DateTime Fecha { get; set; }
        public int UsuarioID { get; set; }

        // Relación con la clase Usuario
        public Usuario Usuario { get; set; }
    }
}