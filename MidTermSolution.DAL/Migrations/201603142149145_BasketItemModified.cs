namespace MidTermSolution.Contracts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class BasketItemModified : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.BasketItems", "BasketItems");
        }

        public override void Down()
        {
            AddColumn("dbo.BasketItems", "BasketItems", c => c.Int(nullable: false));
        }
    }
}
