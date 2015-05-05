namespace What2Eat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class najnowsza : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MealProducts", "BaseWaight", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MealProducts", "BaseWaight", c => c.Double(nullable: false));
        }
    }
}
