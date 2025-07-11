namespace ParkingLotConsoleApp;

public class Driver
{
    public int Id { get; }
    public Vehicle Vehicle { get; }
    public decimal PaymentDue { get; private set; }

    public Driver(int id, Vehicle vehicle)
    {
        Id = id;
        Vehicle = vehicle;
        PaymentDue = 0;
    }

    public void Charge(decimal amount)
    {
        PaymentDue += amount;
    }
}

