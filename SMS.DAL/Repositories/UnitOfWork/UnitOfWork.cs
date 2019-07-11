using SMS.DAL.Context;
using SMS.Models.Contracts;
using System;

namespace SMS.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext context = new AppDbContext();
        private IMemberShipRepository _members;
        private IDayRepository _days;
        private IExamRepository _exams;
        private IExamScoreRepository _examscores;
        private IGroupRepository _groups;
        private ILessonRepository _lessons;
        private ILessonTeacherRepository _lessonteachers;
        private IPeriodRepository _periods;
        private IScheduleRepository _schedules;
        private IStudentGroupRepository _studentgroups;
        private ITimeTableRepository _timetables;

        public IMemberShipRepository Members
        {
            get
            {
                if (_members == null)
                    _members = new MemberShipRepository(context);
                return _members;
            }
        }

        public IDayRepository Days
        {
            get
            {
                if (_days == null)
                    _days = new DayRepository(context);
                return _days;
            }
        }

        public IExamRepository Exams
        {
            get
            {
                if (_exams == null)
                    _exams = new ExamRepository(context);
                return _exams;
            }
        }

        public IExamScoreRepository ExamScores
        {
            get
            {
                if (_examscores == null)
                    _examscores = new ExamScoreRepository(context);
                return _examscores;
            }
        }

        public IGroupRepository Groups
        {
            get
            {
                if (_groups == null)
                    _groups = new GroupRepository(context);
                return _groups;
            }
        }

        public ILessonRepository Lessons
        {
            get
            {
                if (_lessons == null)
                    _lessons = new LessonRepository(context);
                return _lessons;
            }
        }

        public ILessonTeacherRepository LessonTeacher
        {
            get
            {
                if (_lessonteachers == null)
                    _lessonteachers = new LessonTeacherRepository(context);
                return _lessonteachers;
            }
        }

        public IPeriodRepository Periods
        {
            get
            {
                if (_periods == null)
                    _periods = new PeriodRepository(context);
                return _periods;
            }
        }

        public IScheduleRepository Schedules
        {
            get
            {
                if (_schedules == null)
                    _schedules = new ScheduleRepository(context);
                return _schedules;
            }
        }

        public IStudentGroupRepository StudentGroups
        {
            get
            {
                if (_studentgroups == null)
                    _studentgroups = new StudentGroupRepository(context);
                return _studentgroups;
            }
        }

        public ITimeTableRepository TimeTables
        {
            get
            {
                if (_timetables == null)
                    _timetables = new TimeTableRepository(context);
                return _timetables;
            }
        }

        public int Save()
        {
            return context.SaveChanges();
        }
        private bool disposed = false;
        private void Dispose(bool disposing)
        {
            if (!disposed)
                if (disposing)
                    context.Dispose();
            disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
