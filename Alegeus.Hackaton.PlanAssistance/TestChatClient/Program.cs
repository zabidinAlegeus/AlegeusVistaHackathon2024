using TestChatClient;

var test = new ClientHub();
await test.ConnectAsync();
await test.SendAsync("test message");
