using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class HockeyPlayer
{
    public string Name { get; set; }
    public int GoalCount { get; set; }

    public HockeyPlayer() { }

    public HockeyPlayer(string name, int goalCount)
    {
        Name = name;
        GoalCount = goalCount;
    }

    public override string ToString()
    {
        return $"{Name} - {GoalCount} gól";
    }
}


