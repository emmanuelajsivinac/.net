# Basic API with Record Classes
This API utilizes DTOs (Data Transfer Objects) to handle and respond to requests. It allows you to retrieve (GET) a list of animals or people, as well as insert (POST) new elements into these lists.

## DTO (Data Transfer Object)
DTOs are classes designed to transport data between different parts of an application. They focus solely on data transfer, excluding any business logic or unnecessary information.

In this API, we use record classes for DTOs. The primary reason for this choice is that we are working with immutable properties, which are instantiated within a list.
