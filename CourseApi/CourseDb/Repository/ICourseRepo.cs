using CourseDb.DTO;
using CourseDb.Models;

namespace CourseDb.Repository
{
    public interface ICourseRepo
    {
        Task<List<Course>> GetCourse();
        Task AddCourse(Course course);
        Task<Course> DeleteCourse(int id);
        Task<Course> UpdateCourse(int id, CourseDto courseDto);

    }
}