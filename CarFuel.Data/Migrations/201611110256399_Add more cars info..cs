namespace CarFuel.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addmorecarsinfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "PlateNo", c => c.String(nullable: false, maxLength: 10));
            AddColumn("dbo.Cars", "Color", c => c.String(maxLength: 30));

            //สามารถแก้ไขเพิ่มเติมได้ เช่น
            Sql("UPDATE dbo.Cars Set Color='Black'");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cars", "Color");
            DropColumn("dbo.Cars", "PlateNo");
        }
    }
}
