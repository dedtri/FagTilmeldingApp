using FagTilmeldingApp.Codes;

// Iteration 1
string AngivSkole;
string AngivForløb;

Console.WriteLine("Angiv fag: ");
AngivSkole = Console.ReadLine();
Console.WriteLine("Angiv hovedforløb: ");
AngivForløb = Console.ReadLine();

Semester s = new(AngivSkole, AngivForløb);

Console.Clear();

Console.WriteLine(s.SchoolName + ", " +  s.SemesterNavn + " " + "fag timelding app.");
Console.ReadKey();