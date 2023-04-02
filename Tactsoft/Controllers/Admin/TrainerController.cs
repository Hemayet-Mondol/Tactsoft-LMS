using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class TrainerController : Controller
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly ITrainerService _trainerService;
        private readonly ICountryService _countryService;
        private readonly IStateService _stateService;
        private readonly ICityService _cityService;
        public TrainerController(IHttpContextAccessor contextAccessor, ITrainerService trainerService, ICountryService countryService, IStateService stateService, ICityService cityService)
        {
            this._contextAccessor = contextAccessor;
            this._trainerService = trainerService;
            this._countryService = countryService;
            this._stateService = stateService;
            this._cityService = cityService;
        }


        // GET: TrainerController
        public async Task<IActionResult> Index()
        {
            var trainer = await _trainerService.GetAllAsync();
            return View(trainer);
        }

        // GET: TrainerController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var singleTrainer = await _trainerService.FindAsync(id);
            return View(singleTrainer);
        }

        // GET: TrainerController/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: TrainerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Trainer trainer, IFormFile pictureFile, IFormFile CVFile)
        {
            if (ModelState.IsValid)
            {
                if (pictureFile != null && pictureFile.Length > 0)
                {
                    var picturePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/trainer",
                     pictureFile.FileName);

                    using (var stream = new FileStream(picturePath, FileMode.Create))
                    {
                        pictureFile.CopyTo(stream);
                    }
                    trainer.Picture = $"{pictureFile.FileName}";
                }
                if (CVFile != null && CVFile.Length > 0)
                {
                    var CvPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/cv",
                     CVFile.FileName);

                    using (var stream = new FileStream(CvPath, FileMode.Create))
                    {
                        CVFile.CopyTo(stream);
                    }
                    trainer.CV = $"{CVFile.FileName}";
                }
                await _trainerService.InsertAsync(trainer);

                TempData["successAlert"] = "Student save successfull.";
                return RedirectToAction(nameof(Index));
            }
            return View("Create", trainer);
        }

        // GET: TrainerController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var trainer = await _trainerService.FindAsync(id);
            if (trainer == null)
            {
                return NotFound();
            }
            return PartialView(trainer);
        }

        // POST: TrainerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Trainer trainer, IFormFile pictureFile, IFormFile CVFile)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var _trainer = await _trainerService.FindAsync(trainer.Id);

                    if (pictureFile != null && pictureFile.Length > 0)
                    {
                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/trainer",
                         pictureFile.FileName);

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            pictureFile.CopyTo(stream);
                        }
                        trainer.Picture = $"{pictureFile.FileName}";
                    }
                    else
                    {
                        trainer.Picture = _trainer.Picture;
                    }
                    if (CVFile != null && CVFile.Length > 0)
                    {
                        var CvPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/cv",
                         CVFile.FileName);

                        using (var stream = new FileStream(CvPath, FileMode.Create))
                        {
                            CVFile.CopyTo(stream);
                        }
                        trainer.CV = $"{CVFile.FileName}";
                    }
                    else
                    {
                        trainer.CV = _trainer.CV;
                    }
                    _trainer.Picture = trainer.Picture;
                    _trainer.TrainerName = trainer.TrainerName;
                    _trainer.Address = trainer.Address;
                    _trainer.Phone = trainer.Phone;
                    _trainer.Email = trainer.Email;
                    _trainer.DateOfBirth = trainer.DateOfBirth;
                    _trainer.JoiningDate = trainer.JoiningDate;
                    _trainer.LastAcademicInfo = trainer.LastAcademicInfo;
                    _trainer.Experience = trainer.Experience;
                    _trainer.Expertise = trainer.Expertise;
                    _trainer.CV = trainer.CV;
                    _trainer.AboutTrainer = trainer.AboutTrainer;

                    await _trainerService.UpdateAsync(_trainer);
                }
                catch
                {
                    throw;
                }
                TempData["successAlert"] = "Student update successfull.";
                return RedirectToAction(nameof(Index));
            }

            return View(trainer);
        }

        // GET: TrainerController/Delete/5

        public async Task<IActionResult> Delete(int id)
        {
            var trainer = await _trainerService.FindAsync(id);
            if (trainer == null)
            {
                return NotFound();
            }
           

            return View(trainer);
        }

        // POST: TrainerController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trainer = await _trainerService.FindAsync(id);
            if (trainer != null)
            {
                await _trainerService.DeleteAsync(trainer);
                TempData["successAlert"] = "Trainer remove successfull.";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
