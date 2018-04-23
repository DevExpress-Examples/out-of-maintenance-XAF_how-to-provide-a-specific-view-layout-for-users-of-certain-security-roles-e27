Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Security

Namespace E274.Module.Controllers
	Public Class CustomizeViewAgainstRoleMainWindowController
		Inherits WindowController

		Private Const AdministratorsViewSuffix As String = "Administrators"
		Private Const UsersViewSuffix As String = "Users"
		Public Sub New()
			TargetWindowType = WindowType.Main
		End Sub
		Protected Overrides Sub OnActivated()
			MyBase.OnActivated()
			AddHandler Application.ViewCreating, AddressOf Application_ViewCreating
		End Sub
		'Create corresponding views in the application model first! See the Model.DesignedDiffs.XAFML file for an example.
		Private Sub Application_ViewCreating(ByVal sender As Object, ByVal e As ViewCreatingEventArgs)
			Dim roleBasedViewId As String = String.Format("{0}_{1}", e.ViewID,If(DirectCast(SecuritySystem.CurrentUser, ISecurityUserWithRoles).IsUserInRole(AdministratorsViewSuffix), AdministratorsViewSuffix, UsersViewSuffix))
			If Application.FindModelView(roleBasedViewId) IsNot Nothing Then
				e.ViewID = roleBasedViewId
			End If
		End Sub
		Protected Overrides Sub OnDeactivated()
			MyBase.OnDeactivated()
			RemoveHandler Application.ViewCreating, AddressOf Application_ViewCreating
		End Sub
	End Class
End Namespace
