using Microsoft.EntityFrameworkCore;
using timesheetapi.Data;
using timesheetapi.Service;
using timesheetapi.Model;


var builder = WebApplication.CreateBuilder(args);

// DI
builder.Services.AddTransient<UserService>();
builder.Services.AddTransient<TruckService>();
builder.Services.AddTransient<TimesheetService>();
builder.Services.AddTransient<EmailService>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var conn = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApiDbContext>(options =>
    options.UseSqlite(conn));

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapPost("/api/sendemail", (Timesheet obj) =>
{
    return Results.Ok(EmailService.SendEmail(obj));
});

app.MapGet("/api/users", (UserService users) =>
{
    return Results.Ok(users.GetAllUsers());
});

app.MapGet("/api/users/{id}", (UserService users, Guid id) =>
{
    var record = users.GetUserById(id);
    if (record != null)
    {
        return Results.Ok(record);
    }
    return Results.NotFound();
});

app.MapPost("/api/users", (UserService users, User newuser) =>
{
    var record = users.GetUserById(newuser.Id);
    if (record == null)
    {
        users.AddUser(newuser);
        return Results.Created("/api/users", newuser);
    }
    return Results.BadRequest("User already exists");
});
app.MapPut("/api/users/{id}", (UserService users, User updateuser, Guid id) =>
{
    var record = users.GetUserById(id);
    if (record != null)
    {
        users.UpdateUser(updateuser);
        return Results.Ok();
    }
    return Results.BadRequest("User does not exist");
});
app.MapDelete("/api/users/{id}", (UserService users, Guid id) =>
{
    var result = users.DeleteUser(id);
    if (result)
        return Results.NoContent();
    return Results.BadRequest("User does not exist");
});

app.MapGet("/weatherforecast", () =>
    {
        var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
            .ToArray();
        return forecast;
    })
    .WithName("GetWeatherForecast")
    .WithOpenApi();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}