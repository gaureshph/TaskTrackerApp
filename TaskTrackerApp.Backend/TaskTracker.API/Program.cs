using Microsoft.EntityFrameworkCore;
using TaskTracker.Repository.DbContexts;
using TaskTracker.Repository.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = "Server=tcp:task-tracker-app.database.windows.net,1433;Initial Catalog=TaskTrackerApp;Persist Security Info=False;User ID=goureshp;Password=Gajanana@17;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

builder.Services.AddDbContext<TaskTrackerAppContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddScoped<ITasksRepository, TasksRepository>();
builder.Services.AddScoped<IStatusesRepository, StatusesRepository>();
builder.Services.AddScoped<ITagsRepository, TagsRepository>();
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
