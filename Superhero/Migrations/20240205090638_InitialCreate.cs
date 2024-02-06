using Microsoft.EntityFrameworkCore.Migrations;

namespace Superheroes.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Appearance",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Gender = table.Column<string>(nullable: true),
                    Race = table.Column<string>(nullable: true),
                    Height = table.Column<string>(nullable: true),
                    Weight = table.Column<string>(nullable: true),
                    EyeColor = table.Column<string>(nullable: true),
                    HairColor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appearance", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Biography",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FullName = table.Column<string>(nullable: true),
                    AlterEgos = table.Column<string>(nullable: true),
                    Aliases = table.Column<string>(nullable: true),
                    PlaceOfBirth = table.Column<string>(nullable: true),
                    FirstAppearance = table.Column<string>(nullable: true),
                    Publisher = table.Column<string>(nullable: true),
                    Alignment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Biography", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Connections",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GroupAffiliation = table.Column<string>(nullable: true),
                    Relatives = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Connections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Powerstats",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Intelligence = table.Column<string>(nullable: true),
                    Strength = table.Column<string>(nullable: true),
                    Speed = table.Column<string>(nullable: true),
                    Durability = table.Column<string>(nullable: true),
                    Power = table.Column<string>(nullable: true),
                    Combat = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Powerstats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Work",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Occupation = table.Column<string>(nullable: true),
                    Base = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Work", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Superheroes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    PowerstatsId = table.Column<int>(nullable: true),
                    BiographyId = table.Column<int>(nullable: true),
                    AppearanceId = table.Column<int>(nullable: true),
                    WorkId = table.Column<int>(nullable: true),
                    ConnectionsId = table.Column<int>(nullable: true),
                    ImageId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Superheroes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Superheroes_Appearance_AppearanceId",
                        column: x => x.AppearanceId,
                        principalTable: "Appearance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Superheroes_Biography_BiographyId",
                        column: x => x.BiographyId,
                        principalTable: "Biography",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Superheroes_Connections_ConnectionsId",
                        column: x => x.ConnectionsId,
                        principalTable: "Connections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Superheroes_Image_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Superheroes_Powerstats_PowerstatsId",
                        column: x => x.PowerstatsId,
                        principalTable: "Powerstats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Superheroes_Work_WorkId",
                        column: x => x.WorkId,
                        principalTable: "Work",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Superheroes_AppearanceId",
                table: "Superheroes",
                column: "AppearanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Superheroes_BiographyId",
                table: "Superheroes",
                column: "BiographyId");

            migrationBuilder.CreateIndex(
                name: "IX_Superheroes_ConnectionsId",
                table: "Superheroes",
                column: "ConnectionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Superheroes_ImageId",
                table: "Superheroes",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Superheroes_PowerstatsId",
                table: "Superheroes",
                column: "PowerstatsId");

            migrationBuilder.CreateIndex(
                name: "IX_Superheroes_WorkId",
                table: "Superheroes",
                column: "WorkId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Superheroes");

            migrationBuilder.DropTable(
                name: "Appearance");

            migrationBuilder.DropTable(
                name: "Biography");

            migrationBuilder.DropTable(
                name: "Connections");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "Powerstats");

            migrationBuilder.DropTable(
                name: "Work");
        }
    }
}
