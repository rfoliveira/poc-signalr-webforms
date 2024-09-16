<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="default.aspx.vb" Inherits="POCSignalR._Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SignalR Simple POC</title>
    <script src="Scripts/jquery-3.7.1.min.js"></script>
    <script src="Scripts/jquery.signalR-2.4.3.min.js"></script>
    <script src="/signalr/hubs"></script>

    <script type="text/javascript">
        $(function () {
            var hub = $.connection.logHub

            // Definição de métodos a serem chamados no client / server
            hub.client.addMessage = function (message) {
                $('#messages').append('<div>' + message + '</div>')
            }

            hub.client.updateStatus = function (status) {
                $('#status').text(status)
            }

            // Ao inicializad o SignalR...
            $.connection.hub.start().done(function () {
                $('#btnStop').click(function () {
                    hub.server.stopTimer()
                })

                $('#btnStart').click(function () {
                    hub.server.startTimer()
                })

                // Colocando no page_load para exibir um status inicial
                hub.server.getStatus().done(function (status) {
                    $('#status').text(status)
                })

            }).fail(function (error) {
                console.error('Failed to connect to SignalR:', error)
            })
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Messages (in 5s interval):</h2>
            <div id="messages"></div>
            <button id="btnStop">Stop timer</button>
            <button id="btnStart">Start timer</button>
            <h3>Status:</h3>
            <div id="status">Loading status...</div>
        </div>
    </form>    
</body>
</html>
