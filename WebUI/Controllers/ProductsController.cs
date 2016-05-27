using MidTermSolution.Contracts.Repositories;
using MidTermSolution.Models;
using MidTermSolution.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class ProductsController : Controller
    {
        IRepositoryBase<Customer> customers;
        IRepositoryBase<Product> products;
        IRepositoryBase<Basket> baskets;
        IRepositoryBase<BasketItem> basketitems;
        BasketService basketService;

        public ProductsController(IRepositoryBase<Customer> customers, IRepositoryBase<Product> products, IRepositoryBase<Basket> baskets, IRepositoryBase<BasketItem> basketitems)
        {
            this.customers = customers;
            this.products = products;
            this.baskets = baskets;
            this.basketitems = basketitems;
            basketService = new BasketService(this.baskets, this.basketitems);
        }
        // GET: Products
        public ActionResult AddToBasket(int id)
        {
            basketService.AddToBasket(this.HttpContext, id, 1);//always add one to the basket
            return RedirectToAction("BasketSummary");
        }
        //new functions
        public ActionResult QuantityInBasket()
        {
            var result = basketService.QuantityInBasket(this.HttpContext);
            return Json(result);
        }
        //new basket summary method
        public ActionResult BasketSummary()
        {
            ViewBag.QuantityInBasket = basketService.QuantityInBasket(this.HttpContext);
            ViewBag.AmountInBasket = basketService.AmountInBasket(this.HttpContext);
            var model = basketService.GetBasket(this.HttpContext);
            return View(model.BasketItems);
        }
        public ActionResult DeleteFromBasket(int id)
        {
            BasketItem basketItem = basketService.GetBasketItemById(id);
            if (basketItem == null)
            {
                return HttpNotFound();
            }
            return View(basketItem);
        }

        [HttpPost, ActionName("DeleteFromBasket")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            basketService.RemoveFromBasket(id);
            return RedirectToAction("BasketSummary");
        }
        public ActionResult BasketItemDetails(int? id)
        {
            var product = products.GetById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        public ActionResult BasketItemAdd(string searchString, string sortOrder)
        {
            var product = products.GetAll();

            if (!String.IsNullOrEmpty(searchString))
            {
                product = product.Where(s => s.ProductDescription.Contains(searchString));
            }

            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.PriceSortParm = sortOrder == "Price" ? "price_desc" : "Price";

            switch (sortOrder)
            {
                case "name_desc":
                    product = product.OrderByDescending(s => s.ProductDescription);
                    break;
                case "Price":
                    product = product.OrderBy(s => s.Price);
                    break;
                case "price_desc":
                    product = product.OrderByDescending(s => s.Price);
                    break;
                default:
                    product = product.OrderBy(s => s.ProductDescription);
                    break;
            }

            return View(product);
        }
        // GET: list with filter
        public ActionResult Index(string searchString, string sortOrder)
        {
            var product = products.GetAll();

            if (!String.IsNullOrEmpty(searchString))
            {
                product = product.Where(s => s.ProductDescription.Contains(searchString));
            }

            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.PriceSortParm = sortOrder == "Price" ? "price_desc" : "Price";

            switch (sortOrder)
            {
                case "name_desc":
                    product = product.OrderByDescending(s => s.ProductDescription);
                    break;
                case "Price":
                    product = product.OrderBy(s => s.Price);
                    break;
                case "price_desc":
                    product = product.OrderByDescending(s => s.Price);
                    break;
                default:
                    product = product.OrderBy(s => s.ProductDescription);
                    break;
            }

            return View(product);
        }

        // GET: /Details/5
        public ActionResult Details(int? id)
        {
            var product = products.GetById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        public ActionResult EditBasketItem(int id = 0)
        {
            BasketItem item = basketService.GetBasketItem(this.HttpContext, id);

            var prdlst = products.GetAll();
            var query = from p in prdlst
                        select p.ProductID;

            ViewBag.pl = query.ToList();
            return View(item);
        }
        [HttpPost]
        public ActionResult EditBasketItem(BasketItem item)
        {
            basketitems.Update(item);
            basketitems.Commit();

            return RedirectToAction("BasketSummary");
        }
    }
}
