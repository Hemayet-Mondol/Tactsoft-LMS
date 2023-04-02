using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.DependencyResolver;
using System.Reflection.PortableExecutable;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class LessonController : Controller
    {
        private readonly ILessonService _lessonService;
        private readonly ICourseService _courseService;

        public LessonController(ILessonService lessonService, ICourseService courseService)
        {
            this._lessonService = lessonService;
            this._courseService = courseService;
        }
        // GET: LessonController
        public async Task <IActionResult> Index()
        {
            var lesson = await _lessonService.GetAllAsync(x=>x.Course);
            return View(lesson);
        }

        // GET: LessonController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var lesson = await _lessonService.FindAsync(m => m.Id == id, e => e.Course);
            if (lesson == null)
            {
                return NotFound();
            }

            return View(lesson);
        }

        // GET: LessonController/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = _courseService.Dropdown();
            return View();
        }

        // POST: LessonController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Lesson lesson, IFormFile PdfFile)
        {
            if (ModelState.IsValid)
            {
                if (PdfFile != null && PdfFile.Length > 0)
                {
                    var CvPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/LessonPdf",
                     PdfFile.FileName);

                    using (var stream = new FileStream(CvPath, FileMode.Create))
                    {
                        PdfFile.CopyTo(stream);
                    }
                    lesson.LessonPdf = $"{PdfFile.FileName}";
                }


                await _lessonService.InsertAsync(lesson);
                TempData["successAlert"] = "Lesson save successfull.";
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = _courseService.Dropdown();
            TempData["errorAlert"] = "Operation failed.";
            return View(lesson);
        }

        // GET: LessonController/Edit/5
        public async Task<IActionResult> Edit(long id)
        {
            var lesson = await _lessonService.FindAsync(id);
            if (lesson == null)
            {
                return NotFound();
            }
           ViewData["CourseId"] = _courseService.Dropdown();


            return View(lesson);
        }

        // POST: LessonController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(Lesson lesson, IFormFile PdfFile)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var editLesson = await _lessonService.FindAsync(lesson.Id);

                    if (PdfFile != null && PdfFile.Length > 0)
                    {
                        var PdfPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/LessonPdf",
                         PdfFile.FileName);

                        using (var stream = new FileStream(PdfPath, FileMode.Create))
                        {
                            PdfFile.CopyTo(stream);
                        }
                        lesson.LessonPdf = $"{PdfFile.FileName}";
                    }
                    else
                    {
                        editLesson.LessonPdf = lesson.LessonPdf;
                    }
                    editLesson.LessonNumber = lesson.LessonNumber;
                    editLesson.LessonName = lesson.LessonName;
                    editLesson.LessonPdf = lesson.LessonPdf;
                    editLesson.CourseId = lesson.CourseId;

                    await _lessonService.UpdateAsync(editLesson);
                    TempData["successAlert"] = "Lesson update successfull.";
                }
                catch
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = _courseService.Dropdown();
            

            TempData["errorAlert"] = "Operation failed.";
            return View(lesson);
        }

        // GET: LessonController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var lesson = await _lessonService.FindAsync(id);
            if (lesson == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = _courseService.Dropdown();


            return View(lesson);
        }

        // POST: LessonController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lesson = await _lessonService.FindAsync(id);
            if (lesson != null)
            {
                await _lessonService.DeleteAsync(lesson);
               
                TempData["successAlert"] = "Employee remove successfull.";
            }

           
            return RedirectToAction(nameof(Index));
        }
    }
}
