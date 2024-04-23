var geza = new Student
{
    Name = "Géza",
    //School = "BME" nem függ az osztály példánytól ezért az objektumban nem is állítható az értéke
};

var bela = new Student
{
    Name = "Béla",
    //School = "BME" nem függ az osztály példánytól ezért az objektumban nem is állítható az értéke
};

Student.School = "Vasvári Pál Szeged";

Console.WriteLine($"{geza.Name} a {Student.School} iskolába jár");
Console.WriteLine($"{bela.Name} a {Student.School} iskolába jár");


//var prof = new Professor() // nem lehet példányosítani mert static class
//{
//    Name = "Dr. Nagy József"
//};
Professor.Name = "Hapci Vidor";

Console.WriteLine($"{Professor.Name} tanít a {Professor.School} iskolában");
