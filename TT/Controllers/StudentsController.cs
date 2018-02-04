using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TT.Models;

namespace TT.Controllers
{
    public class StudentsController : Controller
    {
        private TTEntities db = new TTEntities();

        // GET: Students
        public ActionResult Index()
        {
            var students = db.Students.Include(s => s.Course);
            ViewBag.courses = db.Courses.ToList();
            return View(students.ToList());
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "CourseName");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Phone,Mobile_,Address,CourseId,UserName,Password,Approved")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(db.Courses, "Id", "CourseName", student.CourseId);
            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "CourseName", student.CourseId);
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Phone,Mobile_,Address,CourseId,UserName,Password,Approved")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "CourseName", student.CourseId);
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult changeCourse(string courseId, string itemId)
        {
            try
            {
                int ItemId = int.Parse(itemId);
                Student user = db.Students.Find(ItemId);
                user.CourseId = int.Parse(courseId);

                db.SaveChanges();

                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Approve(string isApproved, string Id)
        {
            try
            {
                int userId = int.Parse(Id);
                Student user = db.Students.Find(userId);
                user.Approved = bool.Parse(isApproved);
                db.SaveChanges();
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpPost]
        public ActionResult login(string username, string password) {
            
                Student user = db.Students.Where(x => x.UserName == username).FirstOrDefault();
                if (user == null)
                {
                    return Json (new { success = false}, JsonRequestBehavior.AllowGet);
                }
                else
                {
                if (password == user.Password && user.Approved == true)
                {
                    var res = new
                    {
                        firstname = user.FirstName,
                        lastname = user.LastName,
                        phone = user.Phone,
                        mobile = user.Mobile_,
                        address = user.Address,
                        username = user.UserName,
                        coursename = user.Course.CourseName
                    };
                    return Json(new { success = true ,user = res }, JsonRequestBehavior.AllowGet);
                }
                else
                    return Json(new { success = false }, JsonRequestBehavior.AllowGet);
                }

            
        }

        public ActionResult signUp(string firstname, string lastname, string phone, string mobile, string address, string username, string password)
        {
            try
            {

                Student user = new Student()
                {
                    FirstName = firstname,
                    LastName = lastname,
                    Phone = phone,
                    Mobile_ = mobile,
                    Address = address,
                    UserName = username,
                    Password = password
                };

                db.Students.Add(user);
                db.SaveChanges();

                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
