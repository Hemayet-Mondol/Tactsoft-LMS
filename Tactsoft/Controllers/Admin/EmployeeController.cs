using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Tactsoft.Controllers.Admin
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly ICountryService _countryService;
        private readonly IStateService _stateService;
        private readonly ICityService _cityService;
        private readonly IDepartmentService _departmentService;

        public EmployeeController(IEmployeeService employeeService, ICountryService countryService, 
            IStateService stateService, ICityService cityService,IDepartmentService departmentService)
        {
            this._employeeService = employeeService;
            this._countryService = countryService;
            this._stateService = stateService;
            this._cityService = cityService;
            this._departmentService = departmentService;
        }
        // GET: EmployeeController
        public async Task<IActionResult> Index()
        {
            var employees = await _employeeService.GetAllAsync(x=>x.Country,i=>i.State,i=>i.City,i=>i.Department);
            return View(employees);
        }

        // GET: EmployeeController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var employee = await _employeeService.FindAsync(m => m.Id == id, e => e.Country, e => e.State, e => e.City, i => i.Department);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: EmployeeController/Create
        public IActionResult Create()
        {            
            ViewData["DepartmentId"] = _departmentService.Dropdown();
            ViewData["CountryId"] = _countryService.Dropdown();
            ViewData["StateId"] = _stateService.Dropdown();
            ViewData["CityId"] = _cityService.Dropdown();
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employee employee, IFormFile pictureFile)
        {
            if (ModelState.IsValid)
            {
                if (pictureFile != null && pictureFile.Length > 0)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/employees",
                     pictureFile.FileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        pictureFile.CopyTo(stream);
                    }
                    employee.Picture = $"{pictureFile.FileName}";
                }
                
                await _employeeService.InsertAsync(employee);
                TempData["successAlert"] = "Employee save successfull.";
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = _departmentService.Dropdown();
            ViewData["CountryId"] = _countryService.Dropdown();
            ViewData["StateId"] = _stateService.Dropdown();
            ViewData["CityId"] = _cityService.Dropdown();

            TempData["errorAlert"] = "Operation failed.";
            return View(employee);
        }

        // GET: EmployeeController/Edit/5
        public async Task<IActionResult> Edit(long id)
        {
            var employee = await _employeeService.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewData["DepartmentId"] = _departmentService.Dropdown();
            ViewData["CountryId"] = _countryService.Dropdown();
            ViewData["StateId"] = _stateService.Dropdown();
            ViewData["CityId"] = _cityService.Dropdown();

            return View(employee);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(Employee employee, IFormFile pictureFile)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var emp = await _employeeService.FindAsync(employee.Id);

                    if (pictureFile != null && pictureFile.Length > 0)
                    {
                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/employees",
                         pictureFile.FileName);

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            pictureFile.CopyTo(stream);
                        }
                        employee.Picture = $"{pictureFile.FileName}";
                    }
                    else
                    {
                        employee.Picture = emp.Picture;
                    }
                    emp.Picture = employee.Picture;
                    emp.Name = employee.Name;
                    emp.Address = employee.Address;
                    emp.Gender = employee.Gender;
                    emp.Ssc = employee.Ssc;
                    emp.Hsc = employee.Hsc;
                    emp.Bsc = employee.Bsc;
                    emp.Msc = employee.Msc;
                    emp.DepartmentId = employee.DepartmentId;
                    emp.CountryId = employee.CountryId;
                    emp.StateId = employee.StateId;
                    emp.CityId = employee.CityId;

                   await _employeeService.UpdateAsync(emp);
                   TempData["successAlert"] = "Employee update successfull.";
                }
                catch
                {                   
                   throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = _departmentService.Dropdown();
            ViewData["CountryId"] = _countryService.Dropdown();
            ViewData["StateId"] = _stateService.Dropdown();
            ViewData["CityId"] = _cityService.Dropdown();

            TempData["errorAlert"] = "Operation failed.";
            return View(employee);
        }

        // GET: EmployeeController/Delete/5

        public async Task<IActionResult> Delete(int id)
        {
            var employee = await _employeeService.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewData["DepartmentId"] = _departmentService.Dropdown();
            ViewData["CountryId"] = _countryService.Dropdown();
            ViewData["StateId"] = _stateService.Dropdown();
            ViewData["CityId"] = _cityService.Dropdown();

            return View(employee);
        }

        // POST: EmployeeController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _employeeService.FindAsync(id);
            if (employee != null)
            {
                await _employeeService.DeleteAsync(employee);
                TempData["successAlert"] = "Employee remove successfull.";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
