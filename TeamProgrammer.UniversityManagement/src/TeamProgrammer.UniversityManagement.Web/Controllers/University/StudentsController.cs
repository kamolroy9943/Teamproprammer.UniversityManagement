using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using TeamProgrammer.UniversityManagement.Core.Business_Interface;
using TeamProgrammer.UniversityManagement.Core.Entities;
using TeamProgrammer.UniversityManagement.DataRepository.Context;

namespace TeamProgrammer.UniversityManagement.Web.Controllers.University
{
    [Authorize(Roles = "Admin")]
    public class StudentsController : Controller
    {
        private readonly IStudentBusiness _studentBusiness;
        private readonly IDepartmentBusiness _departmentBusiness;
        private readonly ISemesterBusiness _semesterBusiness;
        private readonly ICourseBusiness _courseBusiness;
        private readonly IStudentResultBusiness _studentResultBusiness;
        private readonly ISeassonBusiness _seassonBusiness;

        public StudentsController(IStudentBusiness studentBusiness, IDepartmentBusiness departmentBusiness, ISemesterBusiness semesterBusiness, ICourseBusiness courseBusiness, IStudentResultBusiness studentResultBusiness, ISeassonBusiness seassonBusiness)
        {
            _studentBusiness = studentBusiness;
            _departmentBusiness = departmentBusiness;
            _semesterBusiness = semesterBusiness;
            _courseBusiness = courseBusiness;
            _studentResultBusiness = studentResultBusiness;
            _seassonBusiness = seassonBusiness;
        }

        // GET: Students
        public ActionResult Index()
        {
          return View();
        }

