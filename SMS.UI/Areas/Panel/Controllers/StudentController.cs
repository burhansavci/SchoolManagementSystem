using Microsoft.AspNet.Identity;
using SMS.BLL.Service;
using SMS.Models.Entities;
using SMS.Models.Identity;
using SMS.UI.Areas.Panel.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SMS.UI.Areas.Panel.Controllers
{
    [Authorize(Roles = "principal,personnel")]
    public class StudentController : Controller
    {
        DataService service = new DataService();
        public ActionResult GetStudents()
        {
            var studentGroups = service.UnitOfWork.StudentGroups
                .Get(x => x.Student.IsActive == true && x.Group.IsActive == true)
                .ToList();
            var groups = service.UnitOfWork.Groups.Get(x => x.IsActive == true).ToList();
            ViewBag.groups = groups.OrderBy(x => x.Level).ToList();
            var modals = new List<StudentGetVm>();
            foreach (var studentGroup in studentGroups)
            {
                var modal = new StudentGetVm
                {
                    Id = studentGroup.StudentId,
                    UserName = studentGroup.Student.UserName,
                    FirstName = studentGroup.Student.FirstName,
                    LastName = studentGroup.Student.LastName,
                    ParentPhoneNumber = studentGroup.Student.PhoneNumber,
                    Email = studentGroup.Student.Email,
                    TcNo = studentGroup.Student.TCNo,
                    IsActive = studentGroup.Student.IsActive,
                    Group = $"{studentGroup.Group.Level}-{studentGroup.Group.Name}",
                    GroupId = studentGroup.GroupId,

                };
                modals.Add(modal);

            }
            return View(modals);
        }

        [HttpPost]
        public ActionResult Post(StudentAddVm data)
        {
            if (ModelState.IsValid)
            {
                var userManager = service.UnitOfWork.Members.Users;
                var studentGroupsManager = service.UnitOfWork.StudentGroups;
                var groupManager = service.UnitOfWork.Groups;
                userManager.Create(new AppUser
                {
                    UserName = data.UserName,
                    FirstName = data.FirstName,
                    LastName = data.LastName,
                    PhoneNumber = data.ParentPhoneNumber,
                    Email = data.Email,
                    TCNo = data.TcNo,
                    IsActive = true,
                }, data.Password);

                var groupLevel = int.Parse(data.GroupLevel);
                var groupId = groupManager.Get(x => x.Name == data.GroupName && x.Level == groupLevel).FirstOrDefault().Id;

                var userId = userManager.FindByName(data.UserName).Id;
                userManager.AddToRole(userId, "student");

                studentGroupsManager.Insert(new StudentGroup
                {
                    StudentId = userId,
                    GroupId = groupId
                });

                service.UnitOfWork.Save();
            }
            return Redirect(data.RedirectUrl);
        }

        [HttpPost]
        public ActionResult Update(StudentUpdateVm data)
        {
            if (ModelState.IsValid)
            {   //initilazing managers
                var userManager = service.UnitOfWork.Members.Users;
                var groupManager = service.UnitOfWork.Groups;
                var studentGroupsManager = service.UnitOfWork.StudentGroups;
                // get current user data
                var toBeUpdatedUser = userManager.FindById(data.StudentId);
                var toBeUpdatedStudentGroup = studentGroupsManager.Get(x => x.StudentId == toBeUpdatedUser.Id && x.GroupId == data.GroupId).FirstOrDefault();
                var groupLevel = int.Parse(data.GroupLevel);
                var newGroup = groupManager.Get(x => x.Name == data.GroupName && x.Level == groupLevel).FirstOrDefault();
                //set coming data value to currentuser data
                toBeUpdatedUser.UserName = data.UserName;
                toBeUpdatedUser.FirstName = data.FirstName;
                toBeUpdatedUser.LastName = data.LastName;
                toBeUpdatedUser.PhoneNumber = data.ParentPhoneNumber;
                toBeUpdatedUser.Email = data.Email;
                toBeUpdatedUser.TCNo = data.TcNo;
                //delete existing relation from join table
                studentGroupsManager.Delete(x => x.StudentId == toBeUpdatedStudentGroup.StudentId && x.GroupId == data.GroupId);
                service.UnitOfWork.Save();
                //insert new relation into join table
                userManager.Update(toBeUpdatedUser);
                studentGroupsManager.Insert(new StudentGroup
                {
                    StudentId = toBeUpdatedUser.Id,
                    GroupId = newGroup.Id,
                });
                service.UnitOfWork.Save();
            }
            return Redirect(data.RedirectUrl);
        }

        public void Delete(string userId)
        {
            var userManager = service.UnitOfWork.Members.Users;
            var student = userManager.FindById(userId);
            if (student != null)
            {
                student.IsActive = false;
                service.UnitOfWork.Save();
            }

        }
    }
}