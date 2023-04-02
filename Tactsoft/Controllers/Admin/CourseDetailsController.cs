using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tactsoft.Core.Entities;
using Tactsoft.Service.DbDependencies;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class CourseDetailsController : Controller
    {
        private readonly ILessonService _lessonService;
        private readonly ICourseService _courseService;
        private readonly AppDbContext _context;
        public CourseDetailsController(ILessonService lessonService, ICourseService courseService, AppDbContext context)
        {
            this._lessonService = lessonService;
            this._courseService = courseService;
            this._context = context;
        }
        // GET: CourseDetailsController
        public async Task<IActionResult> Index()
        {
            ViewData["CourseId"] = _courseService.Dropdown();
            var lesson = await _lessonService.GetAllAsync(x => x.Course);
            return View(lesson);
        }
       
        // GET: CourseDetailsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CourseDetailsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CourseDetailsController/Create
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

        // GET: CourseDetailsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CourseDetailsController/Edit/5
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

        // GET: CourseDetailsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CourseDetailsController/Delete/5
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
