using SMS.DAL.Context;
using SMS.Models.Contracts;
using SMS.Models.Entities;

namespace SMS.DAL.Repositories
{
    public class LessonTeacherRepository : Repository<LessonTeacher>, ILessonTeacherRepository
    {
        public LessonTeacherRepository(AppDbContext context) : base(context)
        {
        }
    }
}
