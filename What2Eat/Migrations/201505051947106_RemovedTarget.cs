namespace What2Eat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedTarget : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "Atributes_UserAtributesId", "dbo.UserAtributes");
            DropIndex("dbo.Users", new[] { "Atributes_UserAtributesId" });
            DropTable("dbo.UserAtributes");
            DropTable("dbo.Users");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Password = c.String(),
                        Atributes_UserAtributesId = c.Int(),
                    })
                .PrimaryKey(t => t.UserId);
            
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
            
            CreateIndex("dbo.Users", "Atributes_UserAtributesId");
            AddForeignKey("dbo.Users", "Atributes_UserAtributesId", "dbo.UserAtributes", "UserAtributesId");
        }
    }
}
