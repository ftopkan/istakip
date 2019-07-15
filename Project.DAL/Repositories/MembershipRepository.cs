using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Project.DAL.Context;
using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repositories
{
    public class MembershipRepository
    {

        private AppDbContext context;
        private UserStore<AppUser> _userStore;
        private UserManager<AppUser> _userManager;
        private RoleStore<AppRole> _roleStore;
        private RoleManager<AppRole> _roleManager;

        public MembershipRepository(AppDbContext context)
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
