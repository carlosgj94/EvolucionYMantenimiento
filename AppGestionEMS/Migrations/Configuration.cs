namespace AppGestionEMS.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AppGestionEMS.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AppGestionEMS.Models.ApplicationDbContext context)
        {
            string roleTipoUsuario1 = "tipoUsuario1";
            string roleTipoUsuario2 = "tipoUsuario2";
            string roleTipoUsuario3 = "tipoUsuario3";
            AddRole(context, roleTipoUsuario1);
            AddRole(context, roleTipoUsuario2);
            AddRole(context, roleTipoUsuario3);
            AddUser(context, "xxxxxxx", "xxxxxxx", "xx@upm.es", roleTipoUsuario1);
            AddUser(context, "Jessica", "apellidos", "yesica.diaz@upm.es", roleTipoUsuario2);
            AddUser(context, "Carolina", " apellidos ", "carolina.gallardop@upm.es", roleTipoUsuario2);
            AddUser(context, "ficitio1", " apellidos ", "ficticio1@alumnos.upm.es", roleTipoUsuario3);
            AddUser(context, "ficitio2", " apellidos ", "ficticio2@alumnos.upm.es", roleTipoUsuario3);
            AddUser(context, "ficitio3", " apellidos ", "ficticio3@alumnos.upm.es", roleTipoUsuario3);
        }

        public void AddRole(ApplicationDbContext context, String role)
        {
            IdentityResult IdRoleResult;
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleMgr = new RoleManager<IdentityRole>(roleStore);
            if (!roleMgr.RoleExists(role))
                IdRoleResult = roleMgr.Create(new IdentityRole { Name = role });
        }

        public void AddUser(ApplicationDbContext context, String name, String surname, String email, String role)
        {
            IdentityResult IdUserResult;
            var userMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var appUser = new ApplicationUser
            {
                Nombre = name,
                Apellidos = surname,
                UserName = email,
                Email = email,
            };
            IdUserResult = userMgr.Create(appUser, "123456Aa!");

            var usr = userMgr.FindByEmail(email);
            //asociar usuario con role
            if (!userMgr.IsInRole(usr.Id, role))
            {
                IdUserResult = userMgr.AddToRole(userMgr.FindByEmail(email).Id, role);
            }
        }
    }
}
