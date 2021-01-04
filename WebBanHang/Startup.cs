using Microsoft.Owin;
using Owin;
using WebBanHang.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

[assembly: OwinStartupAttribute(typeof(WebBanHang.Startup))]
namespace WebBanHang
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            SeedAdmin();


        }


        public void SeedAdmin()
        {
            ApplicationDbContext db = new ApplicationDbContext();

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            var roleMananger = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            if(!roleMananger.RoleExists("Admin"))
            {
                roleMananger.Create(new IdentityRole() { Name = "Admin" });
            }

            if (userManager.FindByName("admin@shop.com") == null)
            {
                var user = new ApplicationUser()
                {
                    UserName = "Admin@shop.com",
                    Email = "Admin@shop.com",
                    EmailConfirmed = true,
                };
                userManager.Create(user, "123aA@");
                userManager.AddToRole(userManager.FindByName("Admin@shop.com").Id, "Admin");
            }
        }
    }
}
