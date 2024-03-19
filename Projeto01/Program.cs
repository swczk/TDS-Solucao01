using Microsoft.AspNetCore.Http.HttpResults;
using Projeto01.Model;

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

var places = new List<PlaceModel> {
	new PlaceModel { PlaceID = 1, Name = "Eiffel Tower", City = "Paris", Country = "France", Description = "Iconic iron tower", DateVisited = DateTime.Parse("2022-08-15") },
	new PlaceModel { PlaceID = 2, Name = "Statue of Liberty", City = "New York City", Country = "United States", Description = "Symbol of freedom and democracy", DateVisited = DateTime.Parse("2022-07-10") },
	new PlaceModel { PlaceID = 3, Name = "Machu Picchu", City = "Cusco", Country = "Peru", Description = "Ancient Inca city", DateVisited = DateTime.Parse("2022-09-05") },
	new PlaceModel { PlaceID = 4, Name = "Great Wall of China", City = "Beijing", Country = "China", Description = "World's longest wall", DateVisited = DateTime.Parse("2022-06-20") },
	new PlaceModel { PlaceID = 5, Name = "Taj Mahal", City = "Agra", Country = "India", Description = "Symbol of love", DateVisited = DateTime.Parse("2022-10-12") },
	new PlaceModel { PlaceID = 6, Name = "Pyramids of Giza", City = "Giza", Country = "Egypt", Description = "Ancient burial structures", DateVisited = DateTime.Parse("2022-05-03") },
	new PlaceModel { PlaceID = 7, Name = "Colosseum", City = "Rome", Country = "Italy", Description = "Ancient amphitheater", DateVisited = DateTime.Parse("2022-04-25") },
	new PlaceModel { PlaceID = 8, Name = "Petra", City = "Ma'an Governorate", Country = "Jordan", Description = "Ancient archaeological site", DateVisited = DateTime.Parse("2022-11-18") },
	new PlaceModel { PlaceID = 9, Name = "Sydney Opera House", City = "Sydney", Country = "Australia", Description = "Iconic performing arts center", DateVisited = DateTime.Parse("2022-12-30") },
	new PlaceModel { PlaceID = 10, Name = "Acropolis of Athens", City = "Athens", Country = "Greece", Description = "Ancient citadel", DateVisited = DateTime.Parse("2023-01-05") }
};

app.MapGet("/places", () =>
{
	return places;
});

app.MapGet("/places/{id}", (int id) =>
{
	var place = places.Find(p => p.PlaceID == id);
	if (place is null)
		return Results.NotFound("Sorry, this place doesn't exist.");

	return Results.Ok(place);
});

app.MapPost("/places", (PlaceModel place) =>
{
	places.Add(place);
	return places;
});

app.MapPut("/places/{id}", (PlaceModel updatePlace, int id) =>
{
	var place = places.Find(p => p.PlaceID == id);
	if (place is null)
		return Results.NotFound("Sorry, this place doesn't exist.");

	place.Name = updatePlace.Name;
	place.City = updatePlace.City;
	place.Country = updatePlace.Country;

	return Results.Ok(place);
});

app.MapDelete("/places/{id}", (int id) =>
{
	var place = places.Find(p => p.PlaceID == id);
	if (place is null)
		return Results.NotFound("Sorry, this place doesn't exist.");

	places.Remove(place);

	return Results.Ok("Place removed!");
});

app.Run();
