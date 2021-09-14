using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using proyecto3trimestresena.Models;

namespace proyecto3trimestresena.Models
{
    
    public class Constancia
    {
        

        public DateTime fechaCompra { get; set; }
        public int totalCompra { get; set; }
        public int productoProducto_compra { get; set; }
        public int cantidadProducto_compra { get; set; }
        public string nombreProducto { get; set; }
    } 

}