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
        private readonly  IRepository _repo;

        public HomeController(IRepository repo) { _repo = repo;  }

        public IActionResult Index()
        {
            return View(_repo.Products as IEnumerable<Product>);
        }


        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            _repo.AddProduct(product);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult UpdateProduct(long key)
        {
            return View(_repo.GetProduct(key));
        }




        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            _repo.UpdateProduct(product);
            return RedirectToAction(nameof(Index));
        }

    }
}
