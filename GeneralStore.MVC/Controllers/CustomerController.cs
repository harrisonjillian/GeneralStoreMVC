using GeneralStore.MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace GeneralStore.MVC.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _dbCustomer = new ApplicationDbContext();

        // GET: Customer
        public ActionResult Index()
        {
            return View(_dbCustomer.Customers.ToList());
        }

        // GET: Customer

        public ActionResult Create()
        {
            return View();
        }

        // GET: Customer
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _dbCustomer.Customers.Add(customer);
                _dbCustomer.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Delete
        // Customer/Delete/{id}
       // [HttpDelete]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Customer customer = _dbCustomer.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST : Delete
        // Customer/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Customer customer = _dbCustomer.Customers.Find(id);
            _dbCustomer.Customers.Remove(customer);
            _dbCustomer.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Edit
        // Product/Edit/{id}
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = _dbCustomer.Customers.Find(id);
            if (customer == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            return View(customer);
        }

        // POST: Edit // Porduct / Edit/{id}
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _dbCustomer.Entry(customer).State = EntityState.Modified;
                _dbCustomer.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }
        // GET : Details
        // Product/Details/{id}
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = _dbCustomer.Customers.Find(id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }

    }

}
