Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Utils
Imports DevExpress.Persistent.Base.Security

Namespace Demo
	Public Class SecuritySystemHelper
		Public Shared Function IsUserInRole(ByVal userWithRoles As IUserWithRoles, ByVal roleName As String) As Boolean
			Guard.ArgumentNotNull(userWithRoles, "userWithRoles")
			For Each role As IRole In userWithRoles.Roles
				If role.Name = roleName Then
					Return True
				End If
			Next role
			Return False
		End Function
		Public Shared Function IsUserInRole(ByVal roleName As String) As Boolean
			Return IsUserInRole(TryCast(SecuritySystem.CurrentUser, IUserWithRoles), roleName)
		End Function
		Public Shared Function IsUserAdministrator(ByVal simpleUser As ISimpleUser) As Boolean
			Guard.ArgumentNotNull(simpleUser, "simpleUser")
			Return simpleUser.IsAdministrator
		End Function
	End Class
End Namespace