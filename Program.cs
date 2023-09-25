using Microsoft.EntityFrameworkCore;
using WebExercicios.Configuration;
using WebExercicios.Infra.Database;
using WebExercicios.MapperProfiles;
using WebExercicios.Infra.Middlewares;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("KeyDatabaseMySQL");

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowMyOrigin",
        builder =>
        {
            builder.SetIsOriginAllowed((url) =>
            {
                return true;
            })
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

builder.Services.AddAutoMapper(cfg => {
    cfg.AddProfile<Profiles>();
});
builder.Services.AddControllers();
builder.Services.AddDbContext<ExercicioContext>(options =>
   options.UseMySql(connectionString,
        ServerVersion.AutoDetect(connectionString)));
builder.Services.Configurar();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseMiddleware(typeof(ErrorMiddleware));

app.UseHttpsRedirection();

app.UseCors("AllowMyOrigin");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
