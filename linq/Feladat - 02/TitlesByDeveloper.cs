using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feladat___02;

public class TitlesByDeveloper
{
    public string Developer { get; set; }
    public ICollection<string> Titles { get; set; }

    public TitlesByDeveloper()
    {
    }

    public TitlesByDeveloper(string developer, ICollection<string> titles)
    {
        Developer = developer;
        Titles = titles;
    }
}
