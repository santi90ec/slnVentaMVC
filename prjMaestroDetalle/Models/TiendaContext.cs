using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace prjMaestroDetalle.Models
{
    public class TiendaContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public TiendaContext() : base("name=TiendaContext")
        {
        }

        public System.Data.Entity.DbSet<prjMaestroDetalle.Models.Customer> Customers { get; set; }

        public System.Data.Entity.DbSet<prjMaestroDetalle.Models.Product> Products { get; set; }

        public System.Data.Entity.DbSet<prjMaestroDetalle.Models.Order> Orders { get; set; }

        public System.Data.Entity.DbSet<prjMaestroDetalle.Models.OrderDetail> OrderDetails { get; set; }
    }
}
