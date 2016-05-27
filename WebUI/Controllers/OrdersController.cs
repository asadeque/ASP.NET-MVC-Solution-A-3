using MidTermSolution.Contracts.Repositories;
using MidTermSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class OrdersController : Controller
    {
        // GET: Orders
         IRepositoryBase<Order> orders;


        public OrdersController(IRepositoryBase<Order>orders)
        {

            this.orders = orders;
        }

        public ActionResult Index()
        {
            var model = orders.GetAll();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var order = orders.GetById(id);
            return View(order);
        }


    }
}
