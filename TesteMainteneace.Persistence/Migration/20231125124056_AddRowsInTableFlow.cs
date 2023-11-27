using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestMainteneace.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddRowsInTableFlow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO tab_flow (\"Id\",\"TypeFlow\") VALUES('1','AGUARDANDO ATRIBUIÇÃO')");
            migrationBuilder.Sql("INSERT INTO tab_flow (\"Id\",\"TypeFlow\") VALUES('2','ORDEM DE SEVIÇO INVÁLIDA')");
            migrationBuilder.Sql("INSERT INTO tab_flow (\"Id\",\"TypeFlow\") VALUES('3','AGUARDANDO MANUTENÇÃO')");
            migrationBuilder.Sql("INSERT INTO tab_flow (\"Id\",\"TypeFlow\") VALUES('4','MANUTENÇÃO INICIADA')");
            migrationBuilder.Sql("INSERT INTO tab_flow (\"Id\",\"TypeFlow\") VALUES('5','AGUARDANDO PEÇAS')");
            migrationBuilder.Sql("INSERT INTO tab_flow (\"Id\",\"TypeFlow\") VALUES('6','MANUTENÇÃO FINALIZADA')");
            migrationBuilder.Sql("INSERT INTO tab_flow (\"Id\",\"TypeFlow\") VALUES('7','MANUTENÇÃO INVÁLIDA')");
            migrationBuilder.Sql("INSERT INTO tab_flow (\"Id\",\"TypeFlow\") VALUES('8','ORDEM DE SERVIÇO FINALIZADA')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM tab_flow WHERE \"Id\" = '1'");
            migrationBuilder.Sql("DELETE FROM tab_flow WHERE \"Id\" = '2'");
            migrationBuilder.Sql("DELETE FROM tab_flow WHERE \"Id\" = '3'");
            migrationBuilder.Sql("DELETE FROM tab_flow WHERE \"Id\" = '4'");
            migrationBuilder.Sql("DELETE FROM tab_flow WHERE \"Id\" = '5'");
            migrationBuilder.Sql("DELETE FROM tab_flow WHERE \"Id\" = '6'");
            migrationBuilder.Sql("DELETE FROM tab_flow WHERE \"Id\" = '7'");
            migrationBuilder.Sql("DELETE FROM tab_flow WHERE \"Id\" = '8'");

        }
    }
}
