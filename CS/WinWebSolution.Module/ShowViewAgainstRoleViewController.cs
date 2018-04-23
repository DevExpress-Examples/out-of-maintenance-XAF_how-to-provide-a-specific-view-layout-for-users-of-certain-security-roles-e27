using Demo;
using System;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Model;

namespace WinWebSolution.Module {
    public partial class ShowViewAgainstRoleViewController : ViewController {
        public const string AdministratorsViewSuffix = "Administrators";
        public const string UsersViewSuffix = "Users";
        private XafApplication app;
        protected override void OnFrameAssigned() {
            base.OnFrameAssigned();
            if (app == null) {
                app = Application;
                app.ViewShowing += Application_ViewShowing;
            }
        }
        protected override void Dispose(bool disposing) {
            if (disposing && app != null)
                app.ViewShowing -= Application_ViewShowing;
            base.Dispose(disposing);
        }
        private void Application_ViewShowing(object sender, ViewShowingEventArgs e) {
            IModelView modelView = GetRoleModelView(e.View.Id);
            if (modelView != null)
                e.View.SetInfo(modelView);
        }
        //Dennis: create corresponding views in the application model first.
        private IModelView GetRoleModelView(string defaultViewID) {
            string customViewId = defaultViewID;
            if (SecuritySystemHelper.IsUserInRole(AdministratorsViewSuffix))
                customViewId += String.Format("_{1}", defaultViewID, AdministratorsViewSuffix);
            else
                customViewId += String.Format("_{1}", defaultViewID, UsersViewSuffix);
            return app.FindModelView(customViewId);
        }
    }
}