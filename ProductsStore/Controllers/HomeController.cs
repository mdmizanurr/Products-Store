using Microsoft.AspNetCore.Mvc;
using ProductsStore.Models;
using ProductsStore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsStore.Controllers
{
    public class HomeController : Controller
    {
        private IRepository _repo;

        public HomeController(IRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
           // System.Console.Clear();
            return View(_repo.Products as IQueryable<Product>);
        }


        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            _repo.AddProduct(product);
            return RedirectToAction(nameof(Index));
        }

    }
}
