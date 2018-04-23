using System;
using DevExpress.ExpressApp;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.BaseImpl;

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
            DictionaryNode info = GetRoleViewInfo(e.View.Id);
            if (info != null)
                e.View.SetInfo(info);
        }
        //Dennis: create corresponding views in the application model first.
        private DictionaryNode GetRoleViewInfo(string defaultViewID) {
            string customViewId = defaultViewID;
            if (IsAdministratorsRole())
                customViewId += String.Format("_{1}", defaultViewID, AdministratorsViewSuffix);
            else
                customViewId += String.Format("_{1}", defaultViewID, UsersViewSuffix);
            return app.FindViewInfo(customViewId);
        }
        private bool IsAdministratorsRole() {
            User currentUser = SecuritySystem.CurrentUser as User;
            if (currentUser != null)
                return Convert.ToBoolean(currentUser.Evaluate(CriteriaOperator.Parse("Roles[Name = ?].Count > 0", AdministratorsViewSuffix)));
            return false;
        }
    }
}