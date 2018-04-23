Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.ExpressApp
Imports DevExpress.Data.Filtering
Imports DevExpress.Persistent.BaseImpl

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
			Dim info As DictionaryNode = GetRoleViewInfo(e.View.Id)
			If info IsNot Nothing Then
				e.View.SetInfo(info)
			End If
		End Sub
		'Dennis: create corresponding views in the application model first.
		Private Function GetRoleViewInfo(ByVal defaultViewID As String) As DictionaryNode
			Dim customViewId As String = defaultViewID
			If IsAdministratorsRole() Then
				customViewId &= String.Format("_{1}", defaultViewID, AdministratorsViewSuffix)
			Else
				customViewId &= String.Format("_{1}", defaultViewID, UsersViewSuffix)
			End If
			Return app.FindViewInfo(customViewId)
		End Function
		Private Function IsAdministratorsRole() As Boolean
			Dim currentUser As User = TryCast(SecuritySystem.CurrentUser, User)
			If currentUser IsNot Nothing Then
				Return Convert.ToBoolean(currentUser.Evaluate(CriteriaOperator.Parse("Roles[Name = ?].Count > 0", AdministratorsViewSuffix)))
			End If
			Return False
		End Function
	End Class
End Namespace