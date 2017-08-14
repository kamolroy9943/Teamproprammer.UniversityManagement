using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TeamProgrammer.UniversityManagement.Core.Business_Interface;
using TeamProgrammer.UniversityManagement.Core.Entities;
using TeamProgrammer.UniversityManagement.DataRepository.Context;

namespace TeamProgrammer.UniversityManagement.Web.Controllers.University
{
    [Authorize(Roles = "Admin")]
    public class CoursesController : Controller
    {
        private readonly ICourseBusiness _courseBusiness;
        private readonly IDepartmentBusiness _departmentBusiness;
        private readonly ISemesterBusiness _semesterBusiness;
        private readonly IStudentResultBusiness _studentResultBusiness;

        public CoursesController(ICourseBusiness courseBusiness, IDepartmentBusiness departmentBusiness, ISemesterBusiness semesterBusiness, IStudentResultBusiness studentResultBusiness)
        {
            _courseBusiness = courseBusiness;
            _departmentBusiness = departmentBusiness;
            _semesterBusiness = semesterBusiness;
            _studentResultBusiness = studentResultBusiness;
        }

        // GET: Courses
        public ActionResult Index()
        {
           return View(_courseBusiness.GetAll());
        }

        // GET: Courses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = _courseBusiness.GetById((int)id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // GET: Courses/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(_departmentBusiness.GetAll(), "DepartmentId", "DeptName");
            ViewBag.SemesterId = new SelectList(_semesterBusiness.GetAll(), "SemesterId", "SemesterName");
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseId,CourseName,CourseCode,Credit,Discription,DepartmentId,SemesterId")] Course course)
        {
            if (ModelState.IsValid)
            {
                if (!_courseBusiness.IsCourseNameEnrolled(course.CourseName, course.DepartmentId))
                {
                    if (!_courseBusiness.IsCourseCodeEnrolled(course.CourseCode, course.DepartmentId))
                    {
                        _courseBusiness.Add(course);
                        // return RedirectToAction("Index");
                        ViewBag.Message = "Course Created Successfully!";
                    }
                    else
                    {
                        ViewBag.Message = "Course Already Exists In This Department!";
                    }
                }
                else
                {
                    ViewBag.Message = "Course Already Exists In This Department!";
                }
            }
            ViewBag.DepartmentId = new SelectList(_departmentBusiness.GetAll(), "DepartmentId", "DeptName");
            ViewBag.SemesterId = new SelectList(_semesterBusiness.GetAll(), "SemesterId", "SemesterName");
            return View(course);
        }



        // GET: Courses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = _courseBusiness.GetById((int)id);
            if (course == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(_departmentBusiness.GetAll(), "DepartmentId", "DeptName",course.DepartmentId);
            ViewBag.SemesterId = new SelectList(_semesterBusiness.GetAll(), "SemesterId", "SemesterName",course.SemesterId);

            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseId,CourseName,CourseCode,Credit,Discription,DepartmentId,SemesterId")] Course course)
        {
            if (ModelState.IsValid)
            {

                _courseBusiness.Update(course);
                return RedirectToAction("Index");

            }
            ViewBag.DepartmentId = new SelectList(_departmentBusiness.GetAll(), "DepartmentId", "DeptName");
            ViewBag.SemesterId = new SelectList(_semesterBusiness.GetAll(), "SemesterId", "SemesterName");

            return View(course);
        }

        // GET: Courses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = _courseBusiness.GetById((int)id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (_studentResultBusiness.GetAll().Any(x => x.CourseId == id) != true)
            {
                Course course = _courseBusiness.GetById((int)id);
                _courseBusiness.Delete(course);
                return RedirectToAction("Index");
            }
            else
            {
                // ViewBag.Message = "Result has assigned in this course";
                TempData["message"] = "Result has assigned in this course";
                return RedirectToAction("Delete");
            }
            //return View();
        }

        public JsonResult GetCourseNameByCourseId(int courseId)
        {
            return
                Json(
                    _courseBusiness.GetAll()
                        .Where(x => x.CourseId == courseId)
                        .Select(x => x.CourseName)
                        .FirstOrDefault(), JsonRequestBehavior.AllowGet);
        }
    }
}
