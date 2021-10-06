using Microsoft.EntityFrameworkCore.Migrations;

namespace CatalogoVideos.DAL.Migrations
{
    public partial class Migration00 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VideoCategorias_Categorias_CategoriaId1",
                table: "VideoCategorias");

            migrationBuilder.DropForeignKey(
                name: "FK_VideoCategorias_Videos_CategoriaId",
                table: "VideoCategorias");

            migrationBuilder.DropIndex(
                name: "IX_VideoCategorias_CategoriaId1",
                table: "VideoCategorias");

            migrationBuilder.DropColumn(
                name: "CategoriaId1",
                table: "VideoCategorias");

            migrationBuilder.CreateIndex(
                name: "IX_VideoCategorias_VideoId",
                table: "VideoCategorias",
                column: "VideoId");

            migrationBuilder.AddForeignKey(
                name: "FK_VideoCategorias_Categorias_CategoriaId",
                table: "VideoCategorias",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VideoCategorias_Videos_VideoId",
                table: "VideoCategorias",
                column: "VideoId",
                principalTable: "Videos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VideoCategorias_Categorias_CategoriaId",
                table: "VideoCategorias");

            migrationBuilder.DropForeignKey(
                name: "FK_VideoCategorias_Videos_VideoId",
                table: "VideoCategorias");

            migrationBuilder.DropIndex(
                name: "IX_VideoCategorias_VideoId",
                table: "VideoCategorias");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaId1",
                table: "VideoCategorias",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_VideoCategorias_CategoriaId1",
                table: "VideoCategorias",
                column: "CategoriaId1");

            migrationBuilder.AddForeignKey(
                name: "FK_VideoCategorias_Categorias_CategoriaId1",
                table: "VideoCategorias",
                column: "CategoriaId1",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VideoCategorias_Videos_CategoriaId",
                table: "VideoCategorias",
                column: "CategoriaId",
                principalTable: "Videos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
