# Parking Lot Console App

A C# console application that simulates a parking garage management system with multi-floor parking, vehicle management, and time-based billing.

## Overview

This application demonstrates object-oriented programming principles by implementing a parking garage system that can handle different types of vehicles, track parking times, and calculate charges based on hourly rates.

## Features

- **Multi-floor parking garage** with configurable floors and spots per floor
- **Multiple vehicle types** with different parking space requirements
- **Time-based billing** system with hourly rates
- **Driver management** with payment tracking
- **Real-time parking** and removal operations

## Core Classes

#### `Vehicle` (Abstract Base Class)
- **Purpose**: Base class for all vehicle types
- **Properties**: 
  - `SpotSize`: Number of consecutive parking spots required
- **Implementation**: Abstract class that defines the common interface for all vehicles

#### Vehicle Types
- **`Car`**: Requires 1 parking spot
- **`Limo`**: Requires 2 consecutive parking spots  
- **`SemiTruck`**: Requires 3 consecutive parking spots

#### `Driver`
- **Purpose**: Represents a driver with their vehicle and payment information
- **Properties**:
  - `Id`: Unique driver identifier
  - `Vehicle`: Associated vehicle object
  - `PaymentDue`: Running total of parking charges
- **Methods**:
  - `Charge(decimal amount)`: Adds charges to the driver's payment due

#### `ParkingFloor`
- **Purpose**: Manages parking spots on a single floor
- **Key Features**:
  - Tracks occupied/available spots using an integer array
  - Maintains a mapping between vehicles and their spot ranges
  - Implements contiguous spot allocation for larger vehicles
- **Methods**:
  - `ParkVehicle(Vehicle vehicle)`: Attempts to park a vehicle
  - `RemoveVehicle(Vehicle vehicle)`: Removes a vehicle and frees spots
  - `GetParkingSpots()`: Returns current spot occupancy status
  - `GetVehicleSpots(Vehicle vehicle)`: Returns spot range for a specific vehicle

#### `ParkingGarage`
- **Purpose**: Manages multiple parking floors
- **Features**:
  - Contains a collection of `ParkingFloor` objects
  - Attempts to park vehicles across available floors
  - Handles vehicle removal across all floors
- **Methods**:
  - `ParkVehicle(Vehicle vehicle)`: Parks vehicle on any available floor
  - `RemoveVehicle(Vehicle vehicle)`: Removes vehicle from the garage

#### `ParkingSystem`
- **Purpose**: High-level parking management with billing
- **Features**:
  - Integrates parking garage with time tracking and billing
  - Tracks parking start times for each driver
  - Calculates charges based on hourly rates
- **Methods**:
  - `ParkVehicle(Driver driver)`: Parks a driver's vehicle and starts time tracking
  - `RemoveVehicle(Driver driver)`: Removes vehicle, calculates charges, and bills driver

## Usage Example

```csharp
// Create a parking garage with 3 floors and 2 spots per floor
var parkingGarage = new ParkingGarage(3, 2);

// Create parking system with $5/hour rate
var parkingSystem = new ParkingSystem(parkingGarage, 5);

// Create drivers with different vehicle types
var driver1 = new Driver(1, new Car());        // 1 spot
var driver2 = new Driver(2, new Limo());       // 2 spots
var driver3 = new Driver(3, new SemiTruck());  // 3 spots

// Park vehicles
Console.WriteLine(parkingSystem.ParkVehicle(driver1));  // True
Console.WriteLine(parkingSystem.ParkVehicle(driver2));  // True  
Console.WriteLine(parkingSystem.ParkVehicle(driver3));  // False (not enough space)

// Remove vehicles (automatically calculates and charges fees)
Console.WriteLine(parkingSystem.RemoveVehicle(driver1)); // True
Console.WriteLine(parkingSystem.RemoveVehicle(driver2)); // True
```

## Parking Logic

### Spot Allocation Algorithm
The parking system uses a sliding window algorithm to find consecutive available spots:

1. **Single Spot Vehicles (Cars)**: Can park in any available spot
2. **Multi-Spot Vehicles (Limos, Semi-Trucks)**: Requires consecutive available spots
3. **First-Available Strategy**: Parks vehicles on the first floor with sufficient space

### Billing System
- **Time Tracking**: Records parking start time when vehicle is parked
- **Hourly Billing**: Charges are calculated when vehicle is removed
- **Ceiling Function**: Partial hours are rounded up to full hours
- **Automatic Charging**: Fees are automatically added to driver's payment due

## Configuration

### Garage Configuration
- **Floor Count**: Configurable number of floors in the garage
- **Spots Per Floor**: Configurable number of spots per floor
- **Hourly Rate**: Configurable billing rate per hour

### Vehicle Sizes
- **Car**: 1 spot (can be modified in `Car` constructor)
- **Limo**: 2 spots (can be modified in `Limo` constructor)
- **Semi-Truck**: 3 spots (can be modified in `SemiTruck` constructor)

## Building and Running

```bash
# Clone the repository
git clone [repository-url]

# Navigate to project directory
cd ParkingLotConsoleApp

# Build the project
dotnet build

# Run the application
dotnet run
```
