using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Core.ViewModel;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class AttendenceController : Controller
    {
        private readonly IAttendenceService _attendenceService;
        private readonly IBatchService _batchService;
        private readonly IStudentService _studentService;
        private readonly ICourseService _courseService;


        public AttendenceController(IAttendenceService attendenceService, IBatchService batchService, IStudentService studentService, ICourseService courseService)
        {
            _attendenceService = attendenceService;
            _batchService = batchService;
            _studentService = studentService;
            _courseService = courseService;
        }

        // GET: AttendenceController
        public IActionResult Index()
        {
            ViewData["CourseId"] = _courseService.Dropdown();
            ViewData["BatchId"] = _batchService.Dropdown();
            return View();
        }

        [HttpPost]
        public ActionResult Index(AttendenceReport model)
        {
            ViewData["CourseId"] = _courseService.Dropdown();
            ViewData["BatchId"] = _batchService.Dropdown();

            var employees = _studentService.StudentByBatch(model.BatchId);

            int days = DateTime.DaysInMonth(DateTime.Now.Year, model.Month);
            DateTime firstdayofmonth = new DateTime(DateTime.Now.Year, model.Month, 1);
            DateTime lastdayofmonth = new DateTime(DateTime.Now.Year, model.Month, 1).AddMonths(1).AddDays(-1);

            var attendences = _attendenceService.All().Where(x => x.AttendenceDate >= firstdayofmonth && x.AttendenceDate <= lastdayofmonth).ToList();
            AttendenceReport attendenceReport = new AttendenceReport();
            attendenceReport.BatchId = model.BatchId;
            attendenceReport.Month = model.Month;

            for (int i = 1; i <= days; i++)
            {
                string currentDate = new DateTime(DateTime.Now.Year, model.Month, i).ToShortDateString();
                attendenceReport.AllCurrentMonthDate.Add(currentDate);
            }

            foreach (var item in employees)
            {
                EmployeeAttendenceStatus empStatusVm = new EmployeeAttendenceStatus(days, model.Month);
                empStatusVm.StudentId = (int)item.Id;
                empStatusVm.StudentName = item.StudentName;
                var attendenceWithEmployee = attendences.Where(x => x.StudentId == item.Id).OrderBy(x => x.AttendenceDate).ToList();
                foreach (var attEmp in attendenceWithEmployee)
                {
                    string attndDate = attEmp.AttendenceDate.ToShortDateString();

                    if (attendenceReport.AllCurrentMonthDate.Contains(attndDate))
                    {
                        var statusR = empStatusVm.attendenceStatus.FindIndex(x => x.Date.ToShortDateString() == attndDate);
                        empStatusVm.attendenceStatus.RemoveAt(statusR);

                        var status = new AttendenceStatus();
                        status.Date = attEmp.AttendenceDate;
                        if (attEmp.IsPresent == true)
                        {
                            status.Status = "Present";
                        }

                        if (attEmp.IsPresent == false)
                        {
                            status.Status = "Absense";
                        }
                        empStatusVm.attendenceStatus.Insert(statusR, status);
                    }

                }
                attendenceReport.EmployeeAttendenceStatus.Add(empStatusVm);
            }
            return View(attendenceReport);
        }
        public ActionResult TakeAttendence()
        {
            ViewData["CourseId"] = _courseService.Dropdown();
            ViewData["BatchId"] = _batchService.Dropdown();
            return View(new AttendenceModel());
        }

        // POST: CityController/TakeAttendence
        [HttpPost]
        public ActionResult TakeAttendence(AttendenceModel model)
        {
            ViewData["CourseId"] = _courseService.Dropdown();
            ViewData["BatchId"] = _batchService.Dropdown();
            //var attendences = _attendenceService.All().Any(x => x.AttendenceDate == model.AttendenceDate);
            AttendenceModel attendenceModel = new AttendenceModel();
            attendenceModel.AttendenceDate = model.AttendenceDate;
            attendenceModel.BatchId = model.BatchId;
            //if (attendences)
            //{
            //    var attendecesList = _attendenceService.All().Where(x => x.AttendenceDate == model.AttendenceDate).ToList();
            //    foreach (var item in attendecesList)
            //    {
            //        attendenceModel.AttendenceList.Add(new AttendenceList
            //        {
            //            StudentId = item.StudentId,
            //            AttendenceId = item.Id,
            //            IsPresent = item.IsPresent,
            //            Name = _studentService.NameById(item.StudentId)
            //        });
            //    }
            //    return View(attendenceModel);
            //}

            var employees = _studentService.StudentByBatch(model.BatchId);
            if (employees != null)
            {
                var attendecesList = _attendenceService.All().Where(x => x.AttendenceDate == model.AttendenceDate).ToList();

                foreach (var item in employees)
                {
                    foreach (var attendence in attendecesList)
                    {
                                          
                            attendenceModel.AttendenceList.Add(new AttendenceList
                            {
                                BatchId = model.BatchId,
                                StudentId = item.Id,
                                Name = item.StudentName,
                                IsPresent =  (attendence.StudentId == item.Id) ? true : false,

                            });
                       
                    }
                   
                }
                return View(attendenceModel);
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SaveAttendence(AttendenceModel model)
        {
            if (model.AttendenceList.Count() > 0)
            {
                foreach (var item in model.AttendenceList)
                {
                    if (item.AttendenceId == 0)
                    {
                        //save 
                        await _attendenceService.InsertAsync(new Attendence
                        {
                            AttendenceDate = model.AttendenceDate,
                            StudentId = item.StudentId,
                            BatchId = model.BatchId,
                            IsPresent = item.IsPresent
                        });
                    }
                    else
                    {
                        // update 
                        var existingAttendence = await _attendenceService.FindAsync(item.AttendenceId);
                        if (existingAttendence != null)
                        {
                            existingAttendence.IsPresent = item.IsPresent;
                            existingAttendence.BatchId = item.BatchId;
                            existingAttendence.StudentId = item.StudentId;
                            await _attendenceService.UpdateAsync(existingAttendence.Id, existingAttendence);
                        }
                    }
                }
            }
            return RedirectToAction("TakeAttendence");
        }

        // GET: AttendenceController/Details/5

    }
}
