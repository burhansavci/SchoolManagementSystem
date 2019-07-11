using Microsoft.AspNet.Identity;
using SMS.BLL.Service;
using SMS.Models.Identity;
using SMS.UI.Areas.Panel.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SMS.UI.Areas.Panel.Controllers
{
    [Authorize(Roles = "principal")]
    public class PersonnelController : Controller
    {
        DataService service = new DataService();
        public ActionResult GetPersonnels()
        {
            var personnelRole = service.UnitOfWork.Members.Roles.FindByName("personnel");
            var personnels = service.UnitOfWork.Members.Users.Users.Where(x => x.Roles.Any(y => y.RoleId == personnelRole.Id) && x.IsActive == true).ToList();
            var modals = new List<PersonnelGetVm>();
            foreach (var personnel in personnels)
            {
                var modal = new PersonnelGetVm
                {
                    Id = personnel.Id,
                    UserName = personnel.UserName,
                    FirstName = personnel.FirstName,
                    LastName = personnel.LastName,
                    PhoneNumber = personnel.PhoneNumber,
                    Email = personnel.Email,
                    TcNo = personnel.TCNo,
                    IsActive = personnel.IsActive,
                };
                modals.Add(modal);
            }
            return View(modals);
        }
        [HttpPost]
        public ActionResult Post(PersonnelAddVm data)
        {
            if (ModelState.IsValid)
            {
                var userManager = service.UnitOfWork.Members.Users;
                userManager.Create(new AppUser
                {
                    UserName = data.UserName,
                    FirstName = data.FirstName,
                    LastName = data.LastName,
                    PhoneNumber = data.PhoneNumber,
                    Email = data.Email,
                    TCNo = data.TcNo,
                    IsActive = true,
                }, data.Password);
                var userId = userManager.FindByName(data.UserName).Id;
                userManager.AddToRole(userId, "personnel");

            }
            return Redirect(data.RedirectUrl);
        }
        [HttpPost]
        public ActionResult Update(PersonnelUpdateVm data)
        {
            if (ModelState.IsValid)
            {   //initilazing managers
                var userManager = service.UnitOfWork.Members.Users;
                // get current user data
                var toBeUpdatedUser = userManager.FindById(data.PersonnelId);
                //set coming data value to currentuser data
                toBeUpdatedUser.UserName = data.UserName;
                toBeUpdatedUser.FirstName = data.FirstName;
                toBeUpdatedUser.LastName = data.LastName;
                toBeUpdatedUser.PhoneNumber = data.PhoneNumber;
                toBeUpdatedUser.Email = data.Email;
                toBeUpdatedUser.TCNo = data.TcNo;

                userManager.Update(toBeUpdatedUser);
                service.UnitOfWork.Save();
            }
            return Redirect(data.RedirectUrl);
        }

        public void Delete(string userId)
        {
            var userManager = service.UnitOfWork.Members.Users;
            var personnel = userManager.FindById(userId);
            if (personnel != null)
            {
                personnel.IsActive = false;
                service.UnitOfWork.Save();
            }
        }
    }
}