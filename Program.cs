using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApiKevinPincay;
using WebApiKevinPincay.Data;
using WebApiKevinPincay.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
       .AddDbContext<ApplicationDbContext>
    (opt =>opt.UseSqlServer(builder.Configuration
                                   .GetConnectionString("ConexionSqlServer")));

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