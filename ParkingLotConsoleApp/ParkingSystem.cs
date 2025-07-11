namespace ParkingLotConsoleApp;

public class ParkingSystem
{
    private readonly ParkingGarage _parkingGarage;
    private readonly decimal _hourlyRate;
    private readonly Dictionary<int, DateTime> _timeParked;

    public ParkingSystem(ParkingGarage parkingGarage, decimal hourlyRate)
    {
        _parkingGarage = parkingGarage;
        _hourlyRate = hourlyRate;
        _timeParked = new Dictionary<int, DateTime>();
    }

    public bool ParkVehicle(Driver driver)
    {
        var currentTime = DateTime.Now;
        bool isParked = _parkingGarage.ParkVehicle(driver.Vehicle);

        if (isParked)
        {
            _timeParked[driver.Id] = currentTime;
        }

        return isParked;
    }

    public bool RemoveVehicle(Driver driver)
    {
        if (!_timeParked.TryGetValue(driver.Id, out var parkedTime))
        {
            return false;
        }

        var currentTime = DateTime.Now;
        var hoursParked = Math.Ceiling((currentTime - parkedTime).TotalHours);
        driver.Charge((decimal)hoursParked * _hourlyRate);

        _timeParked.Remove(driver.Id);
        return _parkingGarage.RemoveVehicle(driver.Vehicle);
    }
}
