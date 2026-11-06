using Health.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Health.Data;

public class FitnessDB: DbContext
{
    public FitnessDB(DbContextOptions<FitnessDB> options) : base(options) {}
    public DbSet<BodyMetricLog> BodyMetricLogs {get;set;} = null!;
}