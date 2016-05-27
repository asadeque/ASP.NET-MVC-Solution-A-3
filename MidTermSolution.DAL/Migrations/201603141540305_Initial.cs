namespace MidTermSolution.Contracts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BasketItems",
                c => new
                    {
                        BasketItemID = c.Int(nullable: false, identity: true),
                        BasketID = c.Guid(nullable: false),
                        ProductID = c.Int(nullable: false),
                        BasketItems = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BasketItemID)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.Baskets", t => t.BasketID, cascadeDelete: true)
                .Index(t => t.BasketID)
                .Index(t => t.ProductID);

            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        ImageUrl = c.String(maxLength: 255),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CostPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProductDescription = c.String(),
                    })
                .PrimaryKey(t => t.ProductID);

            CreateTable(
                "dbo.Baskets",
                c => new
                    {
                        BasketID = c.Guid(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BasketID);

            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        Town = c.String(),
                        Province = c.String(),
                        PostalCode = c.String(),
                        EmailAddress = c.String(),
                    })
                .PrimaryKey(t => t.CustomerID);

            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        OrderItemId = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Order_OrderID = c.Int(),
                    })
                .PrimaryKey(t => t.OrderItemId)
                .ForeignKey("dbo.Orders", t => t.Order_OrderID)
                .Index(t => t.Order_OrderID);

            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        CustomerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderID);

        }

        public override void Down()
        {
            DropForeignKey("dbo.OrderItems", "Order_OrderID", "dbo.Orders");
            DropForeignKey("dbo.BasketItems", "BasketID", "dbo.Baskets");
            DropForeignKey("dbo.BasketItems", "ProductID", "dbo.Products");
            DropIndex("dbo.OrderItems", new[] { "Order_OrderID" });
            DropIndex("dbo.BasketItems", new[] { "ProductID" });
            DropIndex("dbo.BasketItems", new[] { "BasketID" });
            DropTable("dbo.Orders");
            DropTable("dbo.OrderItems");
            DropTable("dbo.Customers");
            DropTable("dbo.Baskets");
            DropTable("dbo.Products");
            DropTable("dbo.BasketItems");
        }
    }
}
