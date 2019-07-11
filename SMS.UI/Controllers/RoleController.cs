using Microsoft.AspNet.Identity;
using SMS.BLL.Service;
using SMS.Models.Identity;
using System.Web.Mvc;

namespace SMS.UI.Controllers
{
    public class RoleController : Controller
    {
        DataService service = new DataService();
        public ActionResult CreateRoles()
        {
            if (!service.UnitOfWork.Members.Roles.RoleExists("student"))
                service.UnitOfWork.Members.Roles.Create(new AppRole { Name = "student" });
            if (!service.UnitOfWork.Members.Roles.RoleExists("teacher"))
                service.UnitOfWork.Members.Roles.Create(new AppRole { Name = "teacher" });
            if (!service.UnitOfWork.Members.Roles.RoleExists("personnel"))
                service.UnitOfWork.Members.Roles.Create(new AppRole { Name = "personnel" });
            if (!service.UnitOfWork.Members.Roles.RoleExists("principal"))
                service.UnitOfWork.Members.Roles.Create(new AppRole { Name = "principal" });
            return View();
        }
        public ActionResult CreateUsers()
        {//Add Principal
            if (service.UnitOfWork.Members.Users.FindByName("ogrthsn") == null)
            {
                service.UnitOfWork.Members.Users.Create(new AppUser
                {
                    Email = "hasan.uzun@sms.com",
                    PhoneNumber = "0555776611",
                    UserName = "ogrthsn",
                    TCNo = "11111111654",
                    FirstName = "Hasan",
                    LastName = "Uzun",
                    IsActive = true,
                }, "123qwe");

                var userId = service.UnitOfWork.Members.Users.FindByName("ogrthsn").Id;

                service.UnitOfWork.Members.Users.AddToRole(userId, "teacher");
                service.UnitOfWork.Members.Users.AddToRole(userId, "principal");
            }
            //Add teachers
            if (service.UnitOfWork.Members.Users.FindByName("ogrtftm") == null)
            {
                service.UnitOfWork.Members.Users.Create(new AppUser
                {
                    Email = "fatma.dogru@sms.com",
                    PhoneNumber = "05556665533",
                    UserName = "ogrtftm",
                    TCNo = "22222222222",
                    FirstName = "Fatma",
                    LastName = "Doğru",
                    IsActive = true,
                }, "123qwe");

                var userId = service.UnitOfWork.Members.Users.FindByName("ogrtftm").Id;

                service.UnitOfWork.Members.Users.AddToRole(userId, "teacher");
            }

            if (service.UnitOfWork.Members.Users.FindByName("ogrtogz") == null)
            {
                service.UnitOfWork.Members.Users.Create(new AppUser
                {
                    Email = "ogz.all@sms.com",
                    PhoneNumber = "05551234512",
                    UserName = "ogrtogz",
                    TCNo = "12341234123",
                    FirstName = "Oğuz",
                    LastName = "Allı",
                    IsActive = true,
                }, "123qwe");

                var userId = service.UnitOfWork.Members.Users.FindByName("ogrtogz").Id;

                service.UnitOfWork.Members.Users.AddToRole(userId, "teacher");
            }

            if (service.UnitOfWork.Members.Users.FindByName("ogrtcnn") == null)
            {
                service.UnitOfWork.Members.Users.Create(new AppUser
                {
                    Email = "canan.kara@sms.com",
                    PhoneNumber = "05552220033",
                    UserName = "ogrtcnn",
                    TCNo = "55555555555",
                    FirstName = "Canan",
                    LastName = "Kara",
                    IsActive = true,
                }, "123qwe");

                var userId = service.UnitOfWork.Members.Users.FindByName("ogrtcnn").Id;

                service.UnitOfWork.Members.Users.AddToRole(userId, "teacher");
            }

            if (service.UnitOfWork.Members.Users.FindByName("ogrtays") == null)
            {
                service.UnitOfWork.Members.Users.Create(new AppUser
                {
                    Email = "ayse.zeybek@sms.com",
                    PhoneNumber = "05553331100",
                    UserName = "ogrtays",
                    TCNo = "66666666669",
                    FirstName = "Ayşe",
                    LastName = "Zeybek",
                    IsActive = true,
                }, "123qwe");

                var userId = service.UnitOfWork.Members.Users.FindByName("ogrtays").Id;

                service.UnitOfWork.Members.Users.AddToRole(userId, "teacher");
            }

            if (service.UnitOfWork.Members.Users.FindByName("ogrtdgn") == null)
            {
                service.UnitOfWork.Members.Users.Create(new AppUser
                {
                    Email = "dogan.bayrak@sms.com",
                    PhoneNumber = "05550002211",
                    UserName = "ogrtdgn",
                    TCNo = "77777777777",
                    FirstName = "Doğan",
                    LastName = "Bayrak",
                    IsActive = true,
                }, "123qwe");

                var userId = service.UnitOfWork.Members.Users.FindByName("ogrtdgn").Id;

                service.UnitOfWork.Members.Users.AddToRole(userId, "teacher");
            }
            // Add personnels
            if (service.UnitOfWork.Members.Users.FindByName("prsnlsym") == null)
            {
                service.UnitOfWork.Members.Users.Create(new AppUser
                {
                    Email = "seyma.konak@sms.com",
                    PhoneNumber = "05559998877",
                    UserName = "prsnlsym",
                    TCNo = "19283746500",
                    FirstName = "Şeyma",
                    LastName = "Konak",
                    IsActive = true,
                }, "123qwe");

                var userId = service.UnitOfWork.Members.Users.FindByName("prsnlsym").Id;

                service.UnitOfWork.Members.Users.AddToRole(userId, "personnel");
            }

            if (service.UnitOfWork.Members.Users.FindByName("prsnnlorhn") == null)
            {
                service.UnitOfWork.Members.Users.Create(new AppUser
                {
                    Email = "orhan.doruk@sms.com",
                    PhoneNumber = "05557779911",
                    UserName = "prsnnlorhn",
                    TCNo = "33333333333",
                    FirstName = "Orhan",
                    LastName = "Doruk",
                    IsActive = true,
                }, "123qwe");

                var userId = service.UnitOfWork.Members.Users.FindByName("prsnnlorhn").Id;

                service.UnitOfWork.Members.Users.AddToRole(userId, "personnel");
            }
            //Add students
            if (service.UnitOfWork.Members.Users.FindByName("ogrcn") == null)
            {
                service.UnitOfWork.Members.Users.Create(new AppUser
                {
                    Email = "can.demir@sms.com",
                    PhoneNumber = "05559995544",
                    UserName = "ogrcn",
                    TCNo = "44444444444",
                    FirstName = "Can",
                    LastName = "Demir",
                    IsActive = true,
                }, "123qwe");

                var userId = service.UnitOfWork.Members.Users.FindByName("ogrcn").Id;

                service.UnitOfWork.Members.Users.AddToRole(userId, "student");
            }

            if (service.UnitOfWork.Members.Users.FindByName("ogrzynp") == null)
            {
                service.UnitOfWork.Members.Users.Create(new AppUser
                {
                    Email = "zeynep.buyu@sms.com",
                    PhoneNumber = "05552229900",
                    UserName = "ogrzynp",
                    TCNo = "88888888888",
                    FirstName = "Zeynep",
                    LastName = "Büyü",
                    IsActive = true,
                }, "123qwe");

                var userId = service.UnitOfWork.Members.Users.FindByName("ogrzynp").Id;

                service.UnitOfWork.Members.Users.AddToRole(userId, "student");
            }

            if (service.UnitOfWork.Members.Users.FindByName("ogrzynp1") == null)
            {
                service.UnitOfWork.Members.Users.Create(new AppUser
                {
                    Email = "zeynep.hacioglu@sms.com",
                    PhoneNumber = "05551113355",
                    UserName = "ogrzynp1",
                    TCNo = "99999999999",
                    FirstName = "Zeynep",
                    LastName = "Hacıoğlu",
                    IsActive = true,
                }, "123qwe");

                var userId = service.UnitOfWork.Members.Users.FindByName("ogrzynp1").Id;

                service.UnitOfWork.Members.Users.AddToRole(userId, "student");
            }

            if (service.UnitOfWork.Members.Users.FindByName("ogrhsn") == null)
            {
                service.UnitOfWork.Members.Users.Create(new AppUser
                {
                    Email = "hasan.dogukan@sms.com",
                    PhoneNumber = "05554442211",
                    UserName = "ogrhsn",
                    TCNo = "11111111112",
                    FirstName = "Hasan",
                    LastName = "Doğru",
                    IsActive = true,
                }, "123qwe");

                var userId = service.UnitOfWork.Members.Users.FindByName("ogrhsn").Id;

                service.UnitOfWork.Members.Users.AddToRole(userId, "student");
            }

            if (service.UnitOfWork.Members.Users.FindByName("ogrgmz") == null)
            {
                service.UnitOfWork.Members.Users.Create(new AppUser
                {
                    Email = "gamze.solak@sms.com",
                    PhoneNumber = "05554441122",
                    UserName = "ogrgmz",
                    TCNo = "11111111113",
                    FirstName = "Gamze",
                    LastName = "Solak",
                    IsActive = true,
                }, "123qwe");

                var userId = service.UnitOfWork.Members.Users.FindByName("ogrgmz").Id;

                service.UnitOfWork.Members.Users.AddToRole(userId, "student");
            }

            if (service.UnitOfWork.Members.Users.FindByName("ogrskrn") == null)
            {
                service.UnitOfWork.Members.Users.Create(new AppUser
                {
                    Email = "sukran.adiguzel@sms.com",
                    PhoneNumber = "05558882211",
                    UserName = "ogrskrn",
                    TCNo = "11111111114",
                    FirstName = "Şükran",
                    LastName = "Adıgüzel",
                    IsActive = true,
                }, "123qwe");

                var userId = service.UnitOfWork.Members.Users.FindByName("ogrskrn").Id;

                service.UnitOfWork.Members.Users.AddToRole(userId, "student");
            }

            if (service.UnitOfWork.Members.Users.FindByName("ogrmrt") == null)
            {
                service.UnitOfWork.Members.Users.Create(new AppUser
                {
                    Email = "murat.peynirci@sms.com",
                    PhoneNumber = "05557771122",
                    UserName = "ogrmrt",
                    TCNo = "11111111115",
                    FirstName = "Murat",
                    LastName = "Peynirci",
                    IsActive = true,
                }, "123qwe");

                var userId = service.UnitOfWork.Members.Users.FindByName("ogrmrt").Id;

                service.UnitOfWork.Members.Users.AddToRole(userId, "student");
            }

            if (service.UnitOfWork.Members.Users.FindByName("ograhmt") == null)
            {
                service.UnitOfWork.Members.Users.Create(new AppUser
                {
                    Email = "ahmet.daggezen@sms.com",
                    PhoneNumber = "05553338899",
                    UserName = "ograhmt",
                    TCNo = "11111111117",
                    FirstName = "Ahmet",
                    LastName = "Dağgezen",
                    IsActive = true,
                }, "123qwe");

                var userId = service.UnitOfWork.Members.Users.FindByName("ograhmt").Id;

                service.UnitOfWork.Members.Users.AddToRole(userId, "student");
            }

            if (service.UnitOfWork.Members.Users.FindByName("ogrbsr") == null)
            {
                service.UnitOfWork.Members.Users.Create(new AppUser
                {
                    Email = "busra.bayramoglu@sms.com",
                    PhoneNumber = "05558882200",
                    UserName = "ogrbsr",
                    TCNo = "11111111118",
                    FirstName = "Büşra",
                    LastName = "Bayramoğlu",
                    IsActive = true,
                }, "123qwe");

                var userId = service.UnitOfWork.Members.Users.FindByName("ogrbsr").Id;

                service.UnitOfWork.Members.Users.AddToRole(userId, "student");
            }

            if (service.UnitOfWork.Members.Users.FindByName("ograli1") == null)
            {
                service.UnitOfWork.Members.Users.Create(new AppUser
                {
                    Email = "ali.bayram@sms.com",
                    PhoneNumber = "05556664433",
                    UserName = "ograli1",
                    TCNo = "11111111119",
                    FirstName = "Ali",
                    LastName = "Bayram",
                    IsActive = true,
                }, "123qwe");

                var userId = service.UnitOfWork.Members.Users.FindByName("ograli1").Id;

                service.UnitOfWork.Members.Users.AddToRole(userId, "student");
            }

            if (service.UnitOfWork.Members.Users.FindByName("ogrorhn") == null)
            {
                service.UnitOfWork.Members.Users.Create(new AppUser
                {
                    Email = "orhan.demirci@sms.com",
                    PhoneNumber = "05557774400",
                    UserName = "ogrorhn",
                    TCNo = "11111111121",
                    FirstName = "Orhan",
                    LastName = "Demirci",
                    IsActive = true,
                }, "123qwe");

                var userId = service.UnitOfWork.Members.Users.FindByName("ogrorhn").Id;

                service.UnitOfWork.Members.Users.AddToRole(userId, "student");
            }

            if (service.UnitOfWork.Members.Users.FindByName("ogrmhmt") == null)
            {
                service.UnitOfWork.Members.Users.Create(new AppUser
                {
                    Email = "mehmet.akyol@sms.com",
                    PhoneNumber = "05558880011",
                    UserName = "ogrmhmt",
                    TCNo = "11111111131",
                    FirstName = "Mehmet",
                    LastName = "Akyol",
                    IsActive = true,
                }, "123qwe");

                var userId = service.UnitOfWork.Members.Users.FindByName("ogrmhmt").Id;

                service.UnitOfWork.Members.Users.AddToRole(userId, "student");
            }
            return Redirect("/Role/CreateRoles");
        }

    }
}