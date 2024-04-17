using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RpgApi.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoUmParaUm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Derrotas",
                table: "TB_PERSONAGENS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Disputas",
                table: "TB_PERSONAGENS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Vitorias",
                table: "TB_PERSONAGENS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PersonagemId",
                table: "TB_ARMAS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Nome", "PersonagemId" },
                values: new object[] { "Espada", 1 });

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 2,
                column: "PersonagemId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 3,
                column: "PersonagemId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Nome", "PersonagemId" },
                values: new object[] { "Cajado", 4 });

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Nome", "PersonagemId" },
                values: new object[] { "Arco e flecha", 5 });

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 6,
                column: "PersonagemId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Nome", "PersonagemId" },
                values: new object[] { "Ak-47", 7 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.InsertData(
                table: "TB_PERSONAGENS",
                columns: new[] { "Id", "Classe", "Defesa", "Derrotas", "Disputas", "Forca", "FotoPersonagem", "Inteligencia", "Nome", "PontosVida", "UsuarioId", "Vitorias" },
                values: new object[] { 2, 1, 25, 0, 0, 15, null, 30, "Sam", 100, 1, 0 });

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 42, 42, 120, 187, 193, 15, 138, 249, 213, 136, 71, 242, 175, 88, 209, 5, 251, 191, 125, 139, 57, 161, 172, 128, 72, 209, 130, 181, 183, 102, 116, 242, 191, 62, 228, 29, 27, 19, 187, 221, 101, 16, 22, 206, 63, 47, 220, 109, 217, 76, 206, 76, 21, 167, 84, 66, 173, 120, 252, 66, 79, 177, 109, 5 }, new byte[] { 45, 91, 28, 113, 71, 190, 239, 74, 46, 210, 159, 219, 212, 247, 139, 33, 105, 195, 13, 114, 119, 17, 155, 116, 168, 3, 82, 77, 154, 205, 20, 16, 180, 110, 242, 47, 87, 15, 247, 239, 209, 159, 85, 72, 177, 93, 199, 113, 109, 146, 223, 7, 158, 211, 234, 161, 71, 246, 204, 36, 18, 146, 100, 129, 106, 172, 54, 184, 72, 8, 85, 29, 147, 252, 47, 140, 221, 241, 48, 238, 114, 236, 96, 184, 147, 27, 25, 157, 199, 141, 250, 102, 179, 149, 19, 106, 35, 114, 154, 111, 57, 238, 100, 254, 44, 248, 221, 49, 214, 54, 169, 67, 200, 27, 7, 99, 11, 224, 13, 71, 217, 131, 72, 108, 110, 39, 68, 34 } });

            migrationBuilder.CreateIndex(
                name: "IX_TB_ARMAS_PersonagemId",
                table: "TB_ARMAS",
                column: "PersonagemId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_ARMAS_TB_PERSONAGENS_PersonagemId",
                table: "TB_ARMAS",
                column: "PersonagemId",
                principalTable: "TB_PERSONAGENS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_ARMAS_TB_PERSONAGENS_PersonagemId",
                table: "TB_ARMAS");

            migrationBuilder.DropIndex(
                name: "IX_TB_ARMAS_PersonagemId",
                table: "TB_ARMAS");

            migrationBuilder.DeleteData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "Derrotas",
                table: "TB_PERSONAGENS");

            migrationBuilder.DropColumn(
                name: "Disputas",
                table: "TB_PERSONAGENS");

            migrationBuilder.DropColumn(
                name: "Vitorias",
                table: "TB_PERSONAGENS");

            migrationBuilder.DropColumn(
                name: "PersonagemId",
                table: "TB_ARMAS");

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 1,
                column: "Nome",
                value: "Cajado");

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 4,
                column: "Nome",
                value: "Espada");

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 5,
                column: "Nome",
                value: "Ak-47");

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 7,
                column: "Nome",
                value: "Pistola");

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 92, 109, 70, 154, 192, 139, 251, 67, 206, 164, 29, 36, 128, 173, 255, 38, 231, 139, 217, 235, 50, 111, 71, 206, 243, 91, 11, 126, 158, 69, 26, 235, 83, 59, 107, 122, 209, 222, 84, 44, 22, 37, 221, 242, 180, 194, 24, 34, 191, 70, 52, 250, 207, 34, 90, 196, 164, 248, 158, 224, 32, 75, 142, 171 }, new byte[] { 44, 9, 143, 251, 92, 171, 116, 176, 129, 158, 242, 203, 87, 38, 143, 222, 64, 238, 39, 61, 234, 149, 144, 166, 235, 151, 140, 98, 119, 118, 24, 174, 154, 208, 10, 231, 68, 2, 208, 185, 214, 243, 211, 152, 11, 224, 199, 130, 108, 156, 175, 245, 110, 39, 12, 228, 134, 93, 208, 3, 148, 164, 77, 239, 28, 178, 8, 103, 110, 91, 14, 44, 205, 220, 205, 115, 30, 131, 19, 26, 29, 46, 189, 248, 109, 203, 108, 234, 21, 204, 232, 13, 102, 60, 18, 143, 109, 227, 103, 56, 169, 136, 116, 200, 199, 116, 75, 147, 146, 5, 115, 11, 109, 188, 145, 100, 216, 105, 228, 227, 55, 127, 87, 107, 81, 130, 65, 75 } });
        }
    }
}
