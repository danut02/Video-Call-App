using Microsoft.EntityFrameworkCore;
using VideoCallApp.Data;
using Quobject.SocketIoClientDotNet.Client;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<VideoCallApplicationDbContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("VideoCallDatabasePortal")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
string serverUrl = "http://localhost:7176";

var socket = IO.Socket(serverUrl);
socket.On(Socket.EVENT_CONNECT, () =>
{
    Console.WriteLine("Conectat la server Socket.IO");
});


socket.On("message", (data) =>
{
    Console.WriteLine("Mesaj primit de la server: " + data);
});


socket.Emit("message", "Hello from .NET client!");

Console.WriteLine("Apasă o tastă pentru a închide programul...");
Console.ReadKey();


socket.Disconnect();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();