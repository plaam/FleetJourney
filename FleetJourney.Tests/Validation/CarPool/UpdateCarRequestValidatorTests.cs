﻿using FleetJourney.Application.Contracts.Requests.CarPool;
using FleetJourney.Application.Validation.CarPool;
using FluentValidation.TestHelper;
using Xunit;

namespace FleetJourney.Tests.Validation.CarPool;

public sealed class UpdateCarRequestValidatorTests
{
    private readonly UpdateCarRequestValidator _validator;

    public UpdateCarRequestValidatorTests()
    {
        _validator = new UpdateCarRequestValidator();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public async Task SetLicensePlateNumber_WithInvalidLicensePlateNumber_ShouldReturnValidationError(string licensePlateNumber)
    {
        // Arrange
        var updateCarRequest = new UpdateCarRequest
        {
            LicensePlateNumber = licensePlateNumber,
            Brand = "Valid Brand",
            Model = "Valid Model",
            EndOfLifeMileage = 10000,
            MaintenanceInterval = 5000,
            CurrentMileage = 5000
        };

        // Act
        var result = await _validator.TestValidateAsync(updateCarRequest);

        // Assert
        result.ShouldHaveValidationErrorFor(request => request.LicensePlateNumber)
            .WithErrorMessage("License plate number is required.");
    }

    [Fact]
    public async Task SetLicensePlateNumber_WithInvalidFormat_ShouldReturnValidationError()
    {
        // Arrange
        var updateCarRequest = new UpdateCarRequest
        {
            LicensePlateNumber = "InvalidFormat",
            Brand = "Valid Brand",
            Model = "Valid Model",
            EndOfLifeMileage = 10000,
            MaintenanceInterval = 5000,
            CurrentMileage = 5000
        };

        // Act
        var result = await _validator.TestValidateAsync(updateCarRequest);

        // Assert
        result.ShouldHaveValidationErrorFor(request => request.LicensePlateNumber)
            .WithErrorMessage("Invalid license plate number. Format should be 123-AB-45.");
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public async Task SetBrand_WithInvalidBrand_ShouldReturnValidationError(string brand)
    {
        // Arrange
        var updateCarRequest = new UpdateCarRequest
        {
            LicensePlateNumber = "Valid License Plate Number",
            Brand = brand,
            Model = "Valid Model",
            EndOfLifeMileage = 10000,
            MaintenanceInterval = 5000,
            CurrentMileage = 5000
        };

        // Act
        var result = await _validator.TestValidateAsync(updateCarRequest);

        // Assert
        result.ShouldHaveValidationErrorFor(request => request.Brand)
            .WithErrorMessage("Brand is required.");
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public async Task SetModel_WithInvalidModel_ShouldReturnValidationError(string model)
    {
        // Arrange
        var updateCarRequest = new UpdateCarRequest
        {
            LicensePlateNumber = "Valid License Plate Number",
            Brand = "Valid Brand",
            Model = model,
            EndOfLifeMileage = 10000,
            MaintenanceInterval = 5000,
            CurrentMileage = 5000
        };

        // Act
        var result = await _validator.TestValidateAsync(updateCarRequest);

        // Assert
        result.ShouldHaveValidationErrorFor(request => request.Model)
            .WithErrorMessage("Model is required.");
    }

    [Theory]
    [InlineData(0)]
    public async Task SetEndOfLifeMileage_WithInvalidEndOfLifeMileage_ShouldReturnValidationError(uint endOfLifeMileage)
    {
        // Arrange
        var updateCarRequest = new UpdateCarRequest
        {
            LicensePlateNumber = "Valid License Plate Number",
            Brand = "Valid Brand",
            Model = "Valid Model",
            EndOfLifeMileage = endOfLifeMileage,
            MaintenanceInterval = 5000,
            CurrentMileage = 5000
        };

        // Act
        var result = await _validator.TestValidateAsync(updateCarRequest);

        // Assert
        result.ShouldHaveValidationErrorFor(request => request.EndOfLifeMileage)
            .WithErrorMessage("End of life mileage must be greater than zero.");
    }

    [Theory]
    [InlineData(0)]
    public async Task SetMaintenanceInterval_WithInvalidMaintenanceInterval_ShouldReturnValidationError(uint maintenanceInterval)
    {
        // Arrange
        var updateCarRequest = new UpdateCarRequest
        {
            LicensePlateNumber = "Valid License Plate Number",
            Brand = "Valid Brand",
            Model = "Valid Model",
            EndOfLifeMileage = 10000,
            MaintenanceInterval = maintenanceInterval,
            CurrentMileage = 5000
        };

        // Act
        var result = await _validator.TestValidateAsync(updateCarRequest);

        // Assert
        result.ShouldHaveValidationErrorFor(request => request.MaintenanceInterval)
            .WithErrorMessage("Maintenance interval must be greater than zero.");
    }

    [Theory]
    [InlineData(0)]
    public async Task SetCurrentMileage_WithInvalidCurrentMileage_ShouldReturnValidationError(uint currentMileage)
    {
        // Arrange
        var updateCarRequest = new UpdateCarRequest
        {
            LicensePlateNumber = "Valid License Plate Number",
            Brand = "Valid Brand",
            Model = "Valid Model",
            EndOfLifeMileage = 10000,
            MaintenanceInterval = 5000,
            CurrentMileage = currentMileage
        };

        // Act
        var result = await _validator.TestValidateAsync(updateCarRequest);

        // Assert
        result.ShouldHaveValidationErrorFor(request => request.CurrentMileage)
            .WithErrorMessage("Current mileage must be greater than zero.");
    }
}