using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tactsoft.Service.DbDependencies;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class StudentAttendenceController : Controller
    {
        private readonly ILessonService _lessonService;
        private readonly ICourseService _courseService;
        private readonly AppDbContext _context;
        private readonly IBatchService _batchService;
        private readonly IStudentService _studentService;
        public StudentAttendenceController(ILessonService lessonService, ICourseService courseService, IBatchService batchService, AppDbContext context, IStudentService studentService)
        {
            this._lessonService = lessonService;
            this._courseService = courseService;
            this._batchService = batchService;
            this._context = context;
            this._studentService = studentService;
        }
        // GET: StudentAttendenceController
        public async Task<IActionResult> Index()
        {
            ViewData["CourseId"] = _courseService.Dropdown();
            ViewData["BatchId"] = _batchService.Dropdown();
            var lesson = await _studentService.GetAllAsync(x => x.Course, x => x.Batch);
            return View(lesson);
        }

        // GET: StudentAttendenceController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StudentAttendenceController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentAttendenceController/Create
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

        // GET: StudentAttendenceController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StudentAttendenceController/Edit/5
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

        // GET: StudentAttendenceController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StudentAttendenceController/Delete/5
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
