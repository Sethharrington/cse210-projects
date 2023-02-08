public class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, int points, bool completed,string lastEvent) : base(name, description, points, completed, lastEvent)
    {
    }
    public override string GetStringRepresentation()
    {
        return $"{this.GetType().Name};{_name};{_description};{_points};{_complete};{_lastEvent}";
    }
}