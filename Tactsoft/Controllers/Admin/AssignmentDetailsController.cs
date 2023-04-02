using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class AssignmentDetailsController : Controller
    {
        private readonly IAssignmentDetailsService _assignmentDetailsService;
        private readonly IAssingmentService _assingmentService;
        private readonly IStudentService _studentService;
        

        public AssignmentDetailsController(IAssignmentDetailsService assignmentDetailsService,IAssingmentService assingmentService, IStudentService studentService, IDocumentTypeService documentTypeService)
        {
            _assignmentDetailsService = assignmentDetailsService;
            _assingmentService = assingmentService;
            _studentService = studentService;
           
        }
        // GET: AssignmentDetailsController
        public async Task<IActionResult> Index()
        {
            var assignmentDetails = await _assignmentDetailsService.GetAllAsync(x => x.Student, x => x.Assignment);
            return View(assignmentDetails);
        }

        // GET: AssignmentDetailsController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var assignmentDetails = await _assignmentDetailsService.FindAsync(e => e.Id == id, e => e.Student, e => e.Assignment);
            if (assignmentDetails == null)
            {
                return NotFound();
            }

            return View(assignmentDetails);
        }

        // GET: AssignmentDetailsController/Create
        public async Task<IActionResult> Create()
        {
            ViewData["StudentId"] = _studentService.Dropdown();
            ViewData["AssignmentId"] = _assingmentService.Dropdown();
            return View();
        }

        // POST: AssignmentDetailsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AssignmentDetails assignmentdetails,IFormFile assignmentAttachmentpdfFile)
        {
            if (ModelState.IsValid)
            {
                if (assignmentAttachmentpdfFile != null && assignmentAttachmentpdfFile.Length > 0)
                {
                    var pdfpath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/images/AssignmentAttachmentPdf",assignmentAttachmentpdfFile.FileName);

                    using (var stream = new FileStream(pdfpath, FileMode.Create))
                    {
                        assignmentAttachmentpdfFile.CopyTo(stream);
                    }
                    assignmentdetails.AssignmentAttachment = $"{assignmentAttachmentpdfFile.FileName}";
                }

                await _assignmentDetailsService.InsertAsync(assignmentdetails);
                TempData["successAlert"] = "Attachment Details Save Success";
                return RedirectToAction(nameof(Index));

            }
            TempData["errorAlert"] = "Oparation failed";
            return View(assignmentdetails);

        }

        // GET: AssignmentDetailsController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var assignmentdetails = await _assignmentDetailsService.FindAsync(id);
            if (assignmentdetails == null)
            {
                return NotFound();
            }
            ViewData["StudentId"] = _studentService.Dropdown();
            ViewData["AssignmentId"] = _assingmentService.Dropdown();
            return View(assignmentdetails);
        }

        // POST: AssignmentDetailsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(AssignmentDetails assignmentDetails, IFormFile assignmentAttachmentpdfFile)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var editassignmentdetails = await _assignmentDetailsService.FindAsync(assignmentDetails.Id);

                    if (assignmentAttachmentpdfFile != null && assignmentAttachmentpdfFile.Length > 0)
                    {
                        var PdfPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/AssignmentAttachmentPdf",
                         assignmentAttachmentpdfFile.FileName);

                        using (var stream = new FileStream(PdfPath, FileMode.Create))
                        {
                            assignmentAttachmentpdfFile.CopyTo(stream);
                        }
                        assignmentDetails.AssignmentAttachment = $"{assignmentAttachmentpdfFile.FileName}";
                       
                    }
                    else
                    {
                        editassignmentdetails.AssignmentAttachment = assignmentDetails.AssignmentAttachment;
                    }
                    editassignmentdetails.AssignmentId = assignmentDetails.AssignmentId;
                    editassignmentdetails.StudentId = assignmentDetails.StudentId;
                    editassignmentdetails.Marks = assignmentDetails.Marks;
                    editassignmentdetails.AssignmentAttachment = assignmentDetails.AssignmentAttachment;


                    await _assignmentDetailsService.UpdateAsync(editassignmentdetails);
                    TempData["successAlert"] = "Lesson update successfull.";
                }
                catch
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentId"] = _studentService.Dropdown();
            ViewData["AssignmentId"] = _assingmentService.Dropdown();


            TempData["errorAlert"] = "Operation failed.";
            return View(assignmentDetails);
        }

        // GET: AssignmentDetailsController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var assignmentdetails = await _assignmentDetailsService.FindAsync(e => e.Id == id, e => e.Assignment, e => e.Student);
            ViewData["StudentId"] = _studentService.Dropdown();
            ViewData["AssignmentId"] = _assingmentService.Dropdown();
            return View(assignmentdetails);
        }

        // POST: AssignmentDetailsController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var assignmentdetails = await _assignmentDetailsService.FindAsync(id);
            if (assignmentdetails != null)
            {
                await _assignmentDetailsService.DeleteAsync(assignmentdetails);
                TempData["successAlert"] = "Assignment Details Delete Successfully";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
