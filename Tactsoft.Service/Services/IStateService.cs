using Tactsoft.Core.Entities;
using Tactsoft.Service.Services.Base;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Tactsoft.Service.Services
{   
    public interface IStateService:IBaseService<State>
    {
        IEnumerable<SelectListItem> Dropdown();
    }
}
