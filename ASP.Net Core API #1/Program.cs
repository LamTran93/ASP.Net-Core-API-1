using Application.Interfaces;
using Application.Services;
using Domain.Models;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

List<Job> list = [
    new Job(){ Id = Guid.NewGuid(), Title = "Task number 1", IsCompleted = false},
    new Job(){ Id = Guid.NewGuid(), Title = "Task number 2", IsCompleted = false},
    new Job(){ Id = Guid.NewGuid(), Title = "Task number 3", IsCompleted = false},
    new Job(){ Id = Guid.NewGuid(), Title = "Task number 4", IsCompleted = false},
    new Job(){ Id = Guid.NewGuid(), Title = "Task number 5", IsCompleted = false},
    new Job(){ Id = Guid.NewGuid(), Title = "Task number 6", IsCompleted = false},
    new Job(){ Id = Guid.NewGuid(), Title = "Task number 7", IsCompleted = false},
    new Job(){ Id = Guid.NewGuid(), Title = "Task number 8", IsCompleted = false},
    new Job(){ Id = Guid.NewGuid(), Title = "Task number 9", IsCompleted = false},
    new Job(){ Id = Guid.NewGuid(), Title = "Task number 10", IsCompleted = false}
];

builder.Services.AddSingleton(list);

builder.Services.AddScoped<IJobRepository, JobRepository>();
builder.Services.AddScoped<IJobServices, JobService>();

builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IPersonService, PersonService>();

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
