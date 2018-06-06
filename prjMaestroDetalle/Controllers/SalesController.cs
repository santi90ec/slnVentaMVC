using prjMaestroDetalle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace prjMaestroDetalle.Controllers
{
    public class SalesController : Controller
    {
        TiendaContext db = new TiendaContext();

        // GET: Sales
        public ActionResult NewOrder()
        {
            OrderView orderview = new OrderView();
            orderview.Customer = new CustomerOrder();
            orderview.Products = new List<ProductOrder>();
            Session["OrderView"] = orderview;
            var lista = db.Customers.ToList();
            ViewBag.CustomerId = new SelectList(lista, "CustomerId", "CompanyName");
            return View(orderview);
        }
        [HttpPost]
        public ActionResult NewOrder(OrderView orderview)
        {
            orderview = Session["OrderView"] as OrderView;
            int idcustemer = int.Parse(Request["CustomerId"]);
            DateTime dateorder = Convert.ToDateTime(Request["Customer.OrderDate"]);
            Order neworder = new Order()
            {
                CustomerId= idcustemer,
                OrderDate = dateorder
            };
            db.Orders.Add(neworder);
            db.SaveChanges();
            int lastorderid = db.Orders.ToList().Select(o => o.OrderId).Max();
          
            foreach(ProductOrder item in orderview.Products)
            {
                var detail = new OrderDetail()
                {
                    OrderId = lastorderid,
                    ProductId = item.ProductId,
                    Quantity =item.Quantity
                };
                db.OrderDetails.Add(detail);
                
            }
            db.SaveChanges();

            orderview = Session["OrderView"] as OrderView;
            var lista = db.Customers.ToList();
            ViewBag.CustomerId = new SelectList(lista, "CustomerId", "CompanyName");
            return View(orderview);
        }
        [HttpGet]
        public ActionResult addProduct()
        {
            var lista2 = db.Products.ToList();
            ViewBag.ProductId = new SelectList(lista2, "ProductId", "ProductName");
            return View();

        }
        [HttpPost]
        public ActionResult addProduct(ProductOrder productorder)
        {
            var orderview = Session["OrderView"] as OrderView;
            var productid = int.Parse(Request["ProductId"]);
            var product = db.Products.Find(productid);
            productorder = new ProductOrder()
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                UnitPrice = product.UnitPrice,
                Quantity = int.Parse(Request["Quantity"])
            };
            orderview.Products.Add(productorder);
            var listaCliente = db.Customers.ToList();
            ViewBag.CustomerId = new SelectList(listaCliente, "CustomerId", "CompanyName");
            return View("NewOrder", orderview);
        }
    }
}