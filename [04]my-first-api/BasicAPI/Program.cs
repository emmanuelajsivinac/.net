using BasicAPI.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

const string GetPersonEndpointName = "GetPerson";

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

// GET / people "Genera data"
app.MapGet("people", () => people);

// GET / people "Specified data"
app.MapGet("people/{Id}", (int Id) => people.Find(person => person.Id == Id))
.WithName(GetPersonEndpointName);

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


app.MapGet("/", () => "Hello World!");

app.Run();
