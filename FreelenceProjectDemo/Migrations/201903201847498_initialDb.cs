namespace FreelenceProjectDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CoordinatorTrainingCourseDetails",
                c => new
                    {
                        CoordinatorTrainingCourseDetailId = c.Int(nullable: false, identity: true),
                        CoordinatorTrainingCourseId = c.Int(nullable: false),
                        Achievements = c.String(),
                        Constraints = c.String(),
                        Notes = c.String(),
                        Status = c.Boolean(nullable: false),
                        TrainerParticipating = c.String(),
                        attachment = c.String(),
                    })
                .PrimaryKey(t => t.CoordinatorTrainingCourseDetailId)
                .ForeignKey("dbo.CoordinatorTrainingCourses", t => t.CoordinatorTrainingCourseId, cascadeDelete: true)
                .Index(t => t.CoordinatorTrainingCourseId);
            
            CreateTable(
                "dbo.CoordinatorTrainingCourses",
                c => new
                    {
                        CoordinatorTrainingCourseId = c.Int(nullable: false, identity: true),
                        AssignmentDate = c.DateTime(nullable: false),
                        MajorId = c.Int(nullable: false),
                        CourseId = c.String(maxLength: 128),
                        TrainerName = c.String(),
                        ReportTypeId = c.Int(nullable: false),
                        DeadlineDate = c.DateTime(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CoordinatorTrainingCourseId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.Courses", t => t.CourseId)
                .ForeignKey("dbo.Majors", t => t.MajorId, cascadeDelete: true)
                .ForeignKey("dbo.ReportTypes", t => t.ReportTypeId, cascadeDelete: true)
                .Index(t => t.MajorId)
                .Index(t => t.CourseId)
                .Index(t => t.ReportTypeId)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseId = c.String(nullable: false, maxLength: 128),
                        CourseName = c.String(),
                        MajorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseId)
                .ForeignKey("dbo.Majors", t => t.MajorId, cascadeDelete: true)
                .Index(t => t.MajorId);
            
            CreateTable(
                "dbo.Majors",
                c => new
                    {
                        MajorId = c.Int(nullable: false, identity: true),
                        MajorName = c.String(),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MajorId);
            
            CreateTable(
                "dbo.ReportTypes",
                c => new
                    {
                        ReportTypeId = c.Int(nullable: false, identity: true),
                        ReportName = c.String(),
                        NumberOfReport = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReportTypeId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.CoordinatorTrainingCourseDetails", "CoordinatorTrainingCourseId", "dbo.CoordinatorTrainingCourses");
            DropForeignKey("dbo.CoordinatorTrainingCourses", "ReportTypeId", "dbo.ReportTypes");
            DropForeignKey("dbo.CoordinatorTrainingCourses", "MajorId", "dbo.Majors");
            DropForeignKey("dbo.CoordinatorTrainingCourses", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Courses", "MajorId", "dbo.Majors");
            DropForeignKey("dbo.CoordinatorTrainingCourses", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Courses", new[] { "MajorId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.CoordinatorTrainingCourses", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.CoordinatorTrainingCourses", new[] { "ReportTypeId" });
            DropIndex("dbo.CoordinatorTrainingCourses", new[] { "CourseId" });
            DropIndex("dbo.CoordinatorTrainingCourses", new[] { "MajorId" });
            DropIndex("dbo.CoordinatorTrainingCourseDetails", new[] { "CoordinatorTrainingCourseId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.ReportTypes");
            DropTable("dbo.Majors");
            DropTable("dbo.Courses");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.CoordinatorTrainingCourses");
            DropTable("dbo.CoordinatorTrainingCourseDetails");
        }
    }
}
