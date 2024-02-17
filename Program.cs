using ExamGlobalApi.ExtensionMethod;
using ExamGlobalApi.Middleware;
using ExamGlobalApi.Services;
using NLog;

var builder = WebApplication.CreateBuilder(args);

LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/NLog.config"));

//builder.Services.AddSingleton<ILoggerManager, LoggerManager>();
builder.Services.RegisterLoggerService();//extension method

// Add services to the container.

builder.Services.AddControllers();
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


app.UseMiddleware<ExceptionMiddleware>();//uygulamanýn pipeline ýna ekledim.
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
