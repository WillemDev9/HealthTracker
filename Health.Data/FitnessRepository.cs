using Health.Core.Interfaces;
using Health.Core.Models;

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
        throw new NotImplementedException();
    }

    public async Task SaveBodyMetricLogAsync(BodyMetricLog bodyMetricLog)
    {
        throw new NotImplementedException();
    }
}
