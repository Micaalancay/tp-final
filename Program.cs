using Microsoft.EntityFrameworkCore;
using tp_final.Contexto;
using tp_final.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Configurar Swagger para leer los comentarios XML
builder.Services.AddSwaggerGen(c =>
{
    // Nombre del archivo XML generado por Visual Studio
    var xmlFile = "tp-final.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

// Configurar DbContext y repositorio
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("NorthwindDatabase")));

builder.Services.AddTransient<INorthwindRepository, NorthwindRepository>();

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

app.Run();
