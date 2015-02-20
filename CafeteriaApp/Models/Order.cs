using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CafeteriaApp.Models
{
    public class Order
    {
        public int Id { get; set; }
        public String Cliente { get; set; }

        public int Articulos { get; set; }
        public String Empleado { get; set; }

        public int Total { get; set; }

        public DateTime Fecha { get; set; }

        public Boolean Estado { get; set; }
    }
}