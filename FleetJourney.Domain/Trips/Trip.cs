﻿namespace FleetJourney.Domain.Trips;

public sealed class Trip
{
    public Guid Id { get; init; } = Guid.NewGuid();

    public required uint StartMileage { get; init; }
    
    public required uint EndMileage { get; init; }
    
    public required bool IsPrivateTrip { get; init; }
    
    public required Guid EmployeeId { get; init; }
    
    public required Guid CarId { get; init; }
}