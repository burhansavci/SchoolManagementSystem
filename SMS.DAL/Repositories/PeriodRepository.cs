using SMS.DAL.Context;
using SMS.Models.Contracts;
using SMS.Models.Entities;

namespace SMS.DAL.Repositories
{
    public class PeriodRepository : Repository<Period>, IPeriodRepository
    {
        public PeriodRepository(AppDbContext context) : base(context)
        {
        }
    }
}
