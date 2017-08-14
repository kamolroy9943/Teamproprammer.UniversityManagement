using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using TeamProgrammer.UniversityManagement.Core.Business_Interface;
using TeamProgrammer.UniversityManagement.Core.Entities;
using TeamProgrammer.UniversityManagement.DataRepository.Context;

namespace TeamProgrammer.UniversityManagement.Web.Controllers.University
{
    [Authorize(Roles = "Admin")]
    public class StudentResultsController : Controller
    {
       
        private readonly IDepartmentBusiness _departmentBusiness;
        private readonly IStudentResultBusiness _studentResultBusiness;
        private readonly IStudentBusiness _studentBusiness;
        private readonly ICourseBusiness _courseBusiness;
        private readonly ISemesterBusiness _semesterBusiness;


        public StudentResultsController(IDepartmentBusiness departmentBusiness, IStudentResultBusiness studentResultBusiness, IStudentBusiness studentBusiness, ICourseBusiness courseBusiness, ISemesterBusiness semesterBusiness)
        {
            _departmentBusiness = departmentBusiness;
            _studentResultBusiness = studentResultBusiness;
            _studentBusiness = studentBusiness;
            _courseBusiness = courseBusiness;
            _semesterBusiness = semesterBusiness;
        }
 
        public ActionResult Index()
        {
            var studentResults = _studentResultBusiness.GetAll();
            return View(studentResults.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentResult studentResult = _studentResultBusiness.GetById((int) id);
            if (studentResult == null)
            {
                return HttpNotFound();
            }
            return View(studentResult);
        }
 
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(_departmentBusiness.GetAll(), "DepartmentId", "DeptName");
            ViewBag.CourseId = new SelectList(_courseBusiness.GetAll(), "CourseId", "CourseName");
            ViewBag.StudentId = new SelectList(_studentBusiness.GetAll(), "StudentId", "StudentName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentResultId,StudentId,CourseId,ClassTest,AssignMent,Midterm,SubjectMark,Gpa")] StudentResult studentResult)
        {
            if (studentResult.Gpa <= 0)
            {
                studentResult.Gpa = _studentResultBusiness.GetGpa(studentResult.ClassTest, studentResult.AssignMent,
                studentResult.Midterm, studentResult.SubjectMark);
            }
            if (studentResult.Gpa>=0)
            {
                if (ModelState.IsValid)
                {
                    if (!_studentResultBusiness.IsResultAlreayGiven(studentResult.StudentId, studentResult.CourseId))
                    {

                        _studentResultBusiness.Add(studentResult);
                        //return RedirectToAction("Index");
                        ViewBag.Message = "Result Assigned Successfully!";
                    }
                    else
                    {
                        ViewBag.Message = "Result Allready Assigned!";
                    }
                }
                else
                {
                    ViewBag.Message = "Please Provide Your Information Correctly!";
                }
            }
            else
            {
                ViewBag.Message = "Please Provide Your Information Correctly!";
            }
           
            ViewBag.DepartmentId = new SelectList(_departmentBusiness.GetAll(), "DepartmentId", "DeptName");
            ViewBag.CourseId = new SelectList(_courseBusiness.GetAll(), "CourseId", "CourseName", studentResult.CourseId);
            ViewBag.StudentId = new SelectList(_studentBusiness.GetAll(), "StudentId", "StudentName", studentResult.StudentId);
            return View(studentResult);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentResult studentResult = _studentResultBusiness.GetById((int) id);
            if (studentResult == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(_courseBusiness.GetAll().Where(x=>x.DepartmentId==id), "CourseId", "CourseCode", studentResult.CourseId);
            ViewBag.StudentId = new SelectList(_studentBusiness.GetAll(), "StudentId", "Registration", studentResult.StudentId);
            return View(studentResult);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentResultId,StudentId,CourseId,ClassTest,AssignMent,Midterm,SubjectMark,Gpa")] StudentResult studentResult)
        {
            if (!_studentResultBusiness.IsResultAlreayGiven(studentResult.StudentId, studentResult.CourseId))
            {
                _studentResultBusiness.Update(studentResult);
                //return RedirectToAction("Index");
                ViewBag.Message = "Result Updated Successfully!";
            }
            else
            {
                ViewBag.Message = "Result Allready Assigned!";
            }
            ViewBag.CourseId = new SelectList(_courseBusiness.GetAll(), "CourseId", "CourseCode", studentResult.CourseId);
            ViewBag.StudentId = new SelectList(_studentBusiness.GetAll(), "StudentId", "Registration", studentResult.StudentId);
            return View(studentResult);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentResult studentResult = _studentResultBusiness.GetById((int) id);
            if (studentResult == null)
            {
                return HttpNotFound();
            }
            return View(studentResult);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentResult studentResult = _studentResultBusiness.GetById((int) id);
            _studentResultBusiness.Delete(studentResult);
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        public ActionResult ViewSemesterFinalResult()
        {
            ViewBag.DepartmentId = new SelectList(_departmentBusiness.GetAll(), "DepartmentId", "DeptName");

            return View();
        }
        [AllowAnonymous]
        public JsonResult GetSemesterResultByStudentId(int studentId)
         {
            var semesterId =
                _studentBusiness.GetAll()
                    .Where(x => x.StudentId == studentId)
                    .Select(x => x.SemesterId)
                    .FirstOrDefault();
            var departmentId =
                _studentBusiness.GetAll()
                    .Where(x => x.StudentId == studentId)
                    .Select(x => x.DepartmentId)
                    .FirstOrDefault();
            var courses =
                _courseBusiness.GetAll()
                    .Where(x => x.DepartmentId == departmentId && x.SemesterId == semesterId).ToList();

            int countCourse = _courseBusiness.GetAll().Where(x => x.DepartmentId == departmentId && x.SemesterId==semesterId).Select(x => x.CourseId).Count();
            var studentName =
                _studentBusiness.GetAll()
                    .Where(x => x.StudentId == studentId)
                    .Select(x => x.StudentName)
                    .FirstOrDefault();
            float tgp =(float) (_studentResultBusiness.GetAll()
                    .Where(x => x.StudentId == studentId && x.Student.SemesterId == semesterId)
                    .Sum(x => x.Gpa)/countCourse);
            string tgpa = tgp.ToString("0.00");
            List<dynamic> fresults = new List<dynamic>();
            var courseName = "";
            var courseCode = "";
            dynamic sgpa = 0;
            foreach (var course in courses)
            {
                var cours =
                    _studentResultBusiness.GetAll()
                        .Any(x => x.CourseId == course.CourseId && x.StudentId==studentId);
                        
                if (cours==false)
                {
                    sgpa = "Yet to Assign";
                }
                else
                {
                    sgpa =
                        _studentResultBusiness.GetAll()
                            .Where(x => x.StudentId == studentId && x.CourseId == course.CourseId)
                            .Select(x => x.Gpa)
                            .FirstOrDefault();
                }
                courseName =
                    _courseBusiness.GetAll()
                        .Where(x => x.CourseId == course.CourseId)
                        .Select(x => x.CourseName)
                        .FirstOrDefault();

                 courseCode =
                    _courseBusiness.GetAll()
                        .Where(x =>x.CourseId == course.CourseId)
                        .Select(x => x.CourseCode)
                        .FirstOrDefault();


              var results =new 
               {
                    courseName = courseName, courseCode = courseCode, studentName = studentName,
                    sgpa = tgpa, gpa = sgpa
                };
                fresults.Add(results);
            }

            //int countCourse = _studentResultBusiness.GetAll().Where(x=>x.StudentId==studentId).Select(x=>x.CourseId).Count();
            //float tgpa = (float) _studentResultBusiness.GetAll().Where(x => x.StudentId == studentId).Sum(x => x.Gpa)/countCourse;
            //var results = _studentResultBusiness.GetAll().Where(x => x.StudentId == studentId).Select(x => new
            //{
            //    courseName =x.Course.CourseName,
            //    courseCode = x.Course.CourseCode,
            //    studentName=x.Student.StudentName,
            //    sgpa= tgpa,
            //    gpa = x.Gpa
            //});

            return Json(fresults, JsonRequestBehavior.AllowGet);
            
            //var results = db.StudentResultViewModels.Where(x => x.StudentId == studentId).Select(x => new
            //{
      
            //}).ToList();
            //return Json(results, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetFinalResult()
        {
            ViewBag.DepartmentId = new SelectList(_departmentBusiness.GetAll(), "DepartmentId", "DeptName");
            return View();
        }
        
        public JsonResult OtherCoursesToEnrolling(int studentId)
        {
            int deptId = _studentBusiness.GetAll().Where(x => x.StudentId == studentId).Select(x => x.DepartmentId).FirstOrDefault();
            int semesterId = _studentBusiness.GetAll().Where(x => x.StudentId == studentId).Select(x => x.SemesterId).FirstOrDefault();
            string studentName = _studentBusiness.GetAll().Where(x => x.StudentId == studentId).Select(x => x.StudentName).FirstOrDefault();
            var courses =
               _courseBusiness.GetAll().Where(x => x.DepartmentId == deptId && x.SemesterId == semesterId).Select(x => new
               {
                   courseId = x.CourseId,
                   courseName = x.CourseName,
                   courseCode = x.CourseCode,
                   description = x.Discription,
                   credit = x.Credit,
                   StudentName = studentName
               }).ToList();
            List<dynamic> courseList = new List<dynamic>();
            foreach (dynamic course in courses)
            {
                bool courseInfo = _studentResultBusiness.GetAll().Any(x => x.CourseId == course.courseId && x.StudentId == studentId);
                if (courseInfo) { }
                else
                {
                    courseList.Add(course);
                }
            }
            return Json(courseList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllSmesterResultByStudentId(int studentId)
        {
            List<dynamic> result=new List<dynamic>();
            var semesters = _semesterBusiness.GetAll();
            foreach (var semester in semesters)
            {
                dynamic cgpa;
                float sumOfSgpa = 0;
                int increment = 0;
                dynamic totalGpa = 0;
                var sumOfsubGpa = (float) _studentResultBusiness
                    .GetAll()
                    .Where(x => x.StudentId == studentId && x.Student.Semester.SemesterId == semester.SemesterId).Sum(x => x.Gpa);
                var totalcourse =
                    _studentResultBusiness
                        .GetAll()
                        .Where(x => x.StudentId == studentId && x.Student.Semester.SemesterId == semester.SemesterId).Select(x=>x.CourseId).Count();
                if (sumOfsubGpa>0)
                {
                    increment++;
                     cgpa = sumOfsubGpa / totalcourse;
                     sumOfSgpa += cgpa;
                }
                else
                {
                    cgpa ="Yet to complete";
                }
                if (increment == 8)
                {
                    totalGpa = sumOfSgpa/8;
                }
                else
                {
                    totalGpa = "Yet To Complete";
                }
                string studentName =
                    _studentBusiness.GetAll()
                        .Where(x => x.StudentId == studentId)
                        .Select(x => x.StudentName)
                        .FirstOrDefault();
                var demo = new {semester = semester.SemesterName, cgpa = cgpa, studentName = studentName, totalGpa = totalGpa };
                result.Add(demo);
            }
            

           return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
