using FagTilmeldingApp.Codes;

// Iteration 2
string AngivSkole;
string AngivForløb;

Console.WriteLine("Angiv skole: ");
AngivSkole = Console.ReadLine();
Console.WriteLine("Angiv hovedforløb: ");
AngivForløb = Console.ReadLine();

Semester s = new(AngivSkole, AngivForløb);

Console.Clear();

Console.WriteLine("----------------------------------------------------------------");
Console.WriteLine(s.SchoolName + ", " +  s.SemesterNavn + " " + "fag timelding app.");
Console.WriteLine("----------------------------------------------------------------");

List<Teacher> TeacherList = new()
{
    new Teacher() {LærerId = 1, ForNavn = "Niels", EfterNavn = "Olesen"},
    new Teacher() {LærerId = 2, ForNavn = "Henrik", EfterNavn = "Poulsen" }
};

List<Student> ElevList = new()
{
    new Student() { ElevId = 1, ForNavn = "Martin", EfterNavn = "Jensen" },
    new Student() { ElevId = 2, ForNavn = "Patrik", EfterNavn = "Nielsen"},
    new Student() { ElevId = 3, ForNavn = "Susanne", EfterNavn = "Hansen" },
    new Student() { ElevId = 4, ForNavn = "Thomas", EfterNavn = "Olsen" }
};

List<Course> KurseList = new()
{
    new Course() { CourseId = 1, CourseName = "Grundlæggende Programmering", TeacherId = 1 },
    new Course() { CourseId = 2, CourseName = "Database Programmering", TeacherId = 1 },
    new Course() { CourseId = 3, CourseName = "Studieteknik", TeacherId = 1 },
    new Course() { CourseId = 4, CourseName = "Clientside Programmering", TeacherId = 2 }
};

List<Enrollment> Elist = new List<Enrollment>() { };

int UserElevId = 0;
int UserCourseId = 0;
string errormsg = null;
Student students;
Course courses;

while (true)
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("----------------------------------------------------------------");
    Console.WriteLine(s.SchoolName + ", " + s.SemesterNavn + " " + "fag timelding app.");
    Console.WriteLine("----------------------------------------------------------------");

    List<Enrollment> list = Elist.Where(a => a.CourseId == 1).ToList();
    Console.WriteLine("Elever i Grundlæggende programmering: " + list.Count());
    list = Elist.Where(a => a.CourseId == 2).ToList();
    Console.WriteLine("Elever i Database programmering: " + list.Count());
    list = Elist.Where(a => a.CourseId == 3).ToList();
    Console.WriteLine("Elever i Studieteknik: " + list.Count());
    Console.WriteLine();

    if (Elist != null)
    {
        foreach (Enrollment c in Elist)
        {
            students = ElevList.FirstOrDefault(a => a.ElevId == c.ElevId);
            courses = KurseList.FirstOrDefault(a => a.CourseId == c.CourseId);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(students.ForNavn + " " + students.EfterNavn + " tilmeldt fag: " + courses.CourseName);
            Console.ForegroundColor = ConsoleColor.White;
        }
        Console.WriteLine("----------------------------------------------------------------");
        Console.WriteLine();
    }

    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(errormsg);
    Console.ForegroundColor = ConsoleColor.White;
    errormsg = null;

    while (errormsg == null)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("\nElevID: ");
        try
        {
            UserElevId = Convert.ToInt32(Console.ReadLine());

            List<Student> valid = ElevList.Where(a => a.ElevId == UserElevId).ToList();
            if (valid.Count > 0)
            {
                break;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                errormsg = ("Elev findes ikke");
            }
        }
        catch
        {
            Console.ForegroundColor = ConsoleColor.Red;
            errormsg = ("Det er ikke et tal");
        }
    }

    while (errormsg == null)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("\nKurse ID: ");
        try
        {
            UserCourseId = Convert.ToInt32(Console.ReadLine());

            List<Course> valid3 = KurseList.Where(a => a.CourseId == UserCourseId).ToList();
            if (valid3.Count > 0)
            {
                break;
            }
            else if (valid3.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                errormsg = ("Kursen findes ikke");
            }
        }
        catch
        {
            Console.ForegroundColor = ConsoleColor.Red;
            errormsg = ("Det er ikke et tal");
        }
    }

    if (errormsg == null)
    {
        List<Enrollment> tests = Elist.Where(a => a.ElevId == UserElevId && a.CourseId == UserCourseId).ToList();
    if(tests.Count == 0)
    { 
    Elist.Add(new Enrollment() { EnrollmentId = Elist.Count() + 1, ElevId = UserElevId, CourseId = UserCourseId });
    }
    else
    {
      errormsg = ("\nStudent already exist in that class - Try again!");
    }
    }
}

