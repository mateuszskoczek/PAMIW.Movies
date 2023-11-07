using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Movies.Database.Migrations
{
    /// <inheritdoc />
    public partial class Migration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Director = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Director", "Title", "Year" },
                values: new object[,]
                {
                    { 1, "Nazariusz Szeląg", "attitude-oriented", 2023 },
                    { 2, "Estera Żmuda", "Gorgeous Granite Shirt", 2023 },
                    { 3, "Piotr Buczkowski", "orange", 2022 },
                    { 4, "Józefina Wiśniewski", "Summit", 2022 },
                    { 5, "Aleksy Pilch", "calculating", 2023 },
                    { 6, "Gabriela Izdebski", "Solutions", 2023 },
                    { 7, "Olaf Marek", "Analyst", 2023 },
                    { 8, "Hubert Skalski", "generating", 2023 },
                    { 9, "Elżbieta Pietrzak", "tan", 2023 },
                    { 10, "Regina Pilarski", "bus", 2023 },
                    { 11, "Dina Żyła", "transparent", 2023 },
                    { 12, "Prokles Winiarski", "Realigned", 2023 },
                    { 13, "Teodor Barański", "Refined Fresh Bacon", 2023 },
                    { 14, "Sylwia Stępniak", "benchmark", 2023 },
                    { 15, "Mateusz Przybyła", "upward-trending", 2023 },
                    { 16, "Laurencja Dziedzic", "Cotton", 2023 },
                    { 17, "Wanesa Kałuża", "digital", 2022 },
                    { 18, "Damian Buczkowski", "mindshare", 2022 },
                    { 19, "Ariadna Bujak", "functionalities", 2022 },
                    { 20, "Tomasz Czerwiński", "withdrawal", 2023 },
                    { 21, "Karolina Rybak", "connect", 2022 },
                    { 22, "Patrycy Tomczak", "JSON", 2023 },
                    { 23, "Gabriela Drozd", "New Mexico", 2023 },
                    { 24, "Greta Szymczyk", "Oregon", 2023 },
                    { 25, "Bibiana Lasota", "programming", 2023 },
                    { 26, "Janina Gałka", "deposit", 2023 },
                    { 27, "Walery Kaczmarczyk", "Tactics", 2022 },
                    { 28, "Lucjan Rojek", "maximize", 2023 },
                    { 29, "Ernest Adamus", "Florida", 2023 },
                    { 30, "Katarzyna Frątczak", "complexity", 2023 },
                    { 31, "Tomasz Domagała", "Montana", 2023 },
                    { 32, "Ruta Majewski", "Planner", 2023 },
                    { 33, "Berta Kalisz", "Borders", 2023 },
                    { 34, "Teodora Kulig", "Refined Plastic Table", 2023 },
                    { 35, "Patrycy Niemczyk", "groupware", 2023 },
                    { 36, "Robert Noga", "unleash", 2023 },
                    { 37, "Alan Prokop", "Greenland", 2023 },
                    { 38, "Beniamin Owczarek", "Nepalese Rupee", 2023 },
                    { 39, "Franciszek Kujawski", "Administrator", 2023 },
                    { 40, "Lucjan Korzeniowski", "alarm", 2023 },
                    { 41, "Jerzy Szymczak", "didactic", 2022 },
                    { 42, "Albert Jezierski", "Handmade", 2022 },
                    { 43, "Herman Kujawa", "Turnpike", 2022 },
                    { 44, "Grzegorz Włodarczyk", "Gorgeous Steel Table", 2023 },
                    { 45, "Izajasz Jankowski", "infomediaries", 2023 },
                    { 46, "Apollinary Marzec", "European Unit of Account 17(E.U.A.-17)", 2023 },
                    { 47, "Klara Kozak", "instruction set", 2023 },
                    { 48, "Edwin Jankowski", "Unbranded Steel Table", 2023 },
                    { 49, "Teodora Szostak", "Rapids", 2022 },
                    { 50, "Ryszard Mroczek", "Cotton", 2023 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
