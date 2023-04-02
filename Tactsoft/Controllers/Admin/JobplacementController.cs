using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class JobplacementController : Controller
    {
        private readonly IJobplacementService _jobplacementService;
        private readonly IDepartmentService _departmentService;
        private readonly IOrganizationService _organizationService;
        private readonly IStudentService _studentService;

        public JobplacementController(IJobplacementService jobplacementService, IDepartmentService departmentService, IOrganizationService organizationService, IStudentService studentService)
        {
            _jobplacementService = jobplacementService;
            _departmentService = departmentService;
            _organizationService = organizationService;
            _studentService = studentService;

        }

        // GET: JobplacementController
        public async Task <IActionResult> Index()
        {
            var jobPlacement = await _jobplacementService.GetAllAsync(x=>x.Department,x=>x.Organization, x=>x.Student);
            return View(jobPlacement);
        }

        // GET: JobplacementController/Details/5
        public async Task <IActionResult> Details(int id)
        {
            var jobPlacement = await _jobplacementService.FindAsync(x=>x.Id==id, x =>x.Department, x => x.Organization, x => x.Student);
            if (jobPlacement == null)
            {
                return NotFound();
            }
            return View(jobPlacement);
        }

        // GET: JobplacementController/Create
        public ActionResult Create()
        {
            ViewData["DepartmentId"] = _departmentService.Dropdown();
            ViewData["OrganizationId"] = _organizationService.Dropdown();

            return View();
        }

        // POST: JobplacementController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Create(Jobplacement jobplacement )
        {
            if (ModelState.IsValid)
            {
                await _jobplacementService.InsertAsync(jobplacement);
                TempData["successAlert"] = "Jobplacement Save Successfully";
                return RedirectToAction(nameof(Index));
            }

            ViewData["DepartmentId"] = _departmentService.Dropdown();
            ViewData["OrganizationId"] = _organizationService.Dropdown();
            ViewData["StudentId"] = _studentService.Dropdown();

            TempData["errorAlert"] = "Oparation Failed";
            return View(jobplacement);
        }

        // GET: JobplacementController/Edit/5
        public async Task <IActionResult> Edit(long id)
        {
            var jobplacement = await _jobplacementService.FindAsync(id);
            if (jobplacement == null)
            {
                return NotFound();
            }
            ViewData["DepartmentId"] = _departmentService.Dropdown();
            ViewData["OrganizationId"] = _organizationService.Dropdown();
            ViewData["StudentId"] = _studentService.Dropdown();
            return View(jobplacement);

        }

        // POST: JobplacementController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> EditAsync(Jobplacement jobplacement)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var editedJobplacement = await _jobplacementService.FindAsync(jobplacement.Id);

                    editedJobplacement.Designation = jobplacement.Designation;
                    editedJobplacement.DateOfJoining = jobplacement.DateOfJoining;
                    editedJobplacement.Salary = jobplacement.Salary;
                    editedJobplacement.DepartmentId = jobplacement.DepartmentId;
                    editedJobplacement.OrganizationId = jobplacement.OrganizationId;
                    editedJobplacement.StudentId = jobplacement.StudentId;
                    editedJobplacement.Remarks = jobplacement.Remarks;

                    await _jobplacementService.UpdateAsync(editedJobplacement);

                    TempData["successAlert"] = "Jobplacement Update Successfully";



                    
                }
                catch
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
                

            }
            ViewData["DepartmentId"] = _departmentService.Dropdown();
            ViewData["OrganizationId"] = _organizationService.Dropdown();
            ViewData["StudentId"] = _studentService.Dropdown();

            TempData["errorAlert"] = "Oparation Failed";

            return View(jobplacement);

        }

        // GET: JobplacementController/Delete/5
        public async Task <IActionResult> Delete(int? id)
        {
            var jobplacement = await _jobplacementService.FindAsync(e => e.Id ==id, e => e.Department, e => e.Organization, e => e.Student);
            ViewData["DepartmentId"] = _departmentService.Dropdown();
            ViewData["OrganizationId"] = _organizationService.Dropdown();
            ViewData["StudentId"] = _studentService.Dropdown();
            return View(jobplacement);
        }

        // POST: JobplacementController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> DeleteConfirmed(int id )
        {
            var jobplacement = await _jobplacementService.FindAsync(id);
            if(jobplacement != null)
            {
                await _jobplacementService.DeleteAsync(jobplacement);
                TempData["successAlert"] = "Job Placement Delete Successfully";
            }
            
            return RedirectToAction(nameof(Index));
        }
    }
}
