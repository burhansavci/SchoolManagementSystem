using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SMS.DAL.Context;
using SMS.Models.Contracts;
using SMS.Models.Identity;

namespace SMS.DAL.Repositories
{
    public class MemberShipRepository : IMemberShipRepository
    {
        private AppDbContext context;
        private UserStore<AppUser> _userStore;
        private UserManager<AppUser> _userManager;
        private RoleStore<AppRole> _roleStore;
        private RoleManager<AppRole> _roleManager;

        public MemberShipRepository(AppDbContext context)
        {
            this.context = context;
            _userStore = new UserStore<AppUser>(this.context);
            _roleStore = new RoleStore<AppRole>(this.context);
        }       

        public UserManager<AppUser> Users
        {
            get
            {
                if (_userManager == null)
                    _userManager = new UserManager<AppUser>(_userStore);

                return _userManager;
            }
        }

        public RoleManager<AppRole> Roles
        {
            get
            {
                if (_roleManager == null)
                    _roleManager = new RoleManager<AppRole>(_roleStore);

                return _roleManager;
            }
        }
    }
}
