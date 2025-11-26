using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Seminario.Business.Contracts.Repositories;
using Seminario.Business.Contracts.Services;
using Seminario.Business.Repositories;
using Seminario.Business.Services;
using Seminario.Data;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularDevClient", policy =>
    {
        policy
            .WithOrigins("http://localhost:4200") // tu frontend Angular
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<Context>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("Connection"))
  );


builder.Services.AddScoped<IMessageRepository, MessageRepository>();
builder.Services.AddScoped<IMedicionCompoiscionAguaRepository, MedicionComposicionAguaRepository>();
builder.Services.AddScoped<IMessageServices, MessageServices>();
builder.Services.AddScoped<IMedicionComposicionAguaServices, MedicionComposicionAguaServices>();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseCors("AllowAngularDevClient");


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
