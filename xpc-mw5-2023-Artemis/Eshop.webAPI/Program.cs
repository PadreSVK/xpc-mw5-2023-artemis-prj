using Eshop.webAPI.Configurations;
using Eshop.webAPI.FakeDB;
using Eshop.webAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// todo-other - why?
builder.Services.AddControllers().AddNewtonsoftJson(op => 
    op.SerializerSettings.ReferenceLoopHandling = 
    Newtonsoft.Json.ReferenceLoopHandling.Ignore);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MapperInitializer));
builder.Services.AddSingleton<FakeDatabase>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Initialization of FakeDatabase
// todo-maintability = why is not registered as singleton? 
FakeDatabase.InitDatabase();


app.UseAuthorization();

app.MapControllers();

app.Run();
