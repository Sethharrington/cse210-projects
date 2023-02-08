public class CheckListGoal : Goal
{
    private int _bonusPoints;
    private int _goalLimit;
    private int _timesCompleted;
    public CheckListGoal(string name, string description, int points, int bonusPoints, int goalLimit, int timesCompleted, string lastEvent) : base(name, description, points, timesCompleted >= goalLimit, lastEvent)
    {
        _bonusPoints = bonusPoints;
        _goalLimit = goalLimit;
        _timesCompleted = timesCompleted;
    }

    public override int RecordEvent()
    {
        if (_timesCompleted == _goalLimit)
        {
            _lastEvent = DateTime.Today.ToString("d");
            _timesCompleted++;
            _complete = true;
            return _points + _bonusPoints;
        }
        else
        {
            _lastEvent = DateTime.Today.ToString("d");
            _timesCompleted++;
            return _points;
        }
    }
    public override string GetStringRepresentation()
    {
        return $"{this.GetType().Name};{_name};{_description};{_points};{_bonusPoints};{_goalLimit};{_timesCompleted};{_lastEvent}";
    }
    public override void DisplayGoal()
    {
        Console.Write("[" + (_complete ? "X" : "") + $"] {_name} ({_description}) -- Currently completed: {_timesCompleted}/{_goalLimit} -- Last event: {_lastEvent}");
    }

}