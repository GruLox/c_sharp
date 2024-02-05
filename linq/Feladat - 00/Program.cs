using Feladat___00;

List<Student> students = new List<Student>
{
    new Student("Hetfo Henrik", 10, 154),
    new Student("Kedd Kinga", 13, 250),
    new Student("Szerda Szilard", 9, 98),
    new Student("Csutortok Csongor", 11, 198),
    new Student("Péntek Petra", 13, 245),
    new Student("Szombat Szimonetta", 10, 152),
    new Student("Vasárnap Virág", 13, 221),
};

// legnagyobb pontszam
int maxPoints = students.Max(s => s.Points);

// ki a legtobb pontszamot elert tanulo
Student bestStudent = students.MaxBy(s => s.Points)!;

// legkisebb pontszam
int minPoints = students.Min(s => s.Points);

// ki a legkevesebb pontszamot elert tanulo
Student worstStudent = students.MinBy(s => s.Points)!;

// keresse ki a diakok neveit
IEnumerable<string> names = students.Select(s => s.Name);

// azon diakok nevei akik pontszama meghaladja a 200 pontot
IEnumerable<string> namesWithMoreThan200Points = students.Where(s => s.Points > 200)
                                                         .Select(s => s.Name);

// keressuk ki a diakok neveit ABC szerint novekvo sorrendben
IEnumerable<string> namesOrdered = students.OrderBy(s => s.Name)
                                            .Select(s => s.Name);

// keressuk ki a diakok neveit ABC szerint novekvo sorrendben
// majd pontok alapján csokkeno sorrendben
IEnumerable<string> namesOrderedByNamesThenPoints = students.OrderBy(s => s.Name)
                                                   .ThenByDescending(s => s.Points)
                                                   .Select(s => s.Name);

// rendezzuk osztalyok alapjan csokkeno sorrendbe
// pontok alapjan csokkeno sorrendbe a diakok neveit
IEnumerable<string> namesOrderedByGradeThenPoints = students.OrderByDescending(s => s.Grade)
                                                   .ThenByDescending(s => s.Points)
                                                   .Select(s => s.Name);

//evfolyamonkent elert pontaszamok, evfolyam szerint csokkeno sorrnedben
IEnumerable<GradeWithPoints> gradeWithPoints = students.GroupBy(x => x.Grade)
                                                .Select(x => new GradeWithPoints
                                                {
                                                    Grade = x.Key,
                                                    Points = x.Sum(x => x.Points)
                                                })
                                                .OrderByDescending(x => x.Grade);

// milyen pontszamokat kaptak egyes evfolyamok
// minden pontszam csak 1x fordulhat elo az eredmenyben
IEnumerable<int> distinctedPoints = students.Select(x => x.Points)
                                      .Distinct();
// maskepp
IEnumerable<int> distinctedPoints2 = students.DistinctBy(x => x.Points)
                                      .Select(x => x.Points);     


