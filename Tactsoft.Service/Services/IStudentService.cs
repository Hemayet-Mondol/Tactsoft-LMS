using Microsoft.AspNetCore.Mvc.Rendering;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services.Base;

namespace Tactsoft.Service.Services
{
    public interface IStudentService:IBaseService<Student>
    {
        IEnumerable<SelectListItem> Dropdown();
        IEnumerable<Student> StudentByBatch(int bId);
        string NameById(long id);
    }

}
