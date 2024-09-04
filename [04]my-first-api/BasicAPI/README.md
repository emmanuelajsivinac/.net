# Basic API with Record Classes
This API uses Data Transfer Objects (DTOs) to process and respond to requests. It supports retrieving (GET) lists of animals or people, adding (POST) new entries, updating (PUT) existing entries, and deleting (DELETE) elements from these lists.

## DTO (Data Transfer Object)
DTOs are classes designed to transport data between different parts of an application. They focus solely on data transfer, excluding any business logic or unnecessary information.

In this API, we use record classes for DTOs. The primary reason for this choice is that we are working with immutable properties, which are instantiated within a list.
