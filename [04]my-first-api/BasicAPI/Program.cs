using BasicAPI.Dtos;

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

app.MapGet("people/{Id}", (int Id) => people.Find(person => person.Id == Id))
.WithName(GetPersonEndpointName);

app.MapGet("animals/{Id}", (int Id) => animals.Find(animal => animal.Id == Id))
.WithName(GetAnimalEndpointName);

// POST / "Send and Update Data"

app.MapPost("people", (CreatePeopleDto newPerson)=>
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

app.MapGet("/", () => "Hello World!");

app.Run();
