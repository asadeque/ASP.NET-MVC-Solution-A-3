using MidTermSolution.Contracts.Repositories;
using MidTermSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        IRepositoryBase<Customer> customers;


        public CustomersController(IRepositoryBase<Customer>customers)
        {

            this.customers = customers;
        }

        public ActionResult Index()
        {
            var model = customers.GetAll();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var customer = customers.GetById(id);
            return View(customer);
        }


    }
}
