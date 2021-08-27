<!-- default badges list -->
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E274)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Model.DesignedDiffs.xafml](./CS/WinWebSolution.Module/Model.DesignedDiffs.xafml) (VB: [Model.DesignedDiffs.xafml](./VB/WinWebSolution.Module/Model.DesignedDiffs.xafml))
* [ShowViewAgainstRoleViewController.cs](./CS/WinWebSolution.Module/ShowViewAgainstRoleViewController.cs) (VB: [ShowViewAgainstRoleViewController.vb](./VB/WinWebSolution.Module/ShowViewAgainstRoleViewController.vb))
<!-- default file list end -->
# How to provide a specific View layout for users of certain security roles


<p><strong>Scenario:</strong><br>This example demonstrates how to show a custom View against a role of the currently logged user. Custom Views were created and customized through the Model Editor for each role separately. For more convenience, custom Views have a name of a role in the Id attribute. For instance: Contact_ListView_Administrators, Contact_DetailView_Administrators, Contact_ListView_Users, Contact_DetailView_Users, etc. You may consider a specific naming convention, for example, to add a role name to the end of the view name. Use User and Admin user names with empty password to login into the application.<br><br><img src="https://raw.githubusercontent.com/DevExpress-Examples/how-to-provide-a-specific-view-layout-for-users-of-certain-security-roles-e274/9.2.9+/media/141c6733-28c6-11e6-80bf-00155d62480c.png"><br><br><strong>Implementation details:</strong><br>There is E274.Module\Controllers\<strong>CustomizeViewAgainstRoleMainWindowController</strong> that tracks View showing using the <a href="https://documentation.devexpress.com/eXpressAppFramework/DevExpressExpressAppXafApplication_ViewCreatingtopic.aspx">XafApplication.ViewCreating</a> event and replaces the default View's Id with a custom Id found in the Application Model by the role name. <br><br>Alternatively, you can handle the <a href="https://documentation.devexpress.com/eXpressAppFramework/DevExpressExpressAppXafApplication_UserDifferencesLoadedtopic.aspx">XafApplication.UserDifferencesLoaded</a> event and patch the ViewID of required navigation items under the NavigationItems node as well as the <a href="https://documentation.devexpress.com/eXpressAppFramework/DevExpressExpressAppModelIModelClass_DefaultListViewtopic.aspx">DefaultListView</a>/<a href="https://documentation.devexpress.com/eXpressAppFramework/DevExpressExpressAppModelIModelClass_DefaultDetailViewtopic.aspx">DefaultDetailView</a> attributes of the BOModel | <a href="https://documentation.devexpress.com/#eXpressAppFramework/clsDevExpressExpressAppModelIModelClasstopic">Class</a> nodes.<br><br>See also:<br><a href="https://www.devexpress.com/Support/Center/p/E2375">How to: Show different views for the same object, based on the source view, from where it is open or created</a></p>

<br/>


