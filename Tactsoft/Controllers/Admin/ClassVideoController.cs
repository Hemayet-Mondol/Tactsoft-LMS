using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    
    public class ClassVideoController : Controller
    {
        private readonly IClassVideoService _classVideoService;
        private readonly ILessonService _lessonService;
        public ClassVideoController(IClassVideoService classVideoService, ILessonService lessonService)
        {
            this._classVideoService= classVideoService;
            this._lessonService = lessonService;
        }
        // GET: ClassVideoController
        public async Task<IActionResult> Index()
        {
            var clsv = await _classVideoService.GetAllAsync(x => x.Lesson);
            return View(clsv);
        }

        // GET: ClassVideoController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var clsv = await _classVideoService.FindAsync(m => m.Id == id, e => e.Lesson);
            if (clsv == null)
            {
                return NotFound();
            }

            return View(clsv);
        }

        // GET: ClassVideoController/Create
        public IActionResult Create()
        {
            ViewData["LessonId"] = _lessonService.Dropdown();
            return View();
        }

        // POST: ClassVideoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClassVideo classvideo, IFormFile videoFile)
        {
            if (ModelState.IsValid)
            {
                if (videoFile != null && videoFile.Length > 0)
                {
                    var CvPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/ClassVideo",
                     videoFile.FileName);

                    using (var stream = new FileStream(CvPath, FileMode.Create))
                    {
                        videoFile.CopyTo(stream);
                    }
                    classvideo.VideoUrl = $"{videoFile.FileName}";
                }


                await _classVideoService.InsertAsync(classvideo);
                TempData["successAlert"] = "Class Video save successfull.";
                return RedirectToAction(nameof(Index));
            }
            ViewData["LessonId"] = _lessonService.Dropdown();
            TempData["errorAlert"] = "Operation failed.";
            return View(classvideo);
        }

        // GET: ClassVideoController/Edit/5
        public async Task<IActionResult> Edit(long id)
        {
            var classvideo = await _classVideoService.FindAsync(id);
            if (classvideo == null)
            {
                return NotFound();
            }
            ViewData["LessonId"] = _lessonService.Dropdown();


            return View(classvideo);
        }

        // POST: ClassVideoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(ClassVideo classVideo, IFormFile VideoFileName)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var editclassVideo = await _classVideoService.FindAsync(classVideo.Id);

                    if (VideoFileName != null && VideoFileName.Length > 0)
                    {
                        var PdfPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/ClassVideo",
                         VideoFileName.FileName);

                        using (var stream = new FileStream(PdfPath, FileMode.Create))
                        {
                            VideoFileName.CopyTo(stream);
                        }
                        classVideo.VideoUrl = $"{VideoFileName.FileName}";
                    }
                    else
                    {
                        editclassVideo.VideoUrl = classVideo.VideoUrl;
                    }
                    editclassVideo.VideoFileName = classVideo.VideoFileName;
                    editclassVideo.VideoUrl = classVideo.VideoUrl;
                    editclassVideo.LessonId = classVideo.LessonId;
                    

                    await _classVideoService.UpdateAsync(editclassVideo);
                    TempData["successAlert"] = "Lesson update successfull.";
                }
                catch
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["LessonId"] = _lessonService.Dropdown();


            TempData["errorAlert"] = "Operation failed.";
            return View(classVideo);
        }

        // GET: ClassVideoController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var classVideo = await _classVideoService.FindAsync(id);
            if (classVideo == null)
            {
                return NotFound();
            }
            ViewData["LessonId"] = _lessonService.Dropdown();


            return View(classVideo);
        }

        // POST: ClassVideoController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var classVideo = await _classVideoService.FindAsync(id);
            if (classVideo != null)
            {
                await _classVideoService.DeleteAsync(classVideo);
                TempData["successAlert"] = "Employee remove successfull.";
            }

            TempData["errorAlert"] = "Operation failed.";
            return RedirectToAction(nameof(Index));
        }
    }
}
