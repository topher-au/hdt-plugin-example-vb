Imports System.Collections.Generic
Imports System.Linq
Imports System.Windows.Controls

Imports Hearthstone_Deck_Tracker
Imports Hearthstone_Deck_Tracker.API
Imports Hearthstone_Deck_Tracker.Enums
Imports Hearthstone_Deck_Tracker.Hearthstone
Imports Hearthstone_Deck_Tracker.Hearthstone.Entities

Namespace vbPluginExample

    Public Class MyCode

        Private _info As HearthstoneTextBlock
        Private _player As Integer

        Private ReadOnly Property Entities As Entity()
            Get
                ' Get the Game.Entities, you need to clone it to avoid errors
                Return Helper.DeepClone(Game.Entities).Values.ToArray
            End Get
        End Property

        Private ReadOnly Property PlayerEntity As Entity
            Get
                ' Get the Entity representing the player, there is also the equivalent for the Opponent
                Return If(IsNothing(Entities), Nothing, Entities.First(Function(x) x.IsPlayer()))
            End Get
        End Property

        Public Sub Load()
            _player = Nothing

            ' A text block using the HS font
            _info = New HearthstoneTextBlock
            _info.Text = ""
            _info.FontSize = 18

            ' Get the HDT Overlay canvas object
            Dim canvas = Overlay.OverlayCanvas

            ' Give the text block its position within the canvas
            Canvas.SetTop(_info, canvas.Height / 2)
            Canvas.SetLeft(_info, canvas.Width / 2)

            ' Add the text block to the canvas
            canvas.Children.Add(_info)

            ' Register methods to be called when GameEvents occur
            GameEvents.OnGameStart.Add(New Action(AddressOf NewGame))
            GameEvents.OnPlayerDraw.Add(New Action(Of Card)(AddressOf HandInfo))
        End Sub

        Public Sub NewGame()
            ' Set the player controller id, used to tell who controls a particular
            ' entity (card, health etc.)
            _player = Nothing
            If Not IsNothing(PlayerEntity) Then _
                _player = PlayerEntity.GetTag(GAME_TAG.CONTROLLER)
        End Sub

        Private Sub HandInfo(c As Card)
            ' Find all cards in the players hand and write to the text block
            _info.Text = ""

            If _player = 0 Then _
                NewGame()


            For Each e In Entities
                If e.IsInHand And e.GetTag(GAME_TAG.CONTROLLER) = _player Then _
                    _info.Text &= e.Card.Name & vbNewLine
            Next
        End Sub

    End Class

End Namespace
