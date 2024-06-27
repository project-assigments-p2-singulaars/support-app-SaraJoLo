using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SupportApp.Data;
using SupportApp.Proyects;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IProyectRepository, ProyectRepository>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddCors(options =>
{
       options.AddPolicy("Allowlocalhost4200", policyBuilder =>
        {
            policyBuilder.WithOrigins("http://localhost:4200")
                .AllowAnyMethod().AllowCredentials();
        });
});
        builder.Services.AddDbContext<AppDbContext>(options =>
{
    var conStrBuilder = new SqlConnectionStringBuilder(builder.Configuration.GetConnectionString("DefaultConnection"));
    conStrBuilder.Password = builder.Configuration["PasswordDB"];
    var connection = conStrBuilder.ConnectionString;
    options.UseSqlServer(connection);
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (builder.Environment.IsDevelopment())

{
    builder.Configuration.AddUserSecrets<Program>();
    app.UseSwagger();
    app.UseSwaggerUI();    
}

app.UseCors("Allowlocalhost4200");
app.MapControllers();
app.UseHttpsRedirection();


app.Run();