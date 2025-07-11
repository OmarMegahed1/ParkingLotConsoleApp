namespace ParkingLotConsoleApp;

public class ParkingGarage
{
    private readonly List<ParkingFloor> _parkingFloors;

    public ParkingGarage(int floorCount, int spotsPerFloor)
    {
        _parkingFloors = Enumerable.Range(0, floorCount)
            .Select(_ => new ParkingFloor(spotsPerFloor))
            .ToList();
    }

    public bool ParkVehicle(Vehicle vehicle)
    {
        return _parkingFloors.Any(floor => floor.ParkVehicle(vehicle));
    }

    public bool RemoveVehicle(Vehicle vehicle)
    {
        var floor = _parkingFloors.FirstOrDefault(f => f.GetVehicleSpots(vehicle).HasValue);
        if (floor != null)
        {
            floor.RemoveVehicle(vehicle);
            return true;
        }
        return false;
    }
}
