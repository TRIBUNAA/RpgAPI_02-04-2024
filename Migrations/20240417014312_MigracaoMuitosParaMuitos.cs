using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RpgApi.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoMuitosParaMuitos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_HABILIDADES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Dano = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_HABILIDADES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_PERSONAGENS_HABILIDADES",
                columns: table => new
                {
                    PersonagemId = table.Column<int>(type: "int", nullable: false),
                    HabilidadeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PERSONAGENS_HABILIDADES", x => new { x.PersonagemId, x.HabilidadeId });
                    table.ForeignKey(
                        name: "FK_TB_PERSONAGENS_HABILIDADES_TB_HABILIDADES_HabilidadeId",
                        column: x => x.HabilidadeId,
                        principalTable: "TB_HABILIDADES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_PERSONAGENS_HABILIDADES_TB_PERSONAGENS_PersonagemId",
                        column: x => x.PersonagemId,
                        principalTable: "TB_PERSONAGENS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TB_HABILIDADES",
                columns: new[] { "Id", "Dano", "Nome" },
                values: new object[,]
                {
                    { 1, 35, "Clone" },
                    { 2, 20, "Adormecer" },
                    { 3, 41, "Congelar" },
                    { 4, 10, "Hipnotizar" },
                    { 5, 15, "Ressurreição" },
                    { 6, 48, "Tornado de fogo" },
                    { 7, 49, "Explosão" }
                });

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 182, 151, 246, 27, 12, 33, 19, 70, 177, 0, 160, 124, 68, 138, 121, 178, 38, 22, 38, 167, 192, 4, 76, 101, 50, 63, 104, 199, 237, 126, 151, 141, 203, 84, 127, 72, 186, 217, 165, 26, 180, 51, 21, 5, 52, 239, 148, 11, 136, 222, 105, 17, 192, 147, 187, 70, 115, 52, 90, 184, 143, 52, 8, 189 }, new byte[] { 236, 72, 226, 41, 183, 155, 101, 55, 175, 15, 224, 155, 197, 50, 172, 67, 57, 240, 32, 51, 69, 201, 64, 39, 248, 59, 3, 219, 78, 82, 213, 65, 125, 196, 180, 242, 225, 188, 206, 194, 23, 137, 200, 73, 138, 108, 37, 31, 109, 172, 12, 112, 161, 96, 218, 64, 92, 1, 31, 78, 209, 224, 14, 43, 42, 167, 237, 31, 125, 49, 96, 147, 91, 207, 144, 246, 218, 183, 49, 40, 27, 234, 95, 251, 85, 69, 170, 40, 253, 119, 8, 219, 55, 166, 131, 94, 222, 218, 13, 114, 158, 8, 243, 6, 200, 248, 101, 212, 46, 182, 13, 13, 218, 37, 188, 36, 81, 210, 237, 101, 145, 70, 233, 160, 192, 252, 194, 78 } });

            migrationBuilder.InsertData(
                table: "TB_PERSONAGENS_HABILIDADES",
                columns: new[] { "HabilidadeId", "PersonagemId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 },
                    { 6, 6 },
                    { 7, 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_PERSONAGENS_HABILIDADES_HabilidadeId",
                table: "TB_PERSONAGENS_HABILIDADES",
                column: "HabilidadeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_PERSONAGENS_HABILIDADES");

            migrationBuilder.DropTable(
                name: "TB_HABILIDADES");

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 42, 42, 120, 187, 193, 15, 138, 249, 213, 136, 71, 242, 175, 88, 209, 5, 251, 191, 125, 139, 57, 161, 172, 128, 72, 209, 130, 181, 183, 102, 116, 242, 191, 62, 228, 29, 27, 19, 187, 221, 101, 16, 22, 206, 63, 47, 220, 109, 217, 76, 206, 76, 21, 167, 84, 66, 173, 120, 252, 66, 79, 177, 109, 5 }, new byte[] { 45, 91, 28, 113, 71, 190, 239, 74, 46, 210, 159, 219, 212, 247, 139, 33, 105, 195, 13, 114, 119, 17, 155, 116, 168, 3, 82, 77, 154, 205, 20, 16, 180, 110, 242, 47, 87, 15, 247, 239, 209, 159, 85, 72, 177, 93, 199, 113, 109, 146, 223, 7, 158, 211, 234, 161, 71, 246, 204, 36, 18, 146, 100, 129, 106, 172, 54, 184, 72, 8, 85, 29, 147, 252, 47, 140, 221, 241, 48, 238, 114, 236, 96, 184, 147, 27, 25, 157, 199, 141, 250, 102, 179, 149, 19, 106, 35, 114, 154, 111, 57, 238, 100, 254, 44, 248, 221, 49, 214, 54, 169, 67, 200, 27, 7, 99, 11, 224, 13, 71, 217, 131, 72, 108, 110, 39, 68, 34 } });
        }
    }
}
