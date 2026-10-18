using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Timetable.Application.Groups.Queries.GetGroups;
using Timetable.Application.Lessons.Queries.GetGroupSchedule;
using Timetable.Domain.IRepositories;
using Timetable.Infrastructure.Database;
using Timetable.Infrastructure.Queries;
using Timetable.Infrastructure.Repositories;

namespace Timetable.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // міграція
        services.AddDbContext<SqliteConnectionContext>(options =>
            options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<ILessonRepository, LessonRepository>();
        services.AddScoped<IGroupRepository, GroupRepository>();
        services.AddScoped<ITeacherRepository, TeacherRepository>();
        services.AddScoped<ISubjectRepository, SubjectRepository>();
        services.AddScoped<IClassroomRepository, ClassroomRepository>();

        services.AddScoped<IGroupScheduleQueryService, GroupScheduleQueryService>();
        services.AddScoped<IGroupQueryService, GroupQueryService>();    

        return services;
    }
}