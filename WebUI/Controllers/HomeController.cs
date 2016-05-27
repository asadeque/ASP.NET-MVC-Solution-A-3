using MidTermSolution.Contracts.Data;
using MidTermSolution.Contracts.Repositories;
using MidTermSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        IRepositoryBase<Product> products;
        IRepositoryBase<Customer> customers;
        IRepositoryBase<Order> orders;

        public HomeController(IRepositoryBase<Customer> customers, IRepositoryBase<Product> products, IRepositoryBase<Order> orders)
        {
            this.customers = customers;
            this.products = products;
            this.orders = orders;
        }

        //public ActionResult Index()
        //{
        //    CustomerRepository customers = new CustomerRepository(new DataContext());
        //    ProductRepository products = new ProductRepository(new DataContext());
        //    Orders orders = new Orders(new DataContext());
        //    return View();
        //}

        public ActionResult Index()
        {
            var productList = products.GetAll();

            return View(productList);
            //return View();
        }

        public ActionResult Details(int id)
        {
            var product = products.GetById(id);
            return View(product);
        }

        public ActionResult About()
        {
            ViewBag.Message = "KAS believes in quality.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "We are committed for quick service.";

            return View();
        }
    }
}
