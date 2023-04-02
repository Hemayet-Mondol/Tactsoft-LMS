using Tactsoft.Core.Entities;
using Tactsoft.Service.DbDependencies;
using Tactsoft.Service.Services.Base;

namespace Tactsoft.Service.Services
{
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        private readonly AppDbContext _context;

        public EmployeeService(AppDbContext context) : base(context)
        {
            this._context = context;
        }
    }
}
