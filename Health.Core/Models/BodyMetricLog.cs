namespace Health.Core.Models;

public class BodyMetricLog
{
    public Guid Id {get; set;} = Guid.NewGuid();
    public DateOnly Date {get; set;} = DateOnly.FromDateTime(DateTime.Today);
    public decimal Weight {get; set;}
    public decimal WaistNarrow {get; set;}
    public decimal WaistNaval {get; set;}
    public decimal Hips {get; set;}
    public decimal Chest {get; set;}
    public decimal Shoulders {get; set;}
    public decimal Biceps {get; set;}
    public decimal Forearms {get; set;}
    public decimal Thighs {get; set;}
    public decimal Calves {get; set;}
}