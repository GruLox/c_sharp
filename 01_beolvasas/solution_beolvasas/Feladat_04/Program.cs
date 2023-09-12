Console.Write("Please type in your name: ");
string name = Console.ReadLine();

Console.Write("Please presson a key on your keyboard: ");
char key = Console.ReadKey().KeyChar;

Console.WriteLine();

Console.WriteLine($"{name} ön a/az {key} billentyűt nyomta meg");

Console.ReadKey();