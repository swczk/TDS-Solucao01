using Microsoft.AspNetCore.Http.HttpResults;
using Projeto01;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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

var summaries = new[]
{
	"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

var places = new List<Place> {
	new Place { Id = 1, Name = "Eiffel Tower", City = "Paris", Country = "France" },
	new Place { Id = 2, Name = "Statue of Liberty", City = "New York City", Country = "United States" },
	new Place { Id = 3, Name = "Machu Picchu", City = "Cusco", Country = "Peru" },
	new Place { Id = 4, Name = "Great Wall of China", City = "Beijing", Country = "China" },
	new Place { Id = 5, Name = "Taj Mahal", City = "Agra", Country = "India" },
	new Place { Id = 6, Name = "Pyramids of Giza", City = "Giza", Country = "Egypt" },
	new Place { Id = 7, Name = "Colosseum", City = "Rome", Country = "Italy" },
	new Place { Id = 8, Name = "Petra", City = "Ma'an Governorate", Country = "Jordan" },
	new Place { Id = 9, Name = "Sydney Opera House", City = "Sydney", Country = "Australia" },
	new Place { Id = 10, Name = "Acropolis of Athens", City = "Athens", Country = "Greece" }
};

app.MapGet("/places", () =>
{
	return places;
});

app.MapGet("/places/{id}", (int id) =>
{
	var place = places.Find(p => p.Id == id);
	if (place is null)
		return Results.NotFound("Sorry, this place doesn't exist.");

	return Results.Ok(place);
});

app.MapPost("/places", (Place place) =>
{
	places.Add(place);
	return places;
});

app.MapPut("/places/{id}", (Place updatePlace, int id) =>
{
	var place = places.Find(p => p.Id == id);
	if (place is null)
		return Results.NotFound("Sorry, this place doesn't exist.");

	place.Name = updatePlace.Name;
	place.City = updatePlace.City;
	place.Country = updatePlace.Country;

	return Results.Ok(place);
});

app.MapDelete("/places/{id}", (int id) =>
{
	var place = places.Find(p => p.Id == id);
	if (place is null)
		return Results.NotFound("Sorry, this place doesn't exist.");

	places.Remove(place);

	return Results.Ok("Place removed!");
});

app.Run();
