using System;

namespace BasicAPI.Dtos;

public record class PeopleDto
(
    int Id, 
    string Name,
    string ValueRandom,
    int NumberRandom
);