using FagTilmeldingApp.Codes;

// Iteration 4
string AngivSkole;
string AngivForløb;
string AngivLinje;
string AngivBeskrivelse;
ConsoleKeyInfo cki;

Console.Write("Angiv skole: ");
AngivSkole = Console.ReadLine();
Console.Write("Angiv hovedforløb: ");
AngivForløb = Console.ReadLine();
Console.Write("Angiv uddannelseslinje: ");
AngivLinje = Console.ReadLine();

Semester s = new(AngivSkole, AngivForløb);;

Console.WriteLine("\nØnsker du at angiv en kort beskrivelse af uddannelseslinje?:  ");
Console.WriteLine("1) Ja");
Console.WriteLine("2) Nej");
Console.Write("Vælg 1 eller 2: ");
cki = Console.ReadKey();

if(cki.Key == ConsoleKey.D1)
{
    Console.WriteLine("\nAngiv beskrivelse: ");
    AngivBeskrivelse = Console.ReadLine();
    s.SetUddannelsesLinje(AngivLinje, AngivBeskrivelse);
}
else
{
    s.SetUddannelsesLinje(AngivLinje);
}

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

int UserElevId = 0;
int UserCourseId = 0;

while (true)
{
    Console.Clear();
    Console.WriteLine("----------------------------------------------------------------");
    Console.WriteLine(s.SchoolName + ", " + s.Uddannelseslinje + ", " + s.SemesterNavn + " " + "fag timelding app.");
    Console.WriteLine(s.Uddannelsesbeskrivelse);
    Console.WriteLine("----------------------------------------------------------------");

    List<Enrollment> list = Elist.Where(a => a.CourseId == 1).ToList();
    Console.WriteLine("Elever i Grundlæggende programmering: " + list.Count());
    list = Elist.Where(a => a.CourseId == 2).ToList();
    Console.WriteLine("Elever i Database programmering: " + list.Count());
    list = Elist.Where(a => a.CourseId == 3).ToList();
    Console.WriteLine("Elever i Studieteknik: " + list.Count());
    Console.WriteLine();

    List<Student> students = ElevList.Where(a => a.ElevId == UserElevId).ToList();
    List<Course> courses = KurseList.Where(a => a.CourseId == UserCourseId).ToList();
    foreach (Student student in students)
    {
        Console.Write(student.ForNavn + " " + student.EfterNavn + " tilmeldt fag ");
    }
    foreach (Course course in courses)
    {
        Console.Write(course.CourseName);
    }
    Console.WriteLine("\n---------------------------------------------------------------- \n");

    while (UserElevId != null)
    {
        Console.WriteLine("\nElevID: ");
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
                Console.WriteLine("Elev findes ikke");
            }
        }
        catch
        {
            Console.WriteLine("Det er ikke et tal");
        }
    }

    while (UserCourseId != null)
    {
        Console.WriteLine("\nKurse ID: ");
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
                Console.WriteLine("Kurse findes ikke");
            }
        }
        catch
        {
            Console.WriteLine("Det er ikke et tal");
        }
    }

    List<Enrollment> tests = Elist.Where(a => a.ElevId == UserElevId && a.CourseId == UserCourseId).ToList();
    if(tests.Count == 0)
    { 
    Elist.Add(new Enrollment() { EnrollmentId = Elist.Count() + 1, ElevId = UserElevId, CourseId = UserCourseId });
    }
    else
    {
        Console.WriteLine("\nStudent already exist in that class - Try again!");
        UserElevId = 0;
        UserCourseId = 0;
        Console.ReadKey();
    }
}

