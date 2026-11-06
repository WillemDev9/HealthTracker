using Health.Core.Models;

namespace Health.Core.Interfaces;

public interface IFitnessRepository
{
    public Task SaveBodyMetricLogAsync(BodyMetricLog bodyMetricLog);
    public Task DeleteBodyMetricLogAsync(BodyMetricLog bodyMetricLog);
    public Task<List<BodyMetricLog>> GetFullBodyMetricLogListAsync();
    public Task<BodyMetricLog?> GetBodyMetricLogByIdAsync(Guid id);
}
