using GlucoseMonitor.Domain.Entities;
using GlucoseMonitor.Domain.Interfaces;
using GlucoseMonitor.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;

public class MeasurementRepository : IMeasurementRepository
{
    private readonly AppDbContext _context;

    public MeasurementRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task SaveAsync(Measurement measurement)
    {
        await _context.Measurements.AddAsync(measurement);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Measurement>> GetAllAsync()
    {
        return await _context.Measurements.ToListAsync();
    }

    public async Task<IEnumerable<Measurement>> GetAnomaliesAsync(double lower, double upper)
    {
        return await _context.Measurements
            .Where(m => m.Value < lower || m.Value > upper)
            .ToListAsync();
    }
}
