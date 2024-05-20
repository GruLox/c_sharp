

public class Janitor
{
    public static void Maintenance(string path)
    {
        var condominium = new Condominium(10, 10);
        try
        {
            var lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {
                ProcessLine(line, condominium);
            }
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine("File not found: " + e.Message);
        }
        catch (IOException e)
        {
            Console.WriteLine("IO error: " + e.Message);
        }
    }

    private static void ProcessLine(string line, Condominium condominium)
    {
        var parts = line.Split(' ');
        switch (parts[0])
        {
            case "Alberlet":
                var flat = CreateRentedApartment(parts);
                condominium.AddFlat(flat);
                break;
            case "CsaladiApartman":
                var familyFlat = CreateFamilyApartment(parts);
                condominium.AddFlat(familyFlat);
                break;
            case "Garazs":
                var garage = CreateGarage(parts);
                condominium.AddGarage(garage);
                break;
        }
    }

    private static RentedApartment CreateRentedApartment(string[] parts)
    {
        return new RentedApartment(
            double.Parse(parts[1]),
            int.Parse(parts[2]),
            int.Parse(parts[3]),
            double.Parse(parts[4])
        );
    }

    private static FamilyApartment CreateFamilyApartment(string[] parts)
    {
        return new FamilyApartment(
            double.Parse(parts[1]),
            int.Parse(parts[2]),
            int.Parse(parts[3]),
            double.Parse(parts[4])
        );
    }

    private static Garage CreateGarage(string[] parts)
    {
        return new Garage(
            double.Parse(parts[1]),
            double.Parse(parts[2]),
            parts[3] == "futott"
        );
    }
}

