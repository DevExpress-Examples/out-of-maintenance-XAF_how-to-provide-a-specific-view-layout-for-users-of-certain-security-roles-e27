using System;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base.Security;

namespace Demo {
    public class SecuritySystemHelper {
        public static bool IsUserInRole(IUserWithRoles userWithRoles, string roleName) {
            Guard.ArgumentNotNull(userWithRoles, "userWithRoles");
            foreach (IRole role in userWithRoles.Roles)
                if (role.Name == roleName)
                    return true;
            return false;
        }
        public static bool IsUserInRole(string roleName) {
            return IsUserInRole(SecuritySystem.CurrentUser as IUserWithRoles, roleName);
        }
        public static bool IsUserAdministrator(ISimpleUser simpleUser) {
            Guard.ArgumentNotNull(simpleUser, "simpleUser");
            return simpleUser.IsAdministrator;
        }
    }
}