using BlazorApp2.Components.Pages;
using NetTrisServerWebsite.Components;

Thread t = new(() =>
{
    UdpGameServer server = new();
    server.Start();
});

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddSignalR();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();
app.MapHub<UserHub>("/count");
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
t.Start();
app.Run();