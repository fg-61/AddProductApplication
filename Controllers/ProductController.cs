using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        private readonly ProductRepo _productRepo;
        private readonly SparePartRepo _sparePartRepo;
        private readonly ProductSparePartRepo _productSparePartRepo;
        public ProductController(ProductRepo productRepo,
            SparePartRepo sparePartRepo,
            ProductSparePartRepo productSparePartRepo)
        {
            _productRepo = productRepo;
            _sparePartRepo = sparePartRepo;
            _productSparePartRepo = productSparePartRepo;
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

        [HttpGet]
        public IActionResult AddSparePartToProduct(Guid id)
        {
            //List<SparePart> spareParts = 
            //    _sparePartRepo.Get().ToList();
            var sparePartsOfProduct = _sparePartRepo.GetSparePartsOfProduct(id).ToList();
            var spareParts = _sparePartRepo.Get().ToList();
            List<SparePart> sparePartNotAdded = new List<SparePart>();

            //foreach(var sparePart in spareParts)
            //{
            //    if(sparePart.Any(sparePartsOfProduct))
            //    sparePartNotAdded.Add()
            //}

            ViewBag.ProductId = id;
            return View();
        }

        [HttpPost]
        public IActionResult AddSparePartToProduct(string[] selectedSparePart, Guid id)
        {
            foreach(var sparePartString in selectedSparePart)
            {
                Guid sparePartId = Guid.Parse(sparePartString);
                _productSparePartRepo.Insert(new ProductSparePart
                {
                    SparePartId = sparePartId,
                    ProductId = id
                });
            }
            return RedirectToAction("AddSparePartToProduct", "Product", id);
        }
    }
}
