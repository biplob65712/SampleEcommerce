using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleCommerce.Repositories;
using SampleCommerce.Services;
using SampleEcommerce.Examples;
using SampleEcommerce.Models.Category;
using SampleEFCore.Databases;
using SMECommerce.Repositories.Abstractions;
using System.Diagnostics;

namespace SampleEcommerce.Controllers
{
    public class CategoryController : Controller
    {
        ICategoryService _categoryService;
        private ICategoryResolver _categoryResolver;

        public CategoryController(ICategoryService categoryService, ICategoryResolver categoryResolver)
        {
            _categoryService = categoryService;
            _categoryResolver = categoryResolver;

            Debug.WriteLine($" Category Controller -> Category Service Guid: {_categoryService.Guid}");
        }
        // GET: CategoryController
        public ActionResult Index()
        {
            var categories = _categoryService.Get();

            var categoryListItemVms = categories.Select(c => new CategoryListItemVM()
            {
                Id = c.Id, 
                Name = c.Name,
                Code = c.Code,
                Description = c.Description
            });

            return View(categoryListItemVms);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
