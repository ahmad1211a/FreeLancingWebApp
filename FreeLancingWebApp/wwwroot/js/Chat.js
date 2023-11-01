// chat.js

$(document).ready(function () {
    var chatHub = $.connection.chatHub;

    chatHub.client.receiveMessage = function (senderId, message) {
        // Add the received message to the chat interface
        $('#chatMessages').append('<div><strong>' + senderId + ':</strong> ' + message + '</div>');
    };

    $.connection.hub.start().done(function () {
        // Handle user interactions to send messages
        $('#sendButton').click(function () {
            var receiverId = 'ReceiverUserId'; // Replace with the actual receiver's ID
            var message = $('#messageInput').val();

            // Check for empty messages
            if (message.trim() !== '') {
                chatHub.server.send(UserId, receiverId, message);
                $('#messageInput').val(''); // Clear the input field
            }
        });
    });
});
