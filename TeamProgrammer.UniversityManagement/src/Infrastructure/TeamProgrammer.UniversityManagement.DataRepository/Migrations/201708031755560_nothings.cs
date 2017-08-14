namespace TeamProgrammer.UniversityManagement.DataRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nothings : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DepartmentCourses", "Department_DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.DepartmentCourses", "Course_CourseId", "dbo.Courses");
            DropIndex("dbo.DepartmentCourses", new[] { "Department_DepartmentId" });
            DropIndex("dbo.DepartmentCourses", new[] { "Course_CourseId" });
            CreateIndex("dbo.Courses", "DepartmentId");
            AddForeignKey("dbo.Courses", "DepartmentId", "dbo.Departments", "DepartmentId", cascadeDelete: true);
            DropTable("dbo.DepartmentCourses");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.DepartmentCourses",
                c => new
                    {
                        Department_DepartmentId = c.Int(nullable: false),
                        Course_CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Department_DepartmentId, t.Course_CourseId });
            
            DropForeignKey("dbo.Courses", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Courses", new[] { "DepartmentId" });
            CreateIndex("dbo.DepartmentCourses", "Course_CourseId");
            CreateIndex("dbo.DepartmentCourses", "Department_DepartmentId");
            AddForeignKey("dbo.DepartmentCourses", "Course_CourseId", "dbo.Courses", "CourseId", cascadeDelete: true);
            AddForeignKey("dbo.DepartmentCourses", "Department_DepartmentId", "dbo.Departments", "DepartmentId", cascadeDelete: true);
        }
    }
}
