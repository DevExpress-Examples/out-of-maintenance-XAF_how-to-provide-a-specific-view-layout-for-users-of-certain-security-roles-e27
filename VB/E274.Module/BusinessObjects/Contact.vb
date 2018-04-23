Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Namespace E274.Module.BusinessObjects
	<DefaultClassOptions>
	Public Class Contact
		Inherits Person

		Public Sub New(ByVal session As DevExpress.Xpo.Session)
			MyBase.New(session)

		End Sub
	End Class
End Namespace
