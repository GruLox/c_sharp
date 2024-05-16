public class Comic
{
    private static List<ISuperhero> _superheroes = new List<ISuperhero>();
    public static void Characters(string path)
    {
        try
        {
            using StreamReader sr = new StreamReader(path);
            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine().Split(' ');
                if (line[0] == "Batman")
                {
                    var batman = new Batman();
                    for (int i = 0; i < int.Parse(line[1]); i++)
                    {
                        batman.MakeGadget();
                    }
                    _superheroes.Add(batman);
                }
                else if (line[0] == "IronMan")
                {
                    var ironMan = new IronMan();
                    for (int i = 0; i < int.Parse(line[1]); i++)
                    {
                        ironMan.MakeGadget();
                    }
                    _superheroes.Add(ironMan);
                }
            }
        }
        catch (IOException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public static void Superheroes()
    {
        foreach (var superhero in _superheroes)
        {
            Console.WriteLine(superhero);
        }
    }
}
