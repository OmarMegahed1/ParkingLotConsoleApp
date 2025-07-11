namespace ParkingLotConsoleApp;

public class Program
{
    public static void Main()
    {
        var parkingGarage = new ParkingGarage(3, 2);
        var parkingSystem = new ParkingSystem(parkingGarage, 5);

        var driver1 = new Driver(1, new Car());
        var driver2 = new Driver(2, new Limo());
        var driver3 = new Driver(3, new SemiTruck());

        Console.WriteLine(parkingSystem.ParkVehicle(driver1));      // True
        Console.WriteLine(parkingSystem.ParkVehicle(driver2));      // True
        Console.WriteLine(parkingSystem.ParkVehicle(driver3));      // False

        Console.WriteLine(parkingSystem.RemoveVehicle(driver1));    // True
        Console.WriteLine(parkingSystem.RemoveVehicle(driver2));    // True
        Console.WriteLine(parkingSystem.RemoveVehicle(driver3));    // False
    }
}
