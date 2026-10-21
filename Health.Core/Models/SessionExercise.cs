namespace Health.Core.Models;

public class SessionExercise
{
    public Guid Id {get;set;} = Guid.NewGuid();
    public Guid ExerciseId {get;set;}
    public Exercise Exercise {get; set;} = null!;
    public ExerciseTarget Target {get; set;} = new();
    public List<LoggedSet> Sets {get; set;} = new();
    public string Notes {get; set;} = string.Empty;
}