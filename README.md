
# Blazor Movies Project

#### Video Demo: [Watch Here](https://www.youtube.com/watch?v=RnVmnd6iI88)

#### Description:
The Blazor Movies Project is a dynamic web application developed for Harvard University's CS50 course. This project leverages Blazor WebAssembly and ASP.NET Core to create an interactive movie listing platform. Users can view, create, update, and delete movie listings through a clean and intuitive interface. The application is connected to a SQL Server database that stores all movie data, making it a full-stack solution.

## Features
- **User Authentication**: Supports user registration and login, allowing for differentiated access levels.
- **CRUD Operations**: Authenticated users can create, update, and delete movie listings, while unauthenticated users can only view the listings.
- **Responsive Design**: The application is fully responsive, providing a consistent experience across various devices and screen sizes.
- **Real-time Data Interaction**: Utilizes Blazor's capabilities for real-time UI updates when data changes.

## Installation
To run this project locally, you will need to set up both the Blazor WebAssembly frontend and the ASP.NET Core backend. Follow these steps:
1. Clone the repository to your local machine.
2. Ensure you have .NET 5.0 or later installed.
3. Navigate to the `MoviesApi` project directory and run `dotnet run` to start the backend server.
4. Navigate to the `BlazorMoviesProject` directory and run `dotnet run` to start the frontend application.
5. Access the application via `http://localhost:5000`.

## Usage
After setting up the project, you can:
- **Register/Log in**: To access administrative features.
- **Browse Movies**: All users can browse the existing movie listings.
- **Manage Movies**: Logged-in users can add, edit, or delete movies.

## Database Setup

To set up the database for the Blazor Movies Project, follow these steps:

### Prerequisites
Ensure you have SQL Server Management Studio (SSMS) installed on your machine. If not, you can download it from [SQL Server Management Studio (SSMS)](https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms).

### Steps to Create Database
1. **Navigate to the DatabaseScripts Folder**:
   - Open your project in Visual Studio.
   - Navigate to the `DatabaseScripts` folder.

2. **Open SQL Server Management Studio (SSMS)**:
   - Launch SQL Server Management Studio.
   - Connect to your SQL Server instance.

3. **Execute the Scripts**:
   - In SSMS, open a new query window.
   - Drag and drop the SQL script file from the `DatabaseScripts` folder into the query window or use the `File -> Open -> File...` option to navigate and open the script file.
   - Execute the script by pressing `F5` or clicking on the `Execute` button.

### Configure Connection String
Once the database is created, update the connection strings in the `appsettings.json` file of your ASP.NET Core project to match your SQL Server instance details. This ensures that your application can connect to the newly created database.

### Verify Database Creation
After running the scripts, use SSMS to browse to the SQL Server instance and check if the database and its tables are created correctly and populated with initial data as expected.

### Troubleshooting
If you encounter any issues during the database setup, review the SQL script for any errors and ensure your SQL Server instance is configured to allow script executions. Check for any permission issues that might prevent scripts from running.

## Additional Information
- If modifications are needed based on your environment (e.g., changing database names, schema details), adjust the scripts accordingly before executing.
- Regularly backup your database once changes are made to ensure data safety.


## Credits
This project uses the following open-source packages:
- Blazor WebAssembly
- ASP.NET Core
- Entity Framework Core
- SQL Server

## License
This project is released under the MIT License.

---
