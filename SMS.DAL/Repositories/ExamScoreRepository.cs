using SMS.DAL.Context;
using SMS.Models.Contracts;
using SMS.Models.Entities;

namespace SMS.DAL.Repositories
{
    public class ExamScoreRepository : Repository<ExamScore>, IExamScoreRepository
    {
        public ExamScoreRepository(AppDbContext context) : base(context)
        {
        }
    }
}
