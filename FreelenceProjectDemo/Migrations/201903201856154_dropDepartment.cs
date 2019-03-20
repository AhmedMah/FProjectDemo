namespace FreelenceProjectDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropDepartment : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Majors", "DepartmentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Majors", "DepartmentId", c => c.Int(nullable: false));
        }
    }
}
