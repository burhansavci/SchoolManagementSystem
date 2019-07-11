using System;

namespace SMS.Models.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IMemberShipRepository Members { get; }
        IDayRepository Days { get; }
        IExamRepository Exams { get; }
        IExamScoreRepository ExamScores { get; }
        IGroupRepository Groups { get; }
        ILessonRepository Lessons { get; }
        ILessonTeacherRepository LessonTeacher { get; }
        IPeriodRepository Periods { get; }
        IScheduleRepository Schedules { get; }
        IStudentGroupRepository StudentGroups { get; }
        ITimeTableRepository TimeTables { get; }
        int Save();
    }
}
