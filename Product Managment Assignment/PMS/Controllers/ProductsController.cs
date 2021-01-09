using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PMS.Models;
using PMS.ViewModels;
using System.Data.Entity;

namespace PMS.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext _context;

        public ProductsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ViewResult Index()
        {
            //var products = _context.Products.Include(p => p.Category).ToList();
            //products

            return View();
        }


        public ViewResult New()
        {
            var categories = _context.Categories.ToList();

            var viewModel = new ProductFormViewModel
            {
                Categories = categories
            };

            return View("ProductForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var product = _context.Products.SingleOrDefault(c => c.Id == id);

            if (product == null)
                return HttpNotFound();

            var viewModel = new ProductFormViewModel(product)
            {
                Categories = _context.Categories.ToList()
            };

            return View("ProductForm", viewModel);
        }


        public ActionResult Details(int id)
        {
            var product = _context.Products.Include(p => p.Category).SingleOrDefault(p => p.Id == id);

            if (product == null)
                return HttpNotFound();

            return View(product);
        }

        // GET: Products/Random
        public ActionResult Random()
        {
            var product = new Product() { Name = "Motorola ZX2" };
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" }
            };

            var viewModel = new RandomProductViewModel
            {
                Product = product,
                Customers = customers
            };

            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Product product)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ProductFormViewModel(product)
                {
                    Categories = _context.Categories.ToList()
                };

                return View("ProductForm", viewModel);
            }
            if (product.Id == 0)
            {
                product.DateAdded = DateTime.Now;
                _context.Products.Add(product);
            }
            else
            {
                var productInDb = _context.Products.Single(m => m.Id == product.Id);
                productInDb.Name = product.Name;
                productInDb.CategoryId = product.CategoryId;
                productInDb.NumberInStock = product.NumberInStock;
                productInDb.ReleaseDate = product.ReleaseDate;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Products");
        }
    }
}