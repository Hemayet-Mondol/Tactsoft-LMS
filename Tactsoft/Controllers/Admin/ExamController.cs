using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class ExamController : Controller
    {
        private readonly IExamService _examService;
        public ExamController(IExamService examService)
        {
            this._examService = examService;
        }

        // GET: ExamController
        public async Task<IActionResult> Index()
        {
            var exam = await _examService.GetAllAsync();
            return View(exam);
        }

        // GET: ExamController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var exam = await _examService.FindAsync(m => m.Id == id);
            if (exam == null)
            {
                return NotFound();
            }

            return View(exam);
        }

        // GET: ExamController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ExamController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Exam exam)
        {
            if (ModelState.IsValid)
            {
                await _examService.InsertAsync(exam);
                TempData["successAlert"] = "Exam save successfull.";
                return RedirectToAction(nameof(Index));
            }
            
            TempData["errorAlert"] = "Operation failed.";
            return View(exam);
        }

        // GET: ExamController/Edit/5
        public async Task<IActionResult> Edit(long id)
        {
            var exam = await _examService.FindAsync(id);
            if (exam == null)
            {
                return NotFound();
            }
            


            return View(exam);
        }

        // POST: ExamController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(Exam exam)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var editexam = await _examService.FindAsync(exam.Id);


                    editexam.ExamName = exam.ExamName;
                    editexam.StartDate = exam.StartDate;
                    editexam.EndDate = exam.EndDate;
                    

                    await _examService.UpdateAsync(editexam);
                    TempData["successAlert"] = "Lesson update successfull.";
                }
                catch
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            


            TempData["errorAlert"] = "Operation failed.";
            return View(exam);
        }

        // GET: ExamController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var exam = await _examService.FindAsync(id);
            if (exam == null)
            {
                return NotFound();
            }
            

            return View(exam);
        }

        // POST: ExamController/Delete/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exam = await _examService.FindAsync(id);
            if (exam != null)
            {
                await _examService.DeleteAsync(exam);
                TempData["successAlert"] = "Exam remove successfull.";
            }

            
            return RedirectToAction(nameof(Index));
        }
    }
}
