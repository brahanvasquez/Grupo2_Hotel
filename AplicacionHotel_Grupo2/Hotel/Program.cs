
using Datos.Interfaces;
using Hotel;
using Hotel.Interfaces;
using Hotel.Servicios;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

Config cadenaConexion = new Config(builder.Configuration.GetConnectionString("MySQL"));
builder.Services.AddSingleton(cadenaConexion);

builder.Services.AddScoped<ILoginServicio, LoginServicio>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
