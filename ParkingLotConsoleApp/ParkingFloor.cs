namespace ParkingLotConsoleApp;

public class ParkingFloor
{
    private readonly int[] _spots;
    private readonly Dictionary<Vehicle, (int start, int end)> _vehicleMap;

    public ParkingFloor(int spotCount)
    {
        _spots = new int[spotCount];
        _vehicleMap = new Dictionary<Vehicle, (int, int)>();
    }

    public bool ParkVehicle(Vehicle vehicle)
    {
        int size = vehicle.SpotSize;
        int left = 0;
        int right = 0;

        while (right < _spots.Length)
        {
            if (_spots[right] != 0)
            {
                left = right + 1;
            }

            if (right - left + 1 == size)
            {
                // Found enough spots, park the vehicle
                for (int i = left; i <= right; i++)
                {
                    _spots[i] = 1;
                }
                _vehicleMap[vehicle] = (left, right);
                return true;
            }
            right++;
        }
        return false;
    }

    public void RemoveVehicle(Vehicle vehicle)
    {
        if (_vehicleMap.TryGetValue(vehicle, out var range))
        {
            for (int i = range.start; i <= range.end; i++)
            {
                _spots[i] = 0;
            }
            _vehicleMap.Remove(vehicle);
        }
    }

    public int[] GetParkingSpots()
    {
        return (int[])_spots.Clone();
    }

    public (int start, int end)? GetVehicleSpots(Vehicle vehicle)
    {
        return _vehicleMap.TryGetValue(vehicle, out var spots) ? spots : null;
    }
}
