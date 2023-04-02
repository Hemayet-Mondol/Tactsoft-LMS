using Tactsoft.Core.Entities;
using Tactsoft.Service.DbDependencies;
using Tactsoft.Service.Services.Base;

namespace Tactsoft.Service.Services
{
    public class EventService : BaseService<Event>, IEventService
    {
        private readonly AppDbContext _context;
        public EventService(AppDbContext context) : base(context)
        {
            this._context = context;
        }
    }
}
