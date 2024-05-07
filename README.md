# blazor-movies-project
Repository for a Blazor WebAssembly app with an ASP.NET Core API backend. It features movie listings that users can view, create, update, and delete when authenticated. Unauthenticated users can browse movies. Powered by a SQL Server database, the project showcases modern full-stack development techniques.

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

## Credits
This project uses the following open-source packages:
- Blazor WebAssembly
- ASP.NET Core
- Entity Framework Core
- SQL Server

## License
This project is released under the MIT License.

---
