namespace BTSession03.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PriceReducerNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clothers", "PriceReduce", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Electronics", "PriceReduce", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Electronics", "PriceReduce", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Clothers", "PriceReduce", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
