using System;
using Microsoft.AspNetCore.Mvc;
using StudentRecordManagementSystem.Models;

namespace StudentRecordManagementSystem.Controllers
{
    public class StudentController : Controller
    {
        StudentDataAccessLayer studentDataAccessLayer = null;
        bool IsStaticData = true; // Set to true for static data, false for database access
        public StudentController()
        {
            studentDataAccessLayer = new StudentDataAccessLayer();
        }

        // GET: Student
        public ActionResult Index()
        {
            var students = IsStaticData
                ? studentDataAccessLayer.GetAllStudentStatic()
                : studentDataAccessLayer.GetAllStudent();
            return View(students);
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            var student = IsStaticData
                ? studentDataAccessLayer.GetStudentDataStatic(id)
                : studentDataAccessLayer.GetStudentData(id);
            return View(student);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
            try
            {
                // TODO: Add insert logic here
                if (IsStaticData)
                {
                    studentDataAccessLayer.AddStudentStatic(student);
                }
                else
                {
                    studentDataAccessLayer.AddStudent(student);
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            var student = IsStaticData
                ? studentDataAccessLayer.GetStudentDataStatic(id)
                : studentDataAccessLayer.GetStudentData(id);
            return View(student);
        }

        // POST: Student/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student student)
        {
            try
            {
                // TODO: Add update logic here

                if (IsStaticData)
                {
                    studentDataAccessLayer.UpdateStudentStatic(student);
                }
                else
                {
                    studentDataAccessLayer.UpdateStudent(student);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            var students = IsStaticData
               ? studentDataAccessLayer.GetStudentDataStatic(id)
               : studentDataAccessLayer.GetStudentData(id);
            return View(students);
        }

        // POST: Student/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Student student)
        {
            try
            {
                if (IsStaticData)
                {
                    studentDataAccessLayer.DeleteStudentStatic(student.Id);
                }
                else
                {
                    studentDataAccessLayer.DeleteStudent(student.Id);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}