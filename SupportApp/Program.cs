using DefaultNamespace;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SupportApp.Data;
using SupportApp.DTOs;
using SupportApp.Errors;
using SupportApp.Models;
using SupportApp.Proyects;
using SupportApp.Repository;
using SupportTask.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "SupportApp API", Version = "v1" });

    // Configure Swagger to use the API key for authorization
    options.AddSecurityDefinition("auth", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        Description = "JWT Authorization header using the Bearer scheme."
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "auth"
                }
            },
            new string[] {}
        }
    });
});

builder.Services.AddScoped<IProyectRepository, ProyectRepository>();
builder.Services.AddValidatorsFromAssemblyContaining<Program>();
builder.Services.AddScoped<ISupportTaskRepository, SupportTaskRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddIdentityApiEndpoints<IdentityUser>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddErrorDescriber<CustomErrors>();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    var conStrBuilder = new SqlConnectionStringBuilder(builder.Configuration.GetConnectionString("DefaultConnection"));
    conStrBuilder.Password = builder.Configuration["DbPassword"];
    var connection = conStrBuilder.ConnectionString;
    options.UseSqlServer(connection);
});
builder.Services.AddAuthorization();
builder.Services.AddScoped<IValidator<CreateProyectDto>, CreateProyectValidator>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddCors(options =>
{
    options.AddPolicy("Allowlocalhost4200", policyBuilder =>
    {
        policyBuilder.WithOrigins("http://localhost:4200")
            .AllowAnyMethod().AllowCredentials();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "SupportApp API V1");
        c.RoutePrefix = string.Empty;  // Makes Swagger UI the root page
    });
}

app.UseCors("Allowlocalhost4200");
app.UseHttpsRedirection();
app.MapIdentityApi<IdentityUser>();
app.MapControllers();

app.Run();
