using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.DependencyResolver;
using System.Runtime.CompilerServices;
using Tactsoft.Core.Entities;
using Tactsoft.Service.DbDependencies;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class AttendenceDetailsController : Controller
    {
        private readonly IAttendenceDetailsService _attendenceDetailsService;
        private readonly IStudentService _studentService;
        private readonly IAttendenceService _attendenceService;

        public AttendenceDetailsController (IAttendenceDetailsService attendenceDetailsService,IStudentService studentService, IAttendenceService attendenceService)
        {
            this._attendenceDetailsService = attendenceDetailsService;
            this._studentService = studentService;
            this._attendenceService = attendenceService;
        }




        // GET: AttendenceDetailsController
        public async Task<IActionResult> Index()
        {
            var attendencedetails = await _attendenceDetailsService.GetAllAsync(x=>x.Student,x=>x.Attendence);
            return View(attendencedetails);
        }

        // GET: AttendenceDetailsController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var attendencedetails = await _attendenceDetailsService.FindAsync(m => m.Id == id, e => e.Student, e => e.Attendence);
            if(attendencedetails == null)
            {
                return NotFound();
            }
            return View(attendencedetails);
        }

        //GET: AttendenceDetailsController/Create
        public IActionResult Create()
        {
            ViewData["AttendenceId"] = _attendenceService.Dropdown();
            ViewData["StudentId"] = _studentService.Dropdown();

            return View();
        }

        //POST: AttendenceDetailsController/Create
       [HttpPost]
       [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AttendenceDetails attendenceDetails)
        {
            if (ModelState.IsValid)
            {
                await _attendenceDetailsService.InsertAsync(attendenceDetails);
                TempData["successAlert"] = "Attendence Details save successfull.";
                return RedirectToAction(nameof(Index));
            }
            ViewData["AttendenceId"] = _attendenceService.Dropdown();
            ViewData["StudentId"] = _studentService.Dropdown();
            TempData["errorAlert"] = "Operation failed.";
            return View(attendenceDetails);


        }

        // GET: AttendenceDetailsController/Edit/5
        public async Task<IActionResult> Edit(long id)
        {
            var employee = await _attendenceDetailsService.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewData["AttendenceId"] = _attendenceService.Dropdown();
            ViewData["StudentId"] = _studentService.Dropdown();

            return View(employee);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(AttendenceDetails employee, IFormFile pictureFile)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var emp = await _attendenceDetailsService.FindAsync(employee.Id);

                 
                  
                    emp.AttendenceId = employee.AttendenceId;
                    emp.StudentId = employee.StudentId;
                    emp.Present = employee.Present;
                 

                    await _attendenceDetailsService.UpdateAsync(emp);
                    TempData["successAlert"] = "Employee update successfull.";
                }
                catch
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AttendenceId"] = _attendenceService.Dropdown();
            ViewData["StudentId"] = _studentService.Dropdown();

            TempData["errorAlert"] = "Operation failed.";
            return View(employee);
        }

        // GET: AttendenceDetailsController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var attendencedetails = await _attendenceDetailsService.FindAsync(m => m.Id == id, e => e.Student, e => e.Attendence);
            if (attendencedetails == null)
            {
                return NotFound();
            }

            return View(attendencedetails);
        }

        // POST: AttendenceDetailsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var attendencedetails = await _attendenceDetailsService.FindAsync(id);
            if (attendencedetails != null)
            {
                await _attendenceDetailsService.DeleteAsync(attendencedetails);
                TempData["successAlert"] = "Attendence Details remove successfull.";
            }
            /* TempData["errorAlert"] = "Operation failed.";*/
            return RedirectToAction(nameof(Index));
        }
    }
}
