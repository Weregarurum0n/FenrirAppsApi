﻿using HotelManagementApi.Employees.RequestModels;
using HotelManagementApi.Employees.ResponseModels;
using HotelManagementApi.Shared;
using System.Collections.Generic;

namespace HotelManagementApi.Employees.Repositories
{
    public interface IEmployeesRepository
    {
        List<Employee> GetEmployees(GetEmployees req);
        Employee GetEmployee(int employeeId);
        ReturnStatus SetEmployee(SetEmployee req);
    }
}