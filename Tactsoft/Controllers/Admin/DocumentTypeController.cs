using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class DocumentTypeController : Controller
    {
        private readonly IDocumentTypeService _documentTypeService;
        public DocumentTypeController(IDocumentTypeService documentTypeService)
        {
           _documentTypeService = documentTypeService;
        }
        // GET: DocumentTypeController
        public async Task<IActionResult> Index()
        {
           var doc = await _documentTypeService.GetAllAsync();
            return View(doc);

        }

        // GET: DocumentTypeController/Details/5
        public async Task<IActionResult> Details(int Id)
        {
            var docType = await _documentTypeService.FindAsync(Id);
            return View(docType);
        }

        // GET: DocumentTypeController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DocumentTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DocumentType documentType)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _documentTypeService.InsertAsync(documentType);
                    TempData["successAlert"] = "Registration Save Successfull.";
                    return RedirectToAction("Index");
                }
                return View(documentType);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: DocumentTypeController/Edit/5
        public async Task<IActionResult> Edit(int Id)
        {
            var docType = await _documentTypeService.FindAsync(Id);
            if (docType == null)
            {
                return NotFound();
            }
            return View(docType);
        }

        // POST: DocumentTypeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DocumentType documentType)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _documentTypeService.UpdateAsync(documentType);
                    TempData["successAlert"] = "Registration Update Successfull.";
                    return RedirectToAction("Index");
                }
                return View(documentType);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: DocumentTypeController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var documentType = await _documentTypeService.FindAsync(id);
            if (documentType == null)
            {
                return NotFound();
            }


            return View(documentType);
        }

        // POST: DocumentTypeController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var documentType = await _documentTypeService.FindAsync(id);
            if (documentType != null)
            {
                await _documentTypeService.DeleteAsync(documentType);
                TempData["successAlert"] = "user Type remove successfull.";
            }

            //TempData["errorAlert"] = "Operation failed.";
            return RedirectToAction(nameof(Index));
        }
    }
}
