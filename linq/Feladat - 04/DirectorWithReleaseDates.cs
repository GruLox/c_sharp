using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feladat___04;

public class DirectorWithReleaseDates
{
    public string Director { get; set; }
    public ICollection<DateTime> ReleaseDates { get; set; }

    public DirectorWithReleaseDates()
    {
        
    }

    public DirectorWithReleaseDates(string director, ICollection<DateTime> releaseDates)
    {
        Director = director;
        ReleaseDates = releaseDates;
    }

    
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{Director}");
        foreach (var date in ReleaseDates)
        {
            sb.AppendLine($"\t{date.ToString("yyyy-MM-dd")}, ");
        }
        return sb.ToString();
    }
}
