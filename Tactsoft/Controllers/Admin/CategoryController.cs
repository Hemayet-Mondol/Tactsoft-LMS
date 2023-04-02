using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: CategoryController
        public async Task<IActionResult> Index()
        {
            var cate = await _categoryService.GetAllAsync();
            return View(cate);
        }

        // GET: CategoryController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var cat = await _categoryService.FindAsync(id);
            return View(cat);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _categoryService.InsertAsync(category);
                }
                TempData["successAlert"] = "Category save successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var cat = await _categoryService.FindAsync(id);
            return View(cat);
        }

        // POST: DepartmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _categoryService.UpdateAsync(category);
                }

                TempData["successAlert"] = "Category update successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var cat = await _categoryService.FindAsync(id);
            return View(cat);
        }

        // POST: DepartmentController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            try
            {
                var cat = await _categoryService.FindAsync(id);
                if (cat != null)
                {
                    await _categoryService.DeleteAsync(cat);
                }
                TempData["successAlert"] = "Category delete successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
