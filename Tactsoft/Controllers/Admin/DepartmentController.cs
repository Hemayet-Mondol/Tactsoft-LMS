using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            this._departmentService = departmentService;
        }
        // GET: DepartmentController
        public async Task<IActionResult> Index()
        {
            var departments = await _departmentService.GetAllAsync();
            return View(departments);
        }

        // GET: DepartmentController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var department = await _departmentService.FindAsync(id);
            return View(department);
        }

        // GET: DepartmentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Department department)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    await _departmentService.InsertAsync(department);
                }
                TempData["successAlert"] = "Department save successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DepartmentController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var department = await _departmentService.FindAsync(id);
            return View(department);
        }

        // POST: DepartmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Department department)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _departmentService.UpdateAsync(department);
                }

                TempData["successAlert"] = "Department update successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DepartmentController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var department = await _departmentService.FindAsync(id);
            return View(department);
        }

        // POST: DepartmentController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            try
            {
                var department = await _departmentService.FindAsync(id);
                if (department != null)
                {
                    await _departmentService.DeleteAsync(department);
                }
                TempData["successAlert"] = "Department delete successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
