using MidTermSolution.Contracts.Repositories;
using MidTermSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class AdminController : Controller
    {
        IRepositoryBase<Customer> customers;
        IRepositoryBase<Product> products;
        IRepositoryBase<Order> orders;

        public AdminController(IRepositoryBase<Customer> customers, IRepositoryBase<Product> products, IRepositoryBase<Order>orders)
        {
            this.customers = customers;
            this.products = products;
            this.orders = orders;
        }


        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProductsList()
        {
            var model = products.GetAll();
            return View(model);
        }

        public ActionResult CreateProduct()
        {
            var model = new Product();
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateProduct(Product product)
        {
            products.Insert(product);
            products.Commit();
            return RedirectToAction("ProductsList");
        }




        public ActionResult CustomersList()
        {
            var model = customers.GetAll();
            return View(model);
        }

        public ActionResult CreateCustomer()
        {
            var model = new Customer();
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateCustomer(Customer customer)
        {
            customers.Insert(customer);
            customers.Commit();
            return RedirectToAction("CustomersList");
        }

        public ActionResult OrdersList()
        {
            var model = orders.GetAll();
            return View(model);
        }

        public ActionResult CreateOrder()
        {
            var model = new Order();
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateOrder(Order order)
        {
            orders.Insert(order);
            orders.Commit();
            return RedirectToAction("OrdersList");
        }




        //product detail method
        public ActionResult DetailsProduct(int id)
        {
            var product = products.GetById(id);
            return View(product);
        }

        //customer detail method
        public ActionResult DetailsCustomer(int id)
        {
            var customer = customers.GetById(id);
            return View(customer);
        }

        //order detail method
        public ActionResult DetailsOrder(int id)
        {
            var order = orders.GetById(id);
            return View(order);
        }

        //edit product method
        public ActionResult EditProduct(int id)
        {
            Product product = products.GetById(id);
            return View(product);
        }
        [HttpPost]
        public ActionResult EditProduct(Product product)
        {
            products.Update(product);
            products.Commit();

            return RedirectToAction("ProductsList");
        }
        //edit customer method
        public ActionResult EditCustomer(int id)
        {
            Customer customer = customers.GetById(id);
            return View(customer);
        }
        [HttpPost]
        public ActionResult EditCustomer(Customer customer)
        {
            customers.Update(customer);
            customers.Commit();

            return RedirectToAction("CustomersList");
        }

        //edit order method
        public ActionResult EditOrder(int id)
        {
            Order Order = orders.GetById(id);
            return View(Order);
        }
        [HttpPost]
        public ActionResult EditOrder(Order Order)
        {
            orders.Update(Order);
            orders.Commit();

            return RedirectToAction("OrdersList");
        }
        //delete product method
        public ActionResult DeleteProduct(int id)
        {
            Product product = products.GetById(id);
            return View(product);
        }

        [HttpPost, ActionName("DeleteProduct")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteProductConfirm(int id)
        {
            products.Delete(products.GetById(id));
            //products.Delete(product);
            products.Commit();
            return RedirectToAction("ProductsList");
        }
        //delete customer method
        public ActionResult DeleteCustomer(int id)
        {
            Customer customer = customers.GetById(id);
            return View(customer);
        }

        [HttpPost, ActionName("DeleteCustomer")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCustomerConfirm(int id)
        {
            customers.Delete(customers.GetById(id));
            customers.Commit();
            return RedirectToAction("CustomerList");
        }

        //delete order method
        public ActionResult DeleteOrder(int id)
        {
            Order Order = orders.GetById(id);
            return View(Order);
        }

        [HttpPost, ActionName("DeleteOrder")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteOrderConfirm(int id)
        {
            orders.Delete(orders.GetById(id));
            //Orders.Delete(Order);
            orders.Commit();
            return RedirectToAction("OrderList");
        }
    }
}
