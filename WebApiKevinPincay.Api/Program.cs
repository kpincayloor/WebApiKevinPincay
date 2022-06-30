using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApiKevinPincay.Api;
using WebApiKevinPincay.Api.Data;
using WebApiKevinPincay.Api.Repositories;

var builder = WebApplication.CreateBuilder(args);

var server = builder.Configuration["DbServer"] ?? "host.docker.internal";
var user = builder.Configuration["DbUser"] ?? "SA";
var password = builder.Configuration["Password"] ?? "Passw0rd123";
var database = builder.Configuration["Database"] ?? "BaseDatos";

var connectionString = $"Initial Catalog={database}; Data Source={server};User ID={user};Password={password}";

// Add services to the container.
builder.Services
       .AddDbContext<ApplicationDbContext>
    (opt =>opt.UseSqlServer(connectionString));

IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddScoped(typeof(IClienteRepositorio), typeof(ClienteRepositorio));
builder.Services.AddScoped(typeof(ICuentaRepositorio), typeof(CuentaRepositorio));
builder.Services.AddScoped(typeof(IMovimientoRepositorio), typeof(MovimientoRepositorio));
builder.Services.AddScoped(typeof(IReporteRepositorio), typeof(ReporteRepositorio));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApiKevinPincay v1"));
}

if (app.Environment.IsDevelopment()) {
    app.UseHttpsRedirection();
}

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints => {
    endpoints.MapControllers();
});

app.Run();