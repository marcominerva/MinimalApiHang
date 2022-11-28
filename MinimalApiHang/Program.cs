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

app.MapPost("/api/people", (Person person, DateTime? dateTime) =>
{
    return TypedResults.NoContent();
})
.WithOpenApi(operation => new(operation)
{
    Summary = "Calling this endpoint with no dateTime query parameter will cause the endpoint to hang.  If, instead, you specify a value (let's say 2020-01-01), the endpoint is correctly invoked. After that, if you try to call again the endpoint, with no query parameter, now the API is reached as expected."
})
;

app.Run();

public record class Person(string FirstName, string LastName);