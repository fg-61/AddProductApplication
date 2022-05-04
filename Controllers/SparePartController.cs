using Microsoft.AspNetCore.Mvc;
using ProductApplication.Models.Entities;
using ProductApplication.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductApplication.Controllers
{
    public class SparePartController : Controller
    {
        private SparePartRepo _sparePartRepo;
        public SparePartController(SparePartRepo sparePartRepo)
        {
            _sparePartRepo = sparePartRepo;
        }
        public IActionResult GetAllSparePart()
        {
            List<SparePart> sparePart = _sparePartRepo.Get().ToList();
            return View(sparePart);
        }

        [HttpPost]
        public IActionResult AddSparePart(SparePart model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("GetAllSparePart", "SparePart");
            }

            SparePart sparePart = new SparePart
            {
                Name = model.Name,
                Code = model.Code,
                UnitPrice = model.UnitPrice,
            };
            _sparePartRepo.Insert(sparePart);

            return RedirectToAction("GetAllSparePart", "SparePart");
        }

        public IActionResult DeleteSparePart(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("GetAllSparePart", "SparePart");
            }

            _sparePartRepo.Delete(id);

            return RedirectToAction("GetAllSparePart", "SparePart");
        }

        [HttpGet]
        public IActionResult UpdateSparePart(Guid id)
        {
            var updatedSparePart = _sparePartRepo.GetById(id);
            if (updatedSparePart != null)
            {
                return View(updatedSparePart);
            }

            return RedirectToAction("GetAllSparePart", "SparePart");
        }

        [HttpPost]
        public IActionResult UpdateSparePart(SparePart model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("GetAllSparePart", "SparePart");
            }
            _sparePartRepo.Update(model);
            return RedirectToAction("GetAllSparePart", "SparePart");
        }

        [HttpGet]
        public IActionResult SparePartDetail(Guid id)
        {
            var sparePartDetail = _sparePartRepo.GetById(id);
            return View(sparePartDetail);
        }

    }
}
