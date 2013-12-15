using System.Web.Security;
using Jobney.EF.Learning.Common;

namespace Jobney.EF.Learning.Migrations
{
    public class Setup
    {
        public static void ConfigureSecurityRolesIfNotExist()
        {
            foreach (var role in Constants.SystemRoles())
            {

                if (!Roles.RoleExists(role))
                {
                    Roles.CreateRole(role);
                }
            }
        }
    }
}