Aplication written as a demonstration Task.

## Sample Screenshots

## Database Schema
## Technologies used:

C#
.NET
HTML
CSS
Razor Pages
Basic Login (Authentication/Authorization)
SQL Server
EF Core
Dependency Injection
JS/JQ
XUnit Tests
MOQ
Serilog
Clean Architecture
DTOs

## How to Use

1) Clone this repository.
2) Use the following command in the package manager console to properly apply the migrations: Update-Database -Project DEMOOutOfOfficeApp.Core -StartupProject DEMOOutOfOfficeApp -Context AppDbContext
3) The application has some test data and requires logging in. The users prepared for testing are:

Username: john.doe
Password: password1
RoleID: HRManager

Username: jane.smith
Password: password2
RoleID: Administrator

Username: alice.johnson
Password: password3
RoleID: ProjectManager

Username: bob.brown
Password: password4
RoleID: Employee

Username: charlie.davis
Password: password5
RoleID: HRManager

Username: diana.evans
Password: password6
RoleID: Employee
