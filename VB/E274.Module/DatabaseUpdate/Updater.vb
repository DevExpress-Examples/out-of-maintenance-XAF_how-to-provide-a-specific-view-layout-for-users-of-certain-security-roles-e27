Imports System
Imports System.Linq
Imports DevExpress.ExpressApp
Imports DevExpress.Data.Filtering
Imports DevExpress.ExpressApp.Updating
Imports DevExpress.ExpressApp.Security
Imports DevExpress.ExpressApp.Security.Strategy
Imports DevExpress.Persistent.BaseImpl
Imports E274.Module.BusinessObjects

Namespace E274.Module.DatabaseUpdate
	' For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppUpdatingModuleUpdatertopic.aspx
	Public Class Updater
		Inherits ModuleUpdater

		Public Sub New(ByVal objectSpace As IObjectSpace, ByVal currentDBVersion As Version)
			MyBase.New(objectSpace, currentDBVersion)
		End Sub
		Public Overrides Sub UpdateDatabaseAfterUpdateSchema()
			MyBase.UpdateDatabaseAfterUpdateSchema()
			Dim name As String = "MyName"
			Dim theObject As Contact = ObjectSpace.FindObject(Of Contact)(CriteriaOperator.Parse("FirstName=?", name))
			If theObject Is Nothing Then
				theObject = ObjectSpace.CreateObject(Of Contact)()
				theObject.FirstName = name
			End If
			Dim sampleUser As SecuritySystemUser = ObjectSpace.FindObject(Of SecuritySystemUser)(New BinaryOperator("UserName", "User"))
			If sampleUser Is Nothing Then
				sampleUser = ObjectSpace.CreateObject(Of SecuritySystemUser)()
				sampleUser.UserName = "User"
				sampleUser.SetPassword("")
			End If
			Dim defaultRole As SecuritySystemRole = CreateDefaultRole()
			sampleUser.Roles.Add(defaultRole)

			Dim userAdmin As SecuritySystemUser = ObjectSpace.FindObject(Of SecuritySystemUser)(New BinaryOperator("UserName", "Admin"))
			If userAdmin Is Nothing Then
				userAdmin = ObjectSpace.CreateObject(Of SecuritySystemUser)()
				userAdmin.UserName = "Admin"
				' Set a password if the standard authentication type is used
				userAdmin.SetPassword("")
			End If
			' If a role with the Administrators name doesn't exist in the database, create this role
			Dim adminRole As SecuritySystemRole = ObjectSpace.FindObject(Of SecuritySystemRole)(New BinaryOperator("Name", "Administrators"))
			If adminRole Is Nothing Then
			   adminRole = ObjectSpace.CreateObject(Of SecuritySystemRole)()
				adminRole.Name = "Administrators"
			End If
			adminRole.IsAdministrative = True
			userAdmin.Roles.Add(adminRole)
			 ObjectSpace.CommitChanges()
		End Sub
		Public Overrides Sub UpdateDatabaseBeforeUpdateSchema()
			MyBase.UpdateDatabaseBeforeUpdateSchema()
			'if(CurrentDBVersion < new Version("1.1.0.0") && CurrentDBVersion > new Version("0.0.0.0")) {
			'    RenameColumn("DomainObject1Table", "OldColumnName", "NewColumnName");
			'}
		End Sub
		Private Function CreateDefaultRole() As SecuritySystemRole
			Dim defaultRole As SecuritySystemRole = ObjectSpace.FindObject(Of SecuritySystemRole)(New BinaryOperator("Name", "Users"))
			If defaultRole Is Nothing Then
				defaultRole = ObjectSpace.CreateObject(Of SecuritySystemRole)()
				defaultRole.Name = "Users"
				defaultRole.IsAdministrative = True
			End If
			Return defaultRole
		End Function
	End Class
End Namespace
