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
    public class DepartmentsController : Controller
    {
        private readonly IDepartmentBusiness _departmentBusiness;
        private readonly IStudentBusiness _studentBusiness;

        public DepartmentsController(IDepartmentBusiness departmentBusiness, IStudentBusiness studentBusiness)
        {
            _departmentBusiness = departmentBusiness;
            _studentBusiness = studentBusiness;
        }

        // GET: Departments
        public ActionResult Index()
        {
            return View(_departmentBusiness.GetAll());
        }

        // GET: Departments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = _departmentBusiness.GetById((int) id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // GET: Departments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Departments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DepartmentId,DeptName,DeptCode,DeptCredit,Adminstrator,StratDate,Building")] Department department)
        {
            if (ModelState.IsValid)
            {
                if (!_departmentBusiness.IsDeptNameExists(department.DeptName))
                {
                    if (!_departmentBusiness.IsDeptCodeExists(department.DeptCode))
                    {
                        _departmentBusiness.Add(department);
                        ViewBag.Message = "Department Created Successfully!";
                        // return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.Message = "Department Code Already Exists !";
                    }

                }
                else
                {
                    ViewBag.Message = "Department Name Already Exists !";
                }
            }

            return View(department);
        }

        

        // GET: Departments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = _departmentBusiness.GetById((int) id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // POST: Departments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DepartmentId,DeptName,DeptCode,DeptCredit,Adminstrator,StratDate,Building")] Department department)
        {
            if (ModelState.IsValid)
            {

                if (!_departmentBusiness.IsDeptNameExists(department.DeptName))
                {
                    if (!_departmentBusiness.IsDeptCodeExists(department.DeptCode))
                    {
                        _departmentBusiness.Update(department);
                       // return RedirectToAction("Index");
                        ViewBag.Message = "Department Updated Successfully!";
                        // return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.Message = "Department Code Already Exists !";
                    }

                }
                else
                {
                    ViewBag.Message = "Department Name Already Exists !";
                }
              
            }
            return View(department);
        }

        // GET: Departments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = _departmentBusiness.GetById((int) id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (_studentBusiness.GetAll().Any(x => x.DepartmentId == id) == false)
            {
                Department department = _departmentBusiness.GetById((int)id);
                _departmentBusiness.Delete(department);
                return RedirectToAction("Index");
            }
            else
            {
                TempData["message"] = "Can't Delele Running Department";
                return RedirectToAction("Delete");
            }
         }

        //public JsonResult IsDeptRunning(int deptId)
        //{
        //    var students = _studentBusiness.GetAll().Where(x => x.DepartmentId == deptId).Select(x =>x.StudentName).FirstOrDefault();
        //    return Json(students, JsonRequestBehavior.AllowGet);
        //}
    }
}
