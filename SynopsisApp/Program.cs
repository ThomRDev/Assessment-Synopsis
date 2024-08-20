using SynopsisApp.Config;
using SynopsisApp.Domain.Repositories;
using SynopsisApp.Domain.Repositories.impl;
using SynopsisApp.Service;
using SynopsisApp.Service.impl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddSingleton<ISqlConnectionWrapper>(new SqlConnectionWrapper(connectionString));
builder.Services.AddTransient<DishRepository, DishRepositoryImpl>();
builder.Services.AddTransient<IngredientRepository, IngredientRepositoryImpl>();
builder.Services.AddTransient<DishService, DishServiceImpl>();
builder.Services.AddTransient<IngredientService, IngredientServiceImpl>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin();
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors();

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
