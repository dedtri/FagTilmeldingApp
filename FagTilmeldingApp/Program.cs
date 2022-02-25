global using FagTilmeldingApp.Codes;
using FagTilmeldingApp.Codes.EntityFrameworkModels;
// Iteration 6
string AngivSkole;
string AngivForløb;
string AngivLinje;
string AngivBeskrivelse;
ConsoleKeyInfo cki;

EntityFrameworkHandler eHandler = new();
List<Teacher> TeacherList = eHandler.GetTeacher();
List<Student> ElevList = eHandler.GetStudent();
List<Course> KurseList = eHandler.GetCourses();
List<Class> Elist = eHandler.GetEnrollment();

eHandler.ClearEnrollment();

Console.Write("Angiv skole: ");
AngivSkole = Console.ReadLine();
Console.Write("Angiv hovedforløb: ");
AngivForløb = Console.ReadLine();
Console.Write("Angiv uddannelseslinje: ");
AngivLinje = Console.ReadLine();

Semester s = new(AngivSkole, AngivForløb);

do
{
    Console.Clear();
    Console.WriteLine("Angiv skole: " + AngivSkole);
    Console.WriteLine("Angiv hovedforløb: " + AngivForløb);
    Console.WriteLine("Angiv uddannelseslinje: " + AngivLinje);
    Console.WriteLine("\nØnsker du at angiv en kort beskrivelse af uddannelseslinje?:  ");
    Console.WriteLine("1) Ja");
    Console.WriteLine("2) Nej");
    Console.Write("\nVælg 1 eller 2: ");
    cki = Console.ReadKey();
}
while (cki.Key != ConsoleKey.D1 && cki.Key != ConsoleKey.D2);

if (cki.Key == ConsoleKey.D1)
{
    Console.Write("\nAngiv beskrivelse: ");
    AngivBeskrivelse = Console.ReadLine();
    s.SetUddannelsesLinje(AngivLinje, AngivBeskrivelse);
}
else
{
    s.SetUddannelsesLinje(AngivLinje);
}

int UserElevId = 0;
int UserCourseId = 0;
bool mainflag = true;
string errormsg = null;
Student students = null;
Course courses = null;

while (mainflag)
{
    Console.Clear();

    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("----------------------------------------------------------------");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(s.SchoolName + ", " + s.UddannelsesLinje + ", " + s.SemesterNavn + " " + "fag timelding app.");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine(s.UddannelseslinjeBeskrivelse);
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("----------------------------------------------------------------");

    try
    {
        Elist = eHandler.GetEnrollment();
        List<Class> list3 = Elist.Where(a => a.CourseId == 2).ToList();
        if (list3.Count() > 3)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            throw new Exception("Der må max være 3 elever i Database programmering!");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }

    List<Class> list = Elist.Where(a => a.CourseId == 1).ToList();
    Console.WriteLine("\nElever i Grundlæggende programmering: " + list.Count());
    list = Elist.Where(a => a.CourseId == 2).ToList();
    Console.WriteLine("Elever i Database programmering: " + list.Count());
    list = Elist.Where(a => a.CourseId == 3).ToList();
    Console.WriteLine("Elever i Studieteknik: " + list.Count());
    Console.WriteLine();

    if (Elist != null)
    { 
    foreach (Class c in Elist)
    {
        students = ElevList.FirstOrDefault(a => a.StudentId == c.StudentId);
        courses = KurseList.FirstOrDefault(a => a.CourseId == c.CourseId);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(students.FirstName + " " +  students.LastName + " tilmeldt fag: " + courses.CourseName);
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

            List<Student> valid = ElevList.Where(a => a.StudentId == UserElevId).ToList();
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
    List<Class> valid2 = Elist.Where(a => a.StudentId == UserElevId && a.CourseId == UserCourseId).ToList();
    if(valid2.Count == 0)
    {
        eHandler.InsertEnrollment(UserElevId, UserCourseId);
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        errormsg = ("Student already exist in that class - Try again!");
    }
    }
}

