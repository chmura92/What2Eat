namespace What2Eat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class najnowszaKoziu : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "KcalPer100g", c => c.Double());
            AlterColumn("dbo.Products", "ProteinsPer100g", c => c.Double());
            AlterColumn("dbo.Products", "CarbonitesPer100g", c => c.Double());
            AlterColumn("dbo.Products", "FatPer100g", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "FatPer100g", c => c.Double(nullable: false));
            AlterColumn("dbo.Products", "CarbonitesPer100g", c => c.Double(nullable: false));
            AlterColumn("dbo.Products", "ProteinsPer100g", c => c.Double(nullable: false));
            AlterColumn("dbo.Products", "KcalPer100g", c => c.Double(nullable: false));
        }
    }
}
