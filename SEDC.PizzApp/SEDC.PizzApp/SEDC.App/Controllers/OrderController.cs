using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SEDC.App.Models.DomainModels;
using SEDC.App.Models.ViewModels;

namespace SEDC.App.Controllers
{
    public class OrderController : Controller
    {
        public List<Order> _ordersDb;
        public List<Pizza> _pizzas;

        public OrderController()
        {
            #region List of Users
            User bob = new User()
            {
                FirstName = "Bob",
                LastName = "Bobsky",
                Address = "Bob Street",
                Phone = 080012312345
            };
            User jill = new User()
            {
                FirstName = "Jill",
                LastName = "Wayne",
                Address = "Jill Street",
                Phone = 08006546345
            };
            #endregion


            #region List of Pizzas
            Pizza capri = new Pizza()
            {
                Id = 1,
                Name = "Capricciosa",
                Size = "mini",
                Price = 10.25,
            };
            Pizza toskana = new Pizza()
            {
                Id = 2,
                Name = "Toskana",
                Size = "medium",
                Price = 13.75,
            };
            Pizza peperoni = new Pizza()
            {
                Id = 2,
                Name = "Peperoni",
                Size = "mini-medium",
                Price = 12.25,
            };
            Pizza vegetarian = new Pizza()
            {
                Id = 2,
                Name = "Vegetarian",
                Size = "large",
                Price = 17.5,
            };
            Pizza quattroFormaggi = new Pizza()
            {
                Id = 2,
                Name = "quattro formaggi",
                Size = "medium",
                Price = 14.75,
            };
            _pizzas = new List<Pizza>() { capri, toskana, peperoni };
            #endregion

            #region List of Orders
            Order orderFirst = new Order()
            {
                Id = 1,
                User = bob,
                Pizza = capri,
                Price = capri.Price,
            };
            Order orderSecond = new Order()
            {
                Id = 2,
                User = bob,
                Pizza = toskana,
                Price = toskana.Price,
            };
            Order orderThird = new Order()
            {
                Id = 3,
                User = jill,
                Pizza = peperoni,
                Price = peperoni.Price,
            };
            _ordersDb = new List<Order>() { orderFirst, orderSecond, orderThird };
            #endregion
        }
        [Route("Orders")]
        public IActionResult Index()
        {
            ViewData.Add("Title", "Welcome to the Orders page!");
            ViewBag.Title = "Welcome to the Orders page!";
            Order firstOrder = _ordersDb[0];
            OrdersViewModel ordersViewModel = new OrdersViewModel()
            {
                FirstPizza = firstOrder.Pizza.Name,
                NumberOfOrders = _ordersDb.Count,
                FirstPersonName = $"{firstOrder.User.FirstName} {firstOrder.User.LastName}",
                Order = _ordersDb
            };
            return View(ordersViewModel);
        }
        public IActionResult Details(int? id)
        {
            #region ViewBag and ViewData
            //ViewData.Add("Title", "These are your orders:");
            //ViewData["Title"] = "These are your orders:";
            #endregion
            #region FirstOrDefault solution
            Order order = _ordersDb.FirstOrDefault(x => x.Id == id);
            if (order != null)
            {
                ViewBag.Title = $"This is order no. {order.Id}";
                return View(order);
            }
            return RedirectToAction("Index");
            #endregion
            #region try/catch solution
            //try
            //{
            //    Order order = _ordersDb.Find(x => x.Id == id);
            //    ViewBag.Title = $"This is order no. {order.Id}";
            //    if (order != null) return View(order);
            //}
            //catch
            //{
            //    return RedirectToAction("Index");
            //}
            //return RedirectToAction("Index");
            #endregion
            #region Redirecting to a different controller
            //return RedirectToAction("Index", "Home");
            #endregion
        }
    }
}