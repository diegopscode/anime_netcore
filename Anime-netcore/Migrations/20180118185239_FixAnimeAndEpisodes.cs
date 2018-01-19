using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Animenetcore.Migrations
{
    public partial class FixAnimeAndEpisodes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Episode_Animes_Animeid",
                table: "Episode");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Episode",
                table: "Episode");

            migrationBuilder.DropColumn(
                name: "episodes",
                table: "Animes");

            migrationBuilder.RenameTable(
                name: "Episode",
                newName: "Episdes");

            migrationBuilder.RenameColumn(
                name: "Animeid",
                table: "Episdes",
                newName: "animeid");

            migrationBuilder.RenameIndex(
                name: "IX_Episode_Animeid",
                table: "Episdes",
                newName: "IX_Episdes_animeid");

            migrationBuilder.AddColumn<int>(
                name: "episode",
                table: "Episdes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Episdes",
                table: "Episdes",
                column: "id");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    login = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Episdes_Animes_animeid",
                table: "Episdes",
                column: "animeid",
                principalTable: "Animes",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Episdes_Animes_animeid",
                table: "Episdes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Episdes",
                table: "Episdes");

            migrationBuilder.DropColumn(
                name: "episode",
                table: "Episdes");

            migrationBuilder.RenameTable(
                name: "Episdes",
                newName: "Episode");

            migrationBuilder.RenameColumn(
                name: "animeid",
                table: "Episode",
                newName: "Animeid");

            migrationBuilder.RenameIndex(
                name: "IX_Episdes_animeid",
                table: "Episode",
                newName: "IX_Episode_Animeid");

            migrationBuilder.AddColumn<int>(
                name: "episodes",
                table: "Animes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Episode",
                table: "Episode",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Episode_Animes_Animeid",
                table: "Episode",
                column: "Animeid",
                principalTable: "Animes",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
