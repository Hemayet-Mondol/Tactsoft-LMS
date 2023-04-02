using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class OrganizationController : Controller
    {
        private readonly IOrganizationService _organizationService;
        private readonly ICountryService _countryService;
        private readonly IStateService _stateService;
        private readonly ICityService _cityService;

        public OrganizationController(IOrganizationService organizationService, ICountryService countryService, IStateService stateService, ICityService cityService)
        {
            this._organizationService = organizationService;
            this._countryService = countryService;
            this._stateService = stateService;
            this._cityService = cityService;
        }

        public async Task<IActionResult> Index()
        {
            var org = await _organizationService.GetAllAsync(x => x.Country, i => i.State, i => i.City);
            return View(org);
        }

        // GET: OrganizationController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var org = await _organizationService.FindAsync(m => m.Id == id, e => e.Country, e => e.State, e => e.City);
            if (org == null)
            {
                return NotFound();
            }

            return View(org);
        }

        // GET: OrganizationController/Create
        public ActionResult Create()
        {
            ViewData["CountryId"] = _countryService.Dropdown();
            ViewData["StateId"] = _stateService.Dropdown();
            ViewData["CityId"] = _cityService.Dropdown();
            return View();
        }

        // POST: OrganizationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Organization organization, IFormFile pictureFile)
        {
            if (ModelState.IsValid)
            {
                if (pictureFile != null && pictureFile.Length > 0)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/orgainzation",
                     pictureFile.FileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        pictureFile.CopyTo(stream);
                    }
                    organization.Logo = $"{pictureFile.FileName}";
                }

                await _organizationService.InsertAsync(organization);
                TempData["successAlert"] = "Orgainzation save successfull.";
                return RedirectToAction(nameof(Index));
            }
            ViewData["CountryId"] = _countryService.Dropdown();
            ViewData["StateId"] = _stateService.Dropdown();
            ViewData["CityId"] = _cityService.Dropdown();

            TempData["errorAlert"] = "Operation failed.";
            return View(organization);
        }

        // GET: OrganizationController/Edit/5
        public async Task<IActionResult> Edit(long id)
        {
            var org = await _organizationService.FindAsync(id);
            if (org == null)
            {
                return NotFound();
            }
            ViewData["CountryId"] = _countryService.Dropdown();
            ViewData["StateId"] = _stateService.Dropdown();
            ViewData["CityId"] = _cityService.Dropdown();
            return View(org);
        }

        // POST: OrganizationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(Organization organization, IFormFile pictureFile)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var org = await _organizationService.FindAsync(organization.Id);

                    if (pictureFile != null && pictureFile.Length > 0)
                    {
                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/orgainzation",
                         pictureFile.FileName);

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            pictureFile.CopyTo(stream);
                        }
                        organization.Logo = $"{pictureFile.FileName}";
                    }
                    else
                    {
                        organization.Logo = org.Logo;
                    }
                    org.Logo = organization.Logo;
                    org.OrganizationName = organization.OrganizationName;
                    org.Address = organization.Address;
                    org.Phone = organization.Phone;
                    org.Email = organization.Email;
                    org.Establishment = organization.Establishment;
                    org.ContactPerson = organization.ContactPerson;
                    org.Description = organization.Description;
                    org.CountryId = organization.CountryId;
                    org.StateId = organization.StateId;
                    org.CityId = organization.CityId;

                    await _organizationService.UpdateAsync(org);
                    TempData["successAlert"] = "Organization update successfull.";
                }
                catch
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CountryId"] = _countryService.Dropdown();
            ViewData["StateId"] = _stateService.Dropdown();
            ViewData["CityId"] = _cityService.Dropdown();

            TempData["errorAlert"] = "Operation failed.";
            return View(organization);
        }

        // GET: OrganizationController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var org = await _organizationService.FindAsync(id);
            if (org == null)
            {
                return NotFound();
            }
            ViewData["CountryId"] = _countryService.Dropdown();
            ViewData["StateId"] = _stateService.Dropdown();
            ViewData["CityId"] = _cityService.Dropdown();

            return View(org);
        }

        // POST: EmployeeController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var org = await _organizationService.FindAsync(id);
            if (org != null)
            {
                await _organizationService.DeleteAsync(org);
                TempData["successAlert"] = "Organization remove successfull.";
            }

           
            return RedirectToAction(nameof(Index));
        }
    }
}
