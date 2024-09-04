using System.Data;
using BasicAPI.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging.Console;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

const string GetPersonEndpointName = "GetPerson";
const string GetAnimalEndpointName = "GetAnimal";

List<PeopleDto> people = [
 new (
    1,
    "Alexander",
    "a",
    10
 ),
 new (
    2,
    "Santiago",
    "b",
    20
 ),
 new (
    3,
    "Matias",
    "c",
    30
 )
];

List<AnimalDto> animals = [
 new (
    1,
    "Guffy",
    "Dog",
    "Black"
 ),
 new (
    2,
    "Princess",
    "Cat",
    "Orange"
 )
];

// GET /  "Genera data"
app.MapGet("people", () => people);

app.MapGet("animals", () => animals);


// GET /"Specified data"

app.MapGet("people/{Id}", (int Id) =>
{
   if(Id <= 0)
   {
      var person = people.Find(person => person.Id == Id);

      // Handler when the result of the finding is null.
      return person is null ? Results.NotFound() : Results.Ok(person);
   }else
   {
      return Results.NotFound();
   }
})
.WithName(GetPersonEndpointName);

app.MapGet("animals/{Id}", (int Id) => animals.Find(animal => animal.Id == Id))
.WithName(GetAnimalEndpointName);

// POST / "Send and Update Data"

app.MapPost("people", (CreatePersonDto newPerson)=>
{
    PeopleDto Person = new(
        people.Count + 1,
        newPerson.Name,
        newPerson.ValueRandom,
        newPerson.NumberRandom);
    
    people.Add(Person);

    return Results.CreatedAtRoute(GetPersonEndpointName, new{id = Person.Id}, Person);

});

app.MapPost("animals", (CreateAnimalsDto newAnimal)=>
{
    AnimalDto Animal = new(
        animals.Count + 1,
        newAnimal.Name,
        newAnimal.Kind,
        newAnimal.Color);
    
    animals.Add(Animal);

    return Results.CreatedAtRoute(GetAnimalEndpointName, new{id = Animal.Id}, Animal);

});


// PUT / "Update Data"

app.MapPut("animals/{Id}", (int Id, UpdateAnimalDto updatedAnimal)=>
{

   if(Id >= 0)
   {
      var updateId = animals.FindIndex(animal  => animal.Id == Id);

      animals[updateId] = new AnimalDto(
         Id,
         updatedAnimal.Name,
         updatedAnimal.Kind,
         updatedAnimal.Color
      );

      return Results.NoContent();
   }else
   {
      return Results.NotFound();
   }
});

app.MapPut("people/{Id}", (int Id, UpdatePersonDto updatedPerson)=>{
   var updateId = people.FindIndex(person => person.Id == Id);
   people[updateId] = new PeopleDto(
      Id,
      updatedPerson.Name,
      updatedPerson.ValueRandom,
      updatedPerson.NumberRandom
   );

   return Results.NoContent();

});

// DELETE / "Remove Data"
app.MapDelete("people/{Id}", (int Id)=>{
   people.RemoveAll(person => person.Id == Id);

   return Results.NoContent();
});


app.MapGet("/", () => "Hi there!");

app.Run();
