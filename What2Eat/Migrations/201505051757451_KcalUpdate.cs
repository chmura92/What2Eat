namespace What2Eat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KcalUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "Target_TargetId", "dbo.Targets");
            DropIndex("dbo.Users", new[] { "Target_TargetId" });
            CreateTable(
                "dbo.MealProducts",
                c => new
                    {
                        MealProductId = c.Int(nullable: false, identity: true),
                        BaseWaight = c.Double(nullable: false),
                        Product_ProductId = c.Int(),
                        Meal_MealId = c.Int(),
                    })
                .PrimaryKey(t => t.MealProductId)
                .ForeignKey("dbo.Products", t => t.Product_ProductId)
                .ForeignKey("dbo.Meals", t => t.Meal_MealId)
                .Index(t => t.Product_ProductId)
                .Index(t => t.Meal_MealId);
            
            AddColumn("dbo.Products", "KcalPer100g", c => c.Double(nullable: false));
            AddColumn("dbo.Products", "ProteinsPer100g", c => c.Double(nullable: false));
            AddColumn("dbo.Products", "CarbonitesPer100g", c => c.Double(nullable: false));
            AddColumn("dbo.Products", "FatPer100g", c => c.Double(nullable: false));
            DropColumn("dbo.Users", "Target_TargetId");
            DropTable("dbo.Targets");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Targets",
                c => new
                    {
                        TargetId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.TargetId);
            
            AddColumn("dbo.Users", "Target_TargetId", c => c.Int());
            DropForeignKey("dbo.MealProducts", "Meal_MealId", "dbo.Meals");
            DropForeignKey("dbo.MealProducts", "Product_ProductId", "dbo.Products");
            DropIndex("dbo.MealProducts", new[] { "Meal_MealId" });
            DropIndex("dbo.MealProducts", new[] { "Product_ProductId" });
            DropColumn("dbo.Products", "FatPer100g");
            DropColumn("dbo.Products", "CarbonitesPer100g");
            DropColumn("dbo.Products", "ProteinsPer100g");
            DropColumn("dbo.Products", "KcalPer100g");
            DropTable("dbo.MealProducts");
            CreateIndex("dbo.Users", "Target_TargetId");
            AddForeignKey("dbo.Users", "Target_TargetId", "dbo.Targets", "TargetId");
        }
    }
}
