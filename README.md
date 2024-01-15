
# CozaStore - ASP.NET Core 6 Web Application

## Project Introduction
CozaStore is an e-commerce platform developed with ASP.NET Core 6, designed for facilitating the online sale of various products. The platform features a clean, modern user interface and a robust backend to ensure a smooth shopping experience.

## Technology Stack
- Framework: ASP.NET Core 6
- Database: [Specify your database, e.g., SQL Server, MySQL]
- **Other Used Tools:**
  - Entity Framework Core
  - AutoMapper
  - ASP.NET Identity for authentication and user management

## Project Structure
- **.vs**: Contains Visual Studio configuration and user-specific settings.
- **Business**: Implements the business logic of the application.
- **CozaStore_AspNetCore6**: Main project files for the ASP.NET Core application.
- **DataAccess**: Data access layer handling database interactions.
- **Entities**: Defines the database entities and models.

## Setup and Configuration
To set up the project locally:
1. Clone the repository: `git clone [repository link]`.
2. Navigate to the project directory: `cd CozaStore_AspNetCore6`.
3. Install required packages: `dotnet restore`.
4. Configure the database in `appsettings.json`.
5. Apply database migrations: `dotnet ef database update`.
6. Run the application: `dotnet run`.

## Usage Examples
- User Registration and Authentication: Handled through ASP.NET Identity.
- Product Catalog: Managed in the Business layer, displayed through the main project.
- Order Processing: Handled by a dedicated service in the Business layer.

## Contributing
To contribute to this project:
1. Fork the repository.
2. Create a new branch for your feature.
3. Commit your changes.
4. Push to the branch and open a pull request.
