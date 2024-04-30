List<ISuperhero> superheroes = new List<ISuperhero>
{
    new Wonderwoman("Diana"),
    new Batman("Bruce Wayne"),
    new BlackWidow("Natasha Romanoff")
};

for (int i = 0; i < superheroes.Count; i++)
{
    for (int j = i + 1; j < superheroes.Count; j++)
    {
        ISuperhero attacker = superheroes[i];
        ISuperhero defender = superheroes[j];

        Console.WriteLine($"{attacker.Name} attacks {defender.Name}");
        bool doesAttackerWin = attacker.Fights(defender);

        if (doesAttackerWin)
        {
            Console.WriteLine($"{attacker.Name} wins!");
        }
        else
        {
            Console.WriteLine($"{defender.Name} wins!");
        }

        Console.WriteLine();

        await Task.Delay(1000);
    }
}
