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
        throw new NotImplementedException();
    }

    public async Task<BodyMetricLog?> GetBodyMetricLogByIdAsync(Guid id)
    {
        throw new NotImplementedException();
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
