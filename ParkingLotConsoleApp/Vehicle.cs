namespace ParkingLotConsoleApp;

public abstract class Vehicle
{
    public int SpotSize { get; }

    protected Vehicle(int spotSize)
    {
        SpotSize = spotSize;
    }
}
