using Tactsoft.Service.Services.Base;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tactsoft.Service.Services;

namespace Tactsoft.Service.Dependency
{
    public static class ServiceDependency
    {
        public static void AddServiceDependency(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<IStateService, StateService>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<ITrainerService, TrainerService>();
            services.AddScoped<IBatchService, BatchService>();
            services.AddScoped<IOrganizationService, OrganizationService>();
            services.AddScoped<ILessonService, LessonService>();
            services.AddScoped<IClassRoomService, ClassRoomService>();
            services.AddScoped<IAttendenceService, AttendenceService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IAttendenceDetailsService, AttendenceDetailsService>();
            services.AddScoped<IAssingmentService, AssignmentService>();
            services.AddScoped<IClassVideoService, ClassVideoService>();
            services.AddScoped<IExamService, ExamService>();
            services.AddScoped<IExamResultService, ExamResultService>();
            services.AddScoped<IUserTypeService, UserTypeService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IVenueService, VenueService>();
            services.AddScoped<IDocumentTypeService, DocumentTypeService>();
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IJobplacementService, JobplacementService>();
            services.AddScoped<ILinkService, LinkService>();
			services.AddScoped<IAssignmentDetailsService, AssignmentDetailsService>();
			services.AddScoped<IAttachmentService, AttachmentService>();
		}
    }
}
