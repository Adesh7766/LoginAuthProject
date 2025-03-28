using LoginAuth.DAL.AppDbContext;
using LoginAuth.DAL.IRepository;
using LoginAuth.DAL.Repository;
using Microsoft.EntityFrameworkCore;
using LoginAuth.Service.IService;
using LoginAuth.Service.ServiceImplementation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUsersRepo, UsersRepo>();
builder.Services.AddScoped<IUsersServices, UsersServices>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString)
);

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
