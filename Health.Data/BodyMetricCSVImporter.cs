using Health.Core.Models;
using Health.Data;
using System.IO;

public class BodyMetricCSVImporter
{
    public static async Task ImportBodyMetricHistory(FitnessDB context, string contentRootPath)
    {
        var csvPath = Path.Combine(contentRootPath, "health_tracking.csv");

        if(!File.Exists(csvPath))
        {
            return;
        }

        var lines = File.ReadAllLines(csvPath);

        var dataRows = lines.Skip(2);

        foreach(var line in dataRows)
        {
            if(string.IsNullOrWhiteSpace(line)) continue;

            var columns = line.Split(',');

            if (columns.Length < 2) continue;

            var log = new BodyMetricLog
            {
              Date = DateOnly.Parse(columns[0]),
              Weight = ParseNullableDecimal(columns,1),  
              WaistNarrow = ParseNullableDecimal(columns,2),  
              WaistNavel = ParseNullableDecimal(columns,3),  
              Chest = ParseNullableDecimal(columns,4),
              Shoulders = ParseNullableDecimal(columns,6),  
              Hips = ParseNullableDecimal(columns,7),  
              Biceps = ParseNullableDecimal(columns,8),  
              Thighs = ParseNullableDecimal(columns,9),  
              Calves = ParseNullableDecimal(columns,10),  
              Forearms = ParseNullableDecimal(columns,11),  
            };

            await context.BodyMetricLogs.AddAsync(log);
        }

        await context.SaveChangesAsync();
    }

    private static decimal? ParseNullableDecimal(string[] columns, int index)
    {
        if(index >= columns.Length) return null;

        var val = columns[index].Trim();

        if(string.IsNullOrEmpty(val) || val== "-") return null;

        return decimal.TryParse(val, out var result) ? result: null;
    }
}