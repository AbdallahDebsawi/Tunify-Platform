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

