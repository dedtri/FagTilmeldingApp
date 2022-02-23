using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FagTilmeldingApp.Codes.EntityFrameworkModels;

namespace FagTilmeldingApp.Codes
{
    internal class EntityFrameworkHandler
    {

        public TECContext DB
        {
            get
            { 
                using TECContext db = new TECContext();
                return db;
            }
        }

        public List<Teacher> GetTeacher()
        {
           using TECContext db = new TECContext();

           return db.Teachers.ToList();
        }

        public List<Student> GetStudent()
        {
            using TECContext db = new TECContext();

            return db.Students.ToList();
        }

        public List<Course> GetCourses()
        {
            using TECContext db = new TECContext();

            return db.Courses.ToList();
        }

        public List<Class> GetEnrollment()
        {
            using TECContext db = new TECContext();

            return db.Classes.ToList();
        }

        public void InsertEnrollment(int studentId, int courseId)
        {
            using TECContext db = new TECContext();

            Class enrollment = new() { StudentId = studentId, CourseId = courseId };
            //List<Class> enrollments = db.Classes.ToList();
            //enrollments.Add(enrollment);
            db.Add(enrollment);

            //Could put this in another method
            db.SaveChanges();
        }

        //public void DeleteEnrollment(string fornavn, string efternavn)
        //{
        //    using TECContext db = new TECContext();

        //    foreach (Class item in db.Classes.ToList())
        //    {
        //        if (fornavn == item.Student.FirstName && efternavn == item.Student.LastName)
        //        {
        //            db.Remove(item);
        //        }
        //    }

        //    db.SaveChanges();
        //}

        public void ClearEnrollment()
        {
            using TECContext db = new TECContext();

            foreach (Class item in db.Classes.ToList())

            db.Remove(item);

            db.SaveChanges();
        }
    }
}
