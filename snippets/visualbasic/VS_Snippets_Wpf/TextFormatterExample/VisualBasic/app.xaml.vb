﻿Imports System
Imports System.Windows

Namespace SDKSamples
	''' <summary>
	''' Interaction logic for app.xaml
	''' </summary>

	Partial Public Class app
		Inherits Application
		Private Sub AppStartingUp(ByVal sender As Object, ByVal e As StartupEventArgs)
		 Dim mainWindow As New Window1()
		 mainWindow.InitializeComponent()
		 mainWindow.Show()
		End Sub
	End Class
End Namespace