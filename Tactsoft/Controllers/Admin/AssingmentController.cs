using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class AssingmentController : Controller
    {
        private readonly IAssingmentService _assingmentService;
        private readonly IBatchService _batchService;
        private readonly ICourseService _courseService;
        private readonly IStudentService _studentService;
        public AssingmentController(IAssingmentService assingmentService, IBatchService batchService, ICourseService courseService, IStudentService studentService)
        {
            _assingmentService = assingmentService;
            _batchService = batchService;
            _courseService = courseService;
            _studentService = studentService;
        }

        // GET: AssingmentController
        public async Task<IActionResult> Index()
        {

			ViewData["CourseId"] = _courseService.Dropdown();
			ViewData["BatchId"] = _batchService.Dropdown();
			var assignments = await _assingmentService.GetAllAsync(x => x.Batch , x=>x.Course);
            return View(assignments);
        }

        // GET: AssingmentController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
			ViewData["StudentId"] = _studentService.Dropdown();
			var assignment = await _assingmentService.FindAsync(m => m.Id == id, e => e.Batch, x => x.Course , x=>x.Course.Students);
            if (assignment == null)
            {
                return NotFound();
            }

            return View(assignment);
        }

        // GET: AssingmentController/Create
        public IActionResult Create()
        {
            ViewData["BatchId"] = _batchService.Dropdown();
            ViewData["CourseId"] = _courseService.Dropdown();
            return View();
        }

        // POST: AssingmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Assignment assignment, IFormFile PdfFile)
        {
            if (ModelState.IsValid)
            {
                if (PdfFile != null && PdfFile.Length > 0)
                {
                    var CvPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/assignmentPdf",
                     PdfFile.FileName);

                    using (var stream = new FileStream(CvPath, FileMode.Create))
                    {
                        PdfFile.CopyTo(stream);
                    }
                    assignment.AssingmentPdf = $"{PdfFile.FileName}";
                }


                await _assingmentService.InsertAsync(assignment);
                TempData["successAlert"] = "Lesson save successfull.";
                return RedirectToAction(nameof(Index));
            }
            ViewData["BatchId"] = _batchService.Dropdown();
            ViewData["CourseId"] = _courseService.Dropdown();
            TempData["errorAlert"] = "Operation failed.";
            return View(assignment);
        }

        // GET: AssingmentController/Edit/5
        public async Task<IActionResult> Edit(long id)
        {
            var assignment = await _assingmentService.FindAsync(id);
            if (assignment == null)
            {
                return NotFound();
            }
            ViewData["BatchId"] = _batchService.Dropdown();
            ViewData["CourseId"] = _courseService.Dropdown();


            return View(assignment);
        }

        // POST: LessonController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(Assignment assignment, IFormFile PdfFile)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var editLesson = await _assingmentService.FindAsync(assignment.Id);

                    if (PdfFile != null && PdfFile.Length > 0)
                    {
                        var PdfPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/assignmentPdf",
                         PdfFile.FileName);

                        using (var stream = new FileStream(PdfPath, FileMode.Create))
                        {
                            PdfFile.CopyTo(stream);
                        }
                        assignment.AssingmentPdf = $"{PdfFile.FileName}";
                    }
                    else
                    {
                        editLesson.AssingmentPdf = assignment.AssingmentPdf;
                    }
                    editLesson.AssingmentName = assignment.AssingmentName;
                    editLesson.AssingmentDate = assignment.AssingmentDate;
                    editLesson.AssingmentEndDate = assignment.AssingmentEndDate;
                    editLesson.BatchId = assignment.BatchId;
                    editLesson.Remarks = assignment.Remarks;

                    await _assingmentService.UpdateAsync(editLesson);
                    TempData["successAlert"] = "Lesson update successfull.";
                }
                catch
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["BatchId"] = _batchService.Dropdown();
            ViewData["CourseId"] = _courseService.Dropdown();


            TempData["errorAlert"] = "Operation failed.";
            return View(assignment);
        }

        // GET: AssingmentController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var assignment = await _assingmentService.FindAsync(id);
            if (assignment == null)
            {
                return NotFound();
            }
            ViewData["BatchId"] = _batchService.Dropdown();
            ViewData["CourseId"] = _courseService.Dropdown();

            return View(assignment);
        }

        // POST: AssingmentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var assignment = await _assingmentService.FindAsync(id);
            if (assignment != null)
            {
                await _assingmentService.DeleteAsync(assignment);
                TempData["successAlert"] = "Assignment remove successfull.";
            }

            TempData["errorAlert"] = "Operation failed.";
            return RedirectToAction(nameof(Index));
        }
    }
}
