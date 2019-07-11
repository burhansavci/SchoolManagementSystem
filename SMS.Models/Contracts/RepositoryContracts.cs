using Microsoft.AspNet.Identity;
using SMS.Models.Entities;
using SMS.Models.Identity;

namespace SMS.Models.Contracts
{
    public interface IMemberShipRepository
    {
       UserManager<AppUser> Users { get; }
       RoleManager<AppRole> Roles { get; }
    }
   
    public interface IDayRepository : IRepository<Day>
    {
    }
    public interface IExamRepository : IRepository<Exam>
    {
    }
    public interface IExamScoreRepository : IRepository<ExamScore>
    {
    }
    public interface IGroupRepository : IRepository<Group>
    {
    }
    public interface ILessonRepository : IRepository<Lesson>
    {
    }
    public interface ILessonTeacherRepository : IRepository<LessonTeacher>
    {
    }
    public interface IPeriodRepository : IRepository<Period>
    {
    }
    public interface IScheduleRepository : IRepository<Schedule>
    {
    }
    public interface IStudentGroupRepository : IRepository<StudentGroup>
    {
    }
    public interface ITimeTableRepository : IRepository<TimeTable>
    {
    }
}
