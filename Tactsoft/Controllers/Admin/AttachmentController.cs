using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;
using Attachment = Tactsoft.Core.Entities.Attachment;

namespace Tactsoft.Controllers.Admin
{


    public class AttachmentController : Controller
    {
        private readonly IAttachmentService _attachmentService;
        private readonly IStudentService _studentService;
        private readonly IDocumentTypeService _documentTypeService;

        public AttachmentController(IAttachmentService attachmentService, IStudentService studentService, IDocumentTypeService documentTypeService)
        {
            _attachmentService = attachmentService;
            _studentService = studentService;
            _documentTypeService=documentTypeService;
        }

    
        // GET: AttachmentController
        public async Task <IActionResult> Index()
        {
            var attachment = await _attachmentService.GetAllAsync(x => x.Student, x=>x.DocumentType);
            return View(attachment);
        }

        // GET: AttachmentController/Details/5
        public async Task <IActionResult> Details(int id)
        {
            var attachment = await _attachmentService.FindAsync(e => e.Id == id, e => e.Student, e => e.DocumentType);
            if (attachment == null)
            {
                return NotFound();
            }
            
            return View(attachment);
        }

        // GET: AttachmentController/Create
        public async Task <IActionResult> Create()
        {
            ViewData["StudentId"] = _studentService.Dropdown();
            ViewData["DocumentTypeId"] = _documentTypeService.Dropdown();
            return View();
        }

        // POST: AttachmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Create(Attachment attachment)
        {
            if (ModelState.IsValid)
            {

                await _attachmentService.InsertAsync(attachment);
                TempData["successAlert"] = "Attachment Save Success";
                return RedirectToAction(nameof(Index));

            }
            TempData["errorAlert"] = "Oparation failed";
            return View(attachment);
            
        }

        // GET: AttachmentController/Edit/5
        public async Task <IActionResult> Edit(int id)
        {
            var attachment = await _attachmentService.FindAsync(id);
            if (attachment == null)
            {
                return NotFound();
            }
            ViewData["StudentId"] = _studentService.Dropdown();
            ViewData["DocumentTypeId"] = _documentTypeService.Dropdown();
            return View(attachment);
        }

        // POST: AttachmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAsync(Attachment attachment)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var editedattachment = await _attachmentService.FindAsync(attachment.Id);

                    editedattachment.AttachmentName = attachment.AttachmentName;
                    editedattachment.StudentId = attachment.StudentId;
                    editedattachment.DocumentTypeId = attachment.DocumentTypeId;
                    
                    

                    await _attachmentService.UpdateAsync(editedattachment);

                    TempData["successAlert"] = "Attachment Update Successfully";

                }
                catch
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));

            }
            ViewData["StudentId"] = _studentService.Dropdown();
            ViewData["DocumentTypeId"] = _documentTypeService.Dropdown();

            TempData["errorAlert"] = "Oparation Failed";

            return View(attachment);

        }

        // GET: AttachmentController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var attachment = await _attachmentService.FindAsync(e => e.Id == id, e => e.DocumentType, e => e.Student);
            ViewData["StudentId"] = _studentService.Dropdown();
            ViewData["DocumentTypeId"] = _documentTypeService.Dropdown();
            return View(attachment);
        }

        // POST: AttachmentController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var attachment = await _attachmentService.FindAsync(id);
            if (attachment != null)
            {
                await _attachmentService.DeleteAsync(attachment);
                TempData["successAlert"] = "Attachment Delete Successfully";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
