using TestChatClient;

var test = new ClientHub();
await test.ConnectAsync();

while (true)
{
    var message = Console.ReadLine()!;
    await test.SendAsync(message);
}
