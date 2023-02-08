public class EternalGoal : Goal
{
    private int _timesCompleted;
    public EternalGoal(string name, string description, int points, bool completed, string lastEvent) : base(name, description, points, completed, lastEvent)
    {
    }
    public override int RecordEvent()
    {
        _lastEvent = DateTime.Today.ToString("d");
        return _points;
    }
    public override string GetStringRepresentation()
    {
        return $"{this.GetType().Name};{_name};{_description};{_points};{_lastEvent}";
    }

}