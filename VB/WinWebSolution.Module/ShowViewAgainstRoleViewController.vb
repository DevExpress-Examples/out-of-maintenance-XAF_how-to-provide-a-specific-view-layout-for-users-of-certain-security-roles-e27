Imports Microsoft.VisualBasic
Imports Demo
Imports System
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Model

Namespace WinWebSolution.Module
	Partial Public Class ShowViewAgainstRoleViewController
		Inherits ViewController
		Public Const AdministratorsViewSuffix As String = "Administrators"
		Public Const UsersViewSuffix As String = "Users"
		Private app As XafApplication
		Protected Overrides Overloads Sub OnFrameAssigned()
			MyBase.OnFrameAssigned()
			If app Is Nothing Then
				app = Application
				AddHandler app.ViewShowing, AddressOf Application_ViewShowing
			End If
		End Sub
		Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso app IsNot Nothing Then
				RemoveHandler app.ViewShowing, AddressOf Application_ViewShowing
			End If
			MyBase.Dispose(disposing)
		End Sub
		Private Sub Application_ViewShowing(ByVal sender As Object, ByVal e As ViewShowingEventArgs)
			Dim modelView As IModelView = GetRoleModelView(e.View.Id)
			If modelView IsNot Nothing Then
				e.View.SetInfo(modelView)
			End If
		End Sub
		'Dennis: create corresponding views in the application model first.
		Private Function GetRoleModelView(ByVal defaultViewID As String) As IModelView
			Dim customViewId As String = defaultViewID
			If SecuritySystemHelper.IsUserInRole(AdministratorsViewSuffix) Then
				customViewId &= String.Format("_{1}", defaultViewID, AdministratorsViewSuffix)
			Else
				customViewId &= String.Format("_{1}", defaultViewID, UsersViewSuffix)
			End If
			Return app.FindModelView(customViewId)
		End Function
	End Class
End Namespace