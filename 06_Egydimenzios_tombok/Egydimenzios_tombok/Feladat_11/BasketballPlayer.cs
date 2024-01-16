using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feladat_11;

public class BasketballPlayer
{
    public string Name { get; set; }
    public int Points { get; set; }

    public BasketballPlayer(string name, int points)
    {
        Name = name;
        Points = points;
    }

    public override string ToString()
    {
        return $"{Name} - {Points} pont";
    }
}
