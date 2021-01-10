namespace PMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingCategoryTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Categories (Id, Name) VALUES (1, 'Electronics')");
            Sql("INSERT INTO Categories (Id, Name) VALUES (2, 'Home Appliances')");
            Sql("INSERT INTO Categories (Id, Name) VALUES (3, 'Kitchen Accessories')");
            Sql("INSERT INTO Categories (Id, Name) VALUES (4, 'Clothing')");
            Sql("INSERT INTO Categories (Id, Name) VALUES (5, 'Pantry')");
        }
        
        public override void Down()
        {
        }
    }
}
