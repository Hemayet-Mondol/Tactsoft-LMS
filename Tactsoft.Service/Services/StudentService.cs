using Microsoft.AspNetCore.Mvc.Rendering;
using Tactsoft.Core.Entities;
using Tactsoft.Service.DbDependencies;
using Tactsoft.Service.Services.Base;

namespace Tactsoft.Service.Services
{
    public class StudentService : BaseService<Student>, IStudentService
    {
        private readonly AppDbContext _context;

        public StudentService(AppDbContext context) : base(context)
        {
            this._context = context;
        }
        public IEnumerable<SelectListItem> Dropdown()
        {
            return All().Select(x => new SelectListItem { Text = x.StudentName, Value = x.Id.ToString() });
        }
        public IEnumerable<Student> StudentByBatch(int bId)
        {
            if (bId == 0)
                return All();
            return All().Where(x => x.BatchId == bId);
        }
        public string NameById(long id)
        {
            var stu = Find(id);
            return stu.StudentName;
        }

    }
}
