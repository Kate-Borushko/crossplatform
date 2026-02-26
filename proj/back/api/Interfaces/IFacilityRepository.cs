using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Helpers;
using api.Models;

namespace api.Interfaces
{
    public interface IFacilityRepository
    {
        Task<List<Facility>> GetAllAsync(QueryObjectFacility query);
        Task<Facility?> GetByIdAsync(int id);
        Task<Facility> CreateAsync(Facility facilityModel);
        Task<Facility?> UpdateAsync(int id, Facility facilityModel);
        Task<Facility?> DeleteAsync(int id);
    }
}