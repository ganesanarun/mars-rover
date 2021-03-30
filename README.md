# Mars Rover

* To install .NET 5.0

https://dotnet.microsoft.com/download/dotnet/5.0

* To Run tests with the output from Controller class

`dotnet test -v n`

* To Run the application [From the root folder]

1. `dotnet run --project src/MarsRover/MarsRover.csproj` **Start entering inputs**

2. `dotnet run --project src/MarsRover/MarsRover.csproj < input.txt`

## Entrypoint

* Program.cs

```
static async Task Main()
```

## There are 2 modules

* User Interaction 

   1. Understand user input which can be from any means [console, file, network], convert them into system understandable instructions.

* Rover 

   1. Contains business rules of Plateau and Rover, and commands which could be processed instruction processor of rover.

## Assumptions
 
    1. Only one plateau exists
    2. Negative co-ordinates are not allowed since left most corner is 0,0.
    3. Consider as failure if the commands are making rover to move beyond boundary of Plateau.
    4. Keep the rover where it was if the end result of commands in a set is not within a limit.


