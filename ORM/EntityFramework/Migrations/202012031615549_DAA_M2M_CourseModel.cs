namespace EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DAA_M2M_CourseModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "Code", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "Code");
        }
    }
}
