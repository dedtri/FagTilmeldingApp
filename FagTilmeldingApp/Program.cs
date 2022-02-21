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
    new Course() { CourseId = 3, CourseName = "Studieteknik", TeacherId = 1 }
};

Enrollment E1 = new Enrollment();
List<Enrollment> Elist = new List<Enrollment>() { };

Console.Clear();
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

while (true)
{
    Console.Clear();
    Console.WriteLine("----------------------------------------------------------------");
    Console.WriteLine(s.SchoolName + ", " + s.SemesterNavn + " " + "fag timelding app.");
    Console.WriteLine("----------------------------------------------------------------");

    list = Elist.Where(a => a.CourseId == 1).ToList();
    Console.WriteLine("Elever i Grundlæggende programmering: " + list.Count());
    list = Elist.Where(a => a.CourseId == 2).ToList();
    Console.WriteLine("Elever i Database programmering: " + list.Count());
    list = Elist.Where(a => a.CourseId == 3).ToList();
    Console.WriteLine("Elever i Studieteknik: " + list.Count());
    Console.WriteLine();

    int UserElevId = 0;
    int UserCourseId = 0;

    while (UserElevId != null)
    {
        Console.WriteLine("ElevID: ");
        try
        {
            UserElevId = Convert.ToInt32(Console.ReadLine());

            if (UserElevId <= 4 && UserElevId != 0)
            {
                E1.ElevId = Convert.ToInt32(UserElevId);
                break;
            }
            else
            {
                Console.WriteLine("ElevID findes ikke");
            }
        }
        catch
        {
            Console.WriteLine("Det er ikke et tal");
        }
    }

    while (UserCourseId != null)
    {
        Console.WriteLine("CourseID: ");
        try
        {
            UserCourseId = Convert.ToInt32(Console.ReadLine());

            if (UserCourseId == 1 || UserCourseId == 2 || UserCourseId == 3)
            {
                E1.CourseId = Convert.ToInt32(UserCourseId);
                break;
            }
            else
            {
                Console.WriteLine("ElevID findes ikke");
            }
        }
        catch
        {
            Console.WriteLine("Det er ikke et tal");
        }
    }
    Elist.Add(new Enrollment() { EnrollmentId = Elist.Count() + 1, ElevId = UserElevId, CourseId = UserCourseId });
    
}

