using CourseDb.DTO;
using CourseDb.Models;

namespace CourseDb.Service
{
    public interface ICourseService
    {
        Task<List<Course>> GetCourse();

        Task<Course> AddCourse(CourseDto courseDto);

        Task<CourseDto> DeleteCourse(int id);

        Task<CourseDto> UpdateCourse(int id, CourseDto courseDto);

    }
}