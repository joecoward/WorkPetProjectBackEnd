using AutoMapper;
using Timetable.Application.Groups.Queries.GetGroups;
using Timetable.Application.Lessons.Queries.GetGroupSchedule;
using Timetable.Domain.Aggregates;
using Timetable.Domain.Entities;
using Timetable.Domain.Groups.Queries.GetGroups;

namespace Timetable.Application.Common.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Group, GroupDto>();

        CreateMap<Lesson, LessonDto>()
            .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => src.Time.StartTime))
            .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => src.Time.EndTime));

    }
}