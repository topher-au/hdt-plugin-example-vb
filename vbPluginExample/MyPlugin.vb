Imports System
Imports System.Windows.Controls

Imports Hearthstone_Deck_Tracker.Plugins
Namespace vbPluginExample

    Public Class MyPlugin
        Implements IPlugin

        Public ReadOnly Property Author As String Implements IPlugin.Author
            Get
                Return "Name"
            End Get
        End Property

        Public ReadOnly Property ButtonText As String Implements IPlugin.ButtonText
            Get
                Return "Settings"
            End Get
        End Property

        Public ReadOnly Property Description As String Implements IPlugin.Description
            Get
                Return "Description"
            End Get
        End Property

        Public ReadOnly Property MenuItem As System.Windows.Controls.MenuItem Implements IPlugin.MenuItem
            Get
                Return Nothing
            End Get
        End Property

        Public ReadOnly Property Name As String Implements IPlugin.Name
            Get
                Return "vbPluginExample"
            End Get
        End Property

        Public ReadOnly Property Version As Version Implements IPlugin.Version
            Get
                Return New Version(0, 0, 0, 2)
            End Get
        End Property

        Public Sub OnButtonPress() Implements IPlugin.OnButtonPress

        End Sub

        Public Sub OnLoad() Implements IPlugin.OnLoad
            Dim MyCode As New MyCode
            MyCode.Load()
        End Sub

        Public Sub OnUnload() Implements IPlugin.OnUnload

        End Sub

        Public Sub OnUpdate() Implements IPlugin.OnUpdate

        End Sub

    End Class

End Namespace
