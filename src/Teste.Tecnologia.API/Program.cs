using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Teste.Tecnologia.Infrastructure.Data.Repository;
using Teste.Tecnologia.Infrastructure.IoC;
using Teste.Tecnologia.API.Filters;
using Teste.Tecnologia.API.Mappers;
using Teste.Tecnologia.Domain.Services.Notification;
using Teste.Tecnologia.Domain.Interfaces.Notification;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using System.Reflection;
using Npgsql;

const string CORS = "CORS";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var env = Environment.GetEnvironmentVariable("ENV");
env ??= builder.Environment.EnvironmentName;

builder.Configuration
    .AddJsonFile($"appsettings.json", false, true)
    .AddJsonFile($"appsettings.{env}.json", false, true);

builder.Services.AddCors(opt =>
{
    opt.AddPolicy(CORS, policy => policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
});

builder.Services.AddApiVersioning(config =>
{
    config.DefaultApiVersion = new ApiVersion(1, 0);
    config.AssumeDefaultVersionWhenUnspecified = true;
    config.ReportApiVersions = true;
    config.ApiVersionReader = new UrlSegmentApiVersionReader();
});

builder.Services.AddVersionedApiExplorer(config =>
{
    config.GroupNameFormat = "'v'VVV";
    config.SubstituteApiVersionInUrl = true;
});

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddControllers(opt =>
{
    opt.Filters.Add<NotificationFilter>();
});

var dataSourceBuilder = new NpgsqlDataSourceBuilder(builder.Configuration.GetConnectionString("DefaultConnection"));
var dataSource = dataSourceBuilder.Build();

builder.Services.AddDbContextPool<RepositoryContext>(opt => opt.UseNpgsql(dataSource));

builder.Services.AddHttpContextAccessor();
builder.Services.AddAutoMapper(typeof(CompraProfile));
builder.Services.AddDependencyInjection();

builder.Services.AddDbContextPool<RepositoryContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    ServiceLocator.Initialize(scope.ServiceProvider.GetService<IContainer>());
}


// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    var apiProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
    app.UseSwagger();
    app.UseSwaggerUI(opt =>
    {
        foreach (var groupName in apiProvider.ApiVersionDescriptions.Select(x => x.GroupName))
        {
            opt.SwaggerEndpoint($"/swagger/{groupName}/swagger.json", groupName.ToUpperInvariant());
        }
    });
}

app.UseCors(CORS);
app.UseHttpsRedirection();

app.MapControllers();
app.Run();
