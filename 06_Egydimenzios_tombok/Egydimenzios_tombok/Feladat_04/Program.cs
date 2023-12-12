using Custom.Library.ConsoleExtensions;
using Feladat_04;

const int NUMBER_OF_WORKERS = 5;

Worker[] workers = GetWorkers(NUMBER_OF_WORKERS);
Console.Clear();

Console.WriteLine("Dolgozók: ");
PrintWorkersOnConsole(workers);

Console.WriteLine("\n\nHozzájárulások: ");
PrintContributionToConsole();

static Worker[] GetWorkers(int count)
{
    Worker[] workers = new Worker[count];
    Worker worker;
    for (int i = 0; i < count; i++)
    {
        string name = ExtendedConsole.ReadString($"Kérem adja meg a {i + 1}. dolgozó nevét: ");
        worker = new Worker(name);
        workers[i] = worker;
    }

    return workers;
}

void PrintWorkersOnConsole(Worker[] workers)
{
    Console.WriteLine($"\t\t JAN\t FEB\t MÁR\t ÁPR\t MÁJ\t JÚN\t JÚl\t AUG\t SEP\t OKT\t NOV\t DEC");
    foreach (var worker in workers)
    {
        Console.WriteLine(worker);
    }
}

void PrintContributionToConsole()
{
    Console.WriteLine($"\t\tSZJA\t\tTB\t\tNYHJ");
    foreach (var worker in workers)
    {
        Console.WriteLine($"{worker.Name.PadRight(8)}\t{worker.IncomeTax:F2}\t{worker.MedicalContribution:F2}\t{worker.RetirementBase:F2}");
    }
}