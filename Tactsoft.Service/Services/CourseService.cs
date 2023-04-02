using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tactsoft.Core.Entities;
using Tactsoft.Service.DbDependencies;
using Tactsoft.Service.Services.Base;

namespace Tactsoft.Service.Services
{
    public class CourseService : BaseService<Course>, ICourseService
    {
        private readonly AppDbContext _appDbContext;
        public CourseService(AppDbContext context) : base(context)
        {
            _appDbContext = context;
        }

        public IEnumerable<SelectListItem> Dropdown()
        {
            return All().Select(x => new SelectListItem { Text = x.CourseName, Value = x.Id.ToString() });

        }
    }
}
