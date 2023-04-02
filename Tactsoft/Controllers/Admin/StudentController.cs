using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Tactsoft.Controllers.Admin
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly ICountryService _countryService;
        private readonly IStateService _stateService;
        private readonly ICityService _cityService;
        private readonly IBatchService _batchService;
        private readonly ICourseService _courseService;
        public StudentController(IStudentService studentService, ICountryService countryService,
            IStateService stateService, ICityService cityService, IBatchService batchService , ICourseService courseService)
        {
            this._studentService = studentService;
            this._countryService = countryService;
            this._stateService = stateService;
            this._cityService = cityService;
            this._batchService = batchService;
            this._courseService = courseService;
        }
        // GET: StudentController
        public async Task<IActionResult> Index()
        {
            var students = await _studentService.GetAllAsync(x=>x.Country, x=>x.State, x => x.City, x=>x.Batch , x=>x.Course );
            return View(students);
        }

        // GET: StudentController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var student = await _studentService.FindAsync(x=>x.Id == id, e=>e.Country, e=>e.State, e=>e.City, x => x.Batch , x => x.Course);
            return PartialView("Details",student);
        }

        // GET: StudentController/Create
        public IActionResult Create()
        {
            ViewData["CountryId"] = _countryService.Dropdown();
            ViewData["StateId"] = _stateService.Dropdown();
            ViewData["CityId"] = _cityService.Dropdown();
            ViewData["CourseId"] = _courseService.Dropdown();
            ViewData["BatchId"] = _batchService.Dropdown();
            return PartialView("Create");
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student student, IFormFile pictureFile)
        {
            if (ModelState.IsValid)
            {
                if (pictureFile != null && pictureFile.Length > 0)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/students",
                     pictureFile.FileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        pictureFile.CopyTo(stream);
                    }
                    student.Picture = $"{pictureFile.FileName}";
                }
                await _studentService.InsertAsync(student);

                TempData["successAlert"] = "Student save successfull.";
                return RedirectToAction(nameof(Index));
            }
            ViewData["CountryId"] = _countryService.Dropdown();
            ViewData["StateId"] = _stateService.Dropdown();
            ViewData["CityId"] = _cityService.Dropdown();
            ViewData["CourseId"] = _courseService.Dropdown();
            ViewData["BatchId"] = _batchService.Dropdown();
            return View("Create", student);
        }

        // GET: StudentController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var student = await _studentService.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            ViewData["CountryId"] = _countryService.Dropdown();
            ViewData["StateId"] = _stateService.Dropdown();
            ViewData["CityId"] = _cityService.Dropdown();
            ViewData["CourseId"] = _courseService.Dropdown();
            ViewData["BatchId"] = _batchService.Dropdown();
            return PartialView(student);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Student student, IFormFile pictureFile)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var _student = await _studentService.FindAsync(student.Id);

                    if (pictureFile != null && pictureFile.Length > 0)
                    {                       
                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/students",
                         pictureFile.FileName);

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            pictureFile.CopyTo(stream);
                        }
                        student.Picture = $"{pictureFile.FileName}";
                    }
                    else
                    {
                        student.Picture = _student.Picture;
                    }
                    _student.Picture = student.Picture;
                    _student.StudentName = student.StudentName;
                    _student.StudentEmail = student.StudentEmail;
                    _student.StudentPhone = student.StudentPhone;
                    _student.Address = student.Address;
                    _student.GenderId = student.GenderId;
                    _student.LastAcademicInfo = student.LastAcademicInfo;
                    _student.NameOfInstitute = student.NameOfInstitute;
                    _student.NationalId = student.NationalId;
                    _student.EnrollmentDate = student.EnrollmentDate;
                    _student.DateOfBirth = student.DateOfBirth;
                    _student.Ssc = student.Ssc;
                    _student.Hsc = student.Hsc;
                    _student.Bsc = student.Bsc;
                    _student.CountryId = student.CountryId;
                    _student.StateId = student.StateId;
                    _student.CityId = student.CityId;
                    _student.StudentId = student.StudentId;
                    _student.BatchId = student.BatchId;
                    _student.FathersName= student.FathersName;
                    _student.MothersName= student.MothersName;
                    _student.GuardianName= student.GuardianName;

                    await _studentService.UpdateAsync(_student);
                }
                catch
                {
                    throw;
                }
                TempData["successAlert"] = "Student update successfull.";
                return RedirectToAction(nameof(Index));
            }
            ViewData["CountryId"] = _countryService.Dropdown();
            ViewData["StateId"] = _stateService.Dropdown();
            ViewData["CityId"] = _cityService.Dropdown();
            ViewData["CourseId"] = _courseService.Dropdown();
            ViewData["BatchId"] = _batchService.Dropdown();
            return View(student);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var employee = await _studentService.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewData["CountryId"] = _countryService.Dropdown();
            ViewData["StateId"] = _stateService.Dropdown();
            ViewData["CityId"] = _cityService.Dropdown();
            ViewData["CourseId"] = _courseService.Dropdown();
            ViewData["BatchId"] = _batchService.Dropdown();

            return View(employee);
        }

        // POST: EmployeeController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _studentService.FindAsync(id);
            if (employee != null)
            {
                await _studentService.DeleteAsync(employee);
                TempData["successAlert"] = "Employee remove successfull.";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
