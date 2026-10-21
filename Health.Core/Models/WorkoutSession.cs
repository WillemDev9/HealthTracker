namespace Health.Core.Models;

public class WorkoutSession
{
    public Guid Id {get; set;} = Guid.NewGuid();
    public DateOnly Date {get; set;} = DateOnly.FromDateTime(DateTime.Today);
    public DayOfWeek DayOfWeek => Date.DayOfWeek;
    public List<SessionExercise> SessionExercises {get; set;} = new();

}