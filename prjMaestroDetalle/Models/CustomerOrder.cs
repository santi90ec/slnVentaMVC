using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjMaestroDetalle.Models
{
    public class CustomerOrder:Customer
    {
        public DateTime OrderDate { get; set; }
    }
}