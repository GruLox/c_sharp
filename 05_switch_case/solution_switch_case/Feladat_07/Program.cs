Lifter lifter1 = GetLifter();
Lifter lifter2 = GetLifter();

Console.WriteLine($"{lifter1.Name} erő státusza: {lifter1.StrengthTier()}");
Console.WriteLine($"{lifter2.Name} erő státusza: {lifter2.StrengthTier()}");

Lifter strongerLifter = lifter1.RelativeStrength > lifter2.RelativeStrength ? lifter1 : lifter2;

Console.WriteLine($"{strongerLifter.Name} az erősebb {strongerLifter.RelativeStrength}-szeres relatív erővel");

Lifter GetLifter()
{
    Lifter lifter = new Lifter();

    Console.Write("Enter the name of the lifter: ");
    lifter.Name = Console.ReadLine();

    Console.Write("Enter the age of the lifter: ");
    lifter.Age = int.Parse(Console.ReadLine());

    Console.Write("Enter the body weight of the lifter: ");
    lifter.BodyWeight = double.Parse(Console.ReadLine());

    Console.Write("Enter the bench press 1RM of the lifter: ");
    lifter.BenchPressMax = double.Parse(Console.ReadLine());

    return lifter;
}