using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace W9_assignment_template.Migrations
{
    /// <inheritdoc />
    public partial class AddAbilitiesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Abilities_AbilityId",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_AbilityId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "AbilityId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "CharacterID",
                table: "Abilities");

            migrationBuilder.RenameColumn(
                name: "HealAmount",
                table: "Abilities",
                newName: "Taunt");

            migrationBuilder.RenameColumn(
                name: "DamageAmount",
                table: "Abilities",
                newName: "Shove");

            migrationBuilder.CreateTable(
                name: "CharacterAbilities",
                columns: table => new
                {
                    AbilitiesId = table.Column<int>(type: "int", nullable: false),
                    CharactersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterAbilities", x => new { x.AbilitiesId, x.CharactersId });
                    table.ForeignKey(
                        name: "FK_CharacterAbilities_Abilities_AbilitiesId",
                        column: x => x.AbilitiesId,
                        principalTable: "Abilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterAbilities_Characters_CharactersId",
                        column: x => x.CharactersId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterAbilities_CharactersId",
                table: "CharacterAbilities",
                column: "CharactersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterAbilities");

            migrationBuilder.RenameColumn(
                name: "Taunt",
                table: "Abilities",
                newName: "HealAmount");

            migrationBuilder.RenameColumn(
                name: "Shove",
                table: "Abilities",
                newName: "DamageAmount");

            migrationBuilder.AddColumn<int>(
                name: "AbilityId",
                table: "Characters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CharacterID",
                table: "Abilities",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
