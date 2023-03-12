using AutoMapper;
using CourseDb.DTO;
using CourseDb.Models;

namespace CourseDb.Profiles
{
    public class CourseProfile : Profile
    {
        public CourseProfile() {
            CreateMap<Course, CourseDto>();
            CreateMap<CourseDto, Course>();
        }
    }
}
