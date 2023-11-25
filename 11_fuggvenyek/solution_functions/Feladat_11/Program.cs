using Feladat_11;
using IOLibrary;

List<Worker> workers = GetWorkers(5);

foreach (Worker worker in workers)
{
    Console.WriteLine(worker);
}

List<Worker> GetWorkers(int count)
{
    List<Worker> workers = new List<Worker>();
    for (int i = 0; i < count; i++)
    {
        string name = ExtendedConsole.ReadString($"Kérem adja meg a {i}. dolgozó nevét: ");
        int hoursWorked = ExtendedConsole.ReadInteger($"Kérem adja meg a {i}. dolgozó ledolgozott óráinak számát: ", int.MaxValue, 0);
        workers.Add(new Worker(name, hoursWorked));
    }
    return workers;
}