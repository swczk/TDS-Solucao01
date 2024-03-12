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

var places = new List<Place> {
	new Place { Id = 1, Name = "Eiffel Tower", City = "Paris", Country = "France", Description = "Iconic iron tower", DateVisited = DateTime.Parse("2022-08-15") },
	new Place { Id = 2, Name = "Statue of Liberty", City = "New York City", Country = "United States", Description = "Symbol of freedom and democracy", DateVisited = DateTime.Parse("2022-07-10") },
	new Place { Id = 3, Name = "Machu Picchu", City = "Cusco", Country = "Peru", Description = "Ancient Inca city", DateVisited = DateTime.Parse("2022-09-05") },
	new Place { Id = 4, Name = "Great Wall of China", City = "Beijing", Country = "China", Description = "World's longest wall", DateVisited = DateTime.Parse("2022-06-20") },
	new Place { Id = 5, Name = "Taj Mahal", City = "Agra", Country = "India", Description = "Symbol of love", DateVisited = DateTime.Parse("2022-10-12") },
	new Place { Id = 6, Name = "Pyramids of Giza", City = "Giza", Country = "Egypt", Description = "Ancient burial structures", DateVisited = DateTime.Parse("2022-05-03") },
	new Place { Id = 7, Name = "Colosseum", City = "Rome", Country = "Italy", Description = "Ancient amphitheater", DateVisited = DateTime.Parse("2022-04-25") },
	new Place { Id = 8, Name = "Petra", City = "Ma'an Governorate", Country = "Jordan", Description = "Ancient archaeological site", DateVisited = DateTime.Parse("2022-11-18") },
	new Place { Id = 9, Name = "Sydney Opera House", City = "Sydney", Country = "Australia", Description = "Iconic performing arts center", DateVisited = DateTime.Parse("2022-12-30") },
	new Place { Id = 10, Name = "Acropolis of Athens", City = "Athens", Country = "Greece", Description = "Ancient citadel", DateVisited = DateTime.Parse("2023-01-05") }
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
