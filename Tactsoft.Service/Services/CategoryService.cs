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
    public class CategoryService : BaseService<Category>, ICategoryService
    {
        private readonly AppDbContext _appDbContext;
        public CategoryService(AppDbContext context) : base(context)
        {
            _appDbContext = context;
        }
        public IEnumerable<SelectListItem> Dropdown()
        {
            return All().Select(x => new SelectListItem { Text = x.CategoryName, Value = x.Id.ToString() });
        }
    }
}
