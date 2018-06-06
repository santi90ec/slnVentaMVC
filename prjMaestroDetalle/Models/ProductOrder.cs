using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjMaestroDetalle.Models
{
    public class ProductOrder:Product
    {
        public int Quantity { get; set; }

        public decimal Multiplicacion { get {return UnitPrice* Quantity; } }
    }
}