using _02_Inheritance;

var i7 = new Processor(
    numberOfCores: 16,
    frequency: 4.2,
    manufacturer: "Intel",
    model: "i7",
    type: "14700k"
);
Console.WriteLine(i7);

var aRMProcessor = new ARMProcessor();

//var hardware = new Hardware(); // Error: 'Hardware' is abstract; cannot be instantiated

Console.ReadKey();
