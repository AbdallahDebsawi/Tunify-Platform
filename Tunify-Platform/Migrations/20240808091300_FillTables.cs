using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Tunify_Platform.Migrations
{
    /// <inheritdoc />
    public partial class FillTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "ArtistId", "Bio", "Name" },
                values: new object[,]
                {
                    { 1, "Bio for Artist 1", "Artist 1" },
                    { 2, "Bio for Artist 2", "Artist 2" }
                });

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "SubscriptionId", "Price", "SubscriptionType" },
                values: new object[,]
                {
                    { 1, 0m, "Free" },
                    { 2, 9.99m, "Premium" }
                });

            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "AlbumId", "AlbumName", "ArtistId", "ReleaseDate" },
                values: new object[,]
                {
                    { 1, "Album 1", 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Album 2", 2, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "JoinDate", "SubscriptionId", "Username" },
                values: new object[,]
                {
                    { 1, "admin@tunify.com", new DateTime(2024, 8, 8, 12, 12, 59, 867, DateTimeKind.Local).AddTicks(8573), 1, "Admin" },
                    { 2, "john.doe@tunify.com", new DateTime(2024, 8, 8, 12, 12, 59, 867, DateTimeKind.Local).AddTicks(8590), 2, "JohnDoe" },
                    { 3, "jane.doe@tunify.com", new DateTime(2024, 8, 8, 12, 12, 59, 867, DateTimeKind.Local).AddTicks(8592), 2, "JaneDoe" }
                });

            migrationBuilder.InsertData(
                table: "Playlists",
                columns: new[] { "PlaylistId", "CreatedDate", "PlaylistName", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 8, 12, 12, 59, 867, DateTimeKind.Local).AddTicks(8912), "Top Hits", 1 },
                    { 2, new DateTime(2024, 8, 8, 12, 12, 59, 867, DateTimeKind.Local).AddTicks(8914), "Workout Mix", 2 }
                });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "SongId", "AlbumId", "ArtistId", "Duration", "Genre", "Title" },
                values: new object[,]
                {
                    { 1, 1, 1, 300, "Pop", "Song 1" },
                    { 2, 1, 1, 250, "Rock", "Song 2" },
                    { 3, 2, 2, 200, "Jazz", "Song 3" }
                });

            migrationBuilder.InsertData(
                table: "PlaylistSongs",
                columns: new[] { "PlaylistSongId", "PlaylistId", "SongId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 2, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PlaylistSongs",
                keyColumn: "PlaylistSongId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PlaylistSongs",
                keyColumn: "PlaylistSongId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PlaylistSongs",
                keyColumn: "PlaylistSongId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Playlists",
                keyColumn: "PlaylistId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Playlists",
                keyColumn: "PlaylistId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "SongId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "SongId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "SongId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "AlbumId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "AlbumId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "SubscriptionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "SubscriptionId",
                keyValue: 2);
        }
    }
}
