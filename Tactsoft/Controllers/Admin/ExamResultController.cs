using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class ExamResultController : Controller
    {
        private readonly IExamResultService _examResultService;
        private readonly IExamService _examService;
        private readonly IStudentService _studentService;


        public ExamResultController(IExamResultService examResultService, IExamService examService, IStudentService studentService)
        {
            this._examResultService = examResultService;
            this._examService = examService;
            this._studentService = studentService;
        }

        // GET: ExamResultController
        public async Task<IActionResult> Index()
        {
            var examResult = await _examResultService.GetAllAsync(x => x.Exam,x=>x.Student);
            return View(examResult);
        }

        // GET: ExamResultController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var examResult = await _examResultService.FindAsync(m => m.Id == id, e => e.Student, e => e.Exam);
            if (examResult == null)
            {
                return NotFound();
            }

            return View(examResult);
        }

        // GET: ExamResultController/Create
        public IActionResult Create()
        {
            ViewData["ExamId"] = _examService.Dropdown();
            ViewData["StudentId"] = _studentService.Dropdown();
            
            return View();
        }

        // POST: ExamResultController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ExamResult examResult)
        {
            if (ModelState.IsValid)
            {
               

                await _examResultService.InsertAsync(examResult);
                TempData["successAlert"] = "Exam result save successfull.";
                return RedirectToAction(nameof(Index));
            }
            ViewData["ExamId"] = _examService.Dropdown();
            ViewData["StudentId"] = _studentService.Dropdown();

            TempData["errorAlert"] = "Operation failed.";
            return View(examResult);
        }

        // GET: ExamResultController/Edit/5
        public async Task<IActionResult> Edit(long id)
        {
            var examResult = await _examResultService.FindAsync(id);
            if (examResult == null)
            {
                return NotFound();
            }
            ViewData["ExamId"] = _examService.Dropdown();
            ViewData["StudentId"] = _studentService.Dropdown();

            return View(examResult);
        }

        // POST: ExamResultController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(ExamResult examResult)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var editExamResult = await _examResultService.FindAsync(examResult.Id);


                    editExamResult.ExamId = examResult.ExamId;
                    editExamResult.StudentId = examResult.StudentId;
                    editExamResult.Remarks = examResult.Remarks;
                    
                   

                    await _examResultService.UpdateAsync(editExamResult);
                    TempData["successAlert"] = "Exam Result update successfull.";
                }
                catch
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ExamId"] = _examService.Dropdown();
            ViewData["StudentId"] = _studentService.Dropdown();

            TempData["errorAlert"] = "Operation failed.";
            return View(examResult);
        }

        // GET: ExamResultController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var examResult = await _examResultService.FindAsync(m => m.Id == id, e => e.Student, e => e.Exam);
            if (examResult == null)
            {
                return NotFound();
            }
            ViewData["ExamId"] = _examService.Dropdown();
            ViewData["StudentId"] = _studentService.Dropdown();

            return View(examResult);
        }

        // POST: ExamResultController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var examResult = await _examResultService.FindAsync(m => m.Id == id, e => e.Student, e => e.Exam);
            if (examResult != null)
            {
                await _examResultService.DeleteAsync(examResult);
                TempData["successAlert"] = "Employee remove successfull.";
            }

           
            return RedirectToAction(nameof(Index));
        }
    }
}
