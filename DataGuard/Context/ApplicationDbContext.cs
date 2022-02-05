using ConnectionService;
using DataGuard.Identity.Models;
using DataGuard.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
namespace DataGuard.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public virtual DbSet<ApplicationRole> AspNetRoles { get; set; }
        public virtual DbSet<ApplicationUserRole> UserRoles { get; set; }

        public DbSet<TableIdentity> TableIdentity { get; set; }

        public string GetTableIdentityID(string Prefix, string TableName, int Lenght)
        {

            ApplicationDbContext db = new ApplicationDbContext();
            if (!db.Database.Exists())
            {
                return string.Empty;
            }
            TableIdentity T = new TableIdentity();

            if (db.TableIdentity.Find(TableName) == null)
            {
                T.TableIdentityID = 1;
                T.TableName = TableName;
                T.OperatedDate = DateTime.Now;
                db.TableIdentity.Add(T);
                db.SaveChanges();
            }
            else
            {
                T = db.TableIdentity.Find(TableName);
                T.TableIdentityID += 1;
                T.OperatedDate = DateTime.Now;

                db.Entry(T).State = EntityState.Modified;
                db.SaveChanges();
            }
            string NewID = Prefix + T.TableIdentityID.ToString().PadLeft(Lenght, '0');
            return NewID;
        }
        public ApplicationDbContext()
            : base(ConnectComponent.ConnectiongString, throwIfV1Schema: false)
        {
        }
        static ApplicationDbContext()
        {
            // 在第一次启动网站时初始化数据库添加管理员用户凭据和admin 角色到数据库 
            // Set the database intializer which is run once during application start
            // This seeds the database with admin user credentials and admin role
            // Database.SetInitializer<ApplicationDbContext>(new ApplicationDbInitializer());
        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }


        public bool RoleExists(DataGuard.ApplicationRoleManager roleManager, string name)
        {
            return roleManager.RoleExists(name);
        }
        public bool CreateRole(ApplicationRoleManager _roleManager, string name, string description = "")
        {
            var idResult = _roleManager.Create<ApplicationRole, string>(new ApplicationRole(name, description));
            return idResult.Succeeded;
        }
        public bool AddUserToRole(ApplicationUserManager _userManager, string userId, string roleName)
        {
            var idResult = _userManager.AddToRole(userId, roleName);
            return idResult.Succeeded;
        }
        public void ClearUserRoles(ApplicationUserManager userManager, string userId)
        {
            var user = userManager.FindById(userId);
            var currentRoles = new List<IdentityUserRole>();

            currentRoles.AddRange(user.UserRoles);
            foreach (ApplicationUserRole role in currentRoles)
            {
                userManager.RemoveFromRole(userId, role.Role.Name);
            }
        }
        public void RemoveFromRole(ApplicationUserManager userManager, string userId, string roleName)
        {
            userManager.RemoveFromRole(userId, roleName);
        } 
    }

}