using Health.Core.Interfaces;
using Health.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Health.Data;

public class FitnessRepository : IFitnessRepository
{
    private readonly FitnessDB _db;

    public FitnessRepository(FitnessDB db)
    {
        _db = db;
    }
    public async Task DeleteBodyMetricLogAsync(BodyMetricLog bodyMetricLog)
    {
        var existingLog = await _db.BodyMetricLogs.FindAsync(bodyMetricLog.Id);

        if(existingLog != null)
        {
            _db.BodyMetricLogs.Remove(existingLog);
            await _db.SaveChangesAsync();
        }
    }

    public async Task<BodyMetricLog?> GetBodyMetricLogByIdAsync(Guid id)
    {
        return await _db.BodyMetricLogs.FindAsync(id);
    }

    public async Task<List<BodyMetricLog>> GetFullBodyMetricLogListAsync()
    {
        return await _db.BodyMetricLogs.OrderBy(l => l.Date).ToListAsync();
    }

    public async Task SaveBodyMetricLogAsync(BodyMetricLog bodyMetricLog)
    {

        bool idExists = await _db.BodyMetricLogs.AnyAsync(g =>g.Id == bodyMetricLog.Id);

        if(!idExists)
        {
            await _db.BodyMetricLogs.AddAsync(bodyMetricLog);
        }
        else
        {
            _db.BodyMetricLogs.Update(bodyMetricLog);
        }
        
        await _db.SaveChangesAsync();
    }
}
