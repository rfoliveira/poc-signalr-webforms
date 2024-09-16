Imports Microsoft.AspNet.SignalR
Imports System.Timers

Namespace Hubs
    'Esta classe simula o envio por parte do servidor a clientes "ouvindo" este hub
    Public Class LogHub
        Inherits Hub

        Private Shared ReadOnly _timer As New Timer()
        Private Shared _isTimerRunning As Boolean = True

        Shared Sub New()
            _timer.Interval = 5000
            AddHandler _timer.Elapsed, AddressOf TimerElapsed

            _timer.AutoReset = True
            _timer.Enabled = True
        End Sub

        Private Shared Sub TimerElapsed(sender As Object, e As ElapsedEventArgs)
            If _isTimerRunning Then
                Dim hubContext = GlobalHost.ConnectionManager.GetHubContext(Of LogHub)()
                hubContext.Clients.All.addMessage(String.Format("{0} - Still running", DateTime.UtcNow.ToString("dd/MM/yyyy HH:mm:ss")))
            End If

        End Sub

        Public Sub StopTimer()
            _isTimerRunning = False
            Clients.Caller.updateStatus("Timer stopped")
        End Sub

        Public Sub StartTimer()
            _isTimerRunning = True
            Clients.Caller.updateStatus("Timer running")
        End Sub

        Public Function GetStatus() As String
            Return If(_isTimerRunning, "Timer running", "Timer stopped")
        End Function
    End Class

End Namespace

