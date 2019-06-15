using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TestA8.Models;

namespace TestA8.Controllers
{
    public class PizzaController : Controller
    {
        public ActionResult Menu()
        {
            return View(Models.Menu.Read());
        }

        public ActionResult EnterOrder()
        {
            ViewData["Menu"] = new SelectList(Models.Menu.Read(true));
            return View();
        }

        public ActionResult GetAllOrders()
        {
            return View(OrderSystem.GetAllOrders());
        }

        public ActionResult RemoveOrder(long ticks)
        {
            OrderSystem.RemoveOrder(OrderSystem.GetAllOrders().Find(o => o.OrderTime.Ticks == ticks));

            return RedirectToAction("GetAllOrders", "Pizza");
        }

        [HttpPost]
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public ActionResult EnterOrder(string Pizza, DateTime PickupTime, bool Paid)
        {
            ViewBag.Success = OrderSystem.EnterOrder(Models.Menu.Read().Find(p => p.Name == Pizza), PickupTime, Paid);

            ViewData["Menu"] = new SelectList(Models.Menu.Read(true));
            return View();
        }
    }
}