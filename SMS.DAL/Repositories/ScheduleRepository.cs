using SMS.DAL.Context;
using SMS.Models.Contracts;
using SMS.Models.Entities;

namespace SMS.DAL.Repositories
{
    public class ScheduleRepository : Repository<Schedule>, IScheduleRepository
    {
        public ScheduleRepository(AppDbContext context) : base(context)
        {
        }
    }
}
