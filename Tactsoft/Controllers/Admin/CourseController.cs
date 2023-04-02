using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;
        private readonly ICategoryService _categoryService;

        public CourseController(ICourseService courseService, ICategoryService categoryService)
        {
            _courseService = courseService;
            _categoryService = categoryService;
        }

        // GET: CourseController
        public async Task<IActionResult> Index()
        {
            ViewData["CourseId"] = _courseService.Dropdown();
            var course = await _courseService.GetAllAsync(x => x.Category);
            return View(course);
        }

        // GET: CourseController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var employee = await _courseService.FindAsync(m => m.Id == id, e => e.Category);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: CourseController/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = _categoryService.Dropdown();
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Course course)
        {
            if (ModelState.IsValid)
            {


                await _courseService.InsertAsync(course);
                TempData["successAlert"] = "Course save successfull.";
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = _categoryService.Dropdown();


            TempData["errorAlert"] = "Operation failed.";
            return View(course);
        }

        // GET: CourseController/Edit/5
        public async Task<IActionResult> Edit(long id)
        {
            var course = await _courseService.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = _categoryService.Dropdown();


            return View(course);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(Course course)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var cour = await _courseService.FindAsync(course.Id);

                    cour.CourseName = course.CourseName;
                    cour.Duration = course.Duration;
                    cour.CourseFee = course.CourseFee;
                    cour.CategoryId = course.CategoryId;
                    cour.CoursePageUrl = course.CoursePageUrl;
                    await _courseService.UpdateAsync(cour);
                    TempData["successAlert"] = "Course update successfull.";
                }
                catch
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = _categoryService.Dropdown();


            TempData["errorAlert"] = "Operation failed.";
            return View(course);
        }

        // GET: CourseController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var course =await _courseService.FindAsync(m => m.Id == id, e => e.Category);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: CourseController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var course = await _courseService.FindAsync(id);
            if (course != null)
            {
                await _courseService.DeleteAsync(course);
                TempData["successAlert"] = "Course remove successfull.";
            }

           /* TempData["errorAlert"] = "Operation failed.";*/
            return RedirectToAction(nameof(Index));
        }
    }
}
