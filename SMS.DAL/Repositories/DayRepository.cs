using SMS.DAL.Context;
using SMS.Models.Contracts;
using SMS.Models.Entities;

namespace SMS.DAL.Repositories
{
    public class DayRepository : Repository<Day>, IDayRepository
    {
        public DayRepository(AppDbContext context) : base(context)
        {
        }
    }
}
