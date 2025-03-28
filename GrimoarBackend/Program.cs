using GrimoarBackend.DTOs;
using GrimoarBackend.Operations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();




//app.MapGet("command name", function)
//app.MapGet("/", () => "Oi, Cunt!");
app.MapPut("vypisPostavy", (FiltrPostavyDto filter) => { return CharacterOperations.vypisPostavy(filter);});


app.Run();
