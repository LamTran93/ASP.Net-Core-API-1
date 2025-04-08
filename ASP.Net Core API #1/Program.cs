using Application.Interfaces;
using Application.Services;
using Domain.Models;
using Domain.Models.Enums;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

List<Person> personList = [
                new Person { Id = Guid.NewGuid(), FirstName = "John", LastName = "Doe", DateOfBirth = new DateOnly(1990, 1, 1), Gender = Gender.Male, BirthPlace = "New York", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Person { Id = Guid.NewGuid(), FirstName = "Jane", LastName = "Doe", DateOfBirth = new DateOnly(1991, 2, 2), Gender = Gender.Female, BirthPlace = "Los Angeles", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Person { Id = Guid.NewGuid(), FirstName = "Michael", LastName = "Smith", DateOfBirth = new DateOnly(1985, 3, 3), Gender = Gender.Male, BirthPlace = "Chicago", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Person { Id = Guid.NewGuid(), FirstName = "Emily", LastName = "Johnson", DateOfBirth = new DateOnly(1988, 4, 4), Gender = Gender.Female, BirthPlace = "Houston", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Person { Id = Guid.NewGuid(), FirstName = "David", LastName = "Williams", DateOfBirth = new DateOnly(1992, 5, 5), Gender = Gender.Male, BirthPlace = "Phoenix", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Person { Id = Guid.NewGuid(), FirstName = "Sarah", LastName = "Brown", DateOfBirth = new DateOnly(1993, 6, 6), Gender = Gender.Female, BirthPlace = "Philadelphia", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Person { Id = Guid.NewGuid(), FirstName = "James", LastName = "Jones", DateOfBirth = new DateOnly(1987, 7, 7), Gender = Gender.Male, BirthPlace = "San Antonio", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Person { Id = Guid.NewGuid(), FirstName = "Jessica", LastName = "Garcia", DateOfBirth = new DateOnly(1989, 8, 8), Gender = Gender.Female, BirthPlace = "San Diego", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Person { Id = Guid.NewGuid(), FirstName = "Robert", LastName = "Martinez", DateOfBirth = new DateOnly(1994, 9, 9), Gender = Gender.Male, BirthPlace = "Dallas", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Person { Id = Guid.NewGuid(), FirstName = "Linda", LastName = "Rodriguez", DateOfBirth = new DateOnly(1995, 10, 10), Gender = Gender.Female, BirthPlace = "San Jose", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Person { Id = Guid.NewGuid(), FirstName = "William", LastName = "Hernandez", DateOfBirth = new DateOnly(1986, 11, 11), Gender = Gender.Male, BirthPlace = "Austin", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Person { Id = Guid.NewGuid(), FirstName = "Barbara", LastName = "Lopez", DateOfBirth = new DateOnly(1984, 12, 12), Gender = Gender.Female, BirthPlace = "Jacksonville", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Person { Id = Guid.NewGuid(), FirstName = "Charles", LastName = "Gonzalez", DateOfBirth = new DateOnly(1996, 1, 13), Gender = Gender.Male, BirthPlace = "Fort Worth", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Person { Id = Guid.NewGuid(), FirstName = "Susan", LastName = "Wilson", DateOfBirth = new DateOnly(1997, 2, 14), Gender = Gender.Female, BirthPlace = "Columbus", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Person { Id = Guid.NewGuid(), FirstName = "Joseph", LastName = "Anderson", DateOfBirth = new DateOnly(1983, 3, 15), Gender = Gender.Male, BirthPlace = "Charlotte", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Person { Id = Guid.NewGuid(), FirstName = "Karen", LastName = "Thomas", DateOfBirth = new DateOnly(1982, 4, 16), Gender = Gender.Female, BirthPlace = "San Francisco", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Person { Id = Guid.NewGuid(), FirstName = "Thomas", LastName = "Taylor", DateOfBirth = new DateOnly(1998, 5, 17), Gender = Gender.Male, BirthPlace = "Indianapolis", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Person { Id = Guid.NewGuid(), FirstName = "Nancy", LastName = "Moore", DateOfBirth = new DateOnly(1999, 6, 18), Gender = Gender.Female, BirthPlace = "Seattle", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Person { Id = Guid.NewGuid(), FirstName = "Christopher", LastName = "Jackson", DateOfBirth = new DateOnly(1981, 7, 19), Gender = Gender.Male, BirthPlace = "Denver", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Person { Id = Guid.NewGuid(), FirstName = "Betty", LastName = "Martin", DateOfBirth = new DateOnly(1980, 8, 20), Gender = Gender.Female, BirthPlace = "Washington", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }
            ];

List<Job> jobList = [
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

builder.Services.AddSingleton(personList);
builder.Services.AddSingleton(jobList);

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

await app.RunAsync();
