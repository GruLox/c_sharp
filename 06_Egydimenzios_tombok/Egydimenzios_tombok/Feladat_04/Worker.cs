using System.Text;

namespace Feladat_04;

public class Worker
{
    private const int MONTHS = 12;

    public string Name;
    private int[] _salaries;

    public int SalarySum => _salaries.Sum(x => x);

    public double IncomeTax => Math.Round(SalarySum * 0.335);

    public double MedicalContribution => Math.Round(IncomeTax * 0.45);

    public double RetirementBase => Math.Round(IncomeTax * 0.55);



    public Worker()
    {
        _salaries = GetSalaries();
    }
    public Worker(string name): this() //this meghívja a paraméter nélküli konstruktort
    {
        Name = name;
    }

    private static int[] GetSalaries()
    {
        int[] salaries = new int[12];
        Random rnd = new Random();

        for (int i = 0; i < MONTHS; i++)
        {
            salaries[i] = rnd.Next(210000, 5000000);
        }
        return salaries;
    }

    public override string ToString()
    {
        //return $"{_name} éves fizetése {_salarySum} Ft volt,\n"+
        //    $"{_incomeTax} Ft jövedelemadót fizetett,\n"+
        //    $"ebből {_medicalContribution} Ft volt az egészségügyi hozzájárulás \n"+
        //    $"és {_retirementBase} Ft volt a nyugdíjalap\n";

        StringBuilder builder = new();

        builder.Append(Name.PadLeft(8));
        builder.Append('\t');

        foreach (var salary in _salaries)
        {
            builder.Append(' ');
            builder.Append(salary.ToString().PadRight(7));
        }
        return builder.ToString();
    }


}
