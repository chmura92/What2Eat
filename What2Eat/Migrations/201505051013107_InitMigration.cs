namespace What2Eat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LikedProducts",
                c => new
                    {
                        LikedProductId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Name = c.String(),
                        Value = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LikedProductId);
            
            CreateTable(
                "dbo.Meals",
                c => new
                    {
                        MealId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MealCategory = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MealId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ProductKind = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId);
            
            CreateTable(
                "dbo.Targets",
                c => new
                    {
                        TargetId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.TargetId);
            
            CreateTable(
                "dbo.UserAtributes",
                c => new
                    {
                        UserAtributesId = c.Int(nullable: false, identity: true),
                        Age = c.Int(nullable: false),
                        Haight = c.Int(nullable: false),
                        Weight = c.Double(nullable: false),
                        IsVegan = c.Boolean(nullable: false),
                        Sex = c.String(),
                    })
                .PrimaryKey(t => t.UserAtributesId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Password = c.String(),
                        Atributes_UserAtributesId = c.Int(),
                        Target_TargetId = c.Int(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.UserAtributes", t => t.Atributes_UserAtributesId)
                .ForeignKey("dbo.Targets", t => t.Target_TargetId)
                .Index(t => t.Atributes_UserAtributesId)
                .Index(t => t.Target_TargetId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Target_TargetId", "dbo.Targets");
            DropForeignKey("dbo.Users", "Atributes_UserAtributesId", "dbo.UserAtributes");
            DropIndex("dbo.Users", new[] { "Target_TargetId" });
            DropIndex("dbo.Users", new[] { "Atributes_UserAtributesId" });
            DropTable("dbo.Users");
            DropTable("dbo.UserAtributes");
            DropTable("dbo.Targets");
            DropTable("dbo.Products");
            DropTable("dbo.Meals");
            DropTable("dbo.LikedProducts");
        }
    }
}
