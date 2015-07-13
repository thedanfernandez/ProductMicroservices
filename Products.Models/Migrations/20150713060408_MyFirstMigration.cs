using System.Collections.Generic;
using Microsoft.Data.Entity.Relational.Migrations;
using Microsoft.Data.Entity.Relational.Migrations.Builders;
using Microsoft.Data.Entity.Relational.Migrations.Operations;

namespace Products.Models.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.CreateSequence(
                name: "DefaultSequence",
                type: "bigint",
                startWith: 1L,
                incrementBy: 10);
            migration.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column(type: "int", nullable: false),
                    Description = table.Column(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column(type: "nvarchar(max)", nullable: true),
                    Name = table.Column(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });
            migration.CreateTable(
                name: "Product",
                columns: table => new
                {
                    CategoryId = table.Column(type: "int", nullable: false),
                    Created = table.Column(type: "datetime2", nullable: false),
                    Description = table.Column(type: "nvarchar(max)", nullable: true),
                    Inventory = table.Column(type: "int", nullable: false),
                    LeadTime = table.Column(type: "int", nullable: false),
                    Price = table.Column(type: "decimal(18, 2)", nullable: false),
                    ProductArtUrl = table.Column(type: "nvarchar(max)", nullable: true),
                    ProductDetails = table.Column(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column(type: "int", nullable: false),
                    RecommendationId = table.Column(type: "int", nullable: false),
                    SalePrice = table.Column(type: "decimal(18, 2)", nullable: false),
                    SkuNumber = table.Column(type: "nvarchar(max)", nullable: true),
                    Title = table.Column(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryId",
                        columns: x => x.CategoryId,
                        referencedTable: "Category",
                        referencedColumn: "CategoryId");
                });
        }
        
        public override void Down(MigrationBuilder migration)
        {
            migration.DropSequence("DefaultSequence");
            migration.DropTable("Category");
            migration.DropTable("Product");
        }
    }
}
