using SMS.BLL.Service;
using SMS.Models.Entities;
using SMS.UI.Areas.Panel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS.UI.Areas.Panel.Controllers
{
    [Authorize(Roles = "principal,personnel")]
    public class GroupController : Controller
    {
        DataService service = new DataService();
        public ActionResult GetGroups()
        {
            var groups = service.UnitOfWork.Groups.Get(x => x.IsActive == true);
            var models = new List<GroupGetVm>();
            foreach (var group in groups)
            {
                var model = new GroupGetVm
                {
                    Id = group.Id,
                    Level = group.Level,
                    Name = group.Name,
                    IsActive = true,
                    AddedDate = group.AddedDate
                };
                models.Add(model);
            }
            return View(models);
        }
        [HttpPost]
        public ActionResult Post(GroupAddVm data)
        {
            if (ModelState.IsValid)
            {
                var groupManager = service.UnitOfWork.Groups;
                groupManager.Insert(new Group
                {
                    Level = data.Level,
                    Name = data.Name,
                    AddedDate = DateTime.Now,
                    IsActive = true,
                });

                service.UnitOfWork.Save();
            }
            return Redirect(data.RedirectUrl);
        }
        public ActionResult Update(GroupUpdateVm data)
        {
            if (ModelState.IsValid)
            {
                var groupManager = service.UnitOfWork.Groups;
                var toBeUpdatedGroup = groupManager.GetById(data.GroupId);
                toBeUpdatedGroup.Level = data.Level;
                toBeUpdatedGroup.Name = data.Name;
                groupManager.Update(toBeUpdatedGroup);
                service.UnitOfWork.Save();
            }
            return Redirect(data.RedirectUrl);
        }
        public void Delete(int groupId)
        {
            var groupManager = service.UnitOfWork.Groups;
            var group = groupManager.GetById(groupId);
            if (group != null)
            {
                group.IsActive = false;
                service.UnitOfWork.Save();
            }
        }
    }
}