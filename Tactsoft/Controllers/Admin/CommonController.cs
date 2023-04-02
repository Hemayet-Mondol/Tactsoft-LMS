using Tactsoft.Core.Entities;
using Tactsoft.Service.DbDependencies;
using Microsoft.AspNetCore.Mvc;

namespace Tactsoft.Controllers.Admin
{
    public class CommonController : Controller
    {
        private readonly AppDbContext _context;

        public CommonController(AppDbContext context)
        {
            this._context = context;
        }

        public JsonResult GetStatesByCountryId(int countryId)
        {
            List<State> statesList = new List<State>();
            statesList = (from state in _context.States
                          where state.CountryId == countryId
                          select state).ToList();

            return Json(statesList);

        }

        public JsonResult GetCitiesByStateId(int stateId)
        {
            List<City> citiesList = new List<City>();

            citiesList = (from city in _context.Cities
                          where city.StateId == stateId
                          select city).ToList();

            return Json(citiesList);
        }

        public JsonResult GetLessonByCourse(int courseId)
        {
            var data = from l in _context.Lessons
                       where l.CourseId == courseId
                       join c in _context.Courses on l.CourseId equals c.Id
                       select new { l.LessonName, l.LessonNumber, l.LessonPdf, c.CourseName };

            //List<Lesson> lessonList = new List<Lesson>();
            //lessonList = (from lesson in _context.Lessons
            //              where lesson.CourseId == courseId
            //              select lesson).ToList();

            return Json(data);

        }
        public JsonResult GetIdentityNumber(int courseId, int batchId)
        {
            string date = DateTime.Now.ToString("yy");
            string lastIdNumber = (from n in _context.Students
                                   where n.BatchId == batchId
                                   orderby n.Id descending
                                   select n.StudentId).FirstOrDefault();
            string course = (from c in _context.Courses
                             where c.Id == courseId
                             select c.CourseName).FirstOrDefault();

            string batch = (from b in _context.Batchs
                            where b.Id == batchId && b.CourseId == courseId
                            select b.BatchNumber).FirstOrDefault();


            if (lastIdNumber != null)
            {
                string[] numbers = lastIdNumber.Split('-');
                string lastId = numbers[1].Substring(numbers[1].Length - 5);
                var randomNumber = course + "-" + date + batch + (Convert.ToInt32(lastId) + 1).ToString();
                return Json(randomNumber);
            }
            else 
            { 
                var randomNumber = course + "-" + date + "-" + batch + (10001).ToString();
                return Json(randomNumber);
            }

        }

        public JsonResult GetBatchByCourse(int courseId)
        {
            List<Batch> batchList = new List<Batch>();

            batchList = (from batch in _context.Batchs
                         where batch.CourseId == courseId
                         select batch).ToList();

            return Json(batchList);
        }

        public JsonResult GetStudentByBatch(int batchId)
        {
            List<Student> studentList = new List<Student>();

            studentList = (from student in _context.Students
                         where student.BatchId == batchId
                           select student).ToList();
            return Json(studentList);
        }

		public JsonResult GetAssignmentByBatch(int batchId)
		{
			List<Assignment> assignmentList = new List<Assignment>();

			assignmentList = (from assignment in _context.Assignments
						   where assignment.BatchId == batchId
						   select assignment).ToList();
			return Json(assignmentList);
		}

	}
}
