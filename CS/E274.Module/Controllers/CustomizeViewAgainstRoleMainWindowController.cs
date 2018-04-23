using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Security;

namespace E274.Module.Controllers {
    public class CustomizeViewAgainstRoleMainWindowController : WindowController {
        private const string AdministratorsViewSuffix = "Administrators";
        private const string UsersViewSuffix = "Users";
        public CustomizeViewAgainstRoleMainWindowController() {
            TargetWindowType = WindowType.Main;
        }
        protected override void OnActivated() {
            base.OnActivated();
            Application.ViewCreating += Application_ViewCreating;
        }
        //Create corresponding views in the application model first! See the Model.DesignedDiffs.XAFML file for an example.
        void Application_ViewCreating(object sender, ViewCreatingEventArgs e) {
            string roleBasedViewId = String.Format("{0}_{1}", e.ViewID, ((ISecurityUserWithRoles)SecuritySystem.CurrentUser).IsUserInRole(AdministratorsViewSuffix) ? AdministratorsViewSuffix : UsersViewSuffix);
            if (Application.FindModelView(roleBasedViewId) != null) {
                e.ViewID = roleBasedViewId;
            }
        }
        protected override void OnDeactivated() {
            base.OnDeactivated();
            Application.ViewCreating -= Application_ViewCreating;
        }
    }
}
