using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feladat___04;

public class RatingCount
{
    public int Rating { get; set; }
    public int Count { get; set; }

    public RatingCount()
    {
        
    }
    public RatingCount(int rating, int count)
    {
        Rating = rating;
        Count = count;
    }

    public override string ToString()
    {
        return $"{Rating} - {Count}";
    }
}
