namespace TeamProgrammer.UniversityManagement.DataRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseId = c.Int(nullable: false, identity: true),
                        CourseName = c.String(nullable: false),
                        CourseCode = c.String(nullable: false),
                        Credit = c.Double(nullable: false),
                        Discription = c.String(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        SemesterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseId)
                .ForeignKey("dbo.Semesters", t => t.SemesterId, cascadeDelete: true)
                .Index(t => t.SemesterId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        DeptName = c.String(nullable: false),
                        DeptCode = c.String(nullable: false),
                        DeptCredit = c.Double(nullable: false),
                        Adminstrator = c.String(nullable: false),
                        StratDate = c.DateTime(nullable: false),
                        Building = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        StudentName = c.String(nullable: false),
                        Registration = c.String(),
                        Email = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        SeassonId = c.Int(nullable: false),
                        Address = c.String(nullable: false),
                        ContactNo = c.String(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        SemesterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.Seassons", t => t.SeassonId, cascadeDelete: true)
                .ForeignKey("dbo.Semesters", t => t.SemesterId, cascadeDelete: true)
                .Index(t => t.SeassonId)
                .Index(t => t.DepartmentId)
                .Index(t => t.SemesterId);
            
            CreateTable(
                "dbo.Seassons",
                c => new
                    {
                        SeassonId = c.Int(nullable: false, identity: true),
                        SeassonName = c.String(),
                    })
                .PrimaryKey(t => t.SeassonId);
            
            CreateTable(
                "dbo.Semesters",
                c => new
                    {
                        SemesterId = c.Int(nullable: false, identity: true),
                        SemesterName = c.String(),
                    })
                .PrimaryKey(t => t.SemesterId);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        TeacherId = c.Int(nullable: false, identity: true),
                        TeacherName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        DesignationId = c.Int(nullable: false),
                        JoinDate = c.DateTime(nullable: false),
                        ContactNo = c.String(nullable: false),
                        CreditToBeTaken = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TeacherId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.Designations", t => t.DesignationId, cascadeDelete: true)
                .Index(t => t.DesignationId)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Designations",
                c => new
                    {
                        DesignationId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.DesignationId);
            
            CreateTable(
                "dbo.StudentResults",
                c => new
                    {
                        StudentResultId = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        ClassTest = c.Double(nullable: false),
                        AssignMent = c.Double(nullable: false),
                        Midterm = c.Double(nullable: false),
                        SubjectMark = c.Double(nullable: false),
                        Gpa = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.StudentResultId)
                .ForeignKey("dbo.Courses", t => t.CourseId)
                .ForeignKey("dbo.Students", t => t.StudentId)
                .Index(t => t.StudentId)
                .Index(t => t.CourseId);
            
            //CreateTable(
            //    "dbo.StudentResultView",
            //    c => new
            //        {
            //            StudentId = c.Int(nullable: false, identity: true),
            //            StudentName = c.String(),
            //            Registration = c.String(),
            //            CourseName = c.String(),
            //            CourseCode = c.String(),
            //            Gpa = c.Double(nullable: false),
            //        })
            //    .PrimaryKey(t => t.StudentId);
            
            CreateTable(
                "dbo.DepartmentCourses",
                c => new
                    {
                        Department_DepartmentId = c.Int(nullable: false),
                        Course_CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Department_DepartmentId, t.Course_CourseId })
                .ForeignKey("dbo.Departments", t => t.Department_DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Course_CourseId, cascadeDelete: true)
                .Index(t => t.Department_DepartmentId)
                .Index(t => t.Course_CourseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentResults", "StudentId", "dbo.Students");
            DropForeignKey("dbo.StudentResults", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Teachers", "DesignationId", "dbo.Designations");
            DropForeignKey("dbo.Teachers", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Students", "SemesterId", "dbo.Semesters");
            DropForeignKey("dbo.Courses", "SemesterId", "dbo.Semesters");
            DropForeignKey("dbo.Students", "SeassonId", "dbo.Seassons");
            DropForeignKey("dbo.Students", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.DepartmentCourses", "Course_CourseId", "dbo.Courses");
            DropForeignKey("dbo.DepartmentCourses", "Department_DepartmentId", "dbo.Departments");
            DropIndex("dbo.DepartmentCourses", new[] { "Course_CourseId" });
            DropIndex("dbo.DepartmentCourses", new[] { "Department_DepartmentId" });
            DropIndex("dbo.StudentResults", new[] { "CourseId" });
            DropIndex("dbo.StudentResults", new[] { "StudentId" });
            DropIndex("dbo.Teachers", new[] { "DepartmentId" });
            DropIndex("dbo.Teachers", new[] { "DesignationId" });
            DropIndex("dbo.Students", new[] { "SemesterId" });
            DropIndex("dbo.Students", new[] { "DepartmentId" });
            DropIndex("dbo.Students", new[] { "SeassonId" });
            DropIndex("dbo.Courses", new[] { "SemesterId" });
            DropTable("dbo.DepartmentCourses");
            DropTable("dbo.StudentResultView");
            DropTable("dbo.StudentResults");
            DropTable("dbo.Designations");
            DropTable("dbo.Teachers");
            DropTable("dbo.Semesters");
            DropTable("dbo.Seassons");
            DropTable("dbo.Students");
            DropTable("dbo.Departments");
            DropTable("dbo.Courses");
        }
    }
}
