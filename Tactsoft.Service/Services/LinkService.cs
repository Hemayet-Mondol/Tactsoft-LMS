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
    public class LinkService : BaseService<Link>, ILinkService
    {
        private readonly AppDbContext _context;
        public LinkService(AppDbContext context) : base(context)
        {
            this._context = context;
        }

        public IEnumerable<SelectListItem> Dropdown()
        {
            return All().Select(x => new SelectListItem { Text = x.Course.CourseName, Value = x.Course.Id.ToString() });
        }
        ////public IEnumerable<SelectListItem> Dropdown()
        ////{
        ////    return All().Select(x => new SelectListItem { Text = x.Batch.BatchName, Value = x.Batch.Id.ToString() });
        ////}
    }
}
