using Hotel;
using Hotel.Interfaces;
using Hotel.Servicios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

//Crearemos nuestro propio servicio
//creamos un nuevo objeto de Config e instanciamos mediante el builder el GetConnectionString 
Config cadenaConexion = new Config(builder.Configuration.GetConnectionString("MySQL"));

//Preparamos el objeto para poderlo utilizar en cualquier parte de la aplicacion
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

//Agregamos que permita agregar mas controladores
app.MapControllers();

//Necesitamos que nos permita dejarnos utilizar la autenticacion de .NET
app.UseAuthentication();
app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
