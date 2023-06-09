﻿namespace FleetJourney.Application.Helpers;

public static class ApiEndpoints
{
    private const string ApiBase = "/api";
    
    public static class Employees
    {
        private const string Base = $"{ApiBase}/employees";
        
        public const string Create = Base;
        public const string GetAll = Base;
        public const string Get = $"{Base}/{{id:guid}}";
        public const string GetByEmail = $"{Base}/{{email}}";
        public const string Update = $"{Base}/{{id:guid}}";
        public const string Delete = $"{Base}/{{id:guid}}";
    }
    
    public static class CarPool
    {
        private const string Base = $"{ApiBase}/cars";
        
        public const string Create = Base;
        public const string GetAll = Base;
        public const string Get = $"{Base}/{{id:guid}}";
        public const string Update = $"{Base}/{{id:guid}}";
        public const string Delete = $"{Base}/{{id:guid}}";
    }

    public static class Trips
    {
        private const string Base = $"{ApiBase}/trips";
        
        public const string Create = Base;
        public const string GetAll = Base;
        public const string GetAllByEmployeeId = $"{Base}/employees/{{employeeId:guid}}";
        public const string Get = $"{Base}/{{id:guid}}";
        public const string GetByCarId = $"{Base}/cars/{{carId:guid}}";
        public const string Update = $"{Base}/{{id:guid}}";
        public const string Delete = $"{Base}/{{id:guid}}";
    }
}