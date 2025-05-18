using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Facility;
using api.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace api.Mappers
{
    public static class FacilityMappers
    {
        public static FacilityDto ToFacilityDto(this Facility facilityModel)
        {
            return new FacilityDto
            {
                Id = facilityModel.Id,
                Name = facilityModel.Name,
                Type = facilityModel.Type,
                ColumnType = facilityModel.ColumnType,
                TemperatureTop = facilityModel.TemperatureTop,
                TemperatureBottom = facilityModel.TemperatureBottom,
                PressureTop = facilityModel.PressureTop,
                EmployeeId = facilityModel.EmployeeId
            };
        }

        public static Facility ToFacilityFromCreate(this CreateFacilityDto facilityDto, int employeeId)
        {
            return new Facility
            {
                Name = facilityDto.Name,
                Type = facilityDto.Type,
                ColumnType = facilityDto.ColumnType,
                TemperatureTop = facilityDto.TemperatureTop,
                TemperatureBottom = facilityDto.TemperatureBottom,
                PressureTop = facilityDto.PressureTop,
                EmployeeId = employeeId
            };
        }

        public static Facility ToFacilityFromUpdate(this UpdateFacilityRequestDto facilityDto)
        {
            return new Facility
            {
                Name = facilityDto.Name,
                Type = facilityDto.Type,
                ColumnType = facilityDto.ColumnType,
                TemperatureTop = facilityDto.TemperatureTop,
                TemperatureBottom = facilityDto.TemperatureBottom,
                PressureTop = facilityDto.PressureTop,
            };
        }
    }
}