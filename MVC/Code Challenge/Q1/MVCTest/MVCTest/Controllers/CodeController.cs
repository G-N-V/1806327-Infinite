using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCTest.Models;

namespace MVCTest.Controllers
{
    public class CodeController : Controller
    {
        private northwindEntities db = new northwindEntities();

        public ActionResult CustomersInGermany()
        {
            var customersInGermany = db.Customers.Where(c => c.Country == "Germany").ToList();
            return View(customersInGermany);
        }

        public ActionResult CustomerDetails()
        {
            var customerDetails = db.Orders
                .Where(o => o.OrderID == 10248)
                .Select(o => o.Customer)
                .FirstOrDefault();
            return View(customerDetails);
        }
        // GET: Code
        public ActionResult Index()
        {
            return View();
        }
    }
}