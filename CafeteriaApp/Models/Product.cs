using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CafeteriaApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public String Codigo { get; set; }

        public String Descripcion { get; set; }
        public String  Marca { get; set; }
        public double Costo { get; set; }
        public String Proveedor { get; set; }
        public int Existencia { get; set; }
        public String Estado { get; set; }
    }
}