using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Metadata.Builders;
using Microsoft.Data.Entity.Relational.Migrations.Infrastructure;
using Products.Models;

namespace Products.Models.Migrations
{
    [ContextType(typeof(ProductsContext))]
    partial class MyFirstMigration
    {
        public override string Id
        {
            get { return "20150713060408_MyFirstMigration"; }
        }
        
        public override string ProductVersion
        {
            get { return "7.0.0-beta4-12943"; }
        }
        
        public override IModel Target
        {
            get
            {
                var builder = new BasicModelBuilder()
                    .Annotation("SqlServer:ValueGeneration", "Sequence");
                
                builder.Entity("Products.Models.Category", b =>
                    {
                        b.Property<int>("CategoryId")
                            .GenerateValueOnAdd()
                            .Annotation("OriginalValueIndex", 0)
                            .Annotation("SqlServer:ValueGeneration", "Default");
                        b.Property<string>("Description")
                            .Annotation("OriginalValueIndex", 1);
                        b.Property<string>("ImageUrl")
                            .Annotation("OriginalValueIndex", 2);
                        b.Property<string>("Name")
                            .Annotation("OriginalValueIndex", 3);
                        b.Key("CategoryId");
                    });
                
                builder.Entity("Products.Models.Product", b =>
                    {
                        b.Property<int>("CategoryId")
                            .Annotation("OriginalValueIndex", 0);
                        b.Property<DateTime>("Created")
                            .Annotation("OriginalValueIndex", 1);
                        b.Property<string>("Description")
                            .Annotation("OriginalValueIndex", 2);
                        b.Property<int>("Inventory")
                            .Annotation("OriginalValueIndex", 3);
                        b.Property<int>("LeadTime")
                            .Annotation("OriginalValueIndex", 4);
                        b.Property<decimal>("Price")
                            .Annotation("OriginalValueIndex", 5);
                        b.Property<string>("ProductArtUrl")
                            .Annotation("OriginalValueIndex", 6);
                        b.Property<string>("ProductDetails")
                            .Annotation("OriginalValueIndex", 7);
                        b.Property<int>("ProductId")
                            .GenerateValueOnAdd()
                            .Annotation("OriginalValueIndex", 8)
                            .Annotation("SqlServer:ValueGeneration", "Default");
                        b.Property<int>("RecommendationId")
                            .Annotation("OriginalValueIndex", 9);
                        b.Property<decimal>("SalePrice")
                            .Annotation("OriginalValueIndex", 10);
                        b.Property<string>("SkuNumber")
                            .Annotation("OriginalValueIndex", 11);
                        b.Property<string>("Title")
                            .Annotation("OriginalValueIndex", 12);
                        b.Key("ProductId");
                    });
                
                builder.Entity("Products.Models.Product", b =>
                    {
                        b.ForeignKey("Products.Models.Category", "CategoryId");
                    });
                
                return builder.Model;
            }
        }
    }
}
