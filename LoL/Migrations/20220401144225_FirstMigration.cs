using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoL.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Legends",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Legends", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nickname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Player1Id = table.Column<int>(type: "int", nullable: false),
                    Player2Id = table.Column<int>(type: "int", nullable: false),
                    Player3Id = table.Column<int>(type: "int", nullable: false),
                    Player4Id = table.Column<int>(type: "int", nullable: false),
                    Player5Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teams_Players_Player1Id",
                        column: x => x.Player1Id,
                        principalTable: "Players",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Teams_Players_Player2Id",
                        column: x => x.Player2Id,
                        principalTable: "Players",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Teams_Players_Player3Id",
                        column: x => x.Player3Id,
                        principalTable: "Players",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Teams_Players_Player4Id",
                        column: x => x.Player4Id,
                        principalTable: "Players",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Teams_Players_Player5Id",
                        column: x => x.Player5Id,
                        principalTable: "Players",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Compositions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    Legend1Id = table.Column<int>(type: "int", nullable: false),
                    Legend2Id = table.Column<int>(type: "int", nullable: false),
                    Legend3Id = table.Column<int>(type: "int", nullable: false),
                    Legend4Id = table.Column<int>(type: "int", nullable: false),
                    Legend5Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Compositions_Legends_Legend1Id",
                        column: x => x.Legend1Id,
                        principalTable: "Legends",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Compositions_Legends_Legend2Id",
                        column: x => x.Legend2Id,
                        principalTable: "Legends",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Compositions_Legends_Legend3Id",
                        column: x => x.Legend3Id,
                        principalTable: "Legends",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Compositions_Legends_Legend4Id",
                        column: x => x.Legend4Id,
                        principalTable: "Legends",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Compositions_Legends_Legend5Id",
                        column: x => x.Legend5Id,
                        principalTable: "Legends",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Compositions_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Composition1Id = table.Column<int>(type: "int", nullable: false),
                    Composition2Id = table.Column<int>(type: "int", nullable: false),
                    Winner = table.Column<int>(type: "int", nullable: false),
                    GameDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Compositions_Composition1Id",
                        column: x => x.Composition1Id,
                        principalTable: "Compositions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Games_Compositions_Composition2Id",
                        column: x => x.Composition2Id,
                        principalTable: "Compositions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Compositions_Legend1Id",
                table: "Compositions",
                column: "Legend1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Compositions_Legend2Id",
                table: "Compositions",
                column: "Legend2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Compositions_Legend3Id",
                table: "Compositions",
                column: "Legend3Id");

            migrationBuilder.CreateIndex(
                name: "IX_Compositions_Legend4Id",
                table: "Compositions",
                column: "Legend4Id");

            migrationBuilder.CreateIndex(
                name: "IX_Compositions_Legend5Id",
                table: "Compositions",
                column: "Legend5Id");

            migrationBuilder.CreateIndex(
                name: "IX_Compositions_TeamId",
                table: "Compositions",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_Composition1Id",
                table: "Games",
                column: "Composition1Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Games_Composition2Id",
                table: "Games",
                column: "Composition2Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teams_Player1Id",
                table: "Teams",
                column: "Player1Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teams_Player2Id",
                table: "Teams",
                column: "Player2Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teams_Player3Id",
                table: "Teams",
                column: "Player3Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teams_Player4Id",
                table: "Teams",
                column: "Player4Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teams_Player5Id",
                table: "Teams",
                column: "Player5Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Compositions");

            migrationBuilder.DropTable(
                name: "Legends");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
