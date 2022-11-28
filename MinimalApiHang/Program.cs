var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    _ = app.UseSwagger();
    _ = app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Provato a mettere [FromBody] e [FromQuery], provato a creare una classe e annotarla come [AsParameters], ma niente
app.MapPost("/api/people", (Person person, DateTime? dateTime) =>
{
    return TypedResults.NoContent();
})
.WithOpenApi()
;

app.Run();

public record class Person(string FirstName, string LastName);