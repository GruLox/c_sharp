using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feladat___03;

public class MotorcycleNameAndReleaseYear
{
    public string Brand { get; set; }
    public int ReleaseYear { get; set; }

    public MotorcycleNameAndReleaseYear(string brand, int releaseYear)
    {
        Brand = brand;
        ReleaseYear = releaseYear;
    }

    public override string ToString()
    {
        return $"{Brand} - {ReleaseYear}";
    }
}
