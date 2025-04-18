using Microsoft.EntityFrameworkCore;
using MyMicroservice.GraphQL.Queries;
using MyMicroservice.Infrastructure.Data;
using MyMicroservice.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios para los controladores y Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers(); // Necesario para los controladores REST

// Configuración de la base de datos
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

// Configurar el repositorio
builder.Services.AddScoped<ITioRepository, TioRepository>();

// Configuración de GraphQL
builder.Services.AddGraphQLServer()
    .AddQueryType<TioQuery>(); // Tu clase con los resolvers

var app = builder.Build();

// Configuración del middleware de Swagger solo en entorno de desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Habilitar HTTPS y otros middlewares
app.UseHttpsRedirection();

// Mapeo de controladores REST
app.MapControllers();



// ✅ Mapeo del endpoint GraphQL
app.MapGraphQL(); // <-- Esto expone /graphql y Banana Cake Pop UI

app.Run();
