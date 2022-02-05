using DataGuard.Identity.Models;
using DataGuard.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Web;

namespace DataGuard.Context
{
    /// <summary>
    ///Set the initialization database and the seed data. The current global.ascx is set to null. Replace this sentence with the past.  //System.Data.Entity.Database.SetInitializer<ApplicationDbContext>(new IshopInitializer()); 
    /// </summary>

    public class DataGuardInitializer : CreateDatabaseIfNotExists<ApplicationDbContext>    //1 . CreateDatabaseIfNotExists  2. DropCreateDatabaseIfModelChanges  3. DropCreateDatabaseAlways
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var roleManager = HttpContext.Current.GetOwinContext().Get<ApplicationRoleManager>();

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            //Add  Role  
            var Roles = new List<ApplicationRole>
            {
                new ApplicationRole{Id = "SystemAdmin", Name = "SystemAdmin",Description="Provider Technical Support Account | 技術支持管理員。可以由公司管理員可控定義對角色。"},
                new ApplicationRole{Id = "Admin", Name = "Admin",Description="Main commpany administrator ( client admin account) | 提供給客戶（公司）管理員使用。具有最高對全權權限。"},
                new ApplicationRole{Id = "MainComOprerator", Name = "MainComOprerator",Description="Main commpany  operator ( client account) | 提供給客戶（公司）職員使用。具有可控對部分權限。"},
                new ApplicationRole{Id = "ThirdPartyserviceContractorAdmin", Name = "ThirdPartyserviceContractorAdmin",Description="Contractor adminitrator Third party service Contractor | 提供給第三方合約服務商的管理員 例如地盤承建商管理員"},
                new ApplicationRole{Id = "ThirdPartyserviceContractorOperator", Name = "ThirdPartyserviceContractorOperator",Description="Third Partyservice Contractor operator | 提供給第三方合約服務商的操作員 提供給第三方考勤使用 例如地盤承建商職員"},
                new ApplicationRole{Id = "Emplyee", Name = "Emplyee",Description="main commpany or contractor Emplyee | for  僱員使用 包括閱覽、申請、查詢"},
                new ApplicationRole{Id = "LRO", Name = "LRO",Description="Housing Only View Only for 第三方或政府監察部門瀏覽"},
                new ApplicationRole{Id = "Guest", Name = "Guest",Description="nick name (reserved) 匿名訪問（保留）"}
            };
            Roles.ForEach(s => context.AspNetRoles.AddOrUpdate(s));
            context.SaveChanges();


            string MainCom_Prefix1 = string.Concat(DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString().PadLeft(2, '0')).Substring(2);

            string Generate_UserId = MainCom_Prefix1 + DateTime.Now.Day.ToString().PadLeft(2, '0');

            string MainComId = Generate_UserId; //  string MainComId =  context.GetTableIdentityID("M" + MainCom_Prefix1, "MainCom", 2);

            string Email = String.Format("admin@{0}.com", Generate_UserId);

            string PhoneNumber = String.Format("6000{0}.com", Generate_UserId);
            var user = new ApplicationUser { Id = Generate_UserId, MainComId = MainComId, UserName = Email, Email = Email, PhoneNumber = PhoneNumber };
            var userExists = userManager.FindById(Generate_UserId);
            if (userExists == null)
            {
                var result = userManager.Create(user, "admin888");
                result = userManager.SetLockoutEnabled(user.Id, false);
            }

            //Create Role Admin if it does not exist
            var role = roleManager.FindByName("SystemAdmin");
            if (role == null)
            {
                role = new ApplicationRole("SystemAdmin", "Provider Technical Support Account | Case1 Cloud Computing:技術支持管理員。可以由公司管理員可控定義對角色。Case2: Client Administrator");
                var roleresult = roleManager.Create(role);
            }

            //Add user role (administrator  UserId=620000	Supervisor RoleId=SystemAdmin) 
            var UserRoles = new List<ApplicationUserRole>
            {
                new ApplicationUserRole{UserId = Generate_UserId, RoleId = "SystemAdmin"}
            };
            UserRoles.ForEach(s => context.UserRoles.AddOrUpdate(s));
            context.SaveChanges();

            // Add user admin to Role Admin if not already added
            var rolesForUser = userManager.GetRoles(user.Id);
            if (!rolesForUser.Contains(role.Name))
            {
                var result = userManager.AddToRole(user.Id, role.Name);
            }
        }

    }
}