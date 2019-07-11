using SMS.DAL.Context;
using SMS.Models.Contracts;
using SMS.Models.Entities;

namespace SMS.DAL.Repositories
{
    public class GroupRepository : Repository<Group>, IGroupRepository
    {
        public GroupRepository(AppDbContext context) : base(context)
        {
        }
    }
}
