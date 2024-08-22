using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetCoreVolunteering.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBreedRef : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "breeds",
                table: "species");

            migrationBuilder.CreateTable(
                name: "breeds",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    breeds = table.Column<string>(type: "text", nullable: false),
                    breed_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_breeds", x => x.id);
                    table.ForeignKey(
                        name: "fk_breeds_species_breed_id",
                        column: x => x.breed_id,
                        principalTable: "species",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_breeds_breed_id",
                table: "breeds",
                column: "breed_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "breeds");

            migrationBuilder.AddColumn<string>(
                name: "breeds",
                table: "species",
                type: "jsonb",
                nullable: true);
        }
    }
}
