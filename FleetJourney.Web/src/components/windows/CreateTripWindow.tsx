import React, { useEffect, useState, ChangeEvent } from "react";
import { Employee } from "../../models/Employee.ts";
import { Car } from "../../models/Car.ts";
import { Trip } from "../../models/Trip.ts";

import EmployeeService from "../../services/EmployeeService.ts";
import CarPoolService from "../../services/CarPoolService.ts";
import TripService from "../../services/TripService.ts";

type CreateTripWindowProps = {
    onClose: () => void;
    onCreate: (newTrip: Trip) => void;
};

const CreateTripWindow: React.FC<CreateTripWindowProps> = ({ onClose, onCreate }) => {
    const [employees, setEmployees] = useState<Employee[]>([]);
    const [cars, setCars] = useState<Car[]>([]);
    const [newTrip, setNewTrip] = useState<Trip>({
        id: "",
        carId: "",
        employeeId: "",
        startMileage: 0,
        endMileage: 0,
        isPrivateTrip: false,
    });

    useEffect(() => {
        fetchEmployees();
        fetchCars();
    }, []);

    const fetchEmployees = async () => {
        const fetchedEmployees: Employee[] = await EmployeeService.getEmployees();
        setEmployees(fetchedEmployees);
    };

    const fetchCars = async () => {
        const fetchedCars: Car[] = await CarPoolService.getCars();
        setCars(fetchedCars);
    };

    const handleSelectChange = (e: ChangeEvent<HTMLSelectElement>) => {
        const { name, value } = e.target;
        setNewTrip((previousTrip) => ({
            ...previousTrip,
            [name]: value,
        }));
    };

    const handleInputChange = (e: ChangeEvent<HTMLInputElement>) => {
        const { name, value } = e.target;
        setNewTrip((previousTrip) => ({
            ...previousTrip,
            [name]: value,
        }));
    };

    const handleCheckboxChange = (e: ChangeEvent<HTMLInputElement>) => {
        const { name, checked } = e.target;
        setNewTrip((previousTrip) => ({
            ...previousTrip,
            [name]: checked,
        }));
    };

    const handleSaveClick = async () => {
        const createdTrip: Trip = await TripService.createTrip(newTrip);
        onCreate(createdTrip);
        onClose();
    };

    const handleCancelClick = () => {
        onClose();
    };

    return (
        <div className="fixed top-0 left-0 flex items-center justify-center w-full h-full bg-gray-900 bg-opacity-50">
            <div className="bg-white p-6 rounded shadow-xl flex flex-col">
                <div className="mb-4">
                    <label htmlFor="employeeId" className="text-black-2 font-semibold">
                        Employee:
                    </label>
                    <select
                        className="w-full p-2 border border-gray-300 rounded"
                        name="employeeId"
                        value={newTrip.employeeId}
                        onChange={handleSelectChange}
                    >
                        <option value="">Select an employee</option>
                        {employees.map((employee) => (
                            <option key={employee.id} value={employee.id}>
                                {`${employee.name} ${employee.lastName}`}
                            </option>
                        ))}
                    </select>
                </div>
                <div className="mb-4">
                    <label htmlFor="carId" className="text-black-2 font-semibold">
                        Car:
                    </label>
                    <select
                        className="w-full p-2 border border-gray-300 rounded"
                        name="carId"
                        value={newTrip.carId}
                        onChange={handleSelectChange}
                    >
                        <option value="">Select a car</option>
                        {cars.map((car) => (
                            <option key={car.id} value={car.id}>
                                {`${car.brand} (${car.model})`}
                            </option>
                        ))}
                    </select>
                </div>
                <div className="mb-4">
                    <label htmlFor="startMileage" className="text-black-2 font-semibold">
                        Start Mileage:
                    </label>
                    <input
                        type="number"
                        className="w-full p-2 border border-gray-300 rounded"
                        name="startMileage"
                        value={newTrip.startMileage}
                        onChange={handleInputChange}
                    />
                </div>
                <div className="mb-4">
                    <label htmlFor="endMileage" className="text-black-2 font-semibold">
                        End Mileage:
                    </label>
                    <input
                        type="number"
                        className="w-full p-2 border border-gray-300 rounded"
                        name="endMileage"
                        value={newTrip.endMileage}
                        onChange={handleInputChange}
                    />
                </div>
                <div className="flex items-center mb-3">
                    <input
                        type="checkbox"
                        id="privateTripCheckbox"
                        checked={newTrip.isPrivateTrip}
                        onChange={handleCheckboxChange}
                        name="isPrivateTrip"
                        className="mr-3 mt-1"
                    />
                    <label htmlFor="privateTripCheckbox" className="text-black dark:text-white">
                        Is it a private trip?
                    </label>
                </div>
                <div className="flex justify-end">
                    <button
                        className="bg-blue-500 hover:bg-blue-600 text-black-2 font-semibold py-2 px-4 rounded"
                        onClick={handleSaveClick}
                    >
                        Save
                    </button>
                    <button
                        className="mr-2 bg-gray-200 hover:bg-gray-300 text-black-2 font-semibold py-2 px-4 rounded"
                        onClick={handleCancelClick}
                    >
                        Cancel
                    </button>
                </div>
            </div>
        </div>
    );
};

export default CreateTripWindow;
