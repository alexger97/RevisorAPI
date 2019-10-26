using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APIAttica.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InstrumentNomenclatures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstrumentNomenclatures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InventoryObjectsMain",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryObjectsMain", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaterialNomenclatures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Units = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialNomenclatures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InstrumnetHeader",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    XKey = table.Column<string>(nullable: true),
                    NomenclatureId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstrumnetHeader", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstrumnetHeader_InstrumentNomenclatures_NomenclatureId",
                        column: x => x.NomenclatureId,
                        principalTable: "InstrumentNomenclatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HoldsInstrument",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    InventoryObjectId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoldsInstrument", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoldsInstrument_InventoryObjectsMain_InventoryObjectId",
                        column: x => x.InventoryObjectId,
                        principalTable: "InventoryObjectsMain",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HoldsMaterial",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    InventoryObjectId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoldsMaterial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoldsMaterial_InventoryObjectsMain_InventoryObjectId",
                        column: x => x.InventoryObjectId,
                        principalTable: "InventoryObjectsMain",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ElementInstrumentToUpload",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InstrumnetHeaderId = table.Column<int>(nullable: true),
                    NomenclatureId = table.Column<int>(nullable: true),
                    XKey = table.Column<string>(nullable: true),
                    HoldInstrumentId = table.Column<int>(nullable: true),
                    ImagePhoneSource = table.Column<string>(nullable: true),
                    IsLoaded = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElementInstrumentToUpload", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ElementInstrumentToUpload_HoldsInstrument_HoldInstrumentId",
                        column: x => x.HoldInstrumentId,
                        principalTable: "HoldsInstrument",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ElementInstrumentToUpload_InstrumnetHeader_InstrumnetHeaderId",
                        column: x => x.InstrumnetHeaderId,
                        principalTable: "InstrumnetHeader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ElementInstrumentToUpload_InstrumentNomenclatures_NomenclatureId",
                        column: x => x.NomenclatureId,
                        principalTable: "InstrumentNomenclatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ElementMaterialToUploads",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HoldMaterialId = table.Column<int>(nullable: true),
                    MaterialNomenclatureId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Units = table.Column<string>(nullable: true),
                    Count = table.Column<double>(nullable: false),
                    IsLoaded = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElementMaterialToUploads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ElementMaterialToUploads_HoldsMaterial_HoldMaterialId",
                        column: x => x.HoldMaterialId,
                        principalTable: "HoldsMaterial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ElementMaterialToUploads_MaterialNomenclatures_MaterialNomenclatureId",
                        column: x => x.MaterialNomenclatureId,
                        principalTable: "MaterialNomenclatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TransactInstruments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ElementInstrumentToUploadId = table.Column<int>(nullable: true),
                    Image = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactInstruments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactInstruments_ElementInstrumentToUpload_ElementInstrumentToUploadId",
                        column: x => x.ElementInstrumentToUploadId,
                        principalTable: "ElementInstrumentToUpload",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ElementInstrumentToUpload_HoldInstrumentId",
                table: "ElementInstrumentToUpload",
                column: "HoldInstrumentId");

            migrationBuilder.CreateIndex(
                name: "IX_ElementInstrumentToUpload_InstrumnetHeaderId",
                table: "ElementInstrumentToUpload",
                column: "InstrumnetHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_ElementInstrumentToUpload_NomenclatureId",
                table: "ElementInstrumentToUpload",
                column: "NomenclatureId");

            migrationBuilder.CreateIndex(
                name: "IX_ElementMaterialToUploads_HoldMaterialId",
                table: "ElementMaterialToUploads",
                column: "HoldMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_ElementMaterialToUploads_MaterialNomenclatureId",
                table: "ElementMaterialToUploads",
                column: "MaterialNomenclatureId");

            migrationBuilder.CreateIndex(
                name: "IX_HoldsInstrument_InventoryObjectId",
                table: "HoldsInstrument",
                column: "InventoryObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_HoldsMaterial_InventoryObjectId",
                table: "HoldsMaterial",
                column: "InventoryObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_InstrumnetHeader_NomenclatureId",
                table: "InstrumnetHeader",
                column: "NomenclatureId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactInstruments_ElementInstrumentToUploadId",
                table: "TransactInstruments",
                column: "ElementInstrumentToUploadId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ElementMaterialToUploads");

            migrationBuilder.DropTable(
                name: "TransactInstruments");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "HoldsMaterial");

            migrationBuilder.DropTable(
                name: "MaterialNomenclatures");

            migrationBuilder.DropTable(
                name: "ElementInstrumentToUpload");

            migrationBuilder.DropTable(
                name: "HoldsInstrument");

            migrationBuilder.DropTable(
                name: "InstrumnetHeader");

            migrationBuilder.DropTable(
                name: "InventoryObjectsMain");

            migrationBuilder.DropTable(
                name: "InstrumentNomenclatures");
        }
    }
}
