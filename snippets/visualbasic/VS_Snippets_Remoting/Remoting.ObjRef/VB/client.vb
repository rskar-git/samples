﻿Imports Microsoft.VisualBasic
Imports System.Net.Sockets
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Http
Imports System.Runtime.Remoting.Messaging
Imports System.Runtime.Remoting.Lifetime
Imports System.Runtime.Remoting.Contexts
Imports System.Runtime.Serialization
Imports System.Security.Permissions
Imports SampleNamespace

Public Class SampleClient
   Inherits MarshalByRefObject

   <SecurityPermission(SecurityAction.LinkDemand)> _
   Public Shared Sub Main()
      ChannelServices.RegisterChannel(New HttpChannel(0))
      RemotingConfiguration.RegisterActivatedClientType(GetType(SampleService), "http://localhost:9000/MySampleService")
      Dim myRemoteObject As New SampleService()
      Dim result As Boolean = myRemoteObject.SampleMethod()
      ' System.Runtime.Remoting.ObjRef
      ' <Snippet1>
      Dim objRefSample As ObjRef = RemotingServices.GetObjRefForProxy(myRemoteObject)
      Console.WriteLine("***ObjRef Details***")
      Console.WriteLine("URI:" + ControlChars.Tab + "{0}", objRefSample.URI)
      Dim channelData As Object() = objRefSample.ChannelInfo.ChannelData
      Console.WriteLine("Channel Info:")
      Dim o As Object
      For Each o In  channelData
         Console.WriteLine(ControlChars.Tab + "{0}", o.ToString())
      Next o
      Dim envoyInfo As IEnvoyInfo = objRefSample.EnvoyInfo
      If envoyInfo Is Nothing Then
         Console.WriteLine("This ObjRef does not have envoy information.")
      Else
         Dim envoySinks As IMessageSink = envoyInfo.EnvoySinks
         Console.WriteLine("Envoy Sink Class: {0}", envoySinks)
      End If
      Dim typeInfo As IRemotingTypeInfo = objRefSample.TypeInfo
      Console.WriteLine("Remote type name: {0}", typeInfo.TypeName)
      Console.WriteLine("Can my object cast to a Bitmap? {0}", typeInfo.CanCastTo(GetType(System.Drawing.Bitmap), objRefSample))
      Console.WriteLine("Is this object from this AppDomain? {0}", objRefSample.IsFromThisAppDomain())
      Console.WriteLine("Is this object from this process? {0}", objRefSample.IsFromThisProcess())
      ' </Snippet1>
   End Sub 'Main 
End Class 'SampleClient
