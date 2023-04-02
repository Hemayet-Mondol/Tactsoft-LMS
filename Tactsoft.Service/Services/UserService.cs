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
    public class UserService : BaseService<User>, IUserService
    {
        private readonly AppDbContext _appDbContext;
        public UserService(AppDbContext context) : base(context)
        {
            _appDbContext = context;
        }
        public IEnumerable<SelectListItem> Dropdown()
        {
            return All().Select(x => new SelectListItem { Text = x.UserName, Value = x.Id.ToString() });

        }
    }
}