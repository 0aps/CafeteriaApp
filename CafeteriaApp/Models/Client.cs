using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;

namespace CafeteriaApp.Models
{
    public class Client
    {
        public int Id { get; set; }
        public String Identificador { get; set; }
        public String Nombre { get; set; }
        public String Cedula { get; set; }
        public String Tipo { get; set; }
        public double Credito { get; set; }
        public DateTime Registro { get; set; }
        public String Estado { get; set; }
    }
}