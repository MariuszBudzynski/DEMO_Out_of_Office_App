## Application written as a demonstration Task.

### Sample Screenshots
![Alt text](https://raw.githubusercontent.com/MariuszBudzynski/DEMO_Out_of_Office_App/master/2024-06-22%20141332.png)
![Alt text](https://raw.githubusercontent.com/MariuszBudzynski/DEMO_Out_of_Office_App/master/2024-06-22%20141633.png)
![Alt text](https://raw.githubusercontent.com/MariuszBudzynski/DEMO_Out_of_Office_App/master/2024-06-22%20141556.png)
![Alt text](https://raw.githubusercontent.com/MariuszBudzynski/DEMO_Out_of_Office_App/master/2024-06-22%20141431.png)

### Database Schema
![Alt text](https://raw.githubusercontent.com/MariuszBudzynski/DEMO_Out_of_Office_App/master/DBDiagram.jpg)

### Technologies used:
- C#
- .NET
- HTML
- CSS
- Razor Pages
- Basic Login (Authentication/Authorization)
- SQL Server
- EF Core
- Dependency Injection
- JS/JQ
- XUnit Tests
- MOQ
- Serilog
- Clean Architecture
- DTOs

### How to Use
1. Clone this repository.
2. Use the following command in the package manager console to properly apply the migrations:
   Update-Database -Project DEMOOutOfOfficeApp.Core -StartupProject DEMOOutOfOfficeApp -Context AppDbContext
4. The application has some test data and requires logging in. The users prepared for testing are:

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
