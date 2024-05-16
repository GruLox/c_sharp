public class RoadWay
{
    private static List<Vehicle> _vehicles = [];

    public static void VehiclesComeThrough(string path)
    {
        var lines = File.ReadAllLines(path);
        foreach (var line in lines)
        {
            var parts = line.Split(';');
            if (parts[0] == "robogo")
            {
                _vehicles.Add(new Scooter(parts[1], int.Parse(parts[2]), int.Parse(parts[3])));
            }
            else if (parts[0] == "audi")
            {
                _vehicles.Add(new AudiS8(parts[1], int.Parse(parts[2]), bool.Parse(parts[3])));
            }
        }
    }

    public static void LogFinedVehicles()
    {
        using StreamWriter writer = new("buntetes.txt");

        foreach (Vehicle vehicle in _vehicles)
        {
            writer.WriteLine(vehicle.ToString());
            if (vehicle is AudiS8 audi)
            {
                writer.WriteLine($"Gyorshajtott: {audi.IsSpeeding(90)}");
            }
            else if (vehicle is Scooter scooter)
            {
                writer.WriteLine($"Haladhat: {scooter.CanPassHere(90)}");
            }
        }

    }
}

