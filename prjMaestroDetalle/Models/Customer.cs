using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace prjMaestroDetalle.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string CompanyName { get; set; }

        public string ContactName { get; set; }

        public virtual ICollection<Order> Orders  { get; set; }
    }
}