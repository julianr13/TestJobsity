<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="theChatRoom.aspx.cs" Inherits="Chatroom.theChatRoom" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>The Chat Room</title>
   
    <script src="Scripts/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="Scripts/jquery.signalR-2.4.1.js" type="text/javascript"></script>
    <script src="signalr/hubs" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server" >
     <div class="container">
         Bienvenido/a <asp:Label ID="displayname1" runat="server" />, recuerda que puedes enviar el comando <b>/stock=stock_code</b> para consultar cuota.
         <br />
       
        <input type="text" id="message" />
        <input type="button"  id="sendmessage" value="Send" />
        
        
        <ul id="discussion">
        </ul>
    </div>
        <!--Add script to update the page and send messages.--> 
    <script type="text/javascript">
        $(function () {
            // Declare a proxy to reference the hub. 
            var chat = $.connection.symbolsChat;
            // Create a function that the hub can call to broadcast messages.
            chat.client.broadcastMessage = function (name, message) {
                // Html encode display name and message. 
                var encodedName = $('<div />').text(name).html();
                var encodedMsg = $('<div />').text(message).html();
                // Add the message to the page add Timestamps. 
                var dt = new Date();
                var time = dt.getDay() +"-"+dt.getMonth() + "-" + dt.getFullYear() + " "+ dt.getHours() + ":" + dt.getMinutes() + ":" + dt.getSeconds();
                
                $('#discussion').append('<li>' +time + ' <strong>' + encodedName
                    + '</strong>:&nbsp;&nbsp;' + encodedMsg + '</li>');
            };
            // Get the user name and store it to prepend to messages.
           
            // Set initial focus to message input box.  
            $('#message').focus();
            // Start the connection.
            $.connection.hub.start().done(function () {
                $('#sendmessage').click(function () {
                    // Call the Send method on the hub. 
                    if ($('#message').val().length>0) {
                           chat.server.send($('#<%=displayname1.ClientID%>').html(), $('#message').val());
                    // Clear text box and reset focus for next comment. 
                    $('#message').val('').focus();
                    }
                 
                });
            });
            
        });
        //enter to send mssg
        $(document).ready(function () {
            $(window).keydown(function (event) {
                if (event.keyCode == 13) {
                    $('#sendmessage').click();
                    event.preventDefault();
                    return false;
                }
            });
        });
    </script>
     
    </form>

  
</body>
</html>
