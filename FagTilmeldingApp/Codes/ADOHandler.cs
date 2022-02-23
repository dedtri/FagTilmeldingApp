using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FagTilmeldingApp.Codes
{
    internal class ADOHandler
    {
        public string? ConnectionString 
        {
            get => "Data Source=MARTIN-PC;Initial Catalog=TEC;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }
        public List<Teacher> GetTeacher()
        {
            List<Teacher> teachers = new List<Teacher>();

            using SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();

            SqlCommand command = new SqlCommand
                (
                "SELECT "+
                "* "+
                "FROM Teacher", con
                );

            SqlDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                Teacher teacher = new Teacher() { LærerId = reader.GetInt32(0), ForNavn = reader.GetString(1), EfterNavn = reader.GetString(2) };
                teachers.Add(teacher);
            }

            //con.Close(); - Kun hvis man ikke har using
           
            return teachers;
        }

        public List<Student> GetStudent()
        {
            List<Student> students = new List<Student>();

            using SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();

            SqlCommand command = new SqlCommand
                (
                "SELECT " +
                "* " +
                "FROM Student", con
                );

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Student student = new Student() { ElevId = reader.GetInt32(0), ForNavn = reader.GetString(1), EfterNavn = reader.GetString(2) };
                students.Add(student);
            }

            //con.Close(); - Kun hvis man ikke har using

            return students;
        }

        public List<Course> GetCourses()
        {
            List<Course> courses = new List<Course>();

            using SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();

            SqlCommand command = new SqlCommand
                (
                "SELECT " +
                "* " +
                "FROM Course", con
                );

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Course course = new Course() { CourseId = reader.GetInt32(0), CourseName = reader.GetString(1)};
                courses.Add(course);
            }

            //con.Close(); - Kun hvis man ikke har using

            return courses;
        }

        public List<Enrollment> GetEnrollment()
        {
            List<Enrollment> enrollments = new List<Enrollment>();

            using SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();

            SqlCommand command = new SqlCommand
                (
                "SELECT " +
                "* " +
                "FROM Class", con
                );

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Enrollment enrollment = new Enrollment() { EnrollmentId = reader.GetInt32(0), ElevId = reader.GetInt32(1), CourseId = reader.GetInt32(2) };
                enrollments.Add(enrollment);
            }

            //con.Close(); - Kun hvis man ikke har using

            return enrollments;
        }

        public void InsertEnrollment(int StudentId, int CourseId)
        {
            List<Enrollment> enrollments = new List<Enrollment>();

            using SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();

            SqlCommand command = new SqlCommand($"INSERT INTO Class VALUES ({StudentId}, {CourseId})", con);

            command.ExecuteNonQuery();
        }

        public void DeleteEnrollment()
        {
            List<Enrollment> enrollments = new List<Enrollment>();

            using SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();

            SqlCommand command = new SqlCommand("DELETE FROM Class", con);

            command.ExecuteNonQuery();
        }

        //public void DeleteEnrollment(int elevid)
        //{
        //    List<Enrollment> enrollments = new List<Enrollment>();

        //    using SqlConnection con = new SqlConnection(ConnectionString);
        //    con.Open();

        //    SqlCommand command = new SqlCommand("DELETE FROM Class", con);

        //    command.ExecuteNonQuery();
        //}


    }

}
