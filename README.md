# Tunify Platform

Tunify is a web application for managing music subscriptions, playlists, and songs. This application integrates various entities such as Users, Subscriptions, Playlists, Songs, Artists, Albums, and PlaylistSongs to provide a comprehensive music management system.

## ERD Diagram

![Tunify ERD Diagram](https://github.com/AbdallahDebsawi/Tunify-Platform/blob/Tunify/Tunify-Platform/TunifyERD.png)

## Entity Relationships

- **User**: Can have multiple subscriptions and playlists.
- **Subscription**: Belongs to a User.
- **Playlist**: Contains multiple songs and belongs to a User.
- **Song**: Can belong to multiple playlists and albums. Created by an Artist.
- **Artist**: Can have multiple songs and albums.
- **Album**: Contains multiple songs and belongs to an Artist.
- **PlaylistSongs**: Many-to-many relationship between Playlist and Song.

## Repository Design Pattern

The Repository Design Pattern is used to encapsulate the data access logic of the application. By creating repositories, we can separate the business logic from the data access logic, making the application more modular, testable, and maintainable.

### Benefits:
- **Abstraction:** Repositories provide a layer of abstraction between the data access layer and the business logic, making it easier to modify the underlying data source without affecting the application logic.
- **Testability:** By abstracting the data access logic, repositories can be mocked in unit tests, allowing for better testing of the business logic.
- **Separation of Concerns:** The data access logic is separated from the controllers, leading to cleaner and more maintainable code.


## New Features: Navigation and Routing

In lab 12, we extended the Tunify Platform by implementing new navigation and routing functionalities to enhance user experience and streamline interaction with various components of the application.

### Navigation and Routing

- **Routing Overview**: 
  Our application now utilizes ASP.NET Core's routing mechanism to handle requests and direct them to the appropriate controllers and actions. This structure allows for clean URLs and easy navigation through the app's various features.
  
- **Navigation**: 
  We've implemented navigation menus that allow users to quickly move between different sections of the platform, such as viewing playlists, browsing songs, and exploring artist profiles.

- **Dynamic Routing**: 
  The application now supports dynamic routing for entities like songs, playlists, and artists. For instance, users can view details for specific playlists or songs via URLs that include the corresponding IDs (e.g., `/playlist/1` to view the playlist with ID 1).

## Entity Relationships

The following relationships have been implemented within the Tunify Platform:

### Playlist and Song

- **Many-to-Many Relationship**: 
  - A playlist can contain multiple songs, and a single song can be part of multiple playlists. This is implemented via a join table `PlaylistSongs`, which holds references to both `PlaylistId` and `SongId`.
  - This relationship allows for flexible playlist management, where users can curate playlists with their favorite songs, and the same song can appear in different playlists.

- **Navigation Properties**:
  - The `Playlist` entity includes a collection of `PlaylistSongs`, which in turn references individual songs.
  - Similarly, the `Song` entity includes a collection of `PlaylistSongs`, allowing it to be aware of all the playlists it belongs to.

### Artist and Song

- **One-to-Many Relationship**:
  - An artist can produce multiple songs, but each song is attributed to only one artist. This relationship is captured by having a foreign key (`ArtistId`) in the `Song` entity that references the `Artist` entity.
  - This structure allows the platform to organize and display songs according to their artists, making it easier for users to explore an artist's work.

- **Navigation Properties**:
  - The `Artist` entity includes a collection of `Songs`, which lists all songs produced by the artist.
  - The `Song` entity holds a reference to its associated `Artist`, allowing for seamless navigation between songs and their creators.


## New Feature: Swagger UI Integration

In Lab 14, we enhanced the Tunify Platform by integrating Swagger UI. Swagger UI provides a visual interface for exploring and interacting with the API endpoints available in the Tunify Platform. This addition makes it easier for developers to understand, test, and debug the API.

### Swagger UI Overview

- **Swagger UI**: Swagger UI is an open-source tool that allows you to visualize and interact with your API's resources. It generates an interactive documentation page directly from your API's specifications. With Swagger UI, you can easily test API endpoints without needing to use external tools like Postman.

### Accessing and Using Swagger UI

1. **Accessing Swagger UI**:
   - After running your Tunify Platform application, you can access Swagger UI by navigating to the following URL in your web browser:
     ```
     http://localhost:{port}/swagger
     ```
     Replace `{port}` with the actual port number your application is running on (e.g., `http://localhost:5000/swagger`).

2. **Using Swagger UI**:
   - **Explore Endpoints**: Once on the Swagger UI page, you'll see a list of available API endpoints grouped by their respective controllers. Each endpoint is displayed with its HTTP method (GET, POST, PUT, DELETE, etc.).
   - **View Details**: Click on an endpoint to expand its details. You'll see information such as request parameters, response types, and possible HTTP status codes.
   - **Test Endpoints**: You can interact with the API directly from the Swagger UI. For example, you can fill in the required parameters and click the "Try it out" button to send a request and view the response in real-time.
   - **Authentication**: If your API requires authentication (e.g., JWT tokens), Swagger UI provides a way to input your token so that you can test authenticated endpoints seamlessly.

3. **Configuration**:
   - Swagger UI has been configured to automatically generate API documentation based on the attributes and comments in your code. If you need to customize the Swagger documentation or add descriptions to your endpoints, you can do so by modifying your controllers and models with XML comments and attributes.

### Benefits of Swagger UI

- **Ease of Use**: Swagger UI simplifies the process of testing and interacting with your API.
- **Interactive Documentation**: Developers can quickly understand how the API works without needing to dive into the source code.
- **Streamlined Testing**: Swagger UI allows for quick and efficient testing of API endpoints directly in the browser, reducing the need for external testing tools.

## New Feature: Identity Setup

In Lab 15, we integrated ASP.NET Core Identity into the Tunify Platform. This addition provides robust authentication and authorization features, allowing users to securely register, log in, and log out of the platform.

### Identity Overview

ASP.NET Core Identity is a membership system that adds login functionality to your application. It manages users, passwords, profile data, roles, claims, tokens, and more. In this lab, we implemented Identity to handle user authentication and authorization.

### Using the Registration, Login, and Logout Features

#### 1. **Registration**

- **How to Register**:
  - Navigate to the registration page by visiting:
    ```
    http://localhost:{port}/Identity/Account/Register
    ```
    Replace `{port}` with the actual port number your application is running on (e.g., `http://localhost:5000/Identity/Account/Register`).
  - Fill in the required fields such as Email, Password, and Confirm Password.
  - Click the "Register" button to create a new user account.
  - Upon successful registration, you will be redirected to a confirmation page or logged in automatically, depending on your configuration.

#### 2. **Login**

- **How to Login**:
  - Navigate to the login page by visiting:
    ```
    http://localhost:{port}/Identity/Account/Login
    ```
    Replace `{port}` with the actual port number your application is running on (e.g., `http://localhost:5000/Identity/Account/Login`).
  - Enter your registered Email and Password.
  - Optionally, you can check the "Remember me" box to stay logged in across sessions.
  - Click the "Login" button to authenticate.
  - Upon successful login, you will be redirected to the homepage or the last page you visited before logging in.

#### 3. **Logout**

- **How to Logout**:
  - You can log out of the application by clicking the "Logout" button or link, usually found in the navigation bar.
  - Logging out will end your session and redirect you to the homepage or login page.

### Customization and Configuration

- **Customizing Identity Pages**:
  - The default Identity pages can be customized to fit the design and requirements of your Tunify Platform. You can scaffold the Identity pages to modify the HTML, CSS, and logic according to your needs.

- **Roles and Authorization**:
  - ASP.NET Core Identity allows you to define roles and manage user permissions. You can assign roles to users and restrict access to certain parts of the application based on their roles.

### Benefits of Identity Integration

- **Security**: ASP.NET Core Identity provides built-in features like password hashing, account lockout, and two-factor authentication, making your application more secure.
- **Extensibility**: Identity is highly customizable, allowing you to extend the default user model with additional properties and implement custom authentication logic.
- **User Management**: Identity simplifies the management of user accounts, roles, and permissions, enabling a more organized and secure platform.


