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
    public class ClassVideoService : BaseService<ClassVideo> , IClassVideoService
    {
        private readonly AppDbContext _context;
        public ClassVideoService(AppDbContext context) : base(context)
        {
            this._context = context;
        }
    }
}
