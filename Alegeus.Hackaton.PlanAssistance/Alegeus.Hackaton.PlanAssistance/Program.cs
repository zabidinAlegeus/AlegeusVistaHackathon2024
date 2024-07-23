using Alegeus.Hackaton.PlanAssistance;
using Alegeus.Hackaton.PlanAssistance.Apis;
using Microsoft.Extensions.Caching.Memory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();
builder.Services.AddMemoryCache();
builder.Services.AddSingleton(sp => 
    new AssistantService(sp.GetRequiredService<IMemoryCache>()));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
await app.AddChat();
await app.AddClearChatSessionWca();
app.AddChatHub();
await app.AddCobraChats();
await app.AddClearChatSessionCobra();
app.Run();