        public JsonResult GetAllStudents(string draw, int? start, int? length)
        {
            int initial = start ?? 0;
            int totalPage = length ?? 0;
            var totalRecords = _studentBusiness.GetAll().Count();
            var studentList = _studentBusiness.GetAll().OrderBy(c => c.StudentName).Skip(initial).Take(totalPage);
            var students = studentList.Select(c => new
            {

                StudentId = c.StudentId,
                StudentName = c.StudentName,
                Registration = c.Registration,
                Email = c.Email,
                Date = c.Date,
                Address = c.Address,
                ContactNo = c.ContactNo,
                DeptName = c.Department.DeptName,
                Semester = c.Semester.SemesterName,
                Seasson=c.Seasson.SeassonName
            });
            var jsonData =
                new { draw = draw, recordsTotal = totalRecords, recordsFiltered = totalRecords, data = students };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = _studentBusiness.GetById((int)id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(_departmentBusiness.GetAll(), "DepartmentId", "DeptName");
            ViewBag.SemesterId = new SelectList(_semesterBusiness.GetAll(), "SemesterId", "SemesterName");
            ViewBag.SeassonId = new SelectList(_seassonBusiness.GetAll(), "SeassonId", "SeassonName");

            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include ="StudentId,StudentName,Registration,Email,Date,SeassonId,Address,ContactNo,DepartmentId,SemesterId")] Student student)
        {
            if (string.IsNullOrEmpty(student.Registration))
            {
                string seasson =
                    _seassonBusiness.GetAll()
                        .Where(x => x.SeassonId == student.SeassonId)
                        .Select(x => x.SeassonName)
                        .FirstOrDefault();

                student.Registration = _studentBusiness.GetRegistrationNo(student.DepartmentId, seasson);
            }
            if (ModelState.IsValid)
            {
                _studentBusiness.Add(student);
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentId = new SelectList(_departmentBusiness.GetAll(), "DepartmentId", "DeptName");
            ViewBag.SemesterId = new SelectList(_semesterBusiness.GetAll(), "SemesterId", "SemesterName");
            ViewBag.SeassonId = new SelectList(_seassonBusiness.GetAll(), "SeassonId", "SeassonName");
            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = _studentBusiness.GetById((int)id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(_departmentBusiness.GetAll(), "DepartmentId", "DeptName",
                student.DepartmentId);
            ViewBag.SemesterId = new SelectList(_semesterBusiness.GetAll(), "SemesterId", "SemesterName",
                student.SemesterId);
            ViewBag.SeassonId = new SelectList(_seassonBusiness.GetAll(), "SeassonId", "SeassonName",
                student.SeassonId);
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include ="StudentId,StudentName,Registration,Email,Date,SeassonId,Address,ContactNo,DepartmentId,SemesterId")] Student student)
        {
            if (ModelState.IsValid)
            {
                _studentBusiness.Update(student);
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(_departmentBusiness.GetAll(), "DepartmentId", "DeptName",
                student.DepartmentId);
            ViewBag.SemesterId = new SelectList(_semesterBusiness.GetAll(), "SemesterId", "SemesterName",
                student.SemesterId);
            ViewBag.SeassonId = new SelectList(_seassonBusiness.GetAll(), "SeassonId", "SeassonName",
               student.SeassonId);
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = _studentBusiness.GetById((int)id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = id;
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (_studentResultBusiness.GetAll().Any(x => x.StudentId == id) == false)
            {
                Student student = _studentBusiness.GetById((int)id);
                _studentBusiness.Delete(student);
                return RedirectToAction("Index");
            }
            else
            {
                TempData["message"] = "Delete The Student Result First";
                return RedirectToAction("Delete");
            }
        }

        public ActionResult ShowStudentCourses()
        {
            ViewBag.StudentId = new SelectList(_studentBusiness.GetAll(), "StudentId", "Registration");
            ViewBag.DepartmentId = new SelectList(_departmentBusiness.GetAll(), "DepartmentId", "DeptName");
            return View();
        }

        public JsonResult GetCourseByStudentId(int studentId)
        {
            int deptId = _studentBusiness.GetAll().Where(x => x.StudentId == studentId).Select(x => x.DepartmentId).FirstOrDefault();
            int semesterId = _studentBusiness.GetAll().Where(x => x.StudentId == studentId).Select(x => x.SemesterId).FirstOrDefault();
            string studentName = _studentBusiness.GetAll().Where(x => x.StudentId == studentId).Select(x => x.StudentName).FirstOrDefault();
            var courseList = _courseBusiness.GetAll()
                .Where(x => x.DepartmentId == deptId && x.SemesterId == semesterId)
                .Select(x => new
                {
                    courseId = x.CourseId,
                    courseName = x.CourseName,
                    courseCode = x.CourseCode,
                    description = x.Discription,
                    credit = x.Credit,
                    StudentName = studentName
                }).ToList();
            return Json(courseList, JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        public JsonResult GetSemesters()
        {
            var semesters = _semesterBusiness.GetAll();
            var sem = semesters.Select(x => new
            {
                SemesterId = x.SemesterId,
                SemesterName = x.SemesterName
            });
            return Json(sem, JsonRequestBehavior.AllowGet);

        }

        [AllowAnonymous]
        public JsonResult GetSessions()
        {
            var sessions = _seassonBusiness.GetAll().Select(x => new
            {
                sessionId = x.SeassonId,
                sessionName = x.SeassonName
            });
            return Json(sessions, JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        public JsonResult GetStudentBySemesterIdSessionIdAndDeptId(int deptId, int semesterId, int sessionId)
        {
             
            var students = _studentBusiness.GetAll();
            var results = students.Where(x => x.DepartmentId == deptId && x.SemesterId == semesterId && x.SeassonId==sessionId).Select(x => new
            {
                studentId = x.StudentId,
                registration = x.Registration
            });
          
            return Json(results, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetStudentBySemesterAndDeptId(int deptId, int semesterId,int sessionId)
        {
            int totalCourse = _courseBusiness.GetAll().Count(x => x.DepartmentId == deptId && x.SemesterId == semesterId);
            var students = _studentBusiness.GetAll();
            var results = students.Where(x => x.DepartmentId == deptId && x.SemesterId == semesterId && x.SeassonId==sessionId ).Select(x => new
            {
                studentId = x.StudentId,
                registration = x.Registration
            });
            List<dynamic> studentList = (from result in results let studentInfo = _studentResultBusiness.GetAll().Count(x => x.StudentId == result.studentId) where studentInfo < totalCourse select result).Cast<dynamic>().ToList();
            return Json(studentList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetStudentsBySessionAndDeptid(int deptId, int sessionId)
        {
            var students = _studentBusiness.GetAll();
            var results = students.Where(x => x.DepartmentId == deptId && x.SeassonId == sessionId).Select(x => new
            {
                studentId = x.StudentId,
                registration = x.Registration
            });

            return Json(results, JsonRequestBehavior.AllowGet);
        }





    }
}
