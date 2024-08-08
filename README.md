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
