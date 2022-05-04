using Microsoft.AspNetCore.Mvc;
using ProductApplication.Models.Entities;
using ProductApplication.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductApplication.Controllers
{
    //[Authorize]
    public class ProductController : Controller
    {
        private ProductRepo _productRepo;
        public ProductController(ProductRepo productRepo)
        {
            _productRepo = productRepo;
        }
        public IActionResult GetAllProduct()
        {
            List<Product> products = _productRepo.Get().ToList();
            return View(products);
        }
        [HttpPost]
        public IActionResult AddProduct(Product model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("GetAllProduct", "Product");
            }

            Product product = new Product
            {
                Name = model.Name,
                Code = model.Code,
                UnitPrice = model.UnitPrice,
            };
            _productRepo.Insert(product);

            return RedirectToAction("GetAllProduct", "Product");
        }

        public IActionResult DeleteProduct(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("GetAllProduct", "Product");
            }

            _productRepo.Delete(id);

            return RedirectToAction("GetAllProduct", "Product");
        }

        [HttpGet]
        public IActionResult UpdateProduct(Guid id)
        {
            var updatedProduct = _productRepo.GetById(id);
            if (updatedProduct != null)
            {
                return View(updatedProduct);
            }

            return RedirectToAction("GetAllProduct", "Product");
        }

        [HttpPost]
        public IActionResult UpdateProduct(Product model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("GetAllProduct", "Product");
            }
            _productRepo.Update(model);
            return RedirectToAction("GetAllProduct", "Product");
        }

        [HttpGet]
        public IActionResult ProductDetail(Guid id)
        {
            var productDetail = _productRepo.GetById(id);
            return View(productDetail);
        }
    }
}
