using _03_Abstraction;

Console.WriteLine("Car drive uses his horn!");
var car = new Car();
car.Horn();
SignalVehicleError(car);

await Task.Delay(1000);

Console.WriteLine("Truck driver uses his horn!");
var truck = new Truck();
truck.Horn();
SignalVehicleError(truck);

void SignalVehicleError(Vehicle vehicle)
{
    vehicle.Error();
}

