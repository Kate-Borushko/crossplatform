using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Helpers;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class FacilityRepository : IFacilityRepository
    {
        private readonly ApplicationDBContext _context;
        public FacilityRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Facility> CreateAsync(Facility facilityModel)
        {
            await _context.Facilities.AddAsync(facilityModel);
            await _context.SaveChangesAsync();
            return facilityModel;
        }

        public async Task<Facility?> DeleteAsync(int id)
        {
            var facilityModel = await _context.Facilities.FirstOrDefaultAsync(x => x.Id == id);

            if (facilityModel == null)
            {
                return null;
            }

            _context.Facilities.Remove(facilityModel);
            await _context.SaveChangesAsync();
            return facilityModel;
        }

        public async Task<List<Facility>> GetAllAsync(QueryObject query)
        {
            var facilities = _context.Facilities.AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.Name))
            {
                facilities = facilities.Where(s => s.Name.Contains(query.Name));
            }

            if (!string.IsNullOrWhiteSpace(query.Type))
            {
                facilities = facilities.Where(s => s.Type.Contains(query.Type));
            }

            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    facilities = query.IsDecsending ? facilities.OrderByDescending(n => n.Name) : facilities.OrderBy(n => n.Name);
                }
            }

            return await facilities.ToListAsync();
        }

        public async Task<Facility?> GetByIdAsync(int id)
        {
            return await _context.Facilities.FindAsync(id);
        }

        public async Task<Facility?> UpdateAsync(int id, Facility facilityModel)
        {
            var existingFacility = await _context.Facilities.FindAsync(id);

            if (existingFacility == null)
            {
                return null;
            }

            existingFacility.Name = facilityModel.Name;
            existingFacility.Type = facilityModel.Type;
            existingFacility.ColumnType = facilityModel.ColumnType;
            existingFacility.TemperatureTop = facilityModel.TemperatureTop;
            existingFacility.TemperatureBottom = facilityModel.TemperatureBottom;
            existingFacility.PressureTop = facilityModel.PressureTop;

            await _context.SaveChangesAsync();

            return existingFacility;
        }
    }
}