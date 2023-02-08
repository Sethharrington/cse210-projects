public abstract class Goal
{
    protected string _name;
    protected string _description;
    protected bool _complete;
    protected int _points;
    protected string _lastEvent;
    public Goal(string name, string description, int points, bool complete = false, string lastEvent = "")
    {
        _name = name;
        _description = description;
        _points = points;
        _complete = complete;
        _lastEvent = lastEvent;
    }
    public virtual void DisplayGoal()
    {
        Console.Write("[" + (_complete ? "X" : "") + $"] {_name} ({_description}) -- Last event: {_lastEvent}");
    }
    public virtual int RecordEvent()
    {
        _lastEvent = DateTime.Today.ToString("d");
        _complete = true;
        return _points;
    }
    public abstract string GetStringRepresentation();
}