namespace What2Eat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class chmurka : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MealViewModels",
                c => new
                    {
                        MealViewModelId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        TotalKcal = c.Double(nullable: false),
                        TotalProteins = c.Double(nullable: false),
                        TotalCarbonites = c.Double(nullable: false),
                        TotalFat = c.Double(nullable: false),
                        TotalWeight = c.Double(nullable: false),
                        UserAtributes_Age = c.Int(nullable: false),
                        UserAtributes_Height = c.Int(nullable: false),
                        UserAtributes_Weight = c.Double(nullable: false),
                        UserAtributes_IsVegan = c.Boolean(nullable: false),
                        UserAtributes_Sex = c.Int(nullable: false),
                        Bmi = c.Double(nullable: false),
                        Bmr = c.Double(nullable: false),
                        MealCategory = c.Int(),
                        DayPercent = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MealViewModelId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MealViewModels");
        }
    }
}
