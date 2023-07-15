using AutoMapper;
using Parque.Application;
using Parque.Application.Mappings;
using Parque.Persistence;
using Parque.Shared;
using Parque.WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Services 
builder.Services.AddIOCApplicationLayer();
builder.Services.AddIOCPersintenceLayer(builder.Configuration);
builder.Services.AddIOCSharedLayer();
builder.Services.AddApiVesionExtensions();
// end Services

// Configuración de AutoMapper
var mapperConfig = new MapperConfiguration(cfg =>
{
    cfg.AddProfile<GeneralProfile>(); // Agregar el perfil GeneralProfile
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);


builder.Services.AddCors(options =>
{
    options.AddPolicy("newCorsPolityc", app =>
    {
        app.AllowAnyOrigin()    
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors("newCorsPolityc");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthorization();
app.UseErrorHandlingMiddleware();
app.MapControllers();

app.Run();
