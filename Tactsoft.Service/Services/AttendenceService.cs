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
    public class AttendenceService : BaseService<Attendence>,IAttendenceService
    {
        private readonly AppDbContext _context;

        public AttendenceService(AppDbContext context) : base(context)
        {
            this._context = context;
        }
        public  IEnumerable<SelectListItem> Dropdown()
        {
            return All().Select(x => new SelectListItem { Text = x.AttendenceDate.ToShortDateString(), Value = x.Id.ToString() });
        }
    }
}
