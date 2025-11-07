using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace W9_assignment_template.Migrations
{
    /// <inheritdoc />
    public partial class NewChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Discriminator",
                table: "Characters",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "AbilityId",
                table: "Characters",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Abilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CharacterID = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    DamageAmount = table.Column<int>(type: "int", nullable: true),
                    HealAmount = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abilities", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Characters_AbilityId",
                table: "Characters",
                column: "AbilityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Abilities_AbilityId",
                table: "Characters",
                column: "AbilityId",
                principalTable: "Abilities",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Abilities_AbilityId",
                table: "Characters");

            migrationBuilder.DropTable(
                name: "Abilities");

            migrationBuilder.DropIndex(
                name: "IX_Characters_AbilityId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "AbilityId",
                table: "Characters");

            migrationBuilder.AlterColumn<string>(
                name: "Discriminator",
                table: "Characters",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(13)",
                oldMaxLength: 13);
        }
    }
}
