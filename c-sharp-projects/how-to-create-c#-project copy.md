# How to create a C# project

new solution

```
mkdir Multi_app_solution && cd Multi_app_solution
dotnet new sln -n Multi_app_solution
```
new console app
```
dotnet new console -n Hello_world_not_top_level --use-program-main
```

dotnet new console -n focus_with_fucking_function --use-program-main

dotnet new console -n time --use-program-main

add to solution

```
dotnet sln add .\Hello_world_not_top_level\Hello_world_not_top_level.csproj
```

run

```
dotnet run --project .\Hello_world_not_top_level\
```

list solution projects

```
dotnet sln list
```