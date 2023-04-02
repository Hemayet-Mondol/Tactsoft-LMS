
using Microsoft.AspNetCore.Mvc.Rendering;
using Tactsoft.Core.Entities;

using Tactsoft.Service.Services.Base;

namespace Tactsoft.Service.Services
{
    public interface ICourseService : IBaseService<Course>
    {
        IEnumerable<SelectListItem> Dropdown();
    }
}
